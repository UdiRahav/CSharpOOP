
namespace Ex04.Menus.Interfaces
{
    public abstract class AbstrectItem
    {
        protected readonly string  r_ItemName;
        protected IExcuteItem m_TheFunctionToExcute;
        public AbstrectItem (string i_ItemName)
        {
            this.r_ItemName =  i_ItemName;
        }
        public AbstrectItem (string i_ItemName, IExcuteItem i_TheFunctionToExcute)
        {
            this.r_ItemName = i_ItemName;
            this.m_TheFunctionToExcute = i_TheFunctionToExcute;
        }
        public abstract void ActiveItem();
        public string ItemName
        {
            get { return this.r_ItemName; }
        }
    }
}
