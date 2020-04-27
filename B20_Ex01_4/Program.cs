using System;

namespace B20_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            start();
        }

        private static void start()
        {
            int inputNum = 0;
            int lenOfInput = 8;
            string inputStr;
            bool inputIsLetters = false;
            bool inputIsDigits = false;

            Console.WriteLine("Please enter {0}-char string, with only digits or english letters: ", lenOfInput);
            inputStr = getValidInput(ref inputIsLetters, ref inputIsDigits, ref inputNum);
            analyzeInput(inputStr, inputIsLetters, inputIsDigits, inputNum);
        }

        private static string getValidInput(ref bool io_InputIsLetters, ref bool io_InputIsDigits, ref int io_InputNum)
        {
            int lenOfInput = 8;
            string inputStr;
            bool validInput;

            do
            {
                inputStr = getInput();
                validInput = validateInput(inputStr, ref io_InputIsLetters, ref io_InputIsDigits, ref io_InputNum);
                if (!validInput)
                {
                    Console.WriteLine("Not a valid input. Please enter {0}-char string, with only digits or english letters: ", lenOfInput);
                }
            }
            while (!validInput);

            return inputStr;
        }

        private static string getInput()
        {
            return Console.ReadLine();
        }

        private static bool validateInput(string i_InputStr, ref bool io_InputIsLetters, ref bool io_InputIsDigits, ref int io_InputNum)
        {
            return isInputLenValid(i_InputStr) && isInputTypeValid(i_InputStr, ref io_InputIsLetters, ref io_InputIsDigits, ref io_InputNum);
        }

        private static bool isInputLenValid(string i_InputStr)
        {
            int lenOfInput = 8;
          
            return i_InputStr.Length == lenOfInput;
        }

        private static bool isInputTypeValid(string i_InputStr, ref bool io_InputIsLetters, ref bool io_InputIsDigits, ref int io_InputNum)
        {
            isLettersInput(i_InputStr, ref io_InputIsLetters);
            isDigitsInput(i_InputStr, ref io_InputIsDigits, ref io_InputNum);

            return io_InputIsLetters || io_InputIsDigits;
        }

        private static void isLettersInput(string i_InputStr, ref bool io_InputIsLetters)
        {
            bool inputContainsOnlyLetters = true;

            for(int i = 0; i < i_InputStr.Length && inputContainsOnlyLetters; i++)
            {
                if (!char.IsLetter(i_InputStr[i]))
                {
                    inputContainsOnlyLetters = false;
                }
            }

            if(inputContainsOnlyLetters)
            {
                io_InputIsLetters = true;
            }
        }

        private static void isDigitsInput(string i_InputStr, ref bool io_InputIsDigits, ref int o_InputNum)
        {
            System.Globalization.NumberStyles onlyDigits = System.Globalization.NumberStyles.None;
            bool inputContainsOnlyDigits = int.TryParse(i_InputStr, onlyDigits, null, out o_InputNum);

            if (inputContainsOnlyDigits)
            {
                io_InputIsDigits = true;
            }
        }

        private static void analyzeInput(string i_InputStr, bool i_InputIsLetters, bool i_InputIsDigits, int i_InputNum)
        {
            int countUpperCase;

            if (isPalindrome(i_InputStr))
            {
                Console.WriteLine("{0} is a Palindrome", i_InputStr);
            }
            else
            {
                Console.WriteLine("{0} is NOT a Palindrome", i_InputStr);
            }

            if (i_InputIsDigits)
            {
                if (isDividedByFive(i_InputNum))
                {
                    Console.WriteLine("{0} is divided by 5", i_InputStr);
                }
                else
                {
                    Console.WriteLine("{0} is NOT divided by 5", i_InputStr);
                }
            }
            else if (i_InputIsLetters)
            {
                countUpperCase = countUpperCaseLetters(i_InputStr);
                Console.WriteLine("There are {0} uppercase letters in {1}", countUpperCase, i_InputStr);
            }
        }

        private static bool isPalindrome(string i_InputStr)
        {
            int strLen = i_InputStr.Length;
            bool stringIsPalindrome;

            if (strLen <= 1)
            {
                stringIsPalindrome = true;
            }
            else if (i_InputStr[0] != i_InputStr[strLen - 1]) 
            {
                stringIsPalindrome = false;
            }
            else
            {
                stringIsPalindrome = isPalindrome(i_InputStr.Substring(1, strLen - 2));
            }

            return stringIsPalindrome;
        }

        private static bool isDividedByFive(int i_Num)
        {
            return i_Num % 5 == 0;
        }

        private static int countUpperCaseLetters(string i_InputStr)
        {
            int count = 0;
            int lenOfInput = 8;

            for (int i = 0; i <= lenOfInput - 1; i++) 
            {
                if (char.IsUpper(i_InputStr[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}