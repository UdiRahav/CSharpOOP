
namespace Ex04.Menus.Delegates
{
    public abstract class AbstrectItem
    {
        protected readonly string r_ItemName;
        public AbstrectItem(string i_ItemName)
        {
            this.r_ItemName = i_ItemName;
        }
        public string ItemName
        {
            get { return this.r_ItemName; }
        }
        public abstract void ActiveItem();
    }
}
