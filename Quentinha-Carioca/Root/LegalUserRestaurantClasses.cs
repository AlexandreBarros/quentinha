namespace QuentinhaCarioca.Root
{
    using System;
    public class LegalUserRestaurantClasses
    {
        public Guid LegalUserRestaurantClassesId { get; set; }
        public LegalUser LegalUser { get; set; }
        public RestaurantClasses Class { get; set; }
    }
}
