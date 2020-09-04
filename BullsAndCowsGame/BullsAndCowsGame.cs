using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex02
{
   public  class BullsAndCowsGame
    {

        private eGameStatus m_eGameStatus;
        private eErrorStatus m_eErrorStatus;
        private byte m_MinNumberOfGuesses;
        private byte m_MaxNumberOfGuesses;
        private readonly string r_ComputerRandomWord;
        private byte m_NumberOfGuesses;
        private string m_ShrinkInput;

        private BullsAndCowsUI m_BullsAndCowsUI;
        private BullsAndCowsLogic m_BullsAndCowsLogic;
        private byte m_CurrentTurn;

        public BullsAndCowsGame()
        {
            m_BullsAndCowsLogic = new BullsAndCowsLogic(this);
            m_BullsAndCowsUI = new BullsAndCowsUI(this);
            m_eGameStatus = eGameStatus.NewGame;
            r_ComputerRandomWord = m_BullsAndCowsLogic.getRandomWord();
            m_eErrorStatus = eErrorStatus.NoError;
            m_MinNumberOfGuesses = 4;
            m_MaxNumberOfGuesses = 10;

        }
        public enum eErrorStatus
        {
            NoError,
            syntaxError,
            FormatError,
            LogicError,
            quitError,
        }
        public enum eGameStatus
        {
            NewGame,
            Play,
            LoseStatus,
            WinStatus,
            QuitStatus,
            ErrorStatus,
        }
        public eErrorStatus eErrorMode

        {
            get { return m_eErrorStatus; }
            internal set { m_eErrorStatus = value; }
        }
        public eGameStatus eGameMode
        
        {
            get { return m_eGameStatus; }
            internal set { m_eGameStatus = value; }
        }
        internal string CoumpuretsRandWord
        {
            get
            {
                return r_ComputerRandomWord;
            }
        }
        public string ShrinkInput
        {
            get
            {
                return m_ShrinkInput;
            }
            set
            {
                m_ShrinkInput = value;
            }
        }
        public byte NumberOfGuesses
        {
            get
            {
                return m_NumberOfGuesses;
            }
            set
            {
                m_NumberOfGuesses = value;
            }
        }
        public byte TurnNumber
        {
            get
            {
                return m_CurrentTurn;
            }
           
        }
        internal byte CurrentTurn
        {
            get
            {
                return m_CurrentTurn;
            }
        }
        internal byte MinNumberOfGuesses
        {
            get
            {
                return m_MinNumberOfGuesses;
            }
        }
        internal byte MaxNumberOfGuesses
        {
            get
            {
                return m_MaxNumberOfGuesses;
            }
        }

       
        internal void RunGame()
        {
   
            bool gameIsOn = true;
            string userInput;
            while (gameIsOn)
            {
                if (m_eGameStatus == eGameStatus.NewGame)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_BullsAndCowsUI.WellcomeMsg();
                    m_BullsAndCowsUI.GetNumberOfGuesses();
                    m_BullsAndCowsUI.initialTable(m_NumberOfGuesses);
                    m_eGameStatus = eGameStatus.Play;
                    m_CurrentTurn = 0;
                }

                else if (m_eGameStatus == eGameStatus.Play )
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_BullsAndCowsUI.printTable();
                    if (m_eErrorStatus == eErrorStatus.FormatError)
                    {
                        m_BullsAndCowsUI.formatErrorMsg();
                    }
                    else if (m_eErrorStatus == eErrorStatus.syntaxError)
                    {
                        m_BullsAndCowsUI.syntaxErrorMsg();
                    }
                    else if (m_eErrorStatus == eErrorStatus.LogicError)
                    {
                        m_BullsAndCowsUI.LogicErrorMsg();
                    }

                        m_BullsAndCowsUI.PlayMsg();
                        m_eErrorStatus = eErrorStatus.NoError;
                    bool o_GuessIsVaild;
                    bool o_GuessInFormat;
                    userInput = m_BullsAndCowsUI.GetUserGuess(out o_GuessInFormat);
                    //inputIsVaildv put ture in o_guessIsVAILD if the input logic vaild, change game status otherwise
                    if (o_GuessInFormat)
                    {
                        m_BullsAndCowsLogic.inputIsVaild(m_ShrinkInput, out o_GuessIsVaild);

                        if (o_GuessIsVaild & o_GuessInFormat)
                        {
                            byte o_PerfectHits;
                            byte o_AlmostHits;
                            m_BullsAndCowsUI.storeToPinsColumn = userInput;                    
                            m_BullsAndCowsLogic.CountHitsOfGuess(out o_PerfectHits, out o_AlmostHits, m_ShrinkInput);
                            m_BullsAndCowsUI.storeToResultColumn(o_PerfectHits, o_AlmostHits);
                            m_CurrentTurn++;

                            //after storing the guess need to check if I won, or lost,or keep playing 
                            m_BullsAndCowsLogic.checkGameStatus();
                        }
                    }
                }
          
                else if (m_eGameStatus == eGameStatus.QuitStatus)
                {

                    m_BullsAndCowsUI.GoodByeMsg();
                    gameIsOn = false;
                }

                else if (m_eGameStatus == eGameStatus.LoseStatus)
                {
                    m_BullsAndCowsUI.exposeComputerGuess();
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_BullsAndCowsUI.printTable();
                    if (m_eErrorStatus == eErrorStatus.quitError)
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        m_BullsAndCowsUI.printTable();
                        m_BullsAndCowsUI.quitErrorMsg();
                    }
                    else
                    {
                        m_BullsAndCowsUI.loseMsg();
                    }
                    
                    //change status to new game or quit (N BUTTON)
                    m_BullsAndCowsUI.askToPlayAgain();

                }

                else if (m_eGameStatus == eGameStatus.WinStatus)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_BullsAndCowsUI.printTable();
                    
                    if(m_eErrorStatus == eErrorStatus.quitError)
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        m_BullsAndCowsUI.printTable();
                        m_BullsAndCowsUI.quitErrorMsg();
                    }
                    else
                    {
                        m_BullsAndCowsUI.winMsg();
                    }
                    m_BullsAndCowsUI.askToPlayAgain();
                }
            }
        }
    }
}
