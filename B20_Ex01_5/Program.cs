using System;

namespace B20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            start();
        }

        private static void start()
        {
            int lenOfInput = 9;
            string inputStr;

            Console.WriteLine("Please enter {0}-digit input: ", lenOfInput);
            inputStr = getValidInput();
            printStatisticsOfInput(inputStr);

            Console.ReadLine();
        }

        private static string getValidInput()
        {
            int lenOfInput = 9;
            string inputStr;
            bool isValidInput;

            do
            {
                inputStr = getInput();
                isValidInput = validateInput(inputStr);
                if (!isValidInput)
                {
                    Console.WriteLine("Not a valid input. Please enter {0}-digit input: ", lenOfInput);
                }
            }
            while (!isValidInput);

            return inputStr;
        }

        private static string getInput()
        {
            string inputStr = Console.ReadLine();

            return inputStr;
        }

        private static bool validateInput(string i_Str)
        {
            return isInputLenValid(i_Str) && isInputContainsOnlyDigits(i_Str) && !isInputZero(i_Str);
        }

        private static bool isInputZero(string i_Str)
        {
            string strZero = "000000000";

            return i_Str == strZero;
        }

        private static bool isInputContainsOnlyDigits(string i_Str)
        {
            bool isStringContainsOnlyDigits = true;

            for (int i = 0; i < i_Str.Length && isStringContainsOnlyDigits; i++)
            {
                if (!char.IsDigit(i_Str[i]))
                {
                    isStringContainsOnlyDigits = false;
                }
            }

            return isStringContainsOnlyDigits;
        }

        private static bool isInputLenValid(string i_Str)
        {
            int lenOfInput = 9;

            return i_Str.Length == lenOfInput;
        }

        private static void printStatisticsOfInput(string i_Str)
        {
            int maxDigit = getMaxDigit(i_Str);
            int minDigit = getMinDigit(i_Str);
            int countHowManyDigitsDividedByThree = getHowManyDigitsDividedByThree(i_Str);
            int countHowManyDigitsGreaterThanUnits = getHowManyDigitsGreaterThanUnits(i_Str);
            string outputMsg = string.Format(
@"In {0} the biggest digit is: {1}
the smallest digit is: {2}
there are {3} digits that can be divided by 3
there are {4} digits greater than the units digit.",
            i_Str, 
            maxDigit, 
            minDigit, 
            countHowManyDigitsDividedByThree, 
            countHowManyDigitsGreaterThanUnits);

            Console.WriteLine(outputMsg);
        }

        private static int convertCharToInt(char i_Chr)
        {
            return i_Chr - '0';
        }

        private static int getMaxDigit(string i_Str)
        {
            int maxDigit = 0;
            int currentDigit;

            for (int i = 0; i < i_Str.Length; i++)
            {
                currentDigit = convertCharToInt(i_Str[i]);
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
            }

            return maxDigit;
        }

        private static int getMinDigit(string i_Str)
        {
            int minDigit = 9;
            int currentDigit;

            for (int i = 0; i < i_Str.Length; i++)
            {
                currentDigit = convertCharToInt(i_Str[i]);
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
            }

            return minDigit;
        }

        private static int getHowManyDigitsDividedByThree(string i_Str)
        {
            int counter = 0;
            int currentDigit;

            for (int i = 0; i < i_Str.Length; i++)
            {
                currentDigit = convertCharToInt(i_Str[i]);
                if (currentDigit % 3 == 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int getHowManyDigitsGreaterThanUnits(string i_Str)
        {
            int counter = 0;
            int unitsDigitIndex = i_Str.Length - 1;
            int unitsDigit = convertCharToInt(i_Str[unitsDigitIndex]);

            for (int i = 0; i < unitsDigitIndex; i++)
            {
                if (convertCharToInt(i_Str[i]) > unitsDigit)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}