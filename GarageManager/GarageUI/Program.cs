using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageManager LogicManager = new GarageManager();
            GarageConsoleUI Mygarager = new GarageConsoleUI(LogicManager);
            Mygarager.RunGarageProgram();
        }
    }
}