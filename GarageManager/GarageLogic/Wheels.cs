using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
   public class Wheels
    {
       private readonly string r_ManufacturerName;
       private readonly float r_MaxAirPressureRecommended;
       private float m_CurrentAirPressure;

       public Wheels(string i_ManufacturerName, float i_MaxAirPressureRecommended, float i_CurrentAirPressure)
        {
            //TODO: CHECK THE CONSTERCTOUR
            this.r_ManufacturerName = i_ManufacturerName;
            this.r_MaxAirPressureRecommended = i_MaxAirPressureRecommended;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
        }
        internal void InflateAction(float i_AmountOfAirToAdd)
        {
            if (i_AmountOfAirToAdd + m_CurrentAirPressure < r_MaxAirPressureRecommended)
            {
                this.m_CurrentAirPressure = i_AmountOfAirToAdd + m_CurrentAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxAirPressureRecommended, 0);
            }
        }
        internal void InflateToMaxAirPressure()
        {
            if (m_CurrentAirPressure != r_MaxAirPressureRecommended)
            {
                this.m_CurrentAirPressure += r_MaxAirPressureRecommended - m_CurrentAirPressure;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressureRecommended;
            }
        }
        public override string ToString()
        {
            string vehicleInformation = string.Format(@"The manufacturer wheel's name is : {0}, and the current air pressure of wheels is: {1}"
           , r_ManufacturerName, m_CurrentAirPressure);

            return vehicleInformation;
        }
    }
}
