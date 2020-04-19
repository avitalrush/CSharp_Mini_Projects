using System;

namespace B20_Ex01_3
{
    public class Program
    {
        private static bool s_IsHeightValid = false;

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

            Console.ReadLine();
        }

        private static int getValidHeight()
        {
            string inputHeightStr;
            int inputHeightNum;

            do
            {
                inputHeightStr = getHeight();
                inputHeightNum = validateHeightInput(inputHeightStr);
                if (!s_IsHeightValid)
                {
                    Console.WriteLine("Not a valid input. Please enter a valid number for the hour glass height: ");
                }
            }
            while (!s_IsHeightValid);

            return inputHeightNum;
        }

        private static string getHeight()
        {
            string inputHeightStr = Console.ReadLine();

            return inputHeightStr;
        }

        private static int validateHeightInput(string i_InputHeightStr)
        {
            int inputHeightNum;

            s_IsHeightValid = int.TryParse(i_InputHeightStr, out inputHeightNum);
            if(s_IsHeightValid)
            {
                inputHeightNum = makeHeightOddNumber(inputHeightNum);
            }

            return inputHeightNum;
        }

        private static int makeHeightOddNumber(int i_InputHeightNum)
        {
            if (i_InputHeightNum % 2 == 0)
            {
                i_InputHeightNum++;
            }

            return i_InputHeightNum;
        }
    }
}