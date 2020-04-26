using System;

namespace B20_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            start();
        }

        private static void start()
        {
            int inputHeight;

            Console.WriteLine("Please enter the height for the hour glass: ");
            inputHeight = getValidHeight();
            B20_Ex01_2.Program.PrintStarsHourglass(inputHeight);
        }

        private static int getValidHeight()
        {
            int inputHeightNum;
            string inputHeightStr;
            bool isHeightValid;
            bool isHeightPositive;

            do
            {
                inputHeightStr = getHeight();
                //inputIsValid = checkIfInputIsValid(inputHeightStr, out inputHeightNum)
                //if (!inputIsValid)
                // Console...
                //... while(!inputIsValid)
                inputHeightNum = validateHeightInput(inputHeightStr, out isHeightValid);
                isHeightPositive = checkHeightPositivity(inputHeightNum);
                if (!isHeightValid || !isHeightPositive)
                {
                    Console.WriteLine("Not a valid input. Please enter a valid number for the hour glass height: ");
                }
            }
            while (!isHeightValid || !isHeightPositive);

            return inputHeightNum;
        }

        private static string getHeight()       //naming: getHeightInput
        {
            string inputHeightStr = Console.ReadLine();

            return inputHeightStr;
        }

        private static int validateHeightInput(string i_InputHeightStr, out bool o_IsHeightValid)//
        {
            int inputHeightNum;

            o_IsHeightValid = int.TryParse(i_InputHeightStr, out inputHeightNum);
            if (o_IsHeightValid)
            {
                inputHeightNum = checkHeightParity(inputHeightNum);
            }

            return inputHeightNum;
        }

        private static bool checkHeightPositivity(int i_InputHeightNum)
        {
            return i_InputHeightNum >= 0;
        }

        private static int checkHeightParity(int i_InputHeightNum)
        {
            if (i_InputHeightNum % 2 == 0)
            {
                i_InputHeightNum++;
            }

            return i_InputHeightNum;
        }
    }
}