namespace QuentinhaCarioca.Root
{
    using System;
    public class CarteScheduler
    {
        public Guid CarteSchedulerId { get; set; }
        public Category Carte { get; set; }
        public DateTime EnableDate { get; set; }
    }
}
