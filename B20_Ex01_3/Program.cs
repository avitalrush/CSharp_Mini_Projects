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
            B20_Ex01_2.Program.PrintHourglass(inputHeight);
        }

        private static int getValidHeight()
        {
            int inputHeightNum;
            string inputHeightStr;
            bool validHeight, positiveHeight;

            do
            {
                inputHeightStr = getHeightInput();
                inputHeightNum = validateHeightInputAndConvertToNum(inputHeightStr, out validHeight);
                positiveHeight = checkHeightPositivity(inputHeightNum);
                if (!validHeight || !positiveHeight)
                {
                    Console.WriteLine("Not a valid input. Please enter a valid number for the hour glass height: ");
                }
            }
            while (!validHeight || !positiveHeight);

            return inputHeightNum;
        }

        private static string getHeightInput()
        {
            return Console.ReadLine();
        }

        private static int validateHeightInputAndConvertToNum(string i_InputHeightStr, out bool o_ValidHeight)
        {
            int inputHeightNum;

            o_ValidHeight = int.TryParse(i_InputHeightStr, out inputHeightNum);
            if (o_ValidHeight)
            {
                inputHeightNum = fixHeightParity(inputHeightNum);
            }

            return inputHeightNum;
        }

        private static bool checkHeightPositivity(int i_InputHeightNum)
        {
            return i_InputHeightNum >= 0;
        }

        private static int fixHeightParity(int i_InputHeightNum)
        {
            if (i_InputHeightNum % 2 == 0)
            {
                i_InputHeightNum++;
            }

            return i_InputHeightNum;
        }
    }
}