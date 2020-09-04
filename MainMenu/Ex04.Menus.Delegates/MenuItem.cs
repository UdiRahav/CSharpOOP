using System;
using System.Collections.Generic;
namespace Ex04.Menus.Delegates {
    public class MenuItem : AbstrectItem
    {
        private readonly List<AbstrectItem> m_SubMenuItems;
        protected  MenuItem m_ParentMenuItem;
        public MenuItem(string i_MenuItemName) : base(i_MenuItemName)
        {
            m_SubMenuItems = new List<AbstrectItem>();
            m_SubMenuItems.Add(new BackItem());
        }
        public MenuItem(string i_MenuItemName, AbstrectItem i_AbstrectItemClass) : base(i_MenuItemName)
        {
            m_SubMenuItems = new List<AbstrectItem>();
            m_SubMenuItems.Add(i_AbstrectItemClass);
        }
        private class BackItem : AbstrectItem
        {
            public BackItem() : base("Back")
            {
            }
            public override void ActiveItem()
            {
            }
        }
        public void AddSubItem(AbstrectItem i_MenuSubItem)
        {
            m_SubMenuItems.Add(i_MenuSubItem);
            if (i_MenuSubItem is MenuItem)
            {
                (i_MenuSubItem as MenuItem).m_ParentMenuItem = this;
            }
        }
        protected void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(ItemName);
            int itemIndex = 0;
            foreach (AbstrectItem item in m_SubMenuItems)
            {
                Console.WriteLine("({0}){1}", itemIndex, m_SubMenuItems[itemIndex].ItemName);
                itemIndex++;
            }
        }
        public override void ActiveItem()
        {
            PrintMenu();
            int menuOptionIndex = getUserMenuOption();
            AbstrectItem UserOption = m_SubMenuItems[menuOptionIndex];
            if (UserOption is BackItem)
            {
                m_ParentMenuItem.ActiveItem();
            }
            UserOption.ActiveItem();
            if (UserOption is ActionItem)
            {
                Console.ReadLine();
                ActiveItem();
            }
        }
        private int getUserMenuOption()
        {
            Console.WriteLine("Please choose an option - between 0 to {0}", m_SubMenuItems.Count - 1);
            int userMenuOption = getInvaildInput();
            return userMenuOption;
        }
        private int getInvaildInput()
        {
            int userChoose;
            string UserInput = Console.ReadLine();
            bool inputIsValid = int.TryParse(UserInput, out userChoose);

            if (inputIsValid)
            {
                inputIsValid = userChoose >= 0 && userChoose < m_SubMenuItems.Count;
            }
            while (!inputIsValid)
            {
                Console.WriteLine("wrong input Please choose an option - between 0 to {0}", m_SubMenuItems.Count - 1);
                UserInput = Console.ReadLine();
                inputIsValid = int.TryParse(UserInput, out userChoose);
                if (inputIsValid)
                {
                    inputIsValid = userChoose >= 0 && userChoose < m_SubMenuItems.Count;
                }
            }
            return userChoose;
        }
    }
}
