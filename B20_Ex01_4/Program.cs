﻿using System;

namespace B20_Ex01_4
{
    public class Program
    {
        //private const int k_LenOfInput = 8;
        //private static bool s_IsLettersInput = false;
        //private static bool s_IsDigitsInput = false;
        //private static int s_InputNum = 0;

        public static void Main()
        {
            start();
        }

        private static void start()
        {
            int inputNum = 0;
            string inputStr;
            bool isLettersInput = false;
            bool isDigitsInput = false;

            Console.WriteLine("Please enter 8-char string, with only digits or english letters: ");
            inputStr = getValidInput(ref isLettersInput, ref isDigitsInput, ref inputNum);
            analyzeInputString(inputStr, isLettersInput, isDigitsInput, inputNum);

            Console.ReadLine();
        }

        private static string getValidInput(ref bool io_IsLettersInput, ref bool io_IsDigitsInput, ref int io_InputNum)
        {
            string inputStr;
            bool isInputValid;

            do
            {
                inputStr = getInput();
                isInputValid = validateInput(inputStr, ref io_IsLettersInput, ref io_IsDigitsInput, ref io_InputNum);
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

        private static bool validateInput(string i_Str, ref bool io_IsLettersInput, ref bool io_IsDigitsInput, ref int io_InputNum)
        {
            return isInputLenValid(i_Str) && isInputTypeValid(i_Str, ref io_IsLettersInput, ref io_IsDigitsInput, ref io_InputNum);
        }

        private static bool isInputLenValid(string i_Str)
        {
            int lenOfInput = 8;
          
            return i_Str.Length == lenOfInput;
        }

        private static bool isInputTypeValid(string i_Str, ref bool io_IsLettersInput, ref bool io_IsDigitsInput, ref int io_InputNum)
        {
            return isLettersInput(i_Str, ref io_IsLettersInput) || isDigitsInput(i_Str, ref io_IsDigitsInput, ref io_InputNum);
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

        private static bool isDigitsInput(string i_Str, ref bool io_IsDigitsInput, ref int o_InputNum)
        {
            bool stringContainsOnlyDigits = int.TryParse(i_Str, out o_InputNum);

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

        private static void analyzeInputString(string i_Str, bool i_IsLettersInput, bool i_IsDigitsInput, int i_InputNum)
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
                if (isDividedByFive(i_InputNum))
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
            int strLen = i_Str.Length;
            bool stringIsPalindrome;

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
            int upperCount = 0, lenOfInput = 8;

            for (int i = 0; i <= lenOfInput - 1; i++) 
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