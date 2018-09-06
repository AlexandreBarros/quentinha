namespace QuentinhaCarioca.Root.ViewModel
{
    using System;
    using System.Collections.Generic;
    public class EmployeeRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid LegalUserId { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate{ get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
