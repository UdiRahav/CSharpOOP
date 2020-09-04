using System;
using System.Text;

namespace B19_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            DrawSandClock5();
        }

        public static void DrawSandClockByValue()
        {
            int height = 0;
            Console.WriteLine("Hello please enter your desired sand clock height");
            while (true)
            {
                string userInput = Console.ReadLine();
                bool validInput = int.TryParse(userInput, out height);
                if (userInput != "x" && (!validInput || height < 0))
                {
                    Console.WriteLine("Invalid Input try again or tap  x to exit");
                }
                else if (userInput == "x")
                {
                    Console.WriteLine("bye bye!!!");
                    return;
                }
                else
                {
                    break;
                }
            }
            StringBuilder hourGlassString = new StringBuilder();
            int evenOrOdd = 3;
            DrawUpperTriangle(height, 0, hourGlassString);
            if (height % 2 == 0)
            {
                evenOrOdd = 2;
            }
            DrawDownTriangle(evenOrOdd, (height / 2) - 1, hourGlassString);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }
        public static void DrawSandClock5()
        {
            StringBuilder hourGlassString = new StringBuilder();
            DrawUpperTriangle(5, 0, hourGlassString);
            DrawDownTriangle(3, 1, hourGlassString);
            Console.WriteLine("Please press 'Enter' to exit...");
            Console.ReadLine();
        }


        public static void DrawUpperTriangle(int i_numberOfStarsToPrint, int i_numberOfSpaceToPrint, StringBuilder i_hourGlassString)
        {
            if (i_numberOfStarsToPrint <= 0) return;
            PrintSpaces(i_numberOfSpaceToPrint, i_hourGlassString);
            PrintStars(i_numberOfStarsToPrint, i_hourGlassString);
            i_hourGlassString.Append("\n");
            DrawUpperTriangle(i_numberOfStarsToPrint - 2, ++i_numberOfSpaceToPrint, i_hourGlassString);
        }
        public static void DrawDownTriangle(int i_numberOfStarsToPrint, int i_numberOfSpacesToPrint, StringBuilder i_Triangle)
        {
            if (i_numberOfSpacesToPrint < 0)
            {
                Console.WriteLine(i_Triangle.ToString());
                return;
            }


            PrintSpaces(i_numberOfSpacesToPrint, i_Triangle);
            PrintStars(i_numberOfStarsToPrint, i_Triangle);
            i_Triangle.Append("\n");
            DrawDownTriangle(i_numberOfStarsToPrint + 2, --i_numberOfSpacesToPrint, i_Triangle);
        }
        public static void PrintStars(int i_numberOfSpacesToPrint, StringBuilder i_stringBuilder)
        {
            if (i_numberOfSpacesToPrint == 0) return;
            i_stringBuilder.Append("*");
            PrintStars(i_numberOfSpacesToPrint - 1, i_stringBuilder);
        }
        public static void PrintSpaces(int i_numberOfSpacesToPrint, StringBuilder i_stringBuilder)
        {
            if (i_numberOfSpacesToPrint == 0) return;
            i_stringBuilder.Append(" ");
            PrintSpaces(i_numberOfSpacesToPrint - 1, i_stringBuilder);
        }
    }
}

