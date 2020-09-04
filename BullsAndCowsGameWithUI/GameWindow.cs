
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B19_Ex02
{
    public partial class GameWindow : Form
    {
        private List<GameRow> m_BordRowList = new List<GameRow>();
        private List<Button> m_HiddenWordList = new List<Button>();
        public GameWindow()
        {
            InitializeComponent();
        }
        internal void CreateWindow(int i_NumberOfRows)
        {
            addHiddenWord();
            addGameRows(i_NumberOfRows);
        }
        private void addHiddenWord()
        {
            for (int i = 0; i < GameRow.k_WordLength; i++)
            {
                Button hiddenButton = new Button();
                hiddenButton.Enabled = false;
                hiddenButton.Location = new Point(GameRow.k_XStartPostion +
                    ((GameRow.k_GuessButtonSize + GameRow.k_SpaceSize) * i), GameRow.k_YStartPostion);
                hiddenButton.Size = new Size(GameRow.k_GuessButtonSize, GameRow.k_GuessButtonSize);
                hiddenButton.BackColor = Color.Black;
                hiddenButton.UseVisualStyleBackColor = false;
                m_HiddenWordList.Add(hiddenButton);
                this.Controls.Add(hiddenButton);
            }
        }
        private void addGameRows(int i_NumberOfRows)
        {
            for (int i = 0; i < i_NumberOfRows; i++)
            {
                GameRow Row = new GameRow(i);
                addGuessesButtonLine(Row);
                addFedBackToSqaureToWindow(Row.FeedBackList);
                this.Controls.Add(Row.AccpetButton);
                m_BordRowList.Add(Row);
            }
        }
        private void addFedBackToSqaureToWindow(List<Button> m_FeedBackList)
        {
            for (int i = 0; i < GameRow.k_WordLength; i++)
            {
                this.Controls.Add(m_FeedBackList[i]);
            }
        }
        private void addGuessesButtonLine(GameRow i_Row)
        {
            for (int i = 0; i < GameRow.k_WordLength; i++)
            {
                this.Controls.Add(i_Row.GuessesList[i]);
            }
        }
        internal List<GameRow> GameRows
        {
            get
            {
                return this.m_BordRowList;
            }
        }
        internal List<Button> HiddenWordList
        {
            get
            {
                return m_HiddenWordList;
            }
        }
    }
}
