namespace QuentinhaCarioca.Root
{
    using System;
    using System.Collections.Generic;

    public class Category : IEqualityComparer<Category>
    {
        public Guid CategoryId { get; set; }
        public Category Parent { get; set; }
        public LegalUser LegalUser { get; set; }
        public string Name { get; set; }
        public string UrlCarteLogo { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }
        public List<CategoryItem> CategoriesItems { get; set; }

        public bool Equals(Category x, Category y)
        {
            return x.CategoryId.Equals(y.CategoryId);
        }

        public int GetHashCode(Category obj)
        {
            return obj.CategoryId.GetHashCode();
        }
    }
}
