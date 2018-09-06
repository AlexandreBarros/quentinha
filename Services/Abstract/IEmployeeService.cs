namespace Services.Abstract
{
    using QuentinhaCarioca.Root;
    using QuentinhaCarioca.Root.ViewModel;
    using Repository;
    using System.Collections.Generic;
    public interface IEmployeeService
    {
        IUnitOfWork UnitOfWork { set; }
        void Create(Employee user);
        List<EmployeeRequest> GetAll(int? indexPage, int pageSize, string identifier);
        Employee Get(string identifier);
        void Delete(string identifier);
        void Reactivate(string identifier);
    }
}
