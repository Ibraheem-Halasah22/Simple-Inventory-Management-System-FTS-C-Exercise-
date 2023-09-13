
using Simple_Inventory_System;

namespace Simple_Inventory_Test;

public class InventoryTest
{
    [Fact]
    public void ValidateAddProduct()
    {
        // Arrange
        var name = "product 1";
        var quantity = 20;
        var price = 10.2f;
        var inventory = new Inventory();
        inventory.AddProduct(quantity: quantity, price: price, name: name);
        
        // Act 
        var allProducts = inventory.GetAllProducts();
        var product = allProducts.First();
        var actName = product.Name;
        var actPrice = product.Price;
        var actQuantity = product.Quantity;
        
        // Assert 
        Assert.Single(allProducts);
        Assert.Equal(name, actName);
        Assert.Equal(price, actPrice);
        Assert.Equal(quantity, actQuantity);

        
        
    }
}