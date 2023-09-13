namespace Simple_Inventory_System;

public class Inventory
{
    private List<Product> _listOfProducts;

    public Inventory()
    {
        _listOfProducts = new List<Product>();
    }

    public void AddProduct(int quantity, float price, string name)
    {
        var product = new Product(quantity, price, name);
        _listOfProducts.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return _listOfProducts;
    }

    public List<Product> Search(string searchString)
    {
        var matchesProducts = new List<Product>();
        foreach (var product in _listOfProducts)
        {
            if(product.Name.ToUpper().StartsWith(searchString.ToUpper()))
               matchesProducts.Add(product);
        }

        return matchesProducts;
    }
}