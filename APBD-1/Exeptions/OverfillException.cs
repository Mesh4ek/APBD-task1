namespace APBD_1.Exeptions;

public class OverfillException : Exception
{
    public OverfillException(
        string message = "The weight of the cargo is greater than the capacity of a given container"
        ) : base(message) { }
}