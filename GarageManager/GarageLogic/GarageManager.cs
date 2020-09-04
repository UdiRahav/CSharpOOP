using System;
using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        internal Dictionary<string, ClientTicket> m_VehiclesDictionary = new Dictionary<string, ClientTicket>();
        
        public const string k_OwnerName = "Owner name";
        public const string k_OwnerPhoneNumber = "Owner phone number";
        public const string k_LicenseNumber = "License number";
        public const string k_VechileType = "Vechile type";
        public const string k_ModelName = "Model name";
        public const string k_ManufacturerName = "Manufacturer name";
        public const string k_CurrentAirPressure = "Current air pressure";
        public const string k_CurrentAmountOfEnergy = "Current amount of energy";
        public const string k_CarGoCapcity = "Cargo capcity";
        public const string k_DangerousMaterials = "Dangerous materials";
        public const string k_NumberOfDoors = "Number of doors";
        public const string k_CarColor = "Car color";
        public const string k_EngineVolume = "Engine volume";
        public const string k_MotorcycleLicensType = "Motorcycle licens type";
        
        public void AddCarToGarage(string i_LicenseNumber, Dictionary<string, object> i_VehicleProperties)
        {
            if (m_VehiclesDictionary.ContainsKey(i_LicenseNumber))
            {
                m_VehiclesDictionary[i_LicenseNumber].CarStatus = eCarStatus.InRepair;
            }
            else
            {
                //calls creator, and bond the new vehicle with i_LicenseNumber
                Vehicle VehicleToAdd = VehicleCreator.CreateNewVehcile(i_VehicleProperties);

                m_VehiclesDictionary[i_LicenseNumber] = new ClientTicket(VehicleToAdd,
                                                        (string)i_VehicleProperties[k_OwnerName],
                                                        (string)i_VehicleProperties[k_OwnerPhoneNumber]);
            }
        }
        //this function showes how is in the garage with a status
        public string ShowCarsInGarageBystatus(eCarStatus i_StatusToShow)
        {
            StringBuilder CarsInGarage = new StringBuilder();
            CarsInGarage.Append("The cars in the garage By status");
            CarsInGarage.Append(Environment.NewLine);
            foreach (ClientTicket iterator in m_VehiclesDictionary.Values)
            {
                if (iterator.CarStatus == i_StatusToShow)
                {
                    CarsInGarage.Append(iterator.VehicleLicenseNumber);
                    CarsInGarage.Append(Environment.NewLine);
                }
            }
            return CarsInGarage.ToString();
        }
        //this function showes how is in the garage.
        public string ShowCarsInGarage()
        {
            StringBuilder CarsInGarage = new StringBuilder();
            CarsInGarage.Append("The cars in the garage");
            CarsInGarage.Append(Environment.NewLine);
            foreach (ClientTicket iterator in m_VehiclesDictionary.Values)
            {
                CarsInGarage.Append(iterator.VehicleLicenseNumber);
                CarsInGarage.Append(Environment.NewLine);
            }
            return CarsInGarage.ToString();

        }
        public void ChangeVehicleStatus(string i_LicenseNumber, eCarStatus i_NewCarStatus)
        {
                m_VehiclesDictionary[i_LicenseNumber].CarStatus = i_NewCarStatus;    
        }
        public void inflateWheels(string i_LicenseNumber)
        {
            List<Wheels> wheelsToinflat = m_VehiclesDictionary[i_LicenseNumber].m_vehicle.Wheels;
            foreach (Wheels wheel in wheelsToinflat)
            {
                wheel.InflateToMaxAirPressure();
            }
        }
        public void Addfuel(string i_LicenseNumber, eFuelType i_fuelType, float i_AmountOfFuel)
        {
            if (m_VehiclesDictionary[i_LicenseNumber].m_vehicle.EnergySource is Fuel) {
                Fuel fuelVehicle = (Fuel)m_VehiclesDictionary[i_LicenseNumber].m_vehicle.EnergySource;
                fuelVehicle.fillFuel(i_AmountOfFuel, i_fuelType);
            }
            else
            {
                throw new FormatException();
            }
        }
        public void ChargeVehicle(string i_LicenseNumber, float i_AmountOfElectricity)
        {
            if (m_VehiclesDictionary[i_LicenseNumber].m_vehicle.EnergySource is Electric)
            {
                Electric ElectricitVehicle = (Electric)m_VehiclesDictionary[i_LicenseNumber].m_vehicle.EnergySource;
                ElectricitVehicle.fillEnergy(i_AmountOfElectricity / 60);
            }
            else
            {
                throw new FormatException();
            }
        }
        public string ShowVehicleDetails(string i_LicenseNumber)
        {
            return m_VehiclesDictionary[i_LicenseNumber].ToString();
        }
        public void IsInGarage(string i_LicenseNumber)
        {
            if (!m_VehiclesDictionary.ContainsKey(i_LicenseNumber))
            {
                throw new FormatException();
            }
        }
        
    }
}
