namespace Simple_Inventory_System;

public class Inventory
{
    private List<Product> _listOfProducts;

    Inventory()
    {
        _listOfProducts = new List<Product>();
    }

    public void AddProduct(int quantity, float price, string name)
    {
        var product = new Product(quantity, price, name);
        _listOfProducts.Add(product);
    }
        
}