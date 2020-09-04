using System;
using System.Linq;
using System.Text;


namespace B19_Ex02
{
   internal class BullsAndCowsLogic
    {
        private BullsAndCowsGame m_Game;
        private static Random m_Rnd = new Random();
        private const byte k_RandomWordLength = 4;
        private const Char k_LowerBoundChar = 'A';
        private const Char k_UperBoundChar = 'H';
        private byte m_PerfectHits;

        public BullsAndCowsLogic(BullsAndCowsGame i_bullsAndCowsGame)
        {
            this.m_Game = i_bullsAndCowsGame;
        }
        internal char getRandomChar()
        {
            return (char)m_Rnd.Next(k_LowerBoundChar, k_UperBoundChar);
        }
        internal string getRandomWord()
        {
            StringBuilder randomWord = new StringBuilder();
            
            while (randomWord.Length < k_RandomWordLength)
            {
                char nextRandomChar = getRandomChar();
                if (!randomWord.ToString().Contains(nextRandomChar))
                {
                    randomWord.Append(nextRandomChar);
                }
            }
            return  randomWord.ToString();
        }
        internal void inputIsVaild(string i_UserInput, out bool o_GuessIsVaild)
        {
            o_GuessIsVaild = true;

                if(!validSyntaxGuess(i_UserInput))
                {
                    m_Game.eErrorMode = BullsAndCowsGame.eErrorStatus.syntaxError;
                    o_GuessIsVaild = false;
                }
                else if (!validLogicalGuess(i_UserInput))
                {
                    m_Game.eErrorMode = BullsAndCowsGame.eErrorStatus.LogicError;
                    o_GuessIsVaild = false;
                }
            else
            {
                m_Game.eGameMode = BullsAndCowsGame.eGameStatus.Play;
            }
        }
        private bool validSyntaxGuess(string i_UserGuess)
        {
            bool NoDupplicteChars = true;
            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                for (int j = i + 1; j < i_UserGuess.Length; j++)
                {
                    if (i_UserGuess[i] == i_UserGuess[j])
                    {
                        NoDupplicteChars = false;
                    }
                }
            }
            return NoDupplicteChars & !i_UserGuess.Any(char.IsDigit);
        }
        private bool validLogicalGuess(string i_UserGuess)
        {
            bool allCharsInRange = true;
            for (int i = 0; i < i_UserGuess.Length; i++)
            {

                char charToCheck = i_UserGuess[i];
                if (charToCheck < k_LowerBoundChar | charToCheck > k_UperBoundChar)
                {
                    allCharsInRange = false;
                    break;
                }
            }
            return allCharsInRange;

        }
        internal void CountHitsOfGuess(out byte o_PerfectHits, out byte o_AlmostHits, string i_StringToCheck)
        {
            o_PerfectHits = 0;
            o_AlmostHits = 0;

            for (int i = 0; i < i_StringToCheck.Length; i++)
            {
                if (m_Game.CoumpuretsRandWord.Contains(i_StringToCheck[i]))
                {
                    if (m_Game.CoumpuretsRandWord[i].Equals(i_StringToCheck[i]))
                    {
                        o_PerfectHits++;
                    }
                    else
                    {
                        o_AlmostHits++;
                    }
                }
            }
            m_PerfectHits = o_PerfectHits;
        }
        internal void checkGameStatus()
        {
            if (m_PerfectHits == m_Game.CoumpuretsRandWord.Length)
            {
                m_Game.eGameMode = BullsAndCowsGame.eGameStatus.WinStatus;
            }
            else if (m_Game.CurrentTurn + 1 > m_Game.NumberOfGuesses)
            {
                m_Game.eGameMode = BullsAndCowsGame.eGameStatus.LoseStatus;
            }
        }
    }
}
