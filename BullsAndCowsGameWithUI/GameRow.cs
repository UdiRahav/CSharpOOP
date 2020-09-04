using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B19_Ex02
{
    internal class GameRow
    {
        public const int k_WordLength = 4;
        internal const int k_YStartPostion = 10;
        internal const int k_XStartPostion = 10;
        internal const int k_XAccpetButtomPostion =
        k_XStartPostion + (k_GuessButtonSize + k_SpaceSize) * k_WordLength;
        internal const int k_GuessButtonSize = 40;
        internal const int k_SpaceSize = 5;
        internal const int k_ResultButtonSize = 18;
        internal const int k_SpaceFromHiddenToGuesses = 70;
        internal const int k_XResultPostion = k_XAccpetButtomPostion + k_GuessButtonSize + k_XStartPostion;

        private List<Button> m_RowGuessesList;
        private Button m_AccpetButton;
        private List<Button> m_FeedBackList;
        internal GameRow(int i_RowNumber)
        {
            intliazGuessRowButtons(i_RowNumber);
            intliazeAccpetButton();
            intliazeFeedBacSqaure();
        }
        internal void intliazGuessRowButtons(int i_RowNumber)
        {
            this.m_RowGuessesList = m_RowGuessesList = new List<Button>();
            for (int j = 0; j < k_WordLength; j++)
            {
               Button guessButton = new Button();
               guessButton.Name = " guessButton";
               guessButton.Enabled = false;
               guessButton.Size = new Size(k_GuessButtonSize, k_GuessButtonSize);
               guessButton.Location = new Point(k_XStartPostion +((k_GuessButtonSize + k_SpaceSize) * j),
               k_SpaceFromHiddenToGuesses + ((k_GuessButtonSize + k_SpaceSize) * i_RowNumber));
               m_RowGuessesList.Add(guessButton);
            }
        }
        internal void intliazeAccpetButton()
        {
            this.m_AccpetButton = new Button();
            m_AccpetButton.Name = "AccpetButton";
            m_AccpetButton.Text = "-->>";
            m_AccpetButton.Size = new Size(k_GuessButtonSize, k_GuessButtonSize / 2);
            m_AccpetButton.Location =
            new Point(k_XAccpetButtomPostion, m_RowGuessesList[0].Top + k_GuessButtonSize / 4);
            m_AccpetButton.Enabled = false;
        }
        internal void intliazeFeedBacSqaure()
        {
            m_FeedBackList = new List<Button>();
            for (int i = 0; i < 4; i++)
            {
                Button ResultButton = new Button();
                ResultButton.Enabled = false;
                ResultButton.Name = "ResultButton";
                ResultButton.Size = new Size(k_ResultButtonSize, k_ResultButtonSize);
                m_FeedBackList.Add(ResultButton);

            }
            //top Left 
            m_FeedBackList[0].Location =
                   new Point(k_XResultPostion, m_RowGuessesList[0].Top);
            //top Right 
            m_FeedBackList[1].Location =
                   new Point(k_XResultPostion + k_ResultButtonSize + k_SpaceSize, m_RowGuessesList[0].Top);
            //bootom left 
            m_FeedBackList[2].Location =
                   new Point(k_XResultPostion, m_FeedBackList[0].Location.Y + k_ResultButtonSize + k_SpaceSize);
            //botoon right
            m_FeedBackList[3].Location =
                   new Point(k_XResultPostion + k_ResultButtonSize + k_SpaceSize, m_FeedBackList[0].Location.Y + k_ResultButtonSize + k_SpaceSize);
        }
        internal List<Button> GuessesList
        {
            get
            {
                return m_RowGuessesList;
            }
        }
        internal Button AccpetButton
        {
            get
            {
                return m_AccpetButton;
            }
        }
        internal List<Button> FeedBackList
        {
            get
            {
                return m_FeedBackList;
            }
           
        }
    }
}
