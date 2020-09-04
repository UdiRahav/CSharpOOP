using System;
namespace Ex04.Menus.Interfaces
{
   public class ActionItem : AbstrectItem
    {
        public ActionItem(string i_ActionItemName, IExcuteItem i_TheFunctionToExcute)
            : base(i_ActionItemName, i_TheFunctionToExcute)
        {
        }
        public override void ActiveItem()
        {
            m_TheFunctionToExcute.ExcuteItem();
            Console.WriteLine("==========================Press Enter to go back============================");
            Console.ReadLine();
        }
    }
}
