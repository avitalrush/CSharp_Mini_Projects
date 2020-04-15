using System;

namespace B20_Ex01_1
{
    public class Program
    {
        private const int k_NumOfNumbers = 3;
        private const int k_LenOfInput = 9;

        public static void Main()
        {
            start();
        }

        private static void start()
        {
            Console.WriteLine("Please enter " + k_NumOfNumbers + " " + k_LenOfInput + "-digits binary numbers.");

            Console.WriteLine("Please enter the first number:");
            string inputStr1 = getValidInput();
            int inputNum1 = int.Parse(inputStr1);

            Console.WriteLine("Please enter the second number:");
            string inputStr2 = getValidInput();
            int inputNum2 = int.Parse(inputStr2);

            Console.WriteLine("Please enter the third number:");
            string inputStr3 = getValidInput();
            int inputNum3 = int.Parse(inputStr3);

            int decInput1 = convertFromBinaryToDecimal(inputStr1);
            int decInput2 = convertFromBinaryToDecimal(inputStr2);
            int decInput3 = convertFromBinaryToDecimal(inputStr3);

            printStatisticsOfInput(decInput1, decInput2, decInput3, inputStr1, inputStr2, inputStr3);
            Console.ReadLine();
        }

        private static string getValidInput()
        {
            string inputStr;
            bool isValidInput;
            do
            {
                inputStr = getInput();
                isValidInput = checkIfValidInput(inputStr);
            }
            while(isValidInput == !true);
            return inputStr;
        }

        private static string getInput()
        {
            string inputStr = Console.ReadLine();
            return inputStr;
        }

        private static void printStatisticsOfInput(int i_InputNum1, int i_InputNum2, int i_InputNum3, 
                                                    string i_InputStr1, string i_InputStr2, string i_InputStr3)
        {
            Console.WriteLine("The input numbers in Decimal Format are:");
            printDecNum(i_InputNum1);
            printDecNum(i_InputNum2);
            printDecNum(i_InputNum3);

            printAvgNumOfZerosInNum(i_InputStr1, i_InputStr2, i_InputStr3);
            printAvgNumOfOnesInNum(i_InputStr1, i_InputStr2, i_InputStr3);

            printHowManyArePowersOfTwo(i_InputNum1, i_InputNum2, i_InputNum3);

            string decNumStr1 = i_InputNum1.ToString();
            string decNumStr2 = i_InputNum2.ToString();
            string decNumStr3 = i_InputNum3.ToString();
            printHowManyAreAscOrder(decNumStr1, decNumStr2, decNumStr3);

            printMaxNum(i_InputNum1, i_InputNum2, i_InputNum3);
            printMinNum(i_InputNum1, i_InputNum2, i_InputNum3);
        }

        private static void printDecNum(int i_Num)
        {
            Console.WriteLine(i_Num);
        }

        private static void printAvgNumOfZerosInNum(string i_Str1, string i_Str2, string i_Str3)
        {
            int avg = avgNumOfZerosInNum(i_Str1, i_Str2, i_Str3);
            Console.WriteLine("Average num of Zeros in all {0} numbers is: {1}", k_NumOfNumbers, avg);
        }

        private static int avgNumOfZerosInNum(string i_Str1, string i_Str2, string i_Str3)
        {
            int totalZerosCount = 0;
            int avgOfZeros;
            totalZerosCount += countNumOfZeros(i_Str1);
            totalZerosCount += countNumOfZeros(i_Str2);
            totalZerosCount += countNumOfZeros(i_Str3);
            return avgOfZeros = totalZerosCount / k_NumOfNumbers;
        }

        private static int countNumOfZeros(string i_Str)
        {
            int countZeros = 0;

            for(int i = 0; i< k_LenOfInput; i++)
            {
                if(i_Str[i] == '0')
                {
                    countZeros++;
                }
            }
            return countZeros;
        }

        private static void printAvgNumOfOnesInNum(string i_Str1, string i_Str2, string i_Str3)
        {
            int avg = avgNumOfOnesInNum(i_Str1, i_Str2, i_Str3);
            Console.WriteLine("Average num of Ones in all {0} numbers is: {1}", k_NumOfNumbers, avg);
        }

        private static int avgNumOfOnesInNum(string i_Str1, string i_Str2, string i_Str3)
        {
            int totalOnesCount = 0;
            int avgOfOnes;
            totalOnesCount += countNumOfOnes(i_Str1);
            totalOnesCount += countNumOfOnes(i_Str2);
            totalOnesCount += countNumOfOnes(i_Str3);
            return avgOfOnes = totalOnesCount / k_NumOfNumbers;
        }

        private static int countNumOfOnes(string i_Str)
        {
            int countOnes = 0;
            for (int i = 0; i < k_LenOfInput; i++)
            {
                if (i_Str[i] == '1')
                {
                    countOnes++;
                }
            }
            return countOnes;
        }

        private static void printHowManyArePowersOfTwo(int i_Num1, int i_Num2, int i_Num3)
        {
            int countPowersOfTwo=0;
            if(isPowerOfTwo(i_Num1))
                countPowersOfTwo++;
            if (isPowerOfTwo(i_Num2))
                countPowersOfTwo++;
            if (isPowerOfTwo(i_Num3))
                countPowersOfTwo++;
            Console.WriteLine("{0} of the {1} input numbers are Power of 2", countPowersOfTwo, k_NumOfNumbers);
        }

        private static bool isPowerOfTwo(int i_Num)
        {
            while (((i_Num % 2) == 0) && i_Num > 1)
            {
                i_Num /= 2;
            }
            return (i_Num == 1);
        }

        private static void printHowManyAreAscOrder(string i_Str1, string i_Str2, string i_Str3)
        {
            int countAscOrder = 0;
            if(isDigitsInAscendingOrder(i_Str1))
            {
                countAscOrder++;
            }
            if(isDigitsInAscendingOrder(i_Str2))
            {
                countAscOrder++;
            }
            if(isDigitsInAscendingOrder(i_Str3))
            {
                countAscOrder++;
            }
            Console.WriteLine("{0} of the {1} input numbers' digits are in Ascending order", countAscOrder, k_NumOfNumbers);
        }

        private static bool isDigitsInAscendingOrder(string i_Str)
        {
            for(int i = 1; i < i_Str.Length; i++)
            {
                if(i_Str[i] <= i_Str[i - 1])
                {
                    return !true;
                }
            }
            return true;
        }

        private static void printMaxNum(int i_Num1, int i_Num2, int i_Num3)
        {
            int tempMax = Math.Max(i_Num1, i_Num2);
            int max = Math.Max(tempMax, i_Num3);
            Console.WriteLine("The Max num is {0}", max);
        }

        private static void printMinNum(int i_Num1, int i_Num2, int i_Num3)
        {
            int tempMin = Math.Min(i_Num1, i_Num2);
            int min = Math.Min(tempMin, i_Num3);
            Console.WriteLine("The Min num is {0}", min);
        }

       private static int convertFromBinaryToDecimal(string i_Str)
        {
            int decimalNum = 0;
            for (int i = 0; i <= (i_Str.Length) - 1; i++)
            {
                decimalNum *= 2;
                decimalNum += (int)(i_Str[i] - '0');
            }
            return decimalNum;
        }
      
        private static bool checkIfValidInput(string i_Str)
        {
            bool v_InputIsValid = true;
            if (!isInputLenValid(i_Str))
               return !v_InputIsValid;
            if (!isInputContainOnlyZeroOne(i_Str))
                return !v_InputIsValid;
            return v_InputLenIsValid;
        }
      
        private static bool isInputLenValid(string i_Str)
        {
            return (i_Str.Length == k_LenOfInput);
        }
        
        private static bool isInputContainOnlyZeroOne(string i_Str)
        {
            bool v_InputContainsOnlyOnesZeros = true;    
            for (int i = 0; i < i_Str.Length; i++)
                if (i_Str[i] !='0' && i_Str[i] !='1')
                   return !v_InputContainsOnlyOnesZeros;
            return v_InputContainsOnlyOnesZeros;
        }
    }
}
