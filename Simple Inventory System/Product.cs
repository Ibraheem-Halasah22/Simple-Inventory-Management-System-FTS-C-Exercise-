namespace Simple_Inventory_System;

public class Product
{
    private static int idCounter = 1;

    private static int GetNextId()
    {
        return idCounter++;
    }
    public Product(int quantity, float price, string name)
    {
        Id = GetNextId();
        SetAll(quantity: quantity, price: price, name: name);
    }

    public void SetAll(int quantity, float price, string name)
    {
        Quantity = quantity;
        Price = price;
        Name = name;
    }
    public int Id { get; set; }
    private int _quantity;
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentException("Product Quantity can't be negative");
            _quantity = value;
        }
    }

    public string Name { get; set; }

    private float _price;

    public float Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Product price can't be negative");
            _price = value;
        }
    }
}