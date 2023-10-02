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


    [Fact]
    public void ValidateSearchProduct()
    {
        // Arrange
        var inventory = new Inventory();
        inventory.AddProduct(quantity: 10, price: 15.5f, "prod");
        inventory.AddProduct(quantity: 10, price: 15.5f, "product v");
        inventory.AddProduct(quantity: 10, price: 15.5f, "Product new");
        inventory.AddProduct(quantity: 10, price: 15.5f, "pro vv");
        inventory.AddProduct(quantity: 10, price: 15.5f, "productive prod");
        inventory.AddProduct(quantity: 10, price: 15.5f, "not productive prod");

        // Act
        var result = inventory.Search("Prod");

        // Assert 

        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void ValidateUpdateProduct()
    {
        // Arrange
        var inventory = new Inventory();
        inventory.AddProduct(10, 10.5f, "name a");
        inventory.AddProduct(100, 2.5f, "name b");
        inventory.AddProduct(500, 10.3f, "third name");

               
        var productToEdit = inventory.Search("name").First();
        var id = productToEdit!.Id;

        var newName = "new Name ";
        var newPrice = 4.6f;


        // Act 
        var editResult = inventory.EditProduct(id, name: newName, price: newPrice);
        var editedProduct = inventory.GetById(id);
        var actName = editedProduct?.Name;
        var actPrice = editedProduct?.Price;

        // Assert
        Assert.True(editResult);
        Assert.Equal(newName, actName);
        Assert.Equal(newPrice, actPrice);
    }

    [Fact]
    public void InvalidateUpdateProduct()
    {
        // Arrange
        var inventory = new Inventory();
        inventory.AddProduct(10, 10.5f, "name a");
        inventory.AddProduct(100, 2.5f, "name b");
        inventory.AddProduct(500, 10.3f, "third name");

        int id = 100;
        var newName = "new Name ";
        var newPrice = 4.6f;


        // Act 
        var editResult = inventory.EditProduct(id, name: newName, price: newPrice);


        // Assert
        Assert.False(editResult);
    }

    [Fact]
    public void ValidateDeleteProduct()
    {
        // Arrange
        var inventory = new Inventory();
        inventory.AddProduct(10, 10.5f, "name a");
        inventory.AddProduct(100, 2.5f, "name b");
        inventory.AddProduct(500, 10.3f, "third name");


        var productToDelete = inventory.Search("name").First();
        var id = productToDelete!.Id;

        // Act 
        var deleteResult = inventory.DeleteProduct(id);
        var listOfProductsAfterDelete = inventory.GetAllProducts();
        var removedProduct = inventory.GetById(id);

        // Assert
        Assert.True(deleteResult);
        Assert.DoesNotContain(productToDelete, listOfProductsAfterDelete);
        Assert.Null(removedProduct);
    }
    
    [Fact]
    public void InvalidateDeleteProduct()
    {
        // Arrange
        var inventory = new Inventory();
        inventory.AddProduct(10, 10.5f, "name a");
        inventory.AddProduct(100, 2.5f, "name b");
        inventory.AddProduct(500, 10.3f, "third name");

        int id = 100;


        // Act 
        var deleteResult = inventory.DeleteProduct(id);
        var listOfProductsAfterDelete = inventory.GetAllProducts();

        // Assert
        Assert.False(deleteResult);
        Assert.Equal(3, listOfProductsAfterDelete.Count);
    }
}