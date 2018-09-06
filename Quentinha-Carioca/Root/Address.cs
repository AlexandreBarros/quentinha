namespace QuentinhaCarioca.Root
{
    using System;
    using System.Collections.Generic;
    public class Address
    {
        public Guid AddressId { get; set; }
        public string ZipCode { get; set; }
        public string NeighborHood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string AddOn { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public City City { get; set; }
        public DateTime CreationDate { get; set; }
        public Nullable<DateTime> DetachmentDate { get; set; }
    }

    public class AddressComparer : IEqualityComparer<Address>
    {
        public bool Equals(Address x, Address y)
        {
            return x.AddressId.Equals(y.AddressId);
        }

        public int GetHashCode(Address obj)
        {
            return obj.AddressId.GetHashCode();
        }
    }
}
