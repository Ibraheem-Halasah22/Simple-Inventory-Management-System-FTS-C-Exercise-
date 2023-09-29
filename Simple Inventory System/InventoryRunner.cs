namespace Simple_Inventory_System;

public class InventoryRunner
{
    public static void RunInventory()
    {
        var inventory = new Inventory();
        

        Console.WriteLine("Welcome to this inventory management system\r");
        Console.WriteLine("-------------------------------------------\n");

        
        Console.ReadKey();
    }
}