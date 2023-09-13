namespace Simple_Inventory_System;

public class Inventory
{
    private List<Product> _listOfProducts;

    Inventory()
    {
        _listOfProducts = new List<Product>();
    }
    public void AddProduct(string name, int quantity, float price)
    {
        Product product = new Product(name: name, price:price, quantity: quantity);
        _listOfProducts.Add(product);
    }
        
}