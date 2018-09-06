namespace Infrastructure.Notification
{
    public class Warning : ILevel
    {
        public Warning(string description = "Atenção") => Description = description;
        public string Description { get; }

        public override string ToString() => Description;

    }
}
