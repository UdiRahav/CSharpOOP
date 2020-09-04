

using System;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        public MainMenu() : base("Delegates Menu", new ExitItem())
        {
        }
        private class ExitItem : AbstrectItem
        {
            public ExitItem() : base("Exit")
            {
            }
            public override void ActiveItem()
            {
                Console.WriteLine("Bye bye from Delegates menu!");
                Console.ReadLine();
            }
        }
        public void Show()
        {
            ActiveItem();
        }

    }
}

