namespace Services.Abstract
{
    using QuentinhaCarioca.Root;
    using QuentinhaCarioca.Root.ViewModel;
    using Repository;
    using System.Collections.Generic;
    public interface IIndividualUserService
    {
        IUnitOfWork UnitOfWork { set; }
        Customer Create(Customer entity);
        Customer Get(string identifier);
        List<Customer> GetAll(int pageIndex, int pageSize);
        Customer Edit(Customer entity);
    }
}
