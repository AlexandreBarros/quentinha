namespace Services.Concrete
{
    using QuentinhaCarioca.Root;
    using Repository;
    using Services.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ItemService : IItemService
    {
        #region HEADER 

        private readonly ICommonServices cmSrv;
        private readonly ILegalUserService userSrv;
        private readonly ICategoryService cSrv;
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public ItemService(ICommonServices cmSrv, ILegalUserService us, ICategoryService cs)
        {
            this.cmSrv = cmSrv;
            this.userSrv = us;
            this.cSrv = cs;
            Setup();
        }

        #endregion

        public void Create(Item entity)
        {
            try
            {
                entity.ItemId = Guid.NewGuid();
                entity.CreationDate = DateTime.Now;
                cSrv.UnitOfWork = unitOfWork;
                entity.CategoriesItems.ForEach((x) =>
                {
                    x.Category = cSrv.Get(x.Category.CategoryId.ToString());
                    x.Item = entity;
                });
                unitOfWork.IItemRepository.Add(entity);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CategoryItem> GetItems(string identifier)
        {
            try
            {
                string[] related = { "LegalUser" };
                string[] relatedB = { "Category", "Item" };
                return (from a in unitOfWork.ICategoryItemRepository.All(relatedB).ToList()
                        join b in unitOfWork.ICategoryRepository.All(related).ToList() on a.CategoryId equals b.CategoryId
                        where b.LegalUser.LegalUserId == Guid.Parse(identifier)
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Item GetItem(string identifier)
        {
            try
            {
                string[] related = { "CategoriesItems" };
                Expression<Func<Item, bool>> expression = x => x.ItemId == Guid.Parse(identifier);
                return unitOfWork.IItemRepository.FirstOrDefault(expression, related);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
