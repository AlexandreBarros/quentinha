namespace QuentinhaCarioca.Root
{
    using System;
    using System.Collections.Generic;
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public decimal PricePromo { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public List<CategoryItem> CategoriesItems { get; set; }
    }
}
