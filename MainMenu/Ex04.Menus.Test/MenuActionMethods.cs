using System;


namespace Ex04.Menus.Test
{
    class MenuActionsClass
    {
        private readonly ShowTimeClass r_ShowTimeClass = new ShowTimeClass();
        private readonly ShowDateClass r_ShowDateClass = new ShowDateClass();
        private readonly CountDigitsClass r_CountDigitsClass = new CountDigitsClass();
        private readonly ShowVersionClass r_ShowVersionClass = new ShowVersionClass();
        internal class ShowTimeClass : Interfaces.IExcuteItem
        {
            public void ExcuteItem()
            {
                ShowTime_Method();
            }
            internal void ShowTime_Method()
            {
                Console.WriteLine(DateTime.Now.TimeOfDay);
            }
        }
        internal class ShowDateClass : Interfaces.IExcuteItem
        {
            public void ExcuteItem()
            {
                ShowDate_Method();
            }

            internal void ShowDate_Method()
            {
                Console.WriteLine(DateTime.Today.ToString("d"));
            }
        }
        internal class CountDigitsClass : Interfaces.IExcuteItem
        {
            public void ExcuteItem()
            {
                CountDigits_Method();
            }
            internal void CountDigits_Method()
            {
                string Userinput;
                ushort NumberOfDigits = 0;
                Console.WriteLine("Please enter a sentence:");
                Userinput = Console.ReadLine();
                foreach (char currentCharInString in Userinput)
                {
                    if (char.IsDigit(currentCharInString))
                    {
                        NumberOfDigits++;
                    }
                }
                Console.WriteLine(string.Format("You have {0} Digits  in your sentence"
                    , NumberOfDigits));
            }
        }
        internal class ShowVersionClass : Interfaces.IExcuteItem
        {
            public void ExcuteItem()
            {
                ShowVersion_Method();
            }

            internal void ShowVersion_Method()
            {
                Console.WriteLine("Version: 19.2.4.32");
            }
        }
        internal ShowTimeClass ShowTime
        {
            get { return r_ShowTimeClass; }
        }
        internal ShowDateClass ShowDate
        {
            get { return r_ShowDateClass; }
        }
        internal CountDigitsClass CountDigits
        {
            get { return r_CountDigitsClass; }
        }
        internal ShowVersionClass ShowVersion
        {
            get { return r_ShowVersionClass; }
        }
    }
}
