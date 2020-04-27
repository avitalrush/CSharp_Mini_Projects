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
        }

        private static string getValidInput()
        {
            int lenOfInput = 9;
            string inputStr;
            bool inputIsValid;

            do
            {
                inputStr = getInput();
                inputIsValid = validateInput(inputStr);
                if (!inputIsValid)
                {
                    Console.WriteLine("Not a valid input. Please enter {0}-digit input: ", lenOfInput);
                }
            }
            while (!inputIsValid);

            return inputStr;
        }

        private static string getInput()
        {
            return Console.ReadLine();
        }

        private static bool validateInput(string i_InputStr)
        {
            return isInputLenValid(i_InputStr) && isInputContainsOnlyDigits(i_InputStr) && !isInputZero(i_InputStr);
        }

        private static bool isInputZero(string i_InputStr)
        {
            string zeroStr = "000000000";

            return i_InputStr == zeroStr;
        }

        private static bool isInputContainsOnlyDigits(string i_InputStr)
        {
            bool inputContainsOnlyDigits = true;

            for (int i = 0; i < i_InputStr.Length && inputContainsOnlyDigits; i++)
            {
                if (!char.IsDigit(i_InputStr[i]))
                {
                    inputContainsOnlyDigits = false;
                }
            }

            return inputContainsOnlyDigits;
        }

        private static bool isInputLenValid(string i_InputStr)
        {
            int lenOfInput = 9;

            return i_InputStr.Length == lenOfInput;
        }

        private static void printStatisticsOfInput(string i_InputStr)
        {
            int maxDigit, minDigit, countHowManyDigitsDividedByThree, countHowManyDigitsGreaterThanUnits;
            string outputMsg;

            maxDigit = getMaxDigit(i_InputStr);
            minDigit = getMinDigit(i_InputStr);
            countHowManyDigitsDividedByThree = getHowManyDigitsDividedByThree(i_InputStr);
            countHowManyDigitsGreaterThanUnits = getHowManyDigitsGreaterThanUnits(i_InputStr);
            outputMsg = string.Format(
@"The largest digit is {1}
The smallest digit is {2}
There are {3} digits that can be divided by 3
there are {4} digits greater than the units digit",
                i_InputStr, maxDigit, minDigit, countHowManyDigitsDividedByThree, countHowManyDigitsGreaterThanUnits);
            Console.WriteLine(outputMsg);
        }

        private static int convertCharToInt(char i_Chr)
        {
            return i_Chr - '0';
        }

        private static int getMaxDigit(string i_InputStr)
        {
            int maxDigit = 0;
            int currentDigit;

            for (int i = 0; i < i_InputStr.Length; i++)
            {
                currentDigit = convertCharToInt(i_InputStr[i]);
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
            }

            return maxDigit;
        }

        private static int getMinDigit(string i_InputStr)
        {
            int minDigit = 9;
            int currentDigit;

            for (int i = 0; i < i_InputStr.Length; i++)
            {
                currentDigit = convertCharToInt(i_InputStr[i]);
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
            }

            return minDigit;
        }

        private static int getHowManyDigitsDividedByThree(string i_InputStr)
        {
            int counter = 0;
            int currentDigit;

            for (int i = 0; i < i_InputStr.Length; i++)
            {
                currentDigit = convertCharToInt(i_InputStr[i]);
                if (currentDigit % 3 == 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int getHowManyDigitsGreaterThanUnits(string i_InputStr)
        {
            int counter = 0;
            int unitsDigitIndex, unitsDigit, currentDigit;

            unitsDigitIndex = i_InputStr.Length - 1;
            unitsDigit = convertCharToInt(i_InputStr[unitsDigitIndex]);
            for (int i = 0; i < unitsDigitIndex; i++)
            {
                currentDigit = convertCharToInt(i_InputStr[i]);
                if (currentDigit > unitsDigit)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}