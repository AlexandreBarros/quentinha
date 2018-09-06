namespace Services.Concrete
{
    using QuentinhaCarioca.Root;
    using Repository;
    using Services.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    public class CategoryService : ICategoryService
    {
        #region HEADER 

        private readonly ICommonServices cmSrv;
        private readonly ILegalUserService userSrv;
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public CategoryService(ICommonServices cmSrv, ILegalUserService us)
        {
            this.cmSrv = cmSrv;
            this.userSrv = us;
            Setup();
        }

        #endregion

        public void Create(Category entity)
        {
            try
            {
                userSrv.UnitOfWork = unitOfWork;
                var legalUser = userSrv.Get(entity.LegalUser.LegalUserId.ToString());
                if (legalUser == null)
                    throw new ArgumentNullException("LOJISTA NÃO LOCALIZADO");

                entity.LegalUser = legalUser;
                if (entity.Parent != null)
                    entity.Parent = Get(entity.Parent.CategoryId.ToString());
                entity.CategoryId   = Guid.NewGuid();
                entity.CreationDate = DateTime.Now;
                unitOfWork.ICategoryRepository.Add(entity);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Category Get(string identifier)
        {
            try
            {
                Expression<Func<Category, bool>> expression = x => x.CategoryId == Guid.Parse(identifier);
                string[] related = { "Parent", "LegalUser" };
                return unitOfWork.ICategoryRepository.FirstOrDefault(expression, related);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Category> GetAll(string identifier)
        {
            try
            {
                Expression<Func<Category, bool>> expression = x => x.LegalUser.LegalUserId == Guid.Parse(identifier);
                string[] related = { "Parent", "LegalUser" };
                return unitOfWork.ICategoryRepository.All(expression, related).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Category entity)
        {
            var category = Get(entity.CategoryId.ToString());
            if (category == null)
                throw new ArgumentNullException("CATEGORIA NÃO LOCALIZADA");

            if (entity.Parent == null)
                category.Parent = null;
            else
                category.Parent = Get(entity.Parent.CategoryId.ToString());

            category.Description = entity.Description;
            category.Name = entity.Name;
            category.UrlCarteLogo = entity.UrlCarteLogo;
            unitOfWork.ICategoryRepository.Update(category);
            unitOfWork.Commit();
        }
    }
}
