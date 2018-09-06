namespace QuentinhaCarioca.Root
{
    using System;
    using System.Collections.Generic;
    public class Order
    {
        public Guid OrderId { get; set; }
        public LegalUser LegalUser { get; set; }
        public Employee Employee { get; set; }
        public IndividualUser Customer { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
    }
}
