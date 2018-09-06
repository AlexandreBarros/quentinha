namespace Services.Abstract
{
    using QuentinhaCarioca.Root;
    using Repository;
    using System.Collections.Generic;
    public interface IAddressContactService
    {
        IUnitOfWork UnitOfWork { set; }
        Address GetAddress(string identifier);
        void UpdateAddress(Address address, bool updateHere = true);

        void RemoveAddress(string identifier, bool updateHere = true);

        void UpdateContact(Contact contact, bool updateHere = true);
        void RemoveContact(string identifier, bool updateHere = true);
    }
}
