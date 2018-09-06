namespace Infrastructure.Notification
{
    using System.Collections.Generic;
    using System.Linq;
    public class Notification: INotification
    {
        public IList<object> List { get; } = new List<object>();
        public bool HasNotification => List.Any() ;

        public bool Includes(Description error)
        {
            return List.Contains(error);
        }

        public void Add(Description description)
        {
            List.Add(description);
        }
    }
}
