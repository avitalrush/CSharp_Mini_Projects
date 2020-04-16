using System;

namespace B20_Ex01_4
{
    public class Program
    {
        private const int k_LenOfInput = 8;

        public static void Main()
        {
            start();
        }

        private static void start()
        {
            string inputStr;

            Console.WriteLine("Please enter 8-char string, with only digits or english letters: ");
            inputStr = getValidInput();
            analyzeInputString(inputStr);

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
                    Console.WriteLine("Not valid input. Please enter a valid input:");
                }
            }
            while (isInputValid == !true);

            return inputStr;
        }

        private static string getInput()
        {
            string inputStr = Console.ReadLine();

            return inputStr;
        }

        private static bool validateInput(string i_Str)
        {
            return (isInputLenValid(i_Str) && isInputSameChars(i_Str));
        }

        private static bool isInputLenValid(string i_Str)
        {
            return (i_Str.Length == k_LenOfInput);
        }

        private static bool isInputSameChars(string i_Str)
        {
            return (isInputContainsOnlyLetters(i_Str) || isInputContainsOnlyDigits(i_Str));
        }

        private static bool isInputContainsOnlyLetters(string i_Str)
        {
            bool isInputConsistentWithLetters = true;

            for(int i = 0; i < i_Str.Length; i++)
            {
                if(!(char.IsLetter(i_Str[i]))) // if the char is a English letter
                    isInputConsistentWithLetters = !true;
            }

            return isInputConsistentWithLetters;
        }

        private static bool isInputContainsOnlyDigits(string i_Str)
        {
            bool isInputConsistentWithDigits = true;

            for (int i = 0; i < i_Str.Length; i++)
            {
                if (!(char.IsDigit(i_Str[i]))) // if the char is a English letter
                    isInputConsistentWithDigits = !true;
            }

            return isInputConsistentWithDigits;
        }

        private static void analyzeInputString(string i_Str)
        {
            if (isPalindrome(i_Str))
            {
                Console.WriteLine("{0} is a Palindrome", i_Str);
            }
            else
            {
                Console.WriteLine("{0} is NOT a Palindrome", i_Str);
            }

            if (isDigitString(i_Str))
            {
                if (isDividedByFive(i_Str))
                {
                    Console.WriteLine("{0} is divided by 5", i_Str);
                }
                else
                {
                    Console.WriteLine("{0} is NOT divided by 5", i_Str);
                }
            }

            if (isLetterString(i_Str))
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
            else if (i_Str[0] != i_Str[strLen-1])
            {
                stringIsPalindrome = false;
            }
            else
            {
                stringIsPalindrome = isPalindrome(i_Str.Substring(1,strLen-2));
            }

            return stringIsPalindrome;
        }

        private static bool isDigitString(string i_Str)
        {
            return (char.IsDigit(i_Str[0]));

            // it’s enough to check only the first char of the string
            // because we already know it’s a valid string and all the other chars will be of the same type
        }

        private static bool isDividedByFive(string i_Str)
        {
            int numFromStr = int.Parse(i_Str);

            return (numFromStr % 5 == 0);
        }

        private static bool isLetterString(string i_Str)
        {
            return (char.IsLetter(i_Str[0]));
            
            // it’s enough to check only the first char of the string
            // because we already know it’s a valid string and all the other chars will be of the same type
        }

        private static int countUpperCaseLetters(string i_Str)
        {
            int upperCount = 0;

            for(int i = 0; i <= k_LenOfInput-1; i++)
            {
                if(char.IsUpper(i_Str[i]))
                {
                    upperCount++;
                }
            }

            return upperCount;
        }
    }
}