namespace QuentinhaCarioca.Root
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;

    public class LegalUser
    {
        public Guid LegalUserId { get; set; }
        public string LegalName { get; set; }
        public string NormalizedLegalName { get; set; }
        public string ExhibitionName { get; set; }
        public string NormalizedExhibitionName { get; set; }
        public string UrlData { get; set; }
        public string CNPJ { get; set; }
        public string InscEst { get; set; }
        public string InscMun { get; set; }
        public bool Active { get; set; }
        public bool ShowGeoPosition { get; set; }
        public LegalUserSettings Settings { get; set; }

        public IFormCollection Items { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<RestaurantClasses> Classes { get; set; }
        public List<Employee> Employees { get; set; }

        public List<LegalUserReview> Reviews { get; set; }

        public DateTime CreationDate { get; set; }
        public Nullable<DateTime> DetachmentDate { get; set; }


    }
}
