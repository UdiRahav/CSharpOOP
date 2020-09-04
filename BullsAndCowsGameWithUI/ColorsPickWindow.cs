using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B19_Ex02
{
    internal partial class ColorsPickWindow : Form
    {
        private Button m_Button;
        private HashSet<Color> m_PickedColores;
        public ColorsPickWindow()
        {
            InitializeComponent();
            m_PickedColores = new HashSet<Color>();
        }
        internal ColorsPickWindow(Button i_Button)
        {
            InitializeComponent();
            this.m_Button = i_Button;
        }
        internal void GuessButton_Click(object sender, EventArgs e)
        {
            m_Button = (sender as Button);
            this.ShowDialog();
        }
        internal void ColorButtonPick_Click(object sender, EventArgs e)
        {
            // If the button is Colored already
            if (m_Button.BackColor != default(Color))
            {
                m_PickedColores.Remove(m_Button.BackColor);
            }

            if (!m_PickedColores.Contains((sender as Button).BackColor))
            {
            m_Button.BackColor = (sender as Button).BackColor;
            m_PickedColores.Add((sender as Button).BackColor);
            this.Close();
            }
        }
        internal List<Color> ColorsToPick()
        {
            List<Color> ColorPalette = new List<Color>();
            foreach (Button button in this.Controls)
            {
                ColorPalette.Add(button.BackColor);
            }
            return ColorPalette;
        }
        internal HashSet<Color> PickedColoreSet
        {
            get
            {
                return m_PickedColores;
            }
        }
    }
}
