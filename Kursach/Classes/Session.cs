using System;

namespace Kursach.Classes
{
    public class Session
    {
        public Shop CurrentShop { get; set; }
        public Customer CurrentCustomer { get; set; }
        public int SecurityLevel { get; set; }

        public void Reset()
        {
            CurrentShop = null;
            CurrentCustomer = null;
            SecurityLevel = 0;
        }
    }
}