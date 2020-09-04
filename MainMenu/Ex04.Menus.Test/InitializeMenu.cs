namespace Ex04.Menus.Test
{
    internal class InitializeMenu
    {
        private static readonly MenuActionsClass sr_MenuMethods = new MenuActionsClass();
        public static Interfaces.MainMenu CreateInterfaceMenu()
        {
            Interfaces.MainMenu InterfacesmainMenu = new Interfaces.MainMenu();
            Interfaces.MenuItem subMenu1 = new Interfaces.MenuItem("Show Date/Time");
            Interfaces.MenuItem subMenu2 = new Interfaces.MenuItem("Version and Digits");

            InterfacesmainMenu.AddSubItem(subMenu1);
            InterfacesmainMenu.AddSubItem(subMenu2);

            Interfaces.ActionItem showTimeMethod =  new Interfaces.ActionItem("Show Time", sr_MenuMethods.ShowTime);
            Interfaces.ActionItem showDateMethod = new Interfaces.ActionItem("Show Date", sr_MenuMethods.ShowDate);
            Interfaces.ActionItem countDigitsMethod = new Interfaces.ActionItem("Count Digits", sr_MenuMethods.CountDigits);
            Interfaces.ActionItem ShowVersionMethod = new Interfaces.ActionItem("Show Version", sr_MenuMethods.ShowVersion);

            subMenu1.AddSubItem(showTimeMethod);
            subMenu1.AddSubItem(showDateMethod);
            subMenu2.AddSubItem(countDigitsMethod);
            subMenu2.AddSubItem(ShowVersionMethod);

            return InterfacesmainMenu;
        }
        public static Delegates.MainMenu CreateDelegatesMenu()
        {
            Delegates.MainMenu DelegatesmainMenu = new Delegates.MainMenu();
            Delegates.MenuItem subMenu1 = new Delegates.MenuItem("Show Date/Time");
            Delegates.MenuItem subMenu2 = new Delegates.MenuItem("Version and Digits");

            Delegates.ActionItem showTimeMethod = new Delegates.ActionItem("Show Time");
            Delegates.ActionItem showDateMethod = new Delegates.ActionItem("Show Date");
            Delegates.ActionItem countDigitsMethod = new Delegates.ActionItem("Count Digits");
            Delegates.ActionItem ShowVersionMethod = new Delegates.ActionItem("Show Version" );

            DelegatesmainMenu.AddSubItem(subMenu1);
            DelegatesmainMenu.AddSubItem(subMenu2);
       
            showTimeMethod.m_ActionItemEvent += sr_MenuMethods.ShowTime.ShowTime_Method;
            subMenu1.AddSubItem(showTimeMethod);
            showDateMethod.m_ActionItemEvent += sr_MenuMethods.ShowDate.ShowDate_Method;
            subMenu1.AddSubItem(showDateMethod);
            countDigitsMethod.m_ActionItemEvent += sr_MenuMethods.CountDigits.CountDigits_Method;
            subMenu2.AddSubItem(countDigitsMethod);
            ShowVersionMethod.m_ActionItemEvent += sr_MenuMethods.ShowVersion.ShowVersion_Method;
            subMenu2.AddSubItem(ShowVersionMethod);

            return DelegatesmainMenu;
        }

    }
}
