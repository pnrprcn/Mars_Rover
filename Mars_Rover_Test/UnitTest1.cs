using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Mars_Rover_Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Read_Instructions_Test()
        {
            string[] input_value, input_value2;
            input_value = new string[] { "5 5", "1 1 N", "RMLM", "3 3 W", "LMLM" };// expected_answer
            input_value2 = new string[] { "5 5", "1 1 N", "RMLM" };//expected_answer2

            string expected_answers = "2 2 N\n4 2 E";// put \n between answers for more than one rover's location.
            string expected_answers2 = "2 2 N";


            string output = Mars_Rover_Console.Program.Read_Instructions(input_value);

            Assert.AreEqual(expected_answers, output);
        }

        [TestMethod]
        public void Move_Rover_Test()
        {
            //input values. Move_Rover runs for one rover inside Read_Instructions 
            char[] temp_Rover_Info = new char[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M' };
            int current_x_rover = 1, current_y_rover = 2, x_lenght_plateau = 5, y_lenght_plateau = 5;
            string direction = "N";

            string output = Mars_Rover_Console.Program.Move_Rover(temp_Rover_Info, current_x_rover, current_y_rover, direction, x_lenght_plateau, y_lenght_plateau);

            Assert.AreEqual("1 3 N", output);
        }
    }
}
