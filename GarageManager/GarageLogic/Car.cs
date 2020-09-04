
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eCarColor r_CarColor;
        private readonly eNumberOfDoors r_NumberOfDoors;

        internal Car(string i_m_ModelName, string i_LicenseNumber,
            List<Wheels> i_ListOfWheels,  EnergyType i_EnergyType,
            eNumberOfDoors i_NumberOfDoors, eCarColor i_CarColor)
            : base(i_m_ModelName, i_LicenseNumber, i_ListOfWheels, i_EnergyType )
        {
            this.r_CarColor = i_CarColor;
            this.r_NumberOfDoors = i_NumberOfDoors;
        }
        
        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }
        public eCarColor CarColor
        {
            get
            {
                return r_CarColor;
            }
        }

        public override string ToString()
        {
            return  string.Format(@"{0}
The color of the car is: {1}
Nnumber of doors at the car is: s{2}",base.ToString(), r_CarColor, r_NumberOfDoors);
        }
    }

}
