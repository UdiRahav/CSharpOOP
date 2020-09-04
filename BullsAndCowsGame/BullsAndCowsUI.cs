using System;
using System.Text;

namespace B19_Ex02
{
   internal  class BullsAndCowsUI
    {
        private const string k_HiddenPinFirstLine = "# # # #";
        private const string k_HeftColumnHeadline = "Pins:";
        private const string K_RightColumnHeadline = "Result:";
        private const char K_Wall = '|';
        private const char k_Space = ' ';
        private const char k_Floor = '=';
        private const char k_HitMark = 'V';
        private const char k_MissMark = 'X';
        private const char k_NotExist = ' ';
        private string r_TableLine;
        
        private BullsAndCowsGame m_Game;
        private Table m_Table;

        // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
        public BullsAndCowsUI(BullsAndCowsGame i_bullsAndCowsGame)
        {
            this.m_Game = i_bullsAndCowsGame;  
        }
        internal void GetNumberOfGuesses()
        {
            while (true)
            {
                byte o_NumberOfGuesses;
                bool userGuessIsNum = byte.TryParse(Console.ReadLine(), out o_NumberOfGuesses);
                Ex02.ConsoleUtils.Screen.Clear();

                if (userGuessIsNum)
                {
                    if (o_NumberOfGuesses >= m_Game.MinNumberOfGuesses & o_NumberOfGuesses <= m_Game.MaxNumberOfGuesses)
                    {
                        m_Game.NumberOfGuesses = o_NumberOfGuesses;
                        m_Game.eGameMode = BullsAndCowsGame.eGameStatus.Play;
                        break;
                    }
                    else
                    {
                        //have a range problem!!
                        Console.WriteLine("Number not in range, please select guess number between {0} to {1}"
                            , m_Game.MinNumberOfGuesses, m_Game.MaxNumberOfGuesses);
                    }
                }
                else
                {
                    //have a syntax problem!!
                    Console.WriteLine("syntax error, please select guess number between {0} to {1}"
                        , m_Game.MinNumberOfGuesses, m_Game.MaxNumberOfGuesses);
                }
            }
        }

        internal string GetUserGuess(out bool o_GuessInFormat)
        {
            o_GuessInFormat = true;

                string userInput = Console.ReadLine();
            if (userInput.Equals("Q"))
            {
                m_Game.eGameMode = BullsAndCowsGame.eGameStatus.QuitStatus;
                o_GuessInFormat = false;

            }
           else if (formatIsValid(userInput))
                {
                m_Game.ShrinkInput = userInput.Replace(" ", "");
                m_Game.eGameMode = BullsAndCowsGame.eGameStatus.Play;
            }
            else
            {
                o_GuessInFormat = false;
                m_Game.eErrorMode = BullsAndCowsGame.eErrorStatus.FormatError;
            }
            return userInput;
        }
        private bool formatIsValid(string i_UserGuess)
        {
            bool formatIsVaild = true;
            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                char currentCharTocheck = i_UserGuess[i];
                if (i % 2 != 0 & currentCharTocheck != ' ')
                {
                    formatIsVaild = false;
                    break;
                }
            }
            return formatIsVaild & i_UserGuess.Length == 7;
        }
        public string storeToPinsColumn
        {
            set
            {
                m_Table.m_ArrayOfGuessesAndFeedback[m_Game.CurrentTurn + 2, 0] = value;
            }
        }
        internal void storeToResultColumn(int i_PerfectHit, int i_AlmostHit)
        {

            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < m_Game.CoumpuretsRandWord.Length; i++)
            {
                if (i_PerfectHit > 0)
                {
                    resultString.Append(k_HitMark);
                    i_PerfectHit--;
                }
                else if (i_AlmostHit > 0)
                {
                    resultString.Append(k_MissMark);
                    i_AlmostHit--;
                }
                else
                {
                    resultString.Append(k_NotExist);
                }
                if (i != m_Game.CoumpuretsRandWord.Length - 1)
                {
                    resultString.Append(k_Space);
                }
            }
            m_Table.m_ArrayOfGuessesAndFeedback[m_Game.CurrentTurn + 2, 1] = resultString.ToString();
        }
        internal void initialTable(int i_RowsNumber)
        {
            this.m_Table = new Table(i_RowsNumber);
            m_Table.LeftClumnWidth = (m_Game.CoumpuretsRandWord.Length * 2) + 1;
            m_Table.RightClumnWidth = (m_Game.CoumpuretsRandWord.Length * 2) - 1;
            m_Table.TableWidth = m_Table.LeftClumnWidth + m_Table.RightClumnWidth;
            m_Table.PinheadLine = k_HeftColumnHeadline;
            m_Table.ReusltHeadLine = K_RightColumnHeadline;
            m_Table.HiddenWord = k_HiddenPinFirstLine;
            r_TableLine = addSepratLine();
        }
        private void printLeftCell(int i_Row, int i_Column)
        {
            string EmpttCell = "";
            if (m_Table.m_ArrayOfGuessesAndFeedback[i_Row, i_Column] != null & i_Row != 0)
            {
                string str = string.Format("|{0}{1}{0}|", k_Space, 
                    m_Table.m_ArrayOfGuessesAndFeedback[i_Row, i_Column]);
                Console.Write(str);
            }
            else if (i_Row == 0)
            {
                string str = string.Format("|{1}|", k_Space,
                    m_Table.m_ArrayOfGuessesAndFeedback[i_Row, i_Column]);
                Console.Write(str);
            }
            else
            {
                string str = string.Format("|{0}|", EmpttCell.PadLeft(m_Table.LeftClumnWidth));
                Console.Write(str);
            }
        }
        private void printRigthCell(int i_Row , int i_Column)
        {
            string EmpttCell = "";
            if (m_Table.m_ArrayOfGuessesAndFeedback [i_Row,i_Column] != null )
            {
                string str = string.Format("{0}|", m_Table.m_ArrayOfGuessesAndFeedback[i_Row, i_Column]);
                Console.WriteLine(str);
                Console.Write(r_TableLine);
            }
            else
            {
                string str = string.Format("{0}|", EmpttCell.PadLeft(m_Table.RightClumnWidth));
                Console.WriteLine(str);
               Console.Write(r_TableLine);
            }
        }
        internal void askToPlayAgain()
        { 
                string userInput = Console.ReadLine();
                if (userInput.Equals("N"))
                {
                    m_Game.eGameMode = BullsAndCowsGame.eGameStatus.QuitStatus;
                   
                }
                else if (userInput.Equals("Y"))
                {
                    m_Game.eGameMode = BullsAndCowsGame.eGameStatus.NewGame;
            }
            else 
            {
                m_Game.eErrorMode = BullsAndCowsGame.eErrorStatus.quitError;
            }

        }
        internal void printTable()
        {
            Console.WriteLine("Current board status:{0}", Environment.NewLine);
            for (int row = 0; row < m_Table.m_ArrayOfGuessesAndFeedback.GetLength(0); row++)
            {
                for (int colum = 0; colum < m_Table.m_ArrayOfGuessesAndFeedback.GetLength(1); colum++)
                {
                    if (colum == 0)
                    {
                        printLeftCell(row, colum);
                    }
                    if (colum == 1)
                    {
                        printRigthCell(row, colum);
                    }
                }
            }
        }

        private string addSepratLine()
        {
            StringBuilder TableLine = new StringBuilder();
            TableLine.Append(K_Wall);
            for (int i = 0; i < m_Table.TableWidth + 1; i++)
            {
                if (i == m_Table.LeftClumnWidth)
                {
                    TableLine.Append(K_Wall);
                }
                else
                {
                    TableLine.Append(k_Floor);
                }
            }
            TableLine.Append(K_Wall + "\n");
            return TableLine.ToString();
        }
        internal void exposeComputerGuess()
        {
            StringBuilder stringToExpose = new StringBuilder(m_Game.CoumpuretsRandWord);
            stringToExpose.Insert(1, k_Space);
            stringToExpose.Insert(3, k_Space);
            stringToExpose.Insert(5, k_Space);
            m_Table.m_ArrayOfGuessesAndFeedback[1, 0] = stringToExpose.ToString();
            Console.WriteLine(m_Table.m_ArrayOfGuessesAndFeedback[1, 0]);
        }
        internal void LogicErrorMsg()
        {
            Console.WriteLine("Logical-invaild: inputing an out of range letter <A-H>");
        }
        internal void syntaxErrorMsg()
        {
            Console.WriteLine("Syntax-invalid:inputing a number insttead of a letter");
        }
        internal void formatErrorMsg()
        {
            Console.WriteLine("Wrong format guess,");
        }
        internal void quitErrorMsg()
        {
            Console.WriteLine("Wrong input,{0}Would you like to start a new game? <Y/N>", Environment.NewLine); 
        }
        internal void WellcomeMsg()
        {
            Console.WriteLine("Hello, please select guess number between {0} to {1}",
                m_Game.MinNumberOfGuesses, m_Game.MaxNumberOfGuesses);
        }
        internal void GoodByeMsg()
        {
            Console.WriteLine("Thank you for playing. bye bye");
        }
        internal void PlayMsg()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
        }
        internal void loseMsg()
        {
            Console.WriteLine("No more guesses allowed.You Lost.\nWould you like to start a new game? <Y/N>");
        }
        internal void winMsg()

        {
            Console.WriteLine("\nYou guueseed after {0} steps!Would you like to start a new game? <Y/N>", m_Game.TurnNumber );
        }
    }
}
