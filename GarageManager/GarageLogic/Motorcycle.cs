using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;

        internal Motorcycle(string i_m_ModelName, string i_LicenseNumber,
           List<Wheels> i_ListOfWheels, EnergyType i_EnergyType,
          eLicenseType i_LicenseType, int i_EngineVolume)
          
         : base(i_m_ModelName, i_LicenseNumber, i_ListOfWheels, i_EnergyType)
        {
            this.r_LicenseType = i_LicenseType;
            this.r_EngineVolume = i_EngineVolume;
        }
       
        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }
        public int EngineVolume
        {
            get
            {
                return r_EngineVolume;
            }
        }
        public override string ToString()
        {
            return string.Format(@"{0}
The license type is: {1}
The engine volume is: {2}", base.ToString(), r_LicenseType, r_EngineVolume);
        }
    }
}
