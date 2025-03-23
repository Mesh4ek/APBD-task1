using APBD_1.Containers;
using APBD_1.Enums;
using APBD_1.Ships;

namespace APBD_1;

class Program
{
    static void Main(string[] args)
    {
        var ship1 = new ContainerShip("Ship 1", 12, 3, 30);
        var ship2 = new ContainerShip("Ship 2", 15, 2, 25);
        
        var refrigeratedContainer = new RefrigeratedContainer(250, 300, 2000, 10000, ProductType.Bananas, 20);
        
        var liquidContainer = new LiquidContainer(200, 250, 1500, 8000, false);
        
        var gasContainer = new GasContainer(180, 240, 1600, 7000, 5, false);
        
        ship1.AddContainer(refrigeratedContainer);
        ship1.AddContainer(liquidContainer);
        ship1.AddContainer(gasContainer);
        
        Console.WriteLine("\n--- Ship 1 after adding containers ---");
        ship1.PrintShipInfo();
        
        ship1.LoadContainerCargo(liquidContainer.SerialNumber, 3000);       
        ship1.LoadContainerCargo(refrigeratedContainer.SerialNumber, 5000);  
        
        ship1.UnloadContainer(gasContainer.SerialNumber);

        Console.WriteLine("\n--- Ship 1 after loading and unloading operations ---");
        ship1.PrintShipInfo();
        
        var newLiquidContainer = new LiquidContainer(200, 250, 1500, 8000, false);
        ship1.ReplaceContainer(liquidContainer.SerialNumber, newLiquidContainer);

        Console.WriteLine("\n--- Ship 1 after replacing the liquid container ---");
        ship1.PrintShipInfo();

        ship1.TransferContainer(newLiquidContainer.SerialNumber, ship2);

        Console.WriteLine("\n--- Ship 1 after transferring the liquid container ---");
        ship1.PrintShipInfo();
        Console.WriteLine("\n--- Ship 2 after receiving the transferred container ---");
        ship2.PrintShipInfo();

        ship1.RemoveContainer(refrigeratedContainer.SerialNumber);
        
        Console.WriteLine("\n--- Ship 1 after removing the refrigerated container ---");
        ship1.PrintShipInfo();

        Console.WriteLine("\n--- Final state of all ships ---");
        Console.WriteLine("Ship 1:");
        ship1.PrintShipInfo();
        Console.WriteLine("\nShip 2:");
        ship2.PrintShipInfo();
    }
}