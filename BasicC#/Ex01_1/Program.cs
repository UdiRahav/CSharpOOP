using System;

namespace B10_Ex01_01
{

    class Program
    {
        public static void Main()
        {
            GetBinarySeriesData();
        }
        public static int[] GetUserInput()
        {
            Console.WriteLine("Please enter 4 binary numbers with 8 digits each:");
            int[] arrayOfBinarryInputs = new int[4];
            int numberOfInput = 0;
            while (true)
            {
                String userInput = Console.ReadLine();
                if (userInput.Length != 8)
                {
                    Console.WriteLine("The input you entered is invalid.Please try again.");
                    continue;
                }
                for (int i = 0; i < 8; i++)
                {
                    if (userInput[i] != '0' && userInput[i] != '1')
                    {
                        Console.WriteLine("The input you entered is invalid.Please try again.");
                        break;
                    }
                    if (i == 7)
                    {
                        arrayOfBinarryInputs[numberOfInput++] = int.Parse(userInput);
                    }
                }
                if (numberOfInput == 4)
                {
                    break;
                }
            }
            return arrayOfBinarryInputs;
        }

        public static int[] BinaryToDecimal(int[] i_intArray)
        {
            int[] arrayToReturn = new int[i_intArray.Length];

            for (int i = 0; i < i_intArray.Length; i++)
            {
                int currentNumber = i_intArray[i];
                int currentPowerOfTwo = 1;
                while (currentNumber != 0)
                {
                    arrayToReturn[i] += (currentNumber % 10) * currentPowerOfTwo;
                    currentPowerOfTwo *= 2;
                    currentNumber = currentNumber / 10;
                }
            }
            return arrayToReturn;
        }


        public static void AvgOfOnesAndZeros(int[] i_intArray, out float NumberOfZeros, out float NumberOfones)
        {
            NumberOfZeros = 0;
            NumberOfones = 0;
            for (int i = 0; i < i_intArray.Length; i++)
            {
                int CurrentBinaryNumber = i_intArray[i];
                for (int j = 0; j < 8; j++)
                {
                    if (CurrentBinaryNumber % 10 == 1)
                    {
                        NumberOfones++;
                    }
                    else
                    {
                        NumberOfZeros++;
                    }
                    CurrentBinaryNumber /= 10;
                }
            }
            NumberOfZeros /= 4;
            NumberOfones /= 4;

        }
        public static int CountPowerOfTwoNumbers(int[] i_intArray)
        {
            int powerOfTwoNumbers = 0;
            int currentNumber;
            for (int i = 0; i < i_intArray.Length; i++)
            {
                if (i_intArray[i] == 0)
                {
                  continue;
                }
                currentNumber = i_intArray[i];
                if (Math.Ceiling(Math.Log(currentNumber) / Math.Log(2))
                  == Math.Floor(Math.Log(currentNumber) / Math.Log(2)))
                {
                    powerOfTwoNumbers++;
                }
            }
            return powerOfTwoNumbers;
        }
        public static int CountIncreasingSeries(int[] i_intArray)
        {
            int increaseSeriesCounter = 0;
            for (int i = 0; i < i_intArray.Length; i++)
            {
                int currentNumberToCheck = i_intArray[i];
                while (true)
                {
                    int rightMostDigit = currentNumberToCheck % 10;
                    currentNumberToCheck = currentNumberToCheck / 10;
                    if (rightMostDigit <= (currentNumberToCheck % 10))
                    {
                        break;
                    }
                    if (currentNumberToCheck == 0)
                    {
                        increaseSeriesCounter++;
                        break;
                    }
                }
            }
            return increaseSeriesCounter;
        }
        public static float GetAvgOfElements(int[] i_intArray)
        {
            float sumOfElements = 0;
            for (int i = 0; i < i_intArray.Length; i++)
            {
                sumOfElements += i_intArray[i];
            }
            return sumOfElements / i_intArray.Length;
        }
        public static void GetBinarySeriesData()
        {
            int[] inputAsBinary = GetUserInput();
            int[] decimals = BinaryToDecimal(inputAsBinary);
            Console.Write("the Decimal Numbers are: " + decimals[0]);
            for (int i = 1; i < decimals.Length; i++)
            {
                Console.Write(", " + decimals[i]);
            }
            Console.WriteLine();
            AvgOfOnesAndZeros(inputAsBinary, out float NumberOfZeros, out float NumberOfones);
            string msg = string.Format(
    @"There are {0} numbers which are power of two.
There are {1} numbers which are ascending series.
The general average of the inserted numbers is: {2}.
The  average of the one's in the binary numbers is {3}.
The  average of the zero's in the binary numbers is {4}.
Please press 'Enter' to exit...",
              CountPowerOfTwoNumbers(decimals), CountIncreasingSeries(decimals), GetAvgOfElements(decimals),
             NumberOfones, NumberOfZeros);
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}
   

