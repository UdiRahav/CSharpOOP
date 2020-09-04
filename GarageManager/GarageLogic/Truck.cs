using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {

        private readonly float  r_CarGoCapcity;
        private readonly bool r_ContainsDangerousMaterials;

        //WE will pass Fuel as i_EnergyType then the base constrctour will set the energy to fuel,
        public Truck(string i_m_ModelName, string i_LicenseNumber,
           List<Wheels> i_ListOfWheels, EnergyType i_EnergyType, 
            float i_CarGoCapcity, bool i_ContainsDangerousMaterials)
            : base (i_m_ModelName, i_LicenseNumber, i_ListOfWheels, i_EnergyType)
        {
          this.r_CarGoCapcity = i_CarGoCapcity;
          this.r_ContainsDangerousMaterials = i_ContainsDangerousMaterials;
        }
        public bool ContainsDangerousMaterials
        {
            get
            {
                return r_ContainsDangerousMaterials;
            }
                
        }
        public float CarGoCapcity
        {
            get
            {
                return r_CarGoCapcity;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0}
The cargo Capcity: {1}
The truck contains dangerous materials: {2}", base.ToString(), r_CarGoCapcity, r_ContainsDangerousMaterials);
        }
    }
}
