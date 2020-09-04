
using System;
namespace Ex04.Menus.Delegates
{
    public class ActionItem : MenuItem
    {
        public event Action m_ActionItemEvent;
        public ActionItem(string i_Name) : base(i_Name) {}
        public override void ActiveItem()
        {
            ActionItem_ExcuteItem();
        }
        private void ActionItem_ExcuteItem()
        {
            if (m_ActionItemEvent != null)
            {
                m_ActionItemEvent.Invoke();
            }
            Console.WriteLine("==========================Press Enter to go back============================");
        }
    }
}
