namespace Services.Abstract
{
    using QuentinhaCarioca.Root;
    using QuentinhaCarioca.Root.ViewModel;
    using Repository;
    using System.Collections.Generic;

    public interface ILegalUserService
    {
        IUnitOfWork UnitOfWork { set; }

        #region LEGALUSER
        LegalUser Create(LegalUser entity);
        List<LegalUserResponse> GetAll(int? indexPage, int pageSize);
        LegalUser Get(string identifier);
        void Edit(LegalUser entity);
        void Remove(string identifier);
        #endregion

        #region SETTINGS
        void CreateLegalSettings(LegalUserSettings entity);
        LegalUserSettings GetLegalUserSettings(string identifier);
        void EditLegalSettings(LegalUserSettings entity);

        #endregion

        #region RESTAURANT CLASSES
        List<RestaurantClasses> RestaurantClassList();
        RestaurantClasses GetRestaurantClass(string identifier);

        #endregion





    }
}
