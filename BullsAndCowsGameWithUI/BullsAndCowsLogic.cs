
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B19_Ex02
{
    internal class BullsAndCowsLogic
    {
        private byte m_PerfectHits;
        private List<Color> m_RandomColors;
        private ColorsPickWindow m_ColorsToPickWindow;
        private static Random m_Rnd = new Random();
        public BullsAndCowsLogic()

        {
            m_RandomColors = new List<Color>();
            m_ColorsToPickWindow = new ColorsPickWindow();
            GetRandomRowOfColors();
        }
        private Color getRandomColor(List<Color> i_ColorsPaletteList)
        {
            return i_ColorsPaletteList[m_Rnd.Next(0, 8)];
        }
        internal void GetRandomRowOfColors()
        {
            m_ColorsToPickWindow = new ColorsPickWindow();
            List<Color> ColorsPaletteList = m_ColorsToPickWindow.ColorsToPick();
            while (m_RandomColors.Count < GameRow.k_WordLength)
            {
                Color nextRandomColor = getRandomColor(ColorsPaletteList);
                if (!m_RandomColors.Contains(nextRandomColor))
                {
                    m_RandomColors.Add(nextRandomColor);
                }
            }
        }
        internal void CountHitsOfGuess(out byte o_PerfectHits, out byte o_AlmostHits, List<Button> i_RowToCheck)
        {
            o_PerfectHits = 0;
            o_AlmostHits = 0;

            for (int i = 0; i < i_RowToCheck.Count; i++)
            {
                if (m_RandomColors.Contains(i_RowToCheck[i].BackColor))
                {
                    if (m_RandomColors[i] == i_RowToCheck[i].BackColor)
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
        internal void CheckGameStatus(out bool i_GameOver, int i_CurrentTurn, int i_MaxNumberOfTurns)
        {
            i_GameOver = (m_PerfectHits == m_RandomColors.Count) | i_CurrentTurn + 1 == i_MaxNumberOfTurns;
        }
        internal ColorsPickWindow ColorsToPickWindow
        {
            get
            {
                return m_ColorsToPickWindow;
            }
            
        }
        internal List<Color> RandomComputerColors
        {
            get
            {
                return m_RandomColors;
            }
        }
    }
}
