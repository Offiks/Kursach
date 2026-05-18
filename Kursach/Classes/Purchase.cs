using System;

namespace Kursach.Classes
{
    public class Purchase
    {
        public Customer Buyer { get; set; }
        public Goods Product { get; set; }
        public int price { get; set; }

        public Purchase(Customer buyer, Goods product, int count)
        {
            Buyer = buyer;
            Product = product;
            price = count;
        }

        public override string ToString()
        {
            return $"Товар {Product}, купив {Buyer}, ціна {price}";
        }
    }
}
