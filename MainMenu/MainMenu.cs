using System;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        public MainMenu() : base ("Intarface Menu", new ExitItem())
        {
        }
        private class ExitItem : AbstrectItem
        {
            public ExitItem() : base("Exit")
            {
            }
            public override void ActiveItem()
            {
                Console.WriteLine("Bye bye from Intarface menu!");
                Console.ReadLine();
            }
        }
        public  void Show()
       {
            this.ActiveItem();
       }
 
    }
}
