namespace APBD_1.Ships;

using APBD_1.Containers;

public class ContainerShip
{
    public string Name { get; }
    public double MaxSpeed { get; }
    public int MaxContainerCount { get; }
    public double MaxTotalWeight { get; }
    private List<Container> _containers;
    
     public ContainerShip(string name, double maxSpeed, int maxContainerCount, double maxTotalWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed > 0 ? maxSpeed : throw new ArgumentException("Max speed must be greater than 0");
        MaxContainerCount = maxContainerCount > 0 ? maxContainerCount : throw new ArgumentException("Max container count must be greater than 0");
        MaxTotalWeight = maxTotalWeight > 0 ? maxTotalWeight : throw new ArgumentException("Max total weight must be greater than 0");
        _containers = new List<Container>();
    }
    
    public void AddContainer(Container container)
    {
        if (_containers.Count >= MaxContainerCount)
            throw new InvalidOperationException("Maximum container count reached.");

        double currentTotalWeight = GetCurrentTotalWeight();
        double containerWeight = (container.TareWeight + container.CargoWeight) / 1000.0; // converting kg to tons

        if (currentTotalWeight + containerWeight > MaxTotalWeight)
            throw new InvalidOperationException("Adding this container exceeds the maximum total weight limit.");

        _containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} added to ship {Name}.");
    }
    
    public void RemoveContainer(string serialNumber)
    {
        var container = _containers.Find(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new ArgumentException("Container not found.");
        _containers.Remove(container);
        Console.WriteLine($"Container {serialNumber} removed from ship {Name}.");
    }
    
    public void LoadContainerCargo(string serialNumber, double weight)
    {
        var container = _containers.Find(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new ArgumentException("Container not found.");

        container.LoadCargo(weight);
        Console.WriteLine($"Loaded {weight} kg of cargo into container {serialNumber} on ship {Name}.");
    }
    
    public void UnloadContainer(string serialNumber)
    {
        var container = _containers.Find(c => c.SerialNumber == serialNumber);
        if (container == null)
            throw new ArgumentException("Container not found.");

        container.EmptyCargo();
        Console.WriteLine($"Unloaded container {serialNumber} on ship {Name}.");
    }
    
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = _containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1) throw new ArgumentException("Container not found.");
        
        double currentTotalWeight = GetCurrentTotalWeight();
        double oldContainerWeight = (_containers[index].TareWeight + _containers[index].CargoWeight) / 1000.0;
        double newContainerWeight = (newContainer.TareWeight + newContainer.CargoWeight) / 1000.0;

        if (currentTotalWeight - oldContainerWeight + newContainerWeight > MaxTotalWeight)
            throw new InvalidOperationException("Replacing with this container exceeds the maximum total weight limit.");

        _containers[index] = newContainer;
        Console.WriteLine($"Replaced container {serialNumber} with container {newContainer.SerialNumber} on ship {Name}.");
    }
    
    public void TransferContainer(string serialNumber, ContainerShip targetShip)
    {
        var container = _containers.Find(c => c.SerialNumber == serialNumber);
        if (container == null) throw new ArgumentException("Container not found.");
        
        targetShip.AddContainer(container);
        _containers.Remove(container);
        Console.WriteLine($"Transferred container {serialNumber} from ship {Name} to ship {targetShip.Name}.");
    }
    
    public double GetCurrentTotalWeight()
    {
        double total = 0;
        foreach (var container in _containers)
        {
            total += (container.TareWeight + container.CargoWeight);
        }
        return total / 1000.0; // converting kg to tons
    }
    
    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship {Name}:");
        Console.WriteLine($"Max Speed: {MaxSpeed} knots");
        Console.WriteLine($"Container Count: {_containers.Count}/{MaxContainerCount}");
        Console.WriteLine($"Total Weight: {GetCurrentTotalWeight()} tons (Max: {MaxTotalWeight} tons)");
        Console.WriteLine("Containers:");
        foreach (var container in _containers)
        {
            Console.WriteLine($" - {container.SerialNumber}: Tare {container.TareWeight} kg, Cargo {container.CargoWeight} kg, Max Payload {container.MaxPayload} kg");
        }
    }
}
