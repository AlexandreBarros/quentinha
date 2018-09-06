namespace Infrastructure.Notification
{
    public abstract class Description : IDescription
    {
        public string Message {get;}

        protected Description(string message, params string[] args)
        {
            Message = message;
            for (int i = 0; i < args.Length; i++)
                Message = Message.Replace("{i}", args[i]);
        }
            public override string ToString() => Message;
    }
}
