using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ClientTicket
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eCarStatus m_CarStatus;
        internal Vehicle m_vehicle;

   
        public ClientTicket(Vehicle i_vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            this.m_vehicle = i_vehicle;
            this.r_OwnerName = i_OwnerName;
            this.r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_CarStatus = eCarStatus.InRepair;
            
        }
        public eCarStatus CarStatus
        {
            get
            {
                return m_CarStatus;
            }
            set
            {
                m_CarStatus = value;
            }
        }
        public string VehicleLicenseNumber
        {
            get
            {
                return m_vehicle.LicenseNumber;
            }
        }
        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }
        public string OwnerPhoneNumber
        {
            get
            {
                return r_OwnerPhoneNumber;
            }
        }
        public override string ToString()
        {
            return string.Format(@"{1}{0}The owner name is: {2}{0}The status of the car in the garage is: {3}{0}{4}{0}{5}"
              , Environment.NewLine
              , m_vehicle.ToString()
              , r_OwnerName
              , CarStatus.ToString()
              , m_vehicle.Wheels[0].ToString()
              , m_vehicle.EnergySource.ToString()
               );
        }
    }
}
