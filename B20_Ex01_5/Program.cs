using System;

namespace B20_Ex01_5
{
    public class Program
    {
        //private const int lenOfInput = 9;

        public static void Main()
        {
            start();
        }

        private static void start()
        {
            string inputStr;

            Console.WriteLine("Please enter 9-digit input: ");
            inputStr = getValidInput();
            printStringStats(inputStr);

            Console.ReadLine();
        }

        private static string getValidInput()
        {
            string inputStr;
            bool isInputValid;

            do
            {
                inputStr = getInput();
                isInputValid = validateInput(inputStr);
                if (!isInputValid)
                {
                    Console.WriteLine("Not a valid input. Please enter 9-digit input: ");
                }
            }
            while (!isInputValid);

            return inputStr;
        }

        private static string getInput()
        {
            string inputStr = Console.ReadLine();

            return inputStr;
        }

        private static bool validateInput(string i_Str)
        {
            return isInputLenValid(i_Str) && isInputValid(i_Str);
        }

        private static bool isInputValid(string i_Str)
        {
            bool stringContainsOnlyDigits = true;

            for (int i = 0; i < i_Str.Length && stringContainsOnlyDigits; i++)
            {
                if (!char.IsDigit(i_Str[i]))
                {
                    stringContainsOnlyDigits = false;
                }
            }

            return stringContainsOnlyDigits;
        }

        private static bool isInputLenValid(string i_Str)
        {
            int lenOfInput = 9;

            return i_Str.Length == lenOfInput;
        }

        private static void printStringStats(string i_Str)
        {
            biggestDigit(i_Str);
            smallestDigit(i_Str);
            howManyDigitsCanBeFullyDividedByThree(i_Str);
            howManyDigitsBiggerThanUnitsDigit(i_Str);
        }

        private static int convertFromCharToInt(char i_Chr)
        {
            return i_Chr - '0';
        }

        private static void biggestDigit(string i_Str)
        {
            int firstDigit = 0;
            int maxDigit = convertFromCharToInt(i_Str[firstDigit]);
            int currentDigit;

            for (int i = 1; i < i_Str.Length; i++)
            {
                currentDigit = convertFromCharToInt(i_Str[i]);
                if (currentDigit > maxDigit)
                {
                    maxDigit = currentDigit;
                }
            }

            Console.WriteLine("The biggest digit in the input {0} is: {1}", i_Str, maxDigit);
        }

        private static void smallestDigit(string i_Str)
        {
            int firstDigit = 0;
            int minDigit = convertFromCharToInt(i_Str[firstDigit]);
            int currentDigit;

            for (int i = 1; i < i_Str.Length; i++)
            {
                currentDigit = convertFromCharToInt(i_Str[i]);
                if (currentDigit < minDigit)
                {
                    minDigit = currentDigit;
                }
            }

            Console.WriteLine("The smallest digit in the input {0} is: {1}", i_Str, minDigit);
        }

        private static void howManyDigitsCanBeFullyDividedByThree(string i_Str)
        {
            int countHowManyFullDividedByThree = 0;
            int currentDigit;

            for (int i = 0; i < i_Str.Length; i++)
            {
                currentDigit = convertFromCharToInt(i_Str[i]);
                if (currentDigit % 3 == 0)
                {
                    countHowManyFullDividedByThree++;
                }
            }

            Console.WriteLine("In the input {0}, there are {1} digits can be fully divided by 3 without reminder", i_Str, countHowManyFullDividedByThree);
        }

        private static void howManyDigitsBiggerThanUnitsDigit(string i_Str)
        {
            int countDigitsBiggerThanUnits = 0;
            int unitsDigitIndex = i_Str.Length - 1;
            int unitsDigit = convertFromCharToInt(i_Str[unitsDigitIndex]);

            for (int i = 0; i < i_Str.Length - 1; i++)
            {
                if (convertFromCharToInt(i_Str[i]) > unitsDigit)
                {
                    countDigitsBiggerThanUnits++;
                }
            }

            Console.WriteLine("In the input {0}, there are {1} digits bigger than the units digit", i_Str, countDigitsBiggerThanUnits);
        }
    }
}