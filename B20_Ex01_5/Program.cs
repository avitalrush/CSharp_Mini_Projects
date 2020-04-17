using System;

namespace B20_Ex01_5
{
    public class Program
    {
        private const int k_LenOfInput = 9;

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
            return i_Str.Length == k_LenOfInput;
        }

        private static void printStringStats(string i_Str)
        {
            biggestDigit(i_Str);
            smallestDigit(i_Str);
            howManyDigitsCanBeFullyDividedByThree(i_Str);
            howManyDigitsBiggerThanUnitsDigit(i_Str);
        }

        private static void biggestDigit(string i_Str)
        {
            int bigDigit = i_Str[0] - '0';

            for (int i = 1; i < i_Str.Length; i++)
            {
                if ((i_Str[i] - '0') > bigDigit)
                {
                    bigDigit = i_Str[i] - '0';
                }
            }

            Console.WriteLine("The biggest digit in the input {0} is: {1}", i_Str, bigDigit);
        }

        private static void smallestDigit(string i_Str)
        {
            int smallDigit = i_Str[0] - '0';

            for (int i = 1; i < i_Str.Length; i++)
            {
                if ((i_Str[i] - '0') < smallDigit)
                {
                    smallDigit = i_Str[i] - '0';
                }
            }

            Console.WriteLine("The smallest digit in the input {0} is: {1}", i_Str, smallDigit);
        }

        private static void howManyDigitsCanBeFullyDividedByThree(string i_Str)
        {
            int counterOfHowManyDigitsDivideByThree = 0;

            for (int i = 0; i < i_Str.Length; i++)
            {
                if ((i_Str[i] - '0') % 3 == 0)
                {
                    counterOfHowManyDigitsDivideByThree++;
                }
            }

            Console.WriteLine("In the input {0}, there are {1} digits can be fully divided by 3 without reminder", i_Str, counterOfHowManyDigitsDivideByThree);
        }

        private static void howManyDigitsBiggerThanUnitsDigit(string i_Str)
        {
            int counterOfDigitsBiggerThanUnitsDigit = 0;

            int unitsDigit = i_Str[i_Str.Length - 1] - '0';

            for (int i = 0; i < i_Str.Length - 1; i++)
            {
                if ((i_Str[i] - '0') > unitsDigit)
                {
                    counterOfDigitsBiggerThanUnitsDigit++;
                }
            }

            Console.WriteLine("In the input {0}, there are {1} digits bigger than the units digit", i_Str, counterOfDigitsBiggerThanUnitsDigit);
        }
    }
}