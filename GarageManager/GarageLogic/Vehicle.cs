using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ex03.GarageLogic
{

    public abstract class Vehicle
    {

        //data for healine
        // changed  EnergyType to IEnergyType

        private EnergyType m_EnergyTpye;
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_EnergyPercentageLeft;
        private List<Wheels> r_Wheels;

        public Vehicle(string i_ModelName, string i_LicenseNumber, List<Wheels> i_ListOfWheels, EnergyType i_EnergyType)
        {
            this.m_EnergyTpye = i_EnergyType;
            this.r_LicenseNumber = i_LicenseNumber;
            this.r_ModelName = i_ModelName;
            this.r_Wheels = i_ListOfWheels;
            this.m_EnergyPercentageLeft =
           CalculateEnergyPercentageLeft(m_EnergyTpye.m_CurrentAmountOfEnergy, m_EnergyTpye.r_MaxAmountOfEnergy);
        }

        private float CalculateEnergyPercentageLeft(float i_CurrentAmountOfEnergy, float i_MaxAmountOfEnergy)
        {  
            return (i_CurrentAmountOfEnergy / i_MaxAmountOfEnergy) * 100;
        }
        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        } //Only get
        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        } //Only get
        public float EnergyPercentageLeft
        {
            get
            {
                return m_EnergyPercentageLeft;
            }
        }
        public List<Wheels> Wheels
        {
            get
            {
                return this.r_Wheels;
            }
        }
        public EnergyType EnergySource
        {
            get
            {
                return this.m_EnergyTpye;
            }
        }
        public override string ToString()
        {
            return string.Format(@"The license number is: {1} {0}The model name is: {2}",Environment.NewLine, r_LicenseNumber, r_ModelName);
        }
    }
}

