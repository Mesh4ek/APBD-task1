namespace APBD_1.Interfaces;

public interface IHazardNotifier
{
    void NotifyHazard(string serialNumber, string message);
}