using System;


namespace Ex03.GarageLogic
{
    internal class Fuel : EnergyType
    {
        private readonly eFuelType m_eFuelType;
        public Fuel(float i_CurrentAmountOfEnergy, float i_MaxAmountOfEnergy, eFuelType i_FuelType)
          : base(i_CurrentAmountOfEnergy, i_MaxAmountOfEnergy)
        {
            this.m_eFuelType = i_FuelType;
        }

        
        public eFuelType FuelType
        {
            get
            {
                return m_eFuelType;
            }
        }

        public void fillFuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if (i_AmountOfFuelToAdd + m_CurrentAmountOfEnergy > r_MaxAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(0, r_MaxAmountOfEnergy);
            }
            else if (i_FuelType == m_eFuelType)
            {
                    fillEnergy(i_AmountOfFuelToAdd);
            }
            else
            {
                throw new ArgumentException();
            }
        }



        public override string ToString()
        {
            return string.Format(@"Fuel current amount of is :{0} , and max amount of fuel is : {1} "
, m_CurrentAmountOfEnergy, r_MaxAmountOfEnergy);
        }
    }
}
