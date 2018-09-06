namespace Infrastructure.Notification
{
    public class Information : ILevel
    {
        public Information(string description = "Informação") => Description = description;

        public string Description { get; }

        public override string ToString() => Description;
    }
}
