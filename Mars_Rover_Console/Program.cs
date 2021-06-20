using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Console
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] rover_Instructions;
            int i = 0, j = 0;
            int rover_count = 2;
            string temp_input;
            int input_control_index = 0;
            char[] control_input_arr;
            int x_pleteau, y_pleteau;

            rover_Instructions = new string[(rover_count * 2) + 1];

            Console.Write("\nWIDTH AND LENGHT OF PLETEAU: ");
            temp_input = Console.ReadLine();
            control_input_arr = temp_input.ToCharArray();
            while (control_input_arr.Length != 3 || !Char.IsNumber(control_input_arr[0]) || !Char.IsWhiteSpace(control_input_arr[1]) || !Char.IsNumber(control_input_arr[2]))
            {
                Console.WriteLine("Wrong Input Type\nInput Example: 5 5 (integer-space-integer)");
                temp_input = Console.ReadLine();
                control_input_arr = temp_input.ToCharArray();
            }
            x_pleteau = (int)char.GetNumericValue(control_input_arr[0]);
            y_pleteau = (int)char.GetNumericValue(control_input_arr[2]);
            rover_Instructions[0] = temp_input;
            i = 1;

            for (j = 0; j < rover_count; j++)
            {
                Console.Write((j + 1) + ". ROVER'S POSITION:");
                temp_input = Console.ReadLine();
                control_input_arr = temp_input.ToCharArray();
                while (control_input_arr.Length != 5 || !Char.IsNumber(control_input_arr[0]) || !Char.IsWhiteSpace(control_input_arr[1]) || !Char.IsNumber(control_input_arr[2]) || !Char.IsWhiteSpace(control_input_arr[3]) || !new[] { 'N', 'S', 'W', 'E' }.Contains(control_input_arr[4])
                        || char.GetNumericValue(control_input_arr[0]) > x_pleteau || char.GetNumericValue(control_input_arr[2]) > x_pleteau)
                {
                    Console.WriteLine("Wrong Input.. Input should be in boundaries of " + x_pleteau + "," + y_pleteau + "\nInput Example: 3 2 N (integer-space-integer-space-letter(N,S,W,E))\n");
                    Console.Write((j + 1) + ". ROVER'S POSITION:");
                    temp_input = Console.ReadLine();
                    control_input_arr = temp_input.ToCharArray();
                }


                rover_Instructions[i] = temp_input;
                i++;
                Console.Write((j + 1) + ". ROVER'S INSTRUCTIONS:");
                temp_input = Console.ReadLine();
                control_input_arr = temp_input.ToCharArray();

                while (input_control_index < control_input_arr.Length && !FormatValid(temp_input))
                {

                    Console.WriteLine("Wrong Input\nInput Example: LMMLLMRM (letter-letter-letter...(L,R,M))\n");
                    Console.Write((j + 1) + ". ROVER'S INSTRUCTIONS:");
                    temp_input = Console.ReadLine();
                    control_input_arr = temp_input.ToCharArray();

                    input_control_index++;
                }
                rover_Instructions[i] = temp_input;
                i++;



            }


            Console.Write("---END OF INPUT---\nOUT:\n");

            Console.Write(Read_Instructions(rover_Instructions));


            Console.Write("\nPress any key to close the console.");
            Console.ReadKey();





        }

        public static bool FormatValid(string format)
        {
            string allowableLetters = "LRM";

            foreach (char c in format)
            {

                if (!allowableLetters.Contains(c.ToString()))
                    return false;
            }

            return true;
        }

        public static string Read_Instructions(string[] intructions_array)
        {
            string[] temp_Rover_Info;
            string[] return_Value;
            char[] temp_Rover_Direc;
            char[] tmp;
            int x_lenght, y_lenght, current_x = 0, current_y = 0, rover_count, return_index = 0;
            int i = 0, j = 0; ;
            string direction = null;

            temp_Rover_Info = new string[100];


            rover_count = (intructions_array.Length - 1) / 2;
            return_Value = new string[rover_count];
            //size of pleateu
            temp_Rover_Info = intructions_array[0].Split(' ');
            x_lenght = int.Parse(temp_Rover_Info[0]);
            y_lenght = int.Parse(temp_Rover_Info[1]);

            i++;


            for (j = 0; j < rover_count; j++)
            {
                //rover position
                current_x = int.Parse(intructions_array[i].Split(' ')[0]);
                current_y = int.Parse(intructions_array[i].Split(' ')[1]);
                direction = intructions_array[i].Split(' ')[2];

                //rover direction
                temp_Rover_Direc = intructions_array[i + 1].ToCharArray();
                return_Value[return_index] = Move_Rover(temp_Rover_Direc, current_x, current_y, direction, x_lenght, y_lenght);

                return_index++;
                i = i + 2;
            }



            return string.Join("\n", return_Value);
        }

        public static string Move_Rover(char[] temp_Rover_Info, int current_x, int current_y, string direction, int x_lenght, int y_lenght)
        {
            int i = 0, j = 0;
            string return_Value;
            //                   0    1    2    3
            //direction_Map = [ 'N', 'E', 'S', 'W' ];


            List<string> direction_Map = new List<string>();

            direction_Map.Add("N");
            direction_Map.Add("E");
            direction_Map.Add("S");
            direction_Map.Add("W");



            int direction_Value = direction_Map.IndexOf(direction);


            int count_Rover = 0;


            while (temp_Rover_Info.Length > i)
            {
                if (temp_Rover_Info[i] == 'L')
                {
                    direction_Value = (((direction_Value - 1) % 4) + 4) % 4;
                    direction = direction_Map[direction_Value];


                }
                else if (temp_Rover_Info[i] == 'R')
                {
                    direction_Value = (direction_Value + 1) % 4;
                    direction = direction_Map[direction_Value];
                }
                else
                {
                    if (direction == "N" && current_y < y_lenght)
                    {
                        current_y++;

                    }
                    if (direction == "S" && current_y > 0)
                    {
                        current_y--;

                    }
                    if (direction == "E" && current_x < x_lenght)
                    {
                        current_x++;

                    }
                    if (direction == "W" && current_x > 0)
                    {
                        current_x--;

                    }
                }


                i++;

            }
            return_Value = current_x + " " + current_y + " " + direction;

            return return_Value;
        }
    }
}
