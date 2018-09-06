namespace QuentinhaCarioca.Root
{
    using System;
    public class Promo
    {
        public Guid PromoId { get; set; }
        public LegalUser Legal { get; set; }
        public string Img { get; set; }
        public string FirstLayerFrase { get; set; }
        public string SecondLayerFrase { get; set; }
        public string ThirdLayerFrase { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }
    }
}
