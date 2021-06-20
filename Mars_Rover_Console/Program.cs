﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover_Console
{
    class Program
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

                Console.WriteLine("ok");


            }


            Console.Write("---END OF INPUT---\nOUT:\n");

            // Reading input here


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
    }
}
