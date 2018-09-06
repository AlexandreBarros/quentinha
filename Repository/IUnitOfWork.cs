namespace Repository
{
    using QuentinhaCarioca.Root;
    public interface IUnitOfWork
    {
        void Commit();
        IRepository<LegalUser> ILegalUserRepository { get; }
        IRepository<IndividualUser> IIndividualUserRepository { get; }
        IRepository<Address> IAddressRepository { get; }
        IRepository<Bank> IBankRepository { get; }
        IRepository<BankAccount> IBankAccountRepository { get; }
        IRepository<Brand> IBrandRepository { get; }
        IRepository<Category> ICategoryRepository { get; }
        IRepository<CarteScheduler> ICarteSchedulerRepository { get; }
        IRepository<Contact> IContactRepository { get; }
        IRepository<Item> IItemRepository { get; }
        IRepository<Order> IOrderRepository { get; }        
        IRepository<Employee> IEmployeeRepository { get; }
        IRepository<Promo> IPromoRepository { get; }
        IRepository<City> ICityRepository { get; }
        IRepository<State> IStateRepository { get;  }
        IRepository<LegalUserSettings> ILegalUserSettingsRepository { get; }
        IRepository<Customer> ICustomerRepository { get; }
        IRepository<CategoryItem> ICategoryItemRepository { get; }

        IRepository<LegalUserReview> ILegalUserReviewRepository { get; }

        IRepository<LegalUserRestaurantClasses> ILegalUserRestaurantClassesRepository { get; }

        IRepository<RestaurantClasses> IResturantClassesRepository { get; }
    }
}
