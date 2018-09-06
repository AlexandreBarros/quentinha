namespace Repository
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using QuentinhaCarioca.Root;
    using QuentinhaCarioca.Root.ViewModel;
    using System;
    using System.IO;
    public class OceanicaContext : DbContext
    {
        public virtual DbSet<LegalUser> LegalUser { get; set; }
        public virtual DbSet<IndividualUser> IndividualUser { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public DbSet<LegalUserSettings> LegalUserSettings { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public OceanicaContext()
        { }
        public OceanicaContext(DbContextOptions<OceanicaContext> options)
            : base(options)
        { }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string pPath    = Path.GetFullPath(Directory.GetCurrentDirectory());
            var config      = new ConfigurationBuilder().SetBasePath(pPath).AddJsonFile("appsettings.json").Build();
            var connString  = config.GetSection("ConnectionString");
            optionsBuilder.UseSqlServer(connString.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ADDRESS
            modelBuilder.Entity<Address>
                (x =>
                    {
                        x.Property<Guid>(y => y.AddressId).IsRequired(true).HasColumnType("uniqueidentifier");
                        x.HasKey(y => y.AddressId);
                        x.HasOne<City>(y => y.City);
                        x.Property<string>(y => y.ZipCode).IsRequired(false).HasMaxLength(10);
                        x.Property<string>(y => y.NeighborHood).IsRequired(true).HasMaxLength(100);
                        x.Property<string>(y => y.Street).IsRequired(true).HasMaxLength(100);
                        x.Property<string>(y => y.Number).IsRequired(false).HasMaxLength(10);
                        x.Property<string>(y => y.AddOn).IsRequired(false).HasMaxLength(10);
                        x.Property<string>(y => y.latitude).IsRequired(false).HasMaxLength(100);
                        x.Property<string>(y => y.longitude).IsRequired(false).HasMaxLength(100);
                        x.Property<DateTime>(y => y.CreationDate).IsRequired(true).HasColumnType("DateTime");
                        x.Property<DateTime?>(y => y.DetachmentDate).IsRequired(false).HasColumnType("DateTime");
                    });
            //BANK
            modelBuilder.Entity<Bank>
                (x =>
                {
                    x.Property<int>(y => y.Id);
                    x.HasKey(y => y.Id);
                    x.Property<string>(y => y.Name).HasMaxLength(255).IsRequired(true);
                    x.Property<string>(y => y.Cnpj).HasMaxLength(25).IsRequired(false);
                    x.Property<string>(y => y.Code).HasMaxLength(10).IsRequired(false);
                    x.Property<string>(y => y.Site).HasMaxLength(150).IsRequired(false);
                });
            //BANK ACCOUNT
            modelBuilder.Entity<BankAccount>
                (x =>
                {
                    x.Property<Guid>(y => y.BankAccountId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.BankAccountId);
                    x.HasOne(y => y.Bank);
                    x.HasOne<LegalUser>(y => y.LegalUser);
                    x.Property<string>(y => y.Holder).HasMaxLength(50).IsRequired(true);
                    x.Property<string>(y => y.Agency).HasMaxLength(10).IsRequired(true);
                    x.Property<string>(y => y.AccountNumber).HasMaxLength(20).IsRequired(true);
                    x.Property<string>(y => y.Digit).HasMaxLength(3).IsRequired(true);
                    x.Property<DateTime>(y => y.CreationDate).IsRequired(true).HasColumnType("DateTime");
                    x.Property<DateTime?>(y => y.DetachmentDate).IsRequired(false).HasColumnType("DateTime");

                });
            //BRAND
            modelBuilder.Entity<Brand>
                (x =>
                {
                    x.Property<int>(y => y.BrandId);
                    x.HasKey(y => y.BrandId);
                    x.Property<string>(y => y.Name).HasMaxLength(30).IsRequired(true);
                    x.Property<DateTime>(y => y.CreationDate).IsRequired(true).HasColumnType("DateTime");
                    x.Property<DateTime?>(y => y.DetachmentDate).IsRequired(false).HasColumnType("DateTime");
                });
            //CONTACT
            modelBuilder.Entity<Contact>
                (x =>
                {
                    x.Property<Guid>(y => y.ContactId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.ContactId);
                    x.Property<string>(y => y.ContactName).HasMaxLength(50).IsRequired(false);
                    x.Property<string>(y => y.Phone).HasMaxLength(20).IsRequired(false);
                    x.Property<string>(y => y.CellPhone).HasMaxLength(20).IsRequired(false);
                    x.Property<string>(y => y.Email).HasMaxLength(50).IsRequired(false);
                    x.Property<DateTime>(y => y.CreationDate).IsRequired(true).HasColumnType("DateTime");
                    x.Property<DateTime?>(y => y.DetachmentDate).IsRequired(false).HasColumnType("DateTime");
                });
            //INDIVIDUAL USER
            modelBuilder.Entity<IndividualUser>
                (x =>
                {
                    x.Property<Guid>(y => y.IndividualUserId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.IndividualUserId);
                    x.Property<string>(y => y.PasswordHash).IsRequired(true).HasMaxLength(1024);
                    x.Property<string>(y => y.UserName).IsRequired(true).HasMaxLength(128);
                    x.Property<string>(y => y.NormalizedUserName).IsRequired(true).HasMaxLength(128);
                    x.Property<string>(y => y.FirstName).IsRequired(true).HasMaxLength(30);
                    x.Property<string>(y => y.LastName).IsRequired(true).HasMaxLength(30);
                    x.Property<DateTime>(y => y.CreationDate).IsRequired(true).HasColumnType("DateTime");
                    x.Property<DateTime?>(y => y.DetachmentDate).IsRequired(false).HasColumnType("DateTime");
                    x.HasMany<Contact>(y => y.Contacts);
                    x.HasMany<Address>(y => y.Addresses);
                });


            //LEGAL USER
            modelBuilder.Entity<LegalUser>().Ignore(y => y.Classes);
            modelBuilder.Entity<LegalUser>().Ignore(y => y.Items);
            modelBuilder.Entity<LegalUser>().Ignore(y => y.Settings);
            modelBuilder.Entity<LegalUser>
              (x =>
              {
                  x.Property<Guid>(y => y.LegalUserId).IsRequired(true).HasColumnType("uniqueidentifier");
                  x.HasKey(y => y.LegalUserId);
                  x.Property<bool>(y => y.Active);
                  x.Property<string>(y => y.LegalName).IsRequired(true).HasMaxLength(150);
                  x.Property<string>(y => y.NormalizedLegalName).IsRequired(true).HasMaxLength(150);
                  x.Property<string>(y => y.ExhibitionName).IsRequired(true).HasMaxLength(150);
                  x.Property<string>(y => y.NormalizedExhibitionName).IsRequired(true).HasMaxLength(150);
                  x.Property<string>(y => y.CNPJ).IsRequired(false).HasMaxLength(20);
                  x.Property<string>(y => y.InscEst).IsRequired(false).HasMaxLength(30);
                  x.Property<string>(y => y.InscMun).IsRequired(false).HasMaxLength(30);
                  x.Property<string>(y => y.UrlData).IsRequired(true);
                  x.Property<bool>(y => y.ShowGeoPosition);
                  x.Property<DateTime>(y => y.CreationDate).IsRequired(true).HasColumnType("DateTime");
                  x.Property<DateTime?>(y => y.DetachmentDate).IsRequired(false).HasColumnType("DateTime");
              });            
           
            //ORDER
            modelBuilder.Entity<Order>
                (x =>
                {
                    x.Property<Guid>(y => y.OrderId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.OrderId);
                    x.HasOne<LegalUser>(y => y.LegalUser);
                    x.HasOne<Employee>(y => y.Employee);
                    x.HasOne<IndividualUser>(y => y.Customer);
                    x.Property(y => y.Status);
                    x.Property<DateTime>(y => y.CreationDate).IsRequired(true).HasColumnType("DateTime");
                    x.Property<DateTime?>(y => y.DeliveredDate).IsRequired(false).HasColumnType("DateTime");

                });
            //ROLE
            modelBuilder.Entity<Role>
                (x =>
                {
                    x.Property<Guid>(y => y.Id).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.Id);
                    x.Property<string>(y => y.Name).IsRequired(true).HasMaxLength(50);

                });
            //ROLE
            modelBuilder.Entity<UserRole>
                (x =>
                {
                    x.Property<Guid>(y => y.UserRoleId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.UserRoleId);
                    x.HasOne<IndividualUser>(y => y.User);
                    x.HasOne<Role>(y => y.Role);
                    x.Property<DateTime>(y => y.CreationDate);
                    x.Property<DateTime?>(y => y.DetachmentDate);

                });
            //EMPLOYEE
            modelBuilder.Entity<Employee>
                (x =>
                {
                    x.Property<Guid>(y => y.EmployeeId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.EmployeeId);
                    x.HasOne<IndividualUser>(y => y.User);
                    x.HasOne<LegalUser>(y => y.LegalUser);
                    x.Property<bool>(y => y.Active);
                });
            //PROMO
            modelBuilder.Entity<Promo>
                (x =>
                {
                    x.Property<Guid>(y => y.PromoId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.PromoId);
                    x.HasOne<LegalUser>(y => y.Legal);
                    x.Property<string>(y => y.FirstLayerFrase).IsRequired(true).HasMaxLength(100);
                    x.Property<string>(y => y.SecondLayerFrase).IsRequired(true).HasMaxLength(100);
                    x.Property<string>(y => y.ThirdLayerFrase).IsRequired(true).HasMaxLength(100);
                    x.Property<string>(y => y.Img).IsRequired(true).HasMaxLength(4000);
                    x.Property<DateTime>(y => y.CreationDate);
                    x.Property<DateTime?>(y => y.DetachmentDate);
                });
           
            //CITY
            modelBuilder.Entity<City>
                (x =>
                {
                    x.HasKey(y => y.CityId);
                    x.Property<string>(y => y.Name).IsRequired(true).HasMaxLength(100);
                    x.Property<int>(y => y.StateId);
                });
            //STATE
            modelBuilder.Entity<State>
                (x =>
                {
                    x.HasKey(y => y.Id);
                    x.Property<string>(y => y.Name).IsRequired(true).HasMaxLength(100);
                    x.Property<string>(y => y.Initials).IsRequired(true).HasMaxLength(5);
                });
            //CUSTOMER
            modelBuilder.Entity<Customer>
                (x =>
                {
                    x.Property<Guid>(y => y.CustomerId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.CustomerId);
                    x.HasOne<IndividualUser>(y => y.User);
                });

            //LEGALUSERSETTINGS
            modelBuilder.Entity<LegalUserSettings>
                (x =>
                {
                    x.Property<Guid>(y => y.LegalUserSettingsId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.LegalUserSettingsId);
                    x.HasOne<LegalUser>(y => y.LegalUser);
                    x.Property<decimal>(y => y.DeliveryCoust).HasColumnType("decimal(9,2)");
                    x.Property<bool>(y => y.IsOpen);
                    x.Property<bool>(y => y.MondayIsWorkDay);
                    x.Property<string>(y => y.MondayStartHour).HasMaxLength(5);
                    x.Property<string>(y => y.MondayEndHour).HasMaxLength(5);
                    x.Property<bool>(y => y.TuesdayIsWorkDay);
                    x.Property<string>(y => y.TuesdayStartHour).HasMaxLength(5);
                    x.Property<string>(y => y.TuesdayEndHour).HasMaxLength(5);
                    x.Property<bool>(y => y.WednesdayIsWorkDay);
                    x.Property<string>(y => y.WednesdayStartHour).HasMaxLength(5);
                    x.Property<string>(y => y.WednesdayEndHour).HasMaxLength(5);
                    x.Property<bool>(y => y.ThursdayIsWorkDay);
                    x.Property<string>(y => y.ThursdayStartHour).HasMaxLength(5);
                    x.Property<string>(y => y.ThursdayEndHour).HasMaxLength(5);
                    x.Property<bool>(y => y.FridayIsWorkDay);
                    x.Property<string>(y => y.FridayStartHour).HasMaxLength(5);
                    x.Property<string>(y => y.FridayEndHour).HasMaxLength(5);
                    x.Property<bool>(y => y.SaturdayIsWorkDay);
                    x.Property<string>(y => y.SaturdayStartHour).HasMaxLength(5);
                    x.Property<string>(y => y.SaturdayEndHour).HasMaxLength(5);
                    x.Property<bool>(y => y.SundayIsWorkDay);
                    x.Property<string>(y => y.SundayStartHour).HasMaxLength(5);
                    x.Property<string>(y => y.SundayEndHour).HasMaxLength(5);

                });
            //CATEGORY-ITEM
            modelBuilder.Entity<CategoryItem>
                (x =>
                {
                    x.HasKey(ci => new { ci.CategoryId, ci.ItemId });
                    x.HasOne<Category>(c => c.Category).WithMany(i => i.CategoriesItems).HasForeignKey(c => c.CategoryId);
                    x.HasOne<Item>(i => i.Item).WithMany(c => c.CategoriesItems).HasForeignKey(i => i.ItemId);
                });
            
            //CATEGORY
            modelBuilder.Entity<Category>
                (x =>
                {
                    x.Property<Guid>(y => y.CategoryId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.CategoryId);
                    x.HasOne<Category>(y => y.Parent);
                    x.Property<string>(y => y.Name).IsRequired(true).HasMaxLength(50);
                    x.Property<string>(y => y.Description).IsRequired(true).HasMaxLength(500);
                    x.Property<string>(y => y.UrlCarteLogo).IsRequired(false);
                    x.Property<DateTime>(y => y.CreationDate).IsRequired();
                    x.Property<DateTime?>(y => y.DetachmentDate);
                });
            
            //ITEM 
            modelBuilder.Entity<Item>
                (x =>
                {
                    x.Property<Guid>(y => y.ItemId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.ItemId);
                    x.Property<bool>(y => y.Active);
                    x.Property<DateTime>(y => y.CreationDate);
                    x.Property<string>(y => y.Name).IsRequired(true).HasMaxLength(50);
                    x.Property<string>(y => y.Description).IsRequired(false).HasMaxLength(255);
                    x.Property<string>(y => y.Photo).IsRequired(false);
                    x.Property<decimal>(y => y.Price).IsRequired(true).HasColumnType("decimal(9,6)");
                    x.Property<decimal>(y => y.PricePromo).IsRequired(true).HasColumnType("decimal(9,6)");
                });

            modelBuilder.Entity<LegalUserReview>
                (x =>
                {
                    x.Property<Guid>(y => y.LegalUserReviewId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.LegalUserReviewId);
                    x.HasOne<LegalUser>(y => y.Shop);
                    x.HasOne<IndividualUser>(y => y.User);
                    x.Property<double>(y => y.Review);
                    x.Property<string>(y => y.Comment).HasMaxLength(140);
                    x.Property<DateTime>(y => y.RegisterDate).HasDefaultValueSql("GetDate()");
                });
            modelBuilder.Entity<RestaurantClasses>
                (x =>
                {
                    x.Property<Guid>(y => y.RestaurantClassesId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.RestaurantClassesId);
                    x.Property<string>(y => y.Name).IsRequired(true).HasMaxLength(30);
                });
            modelBuilder.Entity<LegalUserRestaurantClasses>
                (x =>
                {
                    x.Property<Guid>(y => y.LegalUserRestaurantClassesId).IsRequired(true).HasColumnType("uniqueidentifier");
                    x.HasKey(y => y.LegalUserRestaurantClassesId);
                    x.HasOne<LegalUser>(y => y.LegalUser);

                });
        }
    }
}
