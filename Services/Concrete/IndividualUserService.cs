namespace Services.Concrete
{
    using QuentinhaCarioca.Root;
    using QuentinhaCarioca.Root.ViewModel;
    using Repository;
    using Services.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class IndividualUserService : IIndividualUserService
    {
        private ICommonServices cmSrv;
        private IAddressContactService acSrv;
        private ILegalUserService lSrv;

        #region HEADER 

        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public IndividualUserService(ICommonServices cmSrv, IAddressContactService acSrv, ILegalUserService lServ)
        {
            this.acSrv = acSrv;
            this.cmSrv = cmSrv;
            this.lSrv = lServ;
            Setup();
        }

        #endregion

        public Customer Create(Customer entity)
        {
            try
            {
                entity.CustomerId               = Guid.NewGuid();
                entity.User.IndividualUserId    = entity.CustomerId;
                entity.User.CreationDate        = DateTime.Now;
                entity.User.NormalizedUserName  = entity.User.UserName.ToUpper();
                if (entity.User.Addresses != null && entity.User.Addresses.Count > 0)
                {
                    cmSrv.UnitOfWork = unitOfWork;
                    entity.User.Addresses.ForEach((x) =>
                    {
                        x.City = cmSrv.GetCity(x.City.CityId);
                        x.AddressId = Guid.NewGuid();
                        x.CreationDate = DateTime.Now;
                    });
                }
                if (entity.User.Contacts != null && entity.User.Contacts.Count > 0)
                {
                    entity.User.Contacts.ForEach((x) =>
                    {
                        x.ContactId = Guid.NewGuid();
                        x.CreationDate = DateTime.Now;
                    });
                }

                unitOfWork.ICustomerRepository.Add(entity);
                unitOfWork.Commit();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Customer Get(string identifier)
        {
            try
            {
                Expression<Func<IndividualUser, bool>> expression = x => x.IndividualUserId == Guid.Parse(identifier);
                string[] related = { "Addresses", "Contacts" };
                var user = unitOfWork.IIndividualUserRepository.FirstOrDefault(expression, related);
                if (user == null)
                    throw new ArgumentNullException("USUÁRIO NÃO LOCALIZADO");

                acSrv.UnitOfWork = unitOfWork;
                user.Addresses.ForEach((x) =>
                {
                    x = acSrv.GetAddress(x.AddressId.ToString());
                });

                return new Customer { CustomerId = user.IndividualUserId, User = user };
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }


        public List<Customer> GetAll(int pageIndex, int pageSize)
        {
            string[] related = { "Contacts"};
            var result = (from a in unitOfWork.ICustomerRepository.All(pageIndex, pageSize).ToList()
            join b in unitOfWork.IIndividualUserRepository.All(related) on a.CustomerId equals b.IndividualUserId
            select new
            {
                a.CustomerId
                ,
                User = b
            }).ToList();
            List<Customer> resultList = new List<Customer>();
            result.ForEach((x) =>{resultList.Add(new Customer { CustomerId = x.CustomerId, User = x.User });});
            return resultList;
        }


        public Customer Edit(Customer entity)
        {
            var customer = Get(entity.CustomerId.ToString());
            if (customer == null)
                throw new ArgumentNullException("USUÁRIO NÃO LOCALIZADO");

            cmSrv.UnitOfWork = unitOfWork;
            customer.User.Addresses.ForEach((x) =>
            {
                x.AddOn = entity.User.Addresses.First().AddOn;
                if (x.City.CityId != entity.User.Addresses.First().City.CityId)
                    x.City = cmSrv.GetCity(entity.User.Addresses.First().City.CityId);
                x.NeighborHood  = entity.User.Addresses.First().NeighborHood;
                x.Number        = entity.User.Addresses.First().Number;
                x.Street        = entity.User.Addresses.First().Street;
                x.ZipCode       = entity.User.Addresses.First().ZipCode;
            });
            customer.User.Contacts.ForEach((x) =>
            {
                x.CellPhone = entity.User.Contacts.First().CellPhone;
                x.ContactName = entity.User.Contacts.First().ContactName;
                x.Email = entity.User.Contacts.First().Email;
                x.Phone = entity.User.Contacts.First().Phone;
            });

            customer.User.FirstName     = entity.User.FirstName;
            customer.User.LastName      = entity.User.LastName;
            customer.User.NormalizedUserName    = entity.User.UserName.ToUpper();
            customer.User.UserName              = entity.User.UserName;

            unitOfWork.ICustomerRepository.Update(customer);
            unitOfWork.Commit();
            return customer;

        }




    }
}
