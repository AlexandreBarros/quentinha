namespace QuentinhaCarioca.Root
{
    using System;
    public class OrderItem
    {
        public Guid OrderItemId { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public DateTime Date { get; set; }
    }
}
