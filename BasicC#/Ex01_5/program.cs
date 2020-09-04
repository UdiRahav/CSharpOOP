using System;

namespace B10_Ex01_05
{ 
    class Program
    {
        public static void Main()
        {
            NumericStatistics();
        }
        public static string GetUserInput()
        {
            Console.WriteLine("Hello, please enter your integer (8 digits)");
            string userInput;
            while (true)
            {
                userInput = Console.ReadLine();
                if (InputIsValid(userInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The input is invalid, please Try again.");
                }
            }
            return userInput;
        }
        public static Boolean InputIsValid(string i_UserInput)
        {
            int input;
            if (i_UserInput.Length != 8)
            {
                return false;
            }
            if (int.TryParse(i_UserInput, out input))
            {
                if (input >= 0)
                {
                    return true;
                }
            }

            return false;
        }
        public static void SmallestAndBigestDigits(int i_UserInput, out int largestDigit, out int smallestDigit)
        {
            largestDigit = i_UserInput % 10 ;
            smallestDigit = i_UserInput % 10; 
            for (int i =0; i < 8; i++)
            {
                if (i_UserInput % 10 > largestDigit) 
                {
                    largestDigit = i_UserInput % 10;
                }
                if (i_UserInput % 10 < smallestDigit)
                {
                    smallestDigit = i_UserInput % 10;
                }
                i_UserInput /= 10;
            }
        }
        public static int  CountDiv3Numbers(int i_UserInput){
            int Div3NumberCounter = 0;
            for (int i = 0; i < 8; i++) {
                if ((i_UserInput % 10) % 3 == 0)
                {
                    Div3NumberCounter++;
                }
                i_UserInput /= 10;
            }
            return Div3NumberCounter;
        }
        public static int CountGraterThanTelling(int i_UserInput)
        {
            int graterThanTelling = 0;
            int lastDigit = i_UserInput % 10;
            for (int i = 0; i < 8; i++)
            {
                if ((i_UserInput % 10 ) > lastDigit)
                {
                    graterThanTelling++;
                }
                i_UserInput /= 10;
            }
            return graterThanTelling;
        }
        public static void NumericStatistics()
        {
            string userInput = GetUserInput();
            int inputAsInt = int.Parse(userInput);
            int largestDigit;
            int smallestDigit;
            SmallestAndBigestDigits(inputAsInt, out largestDigit, out smallestDigit);
            string msg = string.Format(
@"Your input is {0}.
The largest Digit is {1}.
The smallest sDigit is {2}.
The divided by three numbers is {3}.
The number of digits that greater that the Telling unity {4}.
Please press 'Enter' to exit...",
 userInput, largestDigit, smallestDigit, CountDiv3Numbers(inputAsInt), CountGraterThanTelling(inputAsInt));
            Console.WriteLine(msg);
            Console.ReadLine();

        }
    }
}

