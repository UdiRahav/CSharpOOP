using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B19_Ex02
{
    public class BullsAndCowsGame
    {
        private BullsAndCowsLogic m_LogicManger; 
        private GameWindow m_GameWindow;                
        private int m_NumberOfGuesses; //Number of rows at the window
        private byte m_CurrentTurn;
        private bool m_GameOver;

       internal BullsAndCowsGame()
         {
             m_LogicManger = new BullsAndCowsLogic();
             m_GameWindow = new GameWindow();
             m_CurrentTurn = 0;
             m_GameOver = false;
         }
        [STAThread]
        internal void RunGame()
        {
            NumberOfGuessesWindow LogInWindow = new NumberOfGuessesWindow();
            Application.Run(LogInWindow);
            if (LogInWindow.DialogResult == DialogResult.OK)
            {
                m_NumberOfGuesses = LogInWindow.NumberOfgusses;
                inteatlizeGameWindow();
                playNextStep();
                m_GameWindow.ShowDialog();
            }
       }
       private void inteatlizeGameWindow()
        {
            m_GameWindow.CreateWindow(m_NumberOfGuesses);
            connectButtonsToAction();
        }
       private void connectButtonsToAction()
        {
             ColorsPickWindow PaletteWindow = m_LogicManger.ColorsToPickWindow;
            foreach (GameRow CurrentGameRow in m_GameWindow.GameRows)
            {
                List<Button> CurrentRowGuesses = CurrentGameRow.GuessesList;
                for (int i = 0; i < CurrentRowGuesses.Count; i++) {
                    CurrentRowGuesses[i].Click += PaletteWindow.GuessButton_Click;
                    CurrentRowGuesses[i].Click += enableCurrentAcceptButton;
                }
                CurrentGameRow.AccpetButton.Click += accpetButton_Click;
            }
        }
       private void accpetButton_Click(object sender, EventArgs e)
        {
            byte o_PerefctHits;
            byte o_AlmostHIts;
            m_LogicManger.CountHitsOfGuess(out o_PerefctHits, out o_AlmostHIts,currentGameRow.GuessesList);
            getFedbackResult(o_PerefctHits, o_AlmostHIts);
            m_LogicManger.CheckGameStatus(out m_GameOver, m_CurrentTurn, m_NumberOfGuesses);
            enableCurrentGuessRow(currentGameRow.GuessesList, false);
            (sender as Button).Enabled = false;
            if (!m_GameOver)
            {
                m_CurrentTurn++;
                m_LogicManger.ColorsToPickWindow.PickedColoreSet.Clear();
                playNextStep();
            }
            else
            {
                exposeCoumputerRandomColors();
            }
        }
       private void playNextStep()
        {
            GameRow CurrentRow = currentGameRow;
            enableCurrentGuessRow(CurrentRow.GuessesList, true);
        } 
       private void enableCurrentAcceptButton(object sender, EventArgs e)
        {
            currentGameRow.AccpetButton.Enabled =
            m_LogicManger.ColorsToPickWindow.PickedColoreSet.Count == 4;      
        }
       private void getFedbackResult(byte i_PerfectHits, byte i_AlmostHIts)
        {
            byte CurrentFedBackIndex = 0;
            while (i_PerfectHits != 0)
            {
                currentGameRow.FeedBackList[CurrentFedBackIndex].BackColor = Color.Black;
                i_PerfectHits--;
                CurrentFedBackIndex++;
            }
            while (i_AlmostHIts != 0)
            {
                currentGameRow.FeedBackList[CurrentFedBackIndex].BackColor = Color.Yellow;
                i_AlmostHIts--;
                CurrentFedBackIndex++;
            }
        }
       private void enableCurrentGuessRow(List<Button> i_GuessesList, bool i_EnableButton)
        {
            for (int i = 0; i< i_GuessesList.Count; i++)
            {
                i_GuessesList[i].Enabled = i_EnableButton;
            }
        }
       private void exposeCoumputerRandomColors()
        {
            for (int i = 0 ;i < m_GameWindow.HiddenWordList.Count; i++)
            {
                m_GameWindow.HiddenWordList[i].BackColor = m_LogicManger.RandomComputerColors[i];
            }
        }   
       private GameRow currentGameRow
        {
            get
            {
                return m_GameWindow.GameRows[m_CurrentTurn];
            }
        }   
    }
}
