using System;

namespace B20_Ex01_4
{
    public class Program
    {
        private const int k_LenOfInput = 8;
        //private static bool s_IsLettersInput = false;
       // private static bool s_IsDigitsInput = false;
        private static int s_InputNum = 0;

        public static void Main()
        {
            start();
        }

        private static void start()
        {
            string inputStr;
            bool isLettersInput = false;
            bool isDigitsInput = false;

            Console.WriteLine("Please enter 8-char string, with only digits or english letters: ");
            inputStr = getValidInput(ref isLettersInput, ref isDigitsInput);
            analyzeInputString(inputStr, isLettersInput, isDigitsInput);

            Console.ReadLine();
        }

        private static string getValidInput(ref bool io_IsLettersInput, ref bool io_IsDigitsInput)
        {
            string inputStr;
            bool isInputValid;

            do
            {
                inputStr = getInput();
                isInputValid = validateInput(inputStr, ref io_IsLettersInput, ref io_IsDigitsInput);
                if (!isInputValid)
                {
                    Console.WriteLine("Not a valid input. Please enter 8-char string, with only digits or english letters: ");
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

        private static bool validateInput(string i_Str, ref bool io_IsLettersInput, ref bool io_IsDigitsInput)
        {
            return isInputLenValid(i_Str) && isInputTypeValid(i_Str, ref io_IsLettersInput, ref io_IsDigitsInput);
        }

        private static bool isInputLenValid(string i_Str)
        {
            return i_Str.Length == k_LenOfInput;
        }

        private static bool isInputTypeValid(string i_Str, ref bool io_IsLettersInput, ref bool io_IsDigitsInput)
        {
            return isLettersInput(i_Str, ref io_IsLettersInput) || isDigitsInput(i_Str, ref io_IsDigitsInput);
        }

        private static bool isLettersInput(string i_Str, ref bool io_IsLettersInput)
        {
            bool stringContainsOnlyLetters = true;

            for(int i = 0; i < i_Str.Length && stringContainsOnlyLetters; i++)
            {
                if (!char.IsLetter(i_Str[i]))
                {
                    stringContainsOnlyLetters = false;
                }
            }

            if(stringContainsOnlyLetters)
            {
                io_IsLettersInput = true;
            }

            return stringContainsOnlyLetters;
        }

        private static bool isDigitsInput(string i_Str, ref bool io_IsDigitsInput)
        {
            bool stringContainsOnlyDigits = int.TryParse(i_Str, out s_InputNum);

            if (stringContainsOnlyDigits)
            {
                io_IsDigitsInput = true;
            }

            return stringContainsOnlyDigits;

            /*

            bool stringContainsOnlyDigits = true;

            for (int i = 0; i < i_Str.Length && stringContainsOnlyDigits; i++)
            {
                if (!(char.IsDigit(i_Str[i])))
                {
                    stringContainsOnlyDigits = false;
                }
            }

            if (stringContainsOnlyDigits)
            {
                s_IsDigitsInput = true;
            }

            return stringContainsOnlyDigits;

            */
        }

        private static void analyzeInputString(string i_Str, bool i_IsLettersInput, bool i_IsDigitsInput)
        {
            if (isPalindrome(i_Str))
            {
                Console.WriteLine("{0} is a Palindrome", i_Str);
            }
            else
            {
                Console.WriteLine("{0} is NOT a Palindrome", i_Str);
            }

            if (i_IsDigitsInput)
            {
                if (isDividedByFive(s_InputNum))
                {
                    Console.WriteLine("{0} is divided by 5", i_Str);
                }
                else
                {
                    Console.WriteLine("{0} is NOT divided by 5", i_Str);
                }
            }
            else if (i_IsLettersInput)
            {
                int count = countUpperCaseLetters(i_Str);
                Console.WriteLine("There are {0} uppercase letters in {1}", count, i_Str);
            }
        }

        private static bool isPalindrome(string i_Str)
        {
            bool stringIsPalindrome;
            int strLen = i_Str.Length;

            if (strLen == 1 || strLen == 0)
            {
                stringIsPalindrome = true;
            }
            else if (i_Str[0] != i_Str[strLen - 1]) 
            {
                stringIsPalindrome = false;
            }
            else
            {
                stringIsPalindrome = isPalindrome(i_Str.Substring(1, strLen - 2));
            }

            return stringIsPalindrome;
        }

        private static bool isDividedByFive(int i_Num)
        {
            // int numFromStr = int.Parse(i_Str);
            return i_Num % 5 == 0;
        }

        private static int countUpperCaseLetters(string i_Str)
        {
            int upperCount = 0;

            for (int i = 0; i <= k_LenOfInput - 1; i++) 
            {
                if (char.IsUpper(i_Str[i]))
                {
                    upperCount++;
                }
            }

            return upperCount;
        }
    }
}