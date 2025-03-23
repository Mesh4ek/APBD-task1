namespace APBD_1.Containers;

using APBD_1.Exeptions;

public abstract class Container
{
    private static int _containerEnumerator;
    
    protected Container(double height, double depth, double tareWeight, double maxPayload, char containerType)
    {
        Height = height > 0 ? height : throw new ArgumentException("Height must be greater than 0");
        Depth = depth > 0 ? depth : throw new ArgumentException("Depth must be greater than 0");
        TareWeight = tareWeight > 0 ? tareWeight : throw new ArgumentException("Tare weight must be greater than 0");
        MaxPayload = maxPayload > 0 ? maxPayload : throw new ArgumentException("Max payload must be greater than 0");
        SerialNumber = $"KON-{containerType}-{_containerEnumerator++}";
    }
    
    public double Height { get; }
    public double Depth { get; }
    public double TareWeight { get; }
    public double CargoWeight { get; protected set; }
    public string SerialNumber { get; }
    public double MaxPayload { get; }
    
    public virtual void LoadCargo(double weight)
    {
        if (weight <= 0) throw new ArgumentException("Cargo weight must be greater than 0");
        
        if (CargoWeight + weight > MaxPayload) throw new OverfillException(); 
        
        CargoWeight += weight;
    }
    
    public virtual void EmptyCargo()
    {
        CargoWeight = 0;
        Console.WriteLine($"Container {SerialNumber} has been emptied.");
    }
}