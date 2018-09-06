namespace Infrastructure.Notification
{
    public interface IDescription
    {
        string Message { get; }
        string ToString();
    }
}
