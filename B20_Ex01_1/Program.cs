using System;

namespace B20_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            start();
        }

        private static void start()
        {
            int inputInDecimal1, inputInDecimal2, inputInDecimal3, numOfNumbers, lenOfInput;
            string inputInBinary1, inputInBinary2, inputInBinary3;

            numOfNumbers = 3;
            lenOfInput = 9;
            Console.WriteLine("Please enter {0} {1}-digits binary numbers", numOfNumbers, lenOfInput);
            Console.WriteLine("Please enter the first number: ");
            inputInBinary1 = getValidInput();
            Console.WriteLine("Please enter the second number: ");
            inputInBinary2 = getValidInput();
            Console.WriteLine("Please enter the third number: ");
            inputInBinary3 = getValidInput();
            inputInDecimal1 = convertBinaryToDecimal(inputInBinary1);
            inputInDecimal2 = convertBinaryToDecimal(inputInBinary2);
            inputInDecimal3 = convertBinaryToDecimal(inputInBinary3);
            printStatisticsOfInput(inputInDecimal1, inputInDecimal2, inputInDecimal3, inputInBinary1, inputInBinary2, inputInBinary3);
        }

        private static string getValidInput()
        {
            string inputStr;
            bool inputIsValid;

            do
            {
                inputStr = getInput();
                inputIsValid = checkIfInputIsValid(inputStr);
                if (!inputIsValid)
                {
                    Console.WriteLine("Not valid input. Please enter a valid input: ");
                }
            }
            while (!inputIsValid);

            return inputStr;
        }

        private static string getInput()
        {
            return Console.ReadLine();
        }

        private static void printStatisticsOfInput(int i_InputDec1, int i_InputDec2, int i_InputDec3,
                                                   string i_InputStr1, string i_InputStr2, string i_InputStr3)
        {
            string inputDecStr1, inputDecStr2, inputDecStr3, outputMsg;
            int numOfNumbers, countPowersOfTwo, count, maxOfInputs, minOfInputs;
            float avgOfZeros, avgOfOnes;

            numOfNumbers = 3;
            inputDecStr1 = i_InputDec1.ToString();
            inputDecStr2 = i_InputDec2.ToString();
            inputDecStr3 = i_InputDec3.ToString();
            avgOfZeros = getAvgNumOfZerosInBinaryInput(i_InputStr1, i_InputStr2, i_InputStr3);
            avgOfOnes = getAvgNumOfOnesInBinaryInput(i_InputStr1, i_InputStr2, i_InputStr3);
            countPowersOfTwo = getHowManyNumbersArePowersOfTwo(i_InputDec1, i_InputDec2, i_InputDec3);
            count = getHowManyNumbersAreInAscendingOrder(inputDecStr1, inputDecStr2, inputDecStr3);
            maxOfInputs = getMaxNum(i_InputDec1, i_InputDec2, i_InputDec3);
            minOfInputs = getMinNum(i_InputDec1, i_InputDec2, i_InputDec3);
            outputMsg = string.Format(
@"The input numbers in Decimal Format are
{0}
{1}
{2}
Average number of Zeros in all {3} numbers is {4:0.##}
Average number of Ones in all {3} numbers is {5:0.##}
{6} of the {3} input numbers are Power of 2
{7} of the {3} input numbers' digits are in Ascending order
The largest number is {8}
The smallest number is {9}",
                i_InputDec1, i_InputDec2, i_InputDec3, numOfNumbers, avgOfZeros, avgOfOnes, countPowersOfTwo, count, maxOfInputs, minOfInputs);
            Console.WriteLine(outputMsg);
        }

        private static float getAvgNumOfZerosInBinaryInput(string i_InputStr1, string i_InputStr2, string i_InputStr3)
        {
            int totalZerosCount = 0;
            int numOfNumbers = 3;
            float avgOfZeros = 0;

            totalZerosCount += countNumOfZeros(i_InputStr1);
            totalZerosCount += countNumOfZeros(i_InputStr2);
            totalZerosCount += countNumOfZeros(i_InputStr3);
            avgOfZeros = (float)totalZerosCount / numOfNumbers;

            return avgOfZeros;
        }

        private static int countNumOfZeros(string i_InputStr)
        {
            int countZeros = 0;
            int lenOfInput = 9;

            for (int i = 0; i < lenOfInput; i++)
            {
                if (i_InputStr[i] == '0')
                {
                    countZeros++;
                }
            }

            return countZeros;
        }

        private static float getAvgNumOfOnesInBinaryInput(string i_InputStr1, string i_InputStr2, string i_InputStr3)
        {
            int totalOnesCount = 0, numOfNumbers = 3;
            float avgOfOnes = 0;

            totalOnesCount += countNumOfOnes(i_InputStr1);
            totalOnesCount += countNumOfOnes(i_InputStr2);
            totalOnesCount += countNumOfOnes(i_InputStr3);
            avgOfOnes = (float)totalOnesCount / numOfNumbers;

            return avgOfOnes;
        }

        private static int countNumOfOnes(string i_InputStr)
        {
            int countOnes = 0, lenOfInput = 9;

            for (int i = 0; i < lenOfInput; i++)
            {
                if (i_InputStr[i] == '1')
                {
                    countOnes++;
                }
            }

            return countOnes;
        }

        private static int getHowManyNumbersArePowersOfTwo(int i_Num1, int i_Num2, int i_Num3)
        {
            int countPowersOfTwo = 0;

            if (isNumberPowerOfTwo(i_Num1))
            {
                countPowersOfTwo++;
            }

            if (isNumberPowerOfTwo(i_Num2))
            {
                countPowersOfTwo++;
            }

            if (isNumberPowerOfTwo(i_Num3))
            {
                countPowersOfTwo++;
            }

            return countPowersOfTwo;
        }

        private static bool isNumberPowerOfTwo(int i_Num)
        {
            while (((i_Num % 2) == 0) && i_Num > 1)
            {
                i_Num /= 2;
            }

            return i_Num == 1;
        }

        private static int getHowManyNumbersAreInAscendingOrder(string i_InputStr1, string i_InputStr2, string i_InputStr3)
        {
            int count = 0;

            if (areDigitsInAscendingOrder(i_InputStr1))
            {
                count++;
            }

            if (areDigitsInAscendingOrder(i_InputStr2))
            {
                count++;
            }

            if (areDigitsInAscendingOrder(i_InputStr3))
            {
                count++;
            }

            return count;
        }

        private static bool areDigitsInAscendingOrder(string i_InputStr)
        {
            bool digitsInAscendingOrder = true;

            for (int i = 1; i < i_InputStr.Length && digitsInAscendingOrder; i++)
            {
                if (i_InputStr[i] <= i_InputStr[i - 1])
                {
                    digitsInAscendingOrder = false;
                }
            }

            return digitsInAscendingOrder;
        }

        private static int getMaxNum(int i_Num1, int i_Num2, int i_Num3)
        {
            int tempMax = Math.Max(i_Num1, i_Num2);
            int max = Math.Max(tempMax, i_Num3);

            return max;
        }

        private static int getMinNum(int i_Num1, int i_Num2, int i_Num3)
        {
            int tempMin = Math.Min(i_Num1, i_Num2);
            int min = Math.Min(tempMin, i_Num3);

            return min;
        }

        private static int convertCharToInt(char i_Chr)
        {
            return i_Chr - '0';
        }

        private static int convertBinaryToDecimal(string i_InputStr)
        {
            int currentBinaryDigit, powerByIndex;
            int decimalNumber = 0;
            int mostRightIndex = i_InputStr.Length - 1;

            for (int indexInStr = mostRightIndex; indexInStr >= 0; indexInStr--)
            {
                currentBinaryDigit = convertCharToInt(i_InputStr[indexInStr]);
                powerByIndex = getPowerByIndex(i_InputStr, indexInStr);
                decimalNumber += multiplyDigitByTwoPower(currentBinaryDigit, powerByIndex);
            }

            return decimalNumber;
        }

        private static int getPowerByIndex(string i_InputStr, int i_IndexInStr)
        {
            return i_InputStr.Length - i_IndexInStr - 1;
        }

        private static int multiplyDigitByTwoPower(int i_BinaryDigit, int i_PowerByIndex)
        {
            int powerOfTwoByIndex = (int)Math.Pow(2, i_PowerByIndex);

            return i_BinaryDigit * powerOfTwoByIndex;
        }

        private static bool checkIfInputIsValid(string i_Input)
        {
            return isInputLenValid(i_Input) && isInputContainOnlyZeroOne(i_Input) && !isInputZero(i_Input);
        }

        private static bool isInputLenValid(string i_InputStr)
        {
            int lenOfInput = 9;

            return i_InputStr.Length == lenOfInput;
        }

        private static bool isInputContainOnlyZeroOne(string i_InputStr)
        {
            bool inputContainOnlyZeroOne = true;

            for (int i = 0; i < i_InputStr.Length && inputContainOnlyZeroOne; i++)
            {
                if (i_InputStr[i] != '0' && i_InputStr[i] != '1')
                {
                    inputContainOnlyZeroOne = false;
                }
            }

            return inputContainOnlyZeroOne;
        }

        private static bool isInputZero(string i_InputStr)
        {
            string strZero = "000000000";

            return i_InputStr == strZero;
        }
    }
}