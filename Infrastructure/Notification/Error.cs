namespace Infrastructure.Notification
{
    using System.Collections.Generic;
    using System.Linq;

    public class Error : Notification
    {
        public IList<ErrorDescription> Errors => List.Cast<ErrorDescription>().Where(x => x.Level is Critical).ToList();
        public IList<ErrorDescription> Warnings => List.Cast<ErrorDescription>().Where(x => x.Level is Warning).ToList();
        public IList<ErrorDescription> Informations => List.Cast<ErrorDescription>().Where(x => x.Level is Information).ToList();
        public bool HasErrors => List.Cast<ErrorDescription>().Any(x => x.Level is Critical);
        public bool HasWarnings => List.Cast<ErrorDescription>().Any(x => x.Level is Warning);
        public bool HasInformations => List.Cast<ErrorDescription>().Any(x => x.Level is Information);
    }
}
