namespace Services.Abstract
{
    using QuentinhaCarioca.Root;
    using Repository;
    using System.Collections.Generic;
    public interface ICategoryService
    {
        IUnitOfWork UnitOfWork { set; }
        void Create(Category entity);
        Category Get(string identifier);
        List<Category> GetAll(string identifier);
        void Update(Category entity);
    }
}
