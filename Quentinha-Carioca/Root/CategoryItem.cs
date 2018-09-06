namespace QuentinhaCarioca.Root
{
    using System;
    public class CategoryItem
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}
