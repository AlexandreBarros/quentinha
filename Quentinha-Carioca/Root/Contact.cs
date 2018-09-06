namespace QuentinhaCarioca.Root
{
    using System;
    using System.Collections.Generic;

    public class Contact
    {
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }
    }
    public class ContactComparer : IEqualityComparer<Contact>
    {
        public bool Equals(Contact x, Contact y)
        {
            return x.ContactId.Equals(y.ContactId);
        }

        public int GetHashCode(Contact obj)
        {
            return obj.ContactId.GetHashCode();
        }
    }
}
