namespace QuentinhaCarioca.Root
{
    using System;
    using System.Collections.Generic;
    public class IndividualUser
    {
        public Guid IndividualUserId { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
