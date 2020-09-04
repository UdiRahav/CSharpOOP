using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class GarageConsoleUI
    {

        GarageManager m_LogicManager;
        Dictionary<string, object> m_VehiclesDictionary = new Dictionary<string, object>();
        public GarageConsoleUI(GarageManager i_LogicManager)
        {
            this.m_LogicManager = i_LogicManager;
        }
        public void RunGarageProgram()
        {
            bool stillOn = true;
            while (stillOn)
            {
                Console.Clear();
                string mainMenuOptionSelected = openMainMenu(); //print the manue of the program.
                switch (mainMenuOptionSelected)
                {
                    case "1":
                        // “Insert” a new vehicle into the garage.
                        insertNewVehicleTGarage();
                        break;
                    case "2":
                       // Display a list of license numbers currently in the garage
                        openListOfLicenseByStatus();
                        break;
                    case "3":
                        // Change a certain vehicle’s status
                        changeVehicleStatus();
                        break;
                    case "4":
                        // Inflate tires to maximum
                        inflateTiresToMaximum();
                        break;
                    case "5":
                        //Refuel a fuel-based vehicle
                        refuelfuelVehicle();
                        break;
                    case "6":
                        // Charge an electric-based vehicle
                        chargeElectricVehicle();
                        break;
                    case "7":
                        //TODO: Display vehicle information
                      displayVehiclesInformation();
                        break;
                    case "8":
                        //Exit
                        stillOn = false;
                        Console.WriteLine("Thank you!");
                        break;
                }
            }
        }
        private void displayVehiclesInformation()
        {
            Console.WriteLine("Hello, please enter vehicle's License number To check details:");
            string vehicleLicense = getNotEmptyInput();
            try
            {
                m_LogicManager.IsInGarage(vehicleLicense);
               Console.WriteLine(@"{0} 
press enter for main menu",m_LogicManager.ShowVehicleDetails(vehicleLicense));
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("This vehicle License number not exsit in our garage, press enter for main menu");
                Console.ReadLine();
            }
        }
        private void chargeElectricVehicle()
        {
            Console.WriteLine("Hello, please enter vehicle's License number in order to charge:");
            string vehicleLicense = getNotEmptyInput();
            bool carIsInGarage = true;
            try
            {
               m_LogicManager.IsInGarage(vehicleLicense);
                carIsInGarage = true;
            }
            catch(FormatException)
            {
                Console.WriteLine("This vehicle License number not exsit in our garage, press enter for main menu");
                Console.ReadLine();
                carIsInGarage = false;;

            }

            while (true & carIsInGarage)
            {
                Console.WriteLine("How many minutes would you like to charge your vehicle?");
                float numberOfMinutes = getFloatInput();
                try
                {
                    m_LogicManager.ChargeVehicle(vehicleLicense, numberOfMinutes);
                    Console.WriteLine("It was done now {0} charged with the amount you asked: {1}", vehicleLicense, numberOfMinutes);
                    Console.ReadLine();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You trying to charge a fuel engiane, please go to refuel option at the main menu (option number 5)");
                    Console.ReadLine();
                    break;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(@"want to try again?
(1) Yes
(2) No");
                    string userInput = getNumberInRange(1, 2, true);
                    if (userInput.Equals("2"))
                    {
                        break;
                    }
                }
            }
        }
        private void refuelfuelVehicle()
        {
            Console.WriteLine("Hello, please enter vehicle's License number in order to refuel:");
            string vehicleLicense = getNotEmptyInput();
            bool carIsInGarage = true;
            try
            {
                m_LogicManager.IsInGarage(vehicleLicense);
            }
            catch(FormatException)
            {
                Console.WriteLine("This vehicle License number not exsit in our garage, press enter for main menu");
                Console.ReadLine();
                carIsInGarage = false;
            }
            while (true & carIsInGarage)
                {
                    Console.WriteLine(@"choose you'r vehicles fuel type:
(1) Soler
(2) Octan95
(3) Octan96
(4) Octan98");
                eFuelType fuelType = (eFuelType)int.Parse(getNumberInRange(1, 4, true));
                    Console.WriteLine("What is the amount of fuel you waht to add?");
                    float amountOfFuel = getFloatInput();
                    try
                    {
                    m_LogicManager.Addfuel(vehicleLicense, fuelType, amountOfFuel);
                    Console.WriteLine("It was done now {0} fueled with the amount you asked: {1}", vehicleLicense, amountOfFuel);
                    Console.ReadLine();
                    break;
                    }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("You trying to refuel a elctric engiane, please go to charge option at the main menu (option number 6)");
                    Console.ReadLine();
                    break;
                }
                catch (ArgumentException)
                    {
                        Console.WriteLine(@"Your vehicle is not suppoting this type of fuel
want to try again?
(1) Yes
(2) No");
                        string userInput = getNumberInRange(1, 2, true);
                        if (userInput.Equals("2"))
                        {
                        Console.WriteLine("Thank you !");
                        Console.ReadLine();
                        break;
                        }
                    }
               }   
        }
        private void inflateTiresToMaximum()
        {
            Console.WriteLine("Hello, please enter vehicle's license number in order to inflate Tires:");
            string vehicleLicense = getNotEmptyInput();
            try
            {
                m_LogicManager.IsInGarage(vehicleLicense);
                m_LogicManager.inflateWheels(vehicleLicense);
                Console.WriteLine("Your tires now has the max air pressure that recommended by the manufacturerName.");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("This vehicle License number not exsit in our garage, press enter for main menu");
                Console.ReadLine();
            }
           
          
        }
        private void changeVehicleStatus()
        {
            Console.WriteLine("Hello, please enter vehicle's License number in order to change the status:");
            string VehicleLicense = getNotEmptyInput();
            try
            {
                m_LogicManager.IsInGarage(VehicleLicense);
                Console.WriteLine(@"What this vehicle's new status?
(1) In Repair
(2) Repaired
(3) Payed");
                eCarStatus NewCarStatus = (eCarStatus)int.Parse(getNumberInRange(1, 3, true));
                m_LogicManager.ChangeVehicleStatus(VehicleLicense, NewCarStatus);
                Console.WriteLine("status of {0} changed to {1} status!", VehicleLicense, NewCarStatus);
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("This vehicle License number not exsit in our garage, press enter for main menu");
                Console.ReadLine();
            
            }
           
        }
        private void openListOfLicenseByStatus()
        {
            Console.WriteLine(@"Wich vehicals to display?
(1) In Repair
(2) Repaired
(3) Payed
(4) All");
            eCarStatus DisplaySelection = (eCarStatus)int.Parse(getNumberInRange(1, 4, true));
            if (DisplaySelection == eCarStatus.All)
            {
                Console.WriteLine(m_LogicManager.ShowCarsInGarage());

            }
            else
            {
                Console.WriteLine(m_LogicManager.ShowCarsInGarageBystatus(DisplaySelection));
            }
            Console.WriteLine("Thank you! press enetr to return main menu ");
            Console.ReadLine();
        }
        private void insertNewVehicleTGarage()
        {
            Console.WriteLine("Please eneter your car license number: ");
            string licenseNumber = getNotEmptyInput();
            m_VehiclesDictionary["License number"] = licenseNumber;
            try
            {
              m_LogicManager.IsInGarage(licenseNumber);
               Console.WriteLine("Your car is already in the garage,the satus of the car changed to in in repair ");
            }
            catch
            {    
             //   m_VehiclesDictionary["License number"] = licenseNumber;

                Console.WriteLine("Enter your name: ");
                //TODO: Onnly Letters, and noe empty string.
                string ownerName = getNotEmptyInput();
                m_VehiclesDictionary["Owner name"] = ownerName;

                Console.WriteLine("Enter your phone number: ");
                string ownerPhone = getIntInput().ToString();
                m_VehiclesDictionary["Owner phone number"] = ownerPhone;

                eSupportedVehicles typeOfVehicle = getTypeOfVehicle();
                m_VehiclesDictionary["Vechile type"] = typeOfVehicle;

                Console.WriteLine("Enter your vechile model name: ");
                //TODO:no empty string.
                string ModelName = getNotEmptyInput();
                m_VehiclesDictionary["Model name"] = ModelName;

                Console.WriteLine("Enter your wheels manufacturer name: ");
                //TODO:no empty string.
                string manufacturerName = getNotEmptyInput();
                m_VehiclesDictionary["Manufacturer name"] = manufacturerName;

                getSpacificDataForVehicle(typeOfVehicle);
            }
            finally
            {
                m_LogicManager.AddCarToGarage((string)m_VehiclesDictionary["License number"], m_VehiclesDictionary);
                Console.WriteLine("Thank you! press enetr to return main menu ");
                Console.ReadLine();
            }
        }
        private String openMainMenu()
        {
           Console.WriteLine(@"Hello ! welcome to Udi&David garage program,
please select your action:
(1) Insert a new vehicle into the garage.
(2) Display a list of license numbers currently in the garage
(3) Change a certain vehicle’s status
(4) Inflate tires to maximum
(5) Refuel a fuel-based vehicle
(6) Charge an electric-based vehicle
(7) Display vehicle information
(8) Exit");
            string OptionSelected = getNumberInRange(1, 8, true);
            return OptionSelected;

        }
        private void insertNewCar()
        {
            Console.WriteLine(@"Please Entar Number of doors :
(1) Two door
(2) three doors
(3) four doors
(4) five doors");

           string numberOfDoors = getNumberInRange(1, 4, true);
           m_VehiclesDictionary["Number of doors"] = (eNumberOfDoors)int.Parse(numberOfDoors);
            Console.WriteLine(@"Please Entar Car Color: 
(1) Red
(2) Blue
(3) Black
(4) Gray");
            //TODO:: vconvert String to enum!!!
            string colorOfTheCar = getNumberInRange(1, 4, true);
            m_VehiclesDictionary["Car color"] = (eCarColor)int.Parse(colorOfTheCar);
        }
        private void inserNewMotocycle()
        {
            Console.WriteLine(@"Enter Motorcycle Licens Type : 
(1) A
(2) A1
(3) B
(4) B2");
            //TODO:: check how to convert string to bool and check vaildtion
            string MotorcycleLicensType = getNumberInRange(1, 4, true);
            m_VehiclesDictionary["Motorcycle licens type"] = (eLicenseType)int.Parse(MotorcycleLicensType);

            Console.WriteLine("Enter your engine volume: ");
            //TODO:: check how to convert string to int !!
            int EngineVolume = getIntInput();
            m_VehiclesDictionary["Engine volume"] = EngineVolume;
        }
        private void insertNewTruck()
        {
            Console.WriteLine("Enter your CarGo Capcity : ");
            float CarGoCapcity = getFloatInput();
            m_VehiclesDictionary["Cargo capcity"] = CarGoCapcity;

            Console.WriteLine(@"Your truck carrying dangerous materials :
(1) Yes
(2) No");
            string userInput = getNumberInRange(1, 2, true);
            bool DangerousMaterials = userInput.Equals("1");
            m_VehiclesDictionary["Dangerous materials"] = DangerousMaterials;
        }
        private void getSpacificDataForVehicle(eSupportedVehicles i_VehicleType)
        {
          Console.WriteLine("Enter your current air pressure of wheels: ");
            string  AirPressurAnswer = null;
            string  EnergyAnswer = null;
            switch (i_VehicleType)
                {
                    case eSupportedVehicles.Truck :
                    AirPressurAnswer = getNumberInRange(0, 26, false);
                    Console.WriteLine("Enter your current amount of Solar: ");
                    EnergyAnswer = getNumberInRange(0, 110, false);
                    insertNewTruck();
                    break;

                    case eSupportedVehicles.FuelCar: 
                    case eSupportedVehicles.ElectricCar:
                    AirPressurAnswer = getNumberInRange(0, 31, false);
                    if (i_VehicleType == eSupportedVehicles.FuelCar)
                    {
                        Console.WriteLine("Enter your current amount of Octean96: ");
                        EnergyAnswer = getNumberInRange(0, 55, false);
                        
                    }
                    else
                    {
                        Console.WriteLine("Enter your current amount of battery life: ");
                        EnergyAnswer = getNumberInRange(0, (float)1.8, false);                
                    }
                    insertNewCar();
                    break;
                    case eSupportedVehicles.FuelMotocycle:
                    case eSupportedVehicles.ElectricMotocycle:
                    AirPressurAnswer = getNumberInRange(0, 33, false);
                    if (i_VehicleType == eSupportedVehicles.FuelMotocycle)
                    {
                        Console.WriteLine("Enter your current amout of Octean95: ");
                        EnergyAnswer = getNumberInRange(0, 8, false);
                        
                    }
                    else
                    {
                        Console.WriteLine("Enter your current amount of battery life:");
                        EnergyAnswer = getNumberInRange(0, (float)1.4, false);
                    }
                    inserNewMotocycle();
                    break;
                }
            m_VehiclesDictionary["Current air pressure"] = float.Parse(AirPressurAnswer);
            m_VehiclesDictionary["Current amount of energy"] = float.Parse(EnergyAnswer);
        }
        private string getNumberInRange(float i_minValueOption, float i_maxValueOption, bool i_SelectionForMenu)
        {
            bool SelctedLigealOption = false;
            float manuOption;
            string OptionSelect = null;

            while (!SelctedLigealOption)
            {
                OptionSelect = Console.ReadLine();
                try
                {
                    manuOption = float.Parse(OptionSelect);
                    if (manuOption >= i_minValueOption & manuOption <= i_maxValueOption)
                    {
                        if (i_SelectionForMenu)
                        {
                            SelctedLigealOption = Math.Round(manuOption) == manuOption;
                            if (!SelctedLigealOption)
                            {
                                Console.WriteLine($"{OptionSelect}is Illegal! Please selecet a number in range: <{i_minValueOption} - {i_maxValueOption}>");
                            }
                        }
                        else
                        {
                            SelctedLigealOption = true;
                        }
                    }
                    else
                    {
                        throw new GarageLogic.ValueOutOfRangeException(i_minValueOption, i_maxValueOption);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"{OptionSelect}is Illegal! Please choose a valid number in range: <{i_minValueOption} - {i_maxValueOption}>");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return OptionSelect;

        }
        private eSupportedVehicles getTypeOfVehicle()
        {
            string msg = string.Format(@"please enter your vehicles type
(1) Truck
(2) Fuel Car
(3) Electric Car
(4) Fuel Motocycle
(5) Electric Motocycle");
            Console.WriteLine(msg);
            string licenseNumber = getNumberInRange(1, 5, true);
            return (eSupportedVehicles)int.Parse(licenseNumber);
        }
        private int getIntInput()
        {
            string userInput = null;
            while (true)
            {
                userInput = Console.ReadLine();
                try
                {
                    int.Parse(userInput);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Worng format please enter a number");
                }
            }
            return int.Parse(userInput);
        }
        private string getNotEmptyInput()
        {
            string userInput = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Illegeal input, please try again");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        private float getFloatInput()
        {
            string userInput = null;
            while (true)
            {
                userInput = Console.ReadLine();
                try
                {
                    float.Parse(userInput);
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Worng Format please enter number");
                }
            }
            return float.Parse(userInput); 
        }
    }
}