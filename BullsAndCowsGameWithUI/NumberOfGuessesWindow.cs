using System;
using System.Windows.Forms;

namespace B19_Ex02
{
    public partial class NumberOfGuessesWindow : Form
    {
       private  int m_NumberOfgusses = 4;
        public NumberOfGuessesWindow()
        {
            InitializeComponent();
        }
        private void ChacesButten_Click(object sender, EventArgs e)
        {
            string LastDigit = m_NumberOfgusses.ToString();
            if (m_NumberOfgusses == 10)
            {
                m_NumberOfgusses = 3;
            }
            ChacesButten.Text = ChacesButten.Text.Replace(LastDigit, (++ m_NumberOfgusses).ToString());
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        internal int NumberOfgusses
        {
            get
            {
                return m_NumberOfgusses;
            }
        }       
    }
}
