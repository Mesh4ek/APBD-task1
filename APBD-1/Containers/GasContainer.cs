namespace APBD_1.Containers;

using APBD_1.Interfaces;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; } 
    public bool IsHazardous { get; }
    
    public GasContainer(double height, double depth, double tareWeight, double maxPayload, double pressure, bool isHazardous)
        : base(height, depth, tareWeight, maxPayload, 'G')
    {
        Pressure = pressure > 0 ? pressure : throw new ArgumentException("Pressure must be greater than 0");
        IsHazardous = isHazardous;
    }
    
    public override void EmptyCargo()
    {
        double remaining = 0.05 * CargoWeight;
        CargoWeight = remaining;
        Console.WriteLine($"Gas Container {SerialNumber} has been partially emptied. Remaining cargo: {remaining} kg.");
    }
    
    public void NotifyHazard(string serialNumber, string message)
    {
        Console.WriteLine($"[Hazard Notification] Container {serialNumber}: {message}");
    }
}
