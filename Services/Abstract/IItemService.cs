namespace Services.Abstract
{
    using QuentinhaCarioca.Root;
    using Repository;
    using System;
    using System.Collections.Generic;

    public interface IItemService
    {
        IUnitOfWork UnitOfWork { set; }
        void Create(Item entity);
        List<CategoryItem> GetItems(string identifier);
        Item GetItem(string identifier);
    }
}
