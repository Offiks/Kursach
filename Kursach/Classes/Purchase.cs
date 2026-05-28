using Kursach;
using System;

public class Purchase
{
    private Customer buyer;
    private Goods product;
    private int price;

    public Purchase(Customer buyer, Goods product, int price)
    {
        Buyer = buyer;
        Product = product;
        Price = price;
    }

    public Customer Buyer
    {
        get { return buyer; }
        set
        {
            if (value != null)
            {
                buyer = value;
            }
            else
            {
                Console.WriteLine("Покупець не може бути порожнім.");
            }
        }
    }

    public Goods Product
    {
        get { return product; }
        set
        {
            if (value != null)
            {
                product = value;
            }
            else
            {
                Console.WriteLine("Товар не може бути порожнім.");
            }
        }
    }

    public int Price
    {
        get { return price; }
        set
        {
            if (value > 0)
            {
                price = value;
            }
            else
            {
                Console.WriteLine("Ціна повинна бути більше 0.");
            }
        }
    }



    public override string ToString()
    {
        return $"Товар {Product.Name}, купив {Buyer.Name}, ціна {Price}";
    }
}