namespace Infrastructure.Notification
{
    public class Critical : ILevel
    {
        public Critical(string description = "Crítico") => Description = description;
        public string Description { get; }

        public override string ToString() => Description;
    }
}
