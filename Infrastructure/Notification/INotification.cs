namespace Infrastructure.Notification
{
    using System.Collections.Generic;
    public interface INotification
    {
        IList<object> List { get; }
        bool HasNotification { get; }

        bool Includes(Description error);
        void Add(Description error);
    }
}
