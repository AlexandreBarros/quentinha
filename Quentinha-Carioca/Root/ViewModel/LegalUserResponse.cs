namespace QuentinhaCarioca.Root.ViewModel
{
    using System;
    public class LegalUserResponse
    {
        public Guid LegalUserId { get; set; }
        public string LegalName { get; set; }
        public string ExhibitionName { get; set; }
        public string CNPJ { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Reviews { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }
        public bool Active { get; set; }

    }
}
