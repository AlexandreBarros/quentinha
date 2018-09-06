
namespace Repository
{
    using QuentinhaCarioca.Root;
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        private OceanicaContext context;
        public UnitOfWork()
        {
            context = new OceanicaContext();
        }
        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IRepository<LegalUser> iLegalUserRepository;
        public IRepository<LegalUser> ILegalUserRepository => iLegalUserRepository ?? new Repository<LegalUser>(context);

        private IRepository<IndividualUser> iIndividualUserRepository;
        public IRepository<IndividualUser> IIndividualUserRepository => iIndividualUserRepository ?? new Repository<IndividualUser>(context);

        private IRepository<Address> iAddressRepository;
        public IRepository<Address> IAddressRepository => iAddressRepository ?? new Repository<Address>(context);

        private IRepository<Bank> iBankRepository;
        public IRepository<Bank> IBankRepository => iBankRepository ?? new Repository<Bank>(context);

        private IRepository<BankAccount> iBankAccountRepository;
        public IRepository<BankAccount> IBankAccountRepository => iBankAccountRepository ?? new Repository<BankAccount>(context);

        private IRepository<Brand> iBrandRepository;
        public IRepository<Brand> IBrandRepository => iBrandRepository ?? new Repository<Brand>(context);

        private IRepository<Category> iCategoryRepository;
        public IRepository<Category> ICategoryRepository => iCategoryRepository ?? new Repository<Category>(context);

        private IRepository<CarteScheduler> iCarteSchedulerRepository;
        public IRepository<CarteScheduler> ICarteSchedulerRepository => iCarteSchedulerRepository ?? new Repository<CarteScheduler>(context);

        private IRepository<Contact> iContactRepository;
        public IRepository<Contact> IContactRepository => iContactRepository ?? new Repository<Contact>(context);

        private IRepository<Item> iItemRepository;
        public IRepository<Item> IItemRepository => iItemRepository ?? new Repository<Item>(context);

        private IRepository<Order> iOrderRepository;
        public IRepository<Order> IOrderRepository => iOrderRepository ?? new Repository<Order>(context);
      
        private IRepository<Employee> iEmployeeRepository;
        public IRepository<Employee> IEmployeeRepository => iEmployeeRepository ?? new Repository<Employee>(context);

        private IRepository<Promo> iPromoRepository;
        public IRepository<Promo> IPromoRepository => iPromoRepository ?? new Repository<Promo>(context);

        private IRepository<City> iCityRepository;
        public IRepository<City> ICityRepository => iCityRepository ?? new Repository<City>(context);

        private IRepository<State> iStateRepository;
        public IRepository<State> IStateRepository => iStateRepository ?? new Repository<State>(context);

        private IRepository<LegalUserSettings> iLegalUserSettingsRepository;
        public IRepository<LegalUserSettings> ILegalUserSettingsRepository => iLegalUserSettingsRepository ?? new Repository<LegalUserSettings>(context);

        private IRepository<CategoryItem> iCategoryItemRepository;
        public IRepository<CategoryItem> ICategoryItemRepository => iCategoryItemRepository ?? new Repository<CategoryItem>(context);

        private IRepository<Customer> iCustomerRepository;
        public IRepository<Customer> ICustomerRepository => iCustomerRepository ?? new Repository<Customer>(context);

        private IRepository<LegalUserReview> iLegalUserReviewRepository;
        public IRepository<LegalUserReview> ILegalUserReviewRepository => iLegalUserReviewRepository ?? new Repository<LegalUserReview>(context);


        private IRepository<LegalUserRestaurantClasses> iLegalUserRestaurantClassesRepository;
        public IRepository<LegalUserRestaurantClasses> ILegalUserRestaurantClassesRepository => iLegalUserRestaurantClassesRepository ?? new Repository<LegalUserRestaurantClasses>(context);

        private IRepository<RestaurantClasses> iResturantClassesRepository;
        public IRepository<RestaurantClasses> IResturantClassesRepository => iResturantClassesRepository ?? new Repository<RestaurantClasses>(context);


    }
}
