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
            printStarsHourglass(inputHeight);

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

        private static void printStarsHourglass(int i_NumOfStars)  //MAATEFET
        {
            bool i_ExpendNumOfStars = false; // = down

            printRec(i_NumOfStars, i_NumOfStars, i_ExpendNumOfStars);
        }

        private static void printRec(int i_InitNumOfStars, int i_CurrNumOfStars, bool i_ExpendNumOfStars)
        {
            if (i_CurrNumOfStars == 1)
            {
                printLine((i_InitNumOfStars - i_CurrNumOfStars) / 2, i_CurrNumOfStars);
                i_ExpendNumOfStars = true; // =up
                printRec(i_InitNumOfStars, i_CurrNumOfStars + 2, i_ExpendNumOfStars);
            }
            else if (i_CurrNumOfStars > i_InitNumOfStars && i_ExpendNumOfStars == true)
            {
                return;
            }
            else    // curr>1
            {
                printLine((i_InitNumOfStars - i_CurrNumOfStars) / 2, i_CurrNumOfStars);
                if(i_ExpendNumOfStars == false)
                {
                    printRec(i_InitNumOfStars, i_CurrNumOfStars - 2, i_ExpendNumOfStars);
                }
                else
                {
                    printRec(i_InitNumOfStars, i_CurrNumOfStars + 2, i_ExpendNumOfStars);
                }
            }
        }

        private static void printLine(int i_NumOfSpaces, int i_NumOfStars)
        {
            for (int i = 1; i <= i_NumOfSpaces; i++)
            {
                Console.Write(" ");
            }

            for (int i = 1; i <= i_NumOfStars; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}