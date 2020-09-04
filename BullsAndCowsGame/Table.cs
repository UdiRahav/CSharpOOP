
namespace B19_Ex02
{
    internal class Table
    {
        private int m_RightColumnWidth;
        private int m_LeftClumnWidth;
        private int m_tableWidth;
        internal string[,] m_ArrayOfGuessesAndFeedback;

        internal Table(int i_numberOfgeusses)
        {
            m_ArrayOfGuessesAndFeedback = new string[i_numberOfgeusses + 2 , 2];
        }
        public int TableWidth
        {
            get
            {
                return m_tableWidth;
            }
            set
            {
                m_tableWidth = value;
            }
        }
        public string PinheadLine
        {
            set
            {
                m_ArrayOfGuessesAndFeedback[0,0]= value.PadRight(m_LeftClumnWidth);
            }
        }
        public string ReusltHeadLine
        {
            set
            {
                m_ArrayOfGuessesAndFeedback[0, 1] = value.PadRight(m_RightColumnWidth);
            }
        }
        public int LeftClumnWidth
        {
            get
            {
                return m_LeftClumnWidth;
            }
            set
            {
                m_LeftClumnWidth = value;
            }
        }
        public int RightClumnWidth
        {
            get
            {
                return m_RightColumnWidth;
            }
            set
            {
                m_RightColumnWidth = value;
            }
        }
        public string HiddenWord
        {
            set
            {
                m_ArrayOfGuessesAndFeedback[1, 0] = value;
            }
        }
    }
}
