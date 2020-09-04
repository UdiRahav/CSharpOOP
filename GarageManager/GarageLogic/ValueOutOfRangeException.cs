using System;


namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        readonly float r_MaxValue;
        readonly float r_MinValue;
        
        public ValueOutOfRangeException ( float i_MinValue , float i_MaxValue):
            base(string.Format("input exceeds the allowed range, The range is <{0} - {1}>",i_MinValue, i_MaxValue))
        {
            this.r_MaxValue = i_MaxValue;
            this.r_MinValue = i_MinValue;
        }
        internal float MinValue
        {
            get { return r_MinValue; }
        }

        internal float MaxValue
        {
            get { return r_MaxValue; }
        }
    }
}
