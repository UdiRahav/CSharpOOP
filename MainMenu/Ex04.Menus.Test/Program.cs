
namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfaceMainMenu = InitializeMenu.CreateInterfaceMenu();
            interfaceMainMenu.Show();

            Delegates.MainMenu DelegateMainMenu = InitializeMenu.CreateDelegatesMenu();
            DelegateMainMenu.Show();
        }
    }
}


  