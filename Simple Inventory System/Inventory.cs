namespace Simple_Inventory_System;

public class Inventory
{
    private readonly List<Product> _listOfProducts;

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

    public Product? GetById(int id)
    {
        foreach (var product in _listOfProducts)
        {
            if (product.Id == id)
                return product;
        }

        return null;
    }

    public List<Product?> Search(string searchString)
    {
        var matchesProducts = new List<Product?>();
        foreach (var product in _listOfProducts)
        {
            if(product.Name.ToUpper().StartsWith(searchString.ToUpper()))
               matchesProducts.Add(product);
        }

        return matchesProducts;
    }

    public bool EditProduct(int id, int? quantity = null, float? price = null, string? name = null)
    {
        var productToEdit = GetById(id);

        if (productToEdit == null) return false;
        productToEdit.SetAll(
            quantity:quantity?? productToEdit.Quantity,
            price: price?? productToEdit.Price,
            name: name?? productToEdit.Name
            );
        return true;
    }

    public bool DeleteProduct(int id)
    {
        var productToDelete = GetById(id);
        if (productToDelete == null) return false;

        _listOfProducts.Remove(productToDelete);
        return true;
    }
}