using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergyType
    {
        public float m_CurrentAmountOfEnergy;
        public readonly float r_MaxAmountOfEnergy;
        public EnergyType(float i_CurrentAmountOfEnergy, float i_MaxAmountOfEnergy)
        {
            this.m_CurrentAmountOfEnergy = i_CurrentAmountOfEnergy;
            this.r_MaxAmountOfEnergy = i_MaxAmountOfEnergy;
        }

        //the method receives amount of energy to fill back and fill the energy
        internal protected void fillEnergy(float i_AmoutToFill)
        {
            if (i_AmoutToFill + m_CurrentAmountOfEnergy > r_MaxAmountOfEnergy | i_AmoutToFill < 0)
            {
                throw new ValueOutOfRangeException(r_MaxAmountOfEnergy, 0);
            }
            else
            {
                m_CurrentAmountOfEnergy = m_CurrentAmountOfEnergy + i_AmoutToFill;
            }
        }
        public override string ToString()
        {
            return string.Format(@"The current is: {0}, and the max amount is: {1}"
, m_CurrentAmountOfEnergy,r_MaxAmountOfEnergy);
        }
    }
}
