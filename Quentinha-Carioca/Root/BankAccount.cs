namespace QuentinhaCarioca.Root
{
    using System;
    public class BankAccount
    {
        public Guid BankAccountId { get; set; }
        public LegalUser LegalUser { get; set; }
        public string Holder { get; set; }
        public Bank Bank { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
        public string Digit { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }
    }
}
