using System;

namespace B10_Ex01_04
{

    class program
    {
        public static void Main()
        {
            TextAnalyzing();
        }

        public static void Palindrome(string i_string,int i_startIndex ,int  i_endIndex)
        {
            if (i_startIndex >= i_endIndex)
            {
                Console.WriteLine("your input is a palindrome");
            }
            else if (i_string[i_startIndex] != i_string[i_endIndex])
            {
                Console.WriteLine("your input isn't a palindrome");
            }
            else
            {
                Palindrome(i_string, ++i_startIndex, --i_endIndex);
            }
        }
        public static string GetUserInput()
        {
            Console.WriteLine("Hello, please enter your word/number (12 characters long)");
            string userInput;
            while (true)
            {
                userInput = Console.ReadLine();
                if (IsValid(userInput))
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
        public static Boolean IsValid(string i_UserInput)
        {
            long a;
            Boolean IsAllLetters = true;
            Boolean IsAllDigis = long.TryParse(i_UserInput, out a);
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!Char.IsLetter(i_UserInput[i]))
                {
                    IsAllLetters = false;
                    break;
                }
            }
            return (i_UserInput.Length == 12) && (IsAllDigis || IsAllLetters);
        }
        public static void DivOf3(string i_UserInput)
        {
            if (long.Parse(i_UserInput) % 3 == 0)
            {
                Console.WriteLine("your number divided by 3");
            }
            else
            {
                Console.WriteLine("your number  isn't divided by 3");
            }   
        }
        public static void CountSmallLetters(string i_UserInput)
        {
            int smallLetters = 0;
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (Char.IsLower(i_UserInput[i]))
                {
                    smallLetters++;
                }
            }

            Console.WriteLine("you have "+ smallLetters + " small lLatters");
        }
        public static void TextAnalyzing()
        {
            string input = GetUserInput();
            Palindrome(input, 0, input.Length - 1);
            if (char.IsDigit(input[0]))
            {
                DivOf3(input);
            }
            else
            {
                CountSmallLetters(input);
            }
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }
       
    }
}

