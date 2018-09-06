namespace QuentinhaCarioca.Root
{
    using System;
    public class LegalUserReview
    {
        public Guid LegalUserReviewId { get; set; }
        public LegalUser Shop { get; set; }
        public IndividualUser User { get; set; }
        public double Review { get; set; }
        public string Comment { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
