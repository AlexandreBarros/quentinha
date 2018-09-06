namespace Services.Concrete
{
    using QuentinhaCarioca.Root;
    using Repository;
    using Services.Abstract;
    using System;
    using System.Linq.Expressions;

    public class AddressContactService : IAddressContactService
    {
        #region HEADER 

        private readonly ICommonServices cmSrv;
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public AddressContactService(ICommonServices cmSrv)
        {
            this.cmSrv = cmSrv;
            Setup();
        }

        #endregion

        public Address GetAddress(string identifier)
        {
            string[] related = { "City" };
            Expression<Func<Address, bool>> expression = x => x.AddressId == Guid.Parse(identifier);
            return unitOfWork.IAddressRepository.FirstOrDefault(expression, related);
        }


        public void UpdateAddress(Address address, bool updateHere = true)
        {
            try
            {
                Expression<Func<Address, bool>> expression = x => x.AddressId == address.AddressId;
                var ad = unitOfWork.IAddressRepository.FirstOrDefault(expression);
                if (ad == null)
                    throw new ArgumentNullException("Endereço não localizado");

                cmSrv.UnitOfWork = unitOfWork;
                var city    = cmSrv.GetCity(address.City.CityId);
                ad.AddOn    = address.AddOn;
                ad.City     = city;
                ad.NeighborHood = address.NeighborHood;
                ad.Number   = address.Number;
                ad.Street   = address.Street;
                ad.ZipCode  = address.ZipCode;
                unitOfWork.IAddressRepository.Update(ad);
                if (updateHere)
                    unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RemoveAddress(string identifier, bool updateHere = true)
        {
            try
            {
                Expression<Func<Address, bool>> expression = x => x.AddressId == Guid.Parse(identifier);
                var ad = unitOfWork.IAddressRepository.FirstOrDefault(expression);
                if (ad == null)
                    throw new ArgumentNullException("Endereço não localizado");

                ad.DetachmentDate = DateTime.Now;
                unitOfWork.IAddressRepository.Update(ad);
                if (updateHere)
                    unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void UpdateContact(Contact contact, bool updateHere = true)
        {
            Expression<Func<Contact, bool>> expression = x => x.ContactId == contact.ContactId;
            var ct = unitOfWork.IContactRepository.FirstOrDefault(expression);
            if (ct == null)
                throw new ArgumentNullException("Contato não localizado");

            ct.CellPhone    = contact.CellPhone;
            ct.ContactName  = contact.ContactName;
            ct.Email = contact.Email;
            ct.Phone = contact.Phone;
            unitOfWork.IContactRepository.Update(ct);
            if (updateHere)
                unitOfWork.Commit();
        }

        public void RemoveContact(string identifier, bool updateHere = true)
        {
            Expression<Func<Contact, bool>> expression = x => x.ContactId == Guid.Parse(identifier);
            var ct = unitOfWork.IContactRepository.FirstOrDefault(expression);
            if (ct == null)
                throw new ArgumentNullException("Contato não localizado");
            ct.DetachmentDate = DateTime.Now;
            unitOfWork.IContactRepository.Update(ct);
            if (updateHere)
                unitOfWork.Commit();
        }

    }
}
