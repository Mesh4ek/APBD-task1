namespace APBD_1.Containers;

using APBD_1.Interfaces;
using APBD_1.Exeptions;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidContainer(double height, double depth, double tareWeight, double maxPayload, bool isHazardous)
        : base(height, depth, tareWeight, maxPayload, 'L')
    {
        IsHazardous = isHazardous;
    }
    
    public override void LoadCargo(double weight)
    {
        if (weight <= 0) 
            throw new ArgumentException("Cargo weight must be greater than 0");
        
        double allowedCapacity = IsHazardous ? 0.5 * MaxPayload : 0.9 * MaxPayload;
        
        if (CargoWeight + weight > allowedCapacity)
        {
            NotifyHazard(SerialNumber, "Attempted to load cargo exceeding allowed capacity.");
            throw new OverfillException();
        }
        
        CargoWeight += weight;
    }
    
    public void NotifyHazard(string serialNumber, string message)
    {
        Console.WriteLine($"[Hazard Notification] Container {serialNumber}: {message}");
    }
}
