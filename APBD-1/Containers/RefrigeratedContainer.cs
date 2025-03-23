namespace APBD_1.Containers;

using APBD_1.Controllers;
using APBD_1.Enums;

public class RefrigeratedContainer : Container
{
    public ProductType ProductType { get; } 
    public double MaintainedTemperature { get; }

    public RefrigeratedContainer(double height, double depth, double tareWeight, double maxPayload, ProductType productType, double maintainedTemperature)
        : base(height, depth, tareWeight, maxPayload, 'C')
    {
        if (TemperatureController.IsValid(productType, maintainedTemperature))
        {
            ProductType = productType;
            MaintainedTemperature = maintainedTemperature;
        }
        else
        {
            throw new ArgumentException("Temperature doesn't meet the requirements for this product type");
        }
    }
    
    // absolute cinema
}