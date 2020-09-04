
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {

        private const float k_TruckMaxAirPressureRecommended = 26;
        private const float k_CarMaxAirPressureRecommended = 31;
        private const float k_MotorcycleMaxAirPressureRecommended = 33;

        private const float k_FuelTruckMaxAmountOfEnergy = 110;
        private const float k_FuelCarMaxAmountOfEnergy = 55;
        private const float k_ElectricCarcleMaxAmountOfEnergy = (float)1.8;
        private const float k_FuelMotorcycleMaxAmountOfEnergy = 8;
        private const float k_ElectricMotorcycleMaxAmountOfEnergy = (float)1.4;

        private const byte k_TruckNumberOfWheels = 12;
        private const byte k_CarNumberOfWheels = 4;
        private const byte k_MotorcycleNumberOfWheels = 2;

        private const eFuelType k_Solar = eFuelType.Soler;
        private const eFuelType k_Octan95 = eFuelType.Octan95;
        private const eFuelType k_Octan96 = eFuelType.Octan96;
        private const eFuelType k_Octan98 = eFuelType.Octan98;


        public static Vehicle CreateNewVehcile(Dictionary<string, object> i_ProprotiesDictionary)
        {

            Vehicle vehicleToCreate = null;
            switch ((eSupportedVehicles)i_ProprotiesDictionary[GarageManager.k_VechileType])
            {
                case eSupportedVehicles.Truck:
                    vehicleToCreate = CreateTruck(i_ProprotiesDictionary);
                    break;
                case eSupportedVehicles.FuelCar:
                    vehicleToCreate = CreateFuelCar(i_ProprotiesDictionary);

                    break;
                case eSupportedVehicles.ElectricCar:
                    vehicleToCreate = CreateElectricCar(i_ProprotiesDictionary);

                    break;
                case eSupportedVehicles.FuelMotocycle:
                    vehicleToCreate = CreateFuelMotocycle(i_ProprotiesDictionary);

                    break;
                case eSupportedVehicles.ElectricMotocycle:
                    vehicleToCreate = CreateElectricMotocycle(i_ProprotiesDictionary);
                    break;
            }
            return vehicleToCreate;

        }

        public static List<Wheels> CreateListWheels(string i_ManufacturerName, float i_MaxAirPressureRecommended, float i_CurrentAirPressure, byte i_NumberOfWheels)
        {
            List<Wheels> ListOfWheelsToReturn = new List<Wheels>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                Wheels wheel = new Wheels(i_ManufacturerName, i_MaxAirPressureRecommended, i_CurrentAirPressure);
                ListOfWheelsToReturn.Add(wheel);
            }
            return ListOfWheelsToReturn;
        }

        internal static Truck CreateTruck(Dictionary<string, object> i_ListOfProprties)
        {

            List<Wheels> ListOfWheels = CreateListWheels((string)i_ListOfProprties[GarageManager.k_ManufacturerName],
                k_TruckMaxAirPressureRecommended,
                (float)i_ListOfProprties[GarageManager.k_CurrentAirPressure],
                k_TruckNumberOfWheels);
            EnergyType VehicleCEnergy = new Fuel((float)i_ListOfProprties[GarageManager.k_CurrentAmountOfEnergy],
                k_FuelTruckMaxAmountOfEnergy, k_Solar);



            Truck truck = new Truck((string)i_ListOfProprties[GarageManager.k_ModelName],
                               (string)i_ListOfProprties[GarageManager.k_LicenseNumber],
                               ListOfWheels,
                              VehicleCEnergy,
                              (float)i_ListOfProprties[GarageManager.k_CarGoCapcity],
                              (bool)i_ListOfProprties[GarageManager.k_DangerousMaterials]);
            return truck;
        }
        internal static Car CreateFuelCar(Dictionary<string, object> i_ListOfProprties)
        {
            List<Wheels> ListOfWheels = CreateListWheels((string)i_ListOfProprties[GarageManager.k_ManufacturerName],
                 k_CarMaxAirPressureRecommended,
                 (float)i_ListOfProprties[GarageManager.k_CurrentAirPressure],
                 k_CarNumberOfWheels);

            EnergyType VehicleCEnergy = new Fuel((float)i_ListOfProprties[GarageManager.k_CurrentAmountOfEnergy],
            k_FuelCarMaxAmountOfEnergy,
            k_Octan96);

            Car FuelCar = new Car((string)i_ListOfProprties[GarageManager.k_ModelName],
           (string)i_ListOfProprties[GarageManager.k_LicenseNumber],
           ListOfWheels, VehicleCEnergy,
           (eNumberOfDoors)i_ListOfProprties[GarageManager.k_NumberOfDoors],
           (eCarColor)i_ListOfProprties[GarageManager.k_CarColor]);

            return FuelCar;

        }
        internal static Car CreateElectricCar(Dictionary<string, object> i_ListOfProprties)
        {
            List<Wheels> ListOfWheels = CreateListWheels((string)i_ListOfProprties[GarageManager.k_ManufacturerName],
              k_CarMaxAirPressureRecommended,
              (float)i_ListOfProprties[GarageManager.k_CurrentAirPressure],
              k_CarNumberOfWheels);

            EnergyType VehicleCEnergy = new Electric((float)i_ListOfProprties[GarageManager.k_CurrentAmountOfEnergy],
            k_ElectricCarcleMaxAmountOfEnergy);

            Car FuelCar = new Car((string)i_ListOfProprties[GarageManager.k_ModelName],
           (string)i_ListOfProprties[GarageManager.k_LicenseNumber],
           ListOfWheels, VehicleCEnergy,
           (eNumberOfDoors)i_ListOfProprties[GarageManager.k_NumberOfDoors],
           (eCarColor)i_ListOfProprties[GarageManager.k_CarColor]);

            return FuelCar;
        }
        internal static Motorcycle CreateFuelMotocycle(Dictionary<string, object> i_ListOfProprties)
        {
            List<Wheels> ListOfWheels = CreateListWheels((string)i_ListOfProprties[GarageManager.k_ManufacturerName],
              k_MotorcycleMaxAirPressureRecommended,
              (float)i_ListOfProprties[GarageManager.k_CurrentAirPressure],
              k_MotorcycleNumberOfWheels);

            EnergyType VehicleCEnergy = new Fuel((float)i_ListOfProprties[GarageManager.k_CurrentAmountOfEnergy],
            k_FuelMotorcycleMaxAmountOfEnergy, k_Octan95);

            Motorcycle FuelMotorcycle = new Motorcycle((string)i_ListOfProprties[GarageManager.k_ModelName],
           (string)i_ListOfProprties[GarageManager.k_LicenseNumber],
           ListOfWheels, VehicleCEnergy,
           (eLicenseType)i_ListOfProprties[GarageManager.k_MotorcycleLicensType],
           (int)i_ListOfProprties[GarageManager.k_EngineVolume]);

            return FuelMotorcycle;
        }
        internal static Motorcycle CreateElectricMotocycle(Dictionary<string, object> i_ListOfProprties)
        {
            List<Wheels> ListOfWheels = CreateListWheels((string)i_ListOfProprties[GarageManager.k_ManufacturerName],
            k_MotorcycleMaxAirPressureRecommended,
            (float)i_ListOfProprties[GarageManager.k_CurrentAirPressure],
            k_MotorcycleNumberOfWheels);

            EnergyType VehicleCEnergy = new Electric((float)i_ListOfProprties[GarageManager.k_CurrentAmountOfEnergy],
            k_ElectricMotorcycleMaxAmountOfEnergy);

            Motorcycle ElectricMotocycle = new Motorcycle((string)i_ListOfProprties[GarageManager.k_ModelName],
           (string)i_ListOfProprties[GarageManager.k_LicenseNumber],
           ListOfWheels, VehicleCEnergy,
           (eLicenseType)i_ListOfProprties[GarageManager.k_MotorcycleLicensType],
           (int)i_ListOfProprties[GarageManager.k_EngineVolume]);

            return ElectricMotocycle;
        }
    }
}
