using System;

namespace Kursach
{
    public class RegularCustomer : Customer
    {
        private string name;
        private int totalAmountSpent;

        public RegularCustomer(int balance, string name, int total)
            : base(balance)
        {
            Name = name;
            TotalAmountSpent = total;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                name = value;
            }
        }

        public int TotalAmountSpent
        {
            get { return totalAmountSpent; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total cannot be negative");
                totalAmountSpent = value;
            }
        }

        public override (string Name, int PersonalDiscount) GetDiscount(Goods goods)
        {
            int PersonalDiscount = TotalAmountSpent / 1000;
            if (PersonalDiscount > 15) 
                PersonalDiscount = 15;
            if (PersonalDiscount > goods.MaxDiscount)
                PersonalDiscount = goods.MaxDiscount;

            return (Name, PersonalDiscount);
        }

        //Тут наверно лучше передалать
        public override bool Buy(Goods goods)
        { 
            var (customerName, discount) = GetDiscount(goods);

            int finalPrice = goods.Price * discount / 100;
            if (Balance >= finalPrice)
            {
                TotalAmountSpent += finalPrice;
                Balance -= finalPrice;
                return true;
            }
            else {
                throw new ArgumentException("Insufficient balance");
            }
        }

        public override string ToString()
        {
            return $"Постоянный покупатель: {Name}, Баланс: {Balance}, Потрачено всего: {TotalAmountSpent}";
        }

    }
}