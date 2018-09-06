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
    public class EmployeeService : IEmployeeService
    {
        private ICommonServices cmSrv;
        private IAddressContactService acSrv;
        private ILegalUserService lSrv;

        #region HEADER 

        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public EmployeeService(ICommonServices cmSrv, IAddressContactService acSrv, ILegalUserService lServ)
        {
            this.acSrv = acSrv;
            this.cmSrv = cmSrv;
            this.lSrv = lServ;
            Setup();
        }

        #endregion

        public void Create(Employee user)
        {
            try
            {
                lSrv.UnitOfWork = unitOfWork;
                var legalUser = lSrv.Get(user.LegalUser.LegalUserId.ToString());
                if (legalUser == null)
                    throw new ArgumentNullException("LOJISTA NÃO LOCALIZADO");

                user.LegalUser = legalUser;
                user.Active = true;
                var uid = Guid.NewGuid();
                user.EmployeeId = uid;
                user.User.IndividualUserId = uid;
                user.User.CreationDate = DateTime.Now;
                user.User.NormalizedUserName = user.User.UserName.ToUpper();
                user.User.Contacts.ForEach(
                    (x) =>
                    {
                        x.ContactId = Guid.NewGuid();
                        x.CreationDate = DateTime.Now;
                    });

                unitOfWork.IEmployeeRepository.Add(user);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<EmployeeRequest> GetAll(int? indexPage, int pageSize, string identifier)
        {
            try
            {

                Expression<Func<Employee, bool>> expression = x => x.LegalUser.LegalUserId == Guid.Parse(identifier);
                string[] param = { "LegalUser" };
                return unitOfWork
                                        .IEmployeeRepository
                                        .All(indexPage.Value, pageSize,expression, param)
                                        .Select(x => new EmployeeRequest
                                        {
                                            FirstName = x.User.FirstName
                                            , LastName = x.User.LastName
                                            , UserName = x.User.UserName
                                            , CreationDate =  x.User.CreationDate
                                            , EmployeeId = x.EmployeeId
                                            , DetachmentDate = x.User.DetachmentDate
                                        }).ToList(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee Get(string identifier)
        {
            try
            {
                Expression<Func<Employee, bool>> expression = x => x.EmployeeId == Guid.Parse(identifier);
                string[] param = { "IndividualUser", "LegalUser" };

                Expression<Func<IndividualUser, bool>> iExpression = x => x.IndividualUserId == Guid.Parse(identifier);
                string[] related = { "Contacts", "Addresses" };

                return (from a in unitOfWork.IEmployeeRepository.All(expression, param)
                             join b in unitOfWork.IIndividualUserRepository.All(iExpression,related)
                             on a.EmployeeId equals b.IndividualUserId
                             select new Employee
                             {
                                 Active = a.Active
                                 , EmployeeId = Guid.Parse(identifier)
                                 , LegalUser = a.LegalUser
                                 , User = b
                             }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void Delete(string identifier)
        {
            try
            {
                Expression<Func<Employee, bool>> expression = x => x.EmployeeId == Guid.Parse(identifier);
                string[] related = { "User" };
                var employee = unitOfWork.IEmployeeRepository.FirstOrDefault(expression,related);
                if (employee == null)
                    throw new ArgumentNullException("FUNCIONÁRIO NÃO LOCALIZADO");

                employee.User.DetachmentDate = DateTime.Now;
                employee.Active = false;
                unitOfWork.IEmployeeRepository.Update(employee);
                unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Reactivate(string identifier)
        {
            try
            {
                Expression<Func<Employee, bool>> expression = x => x.EmployeeId == Guid.Parse(identifier);
                string[] related = { "User" };
                var employee = unitOfWork.IEmployeeRepository.FirstOrDefault(expression, related);
                if (employee == null)
                    throw new ArgumentNullException("FUNCIONÁRIO NÃO LOCALIZADO");

                employee.User.DetachmentDate = null;
                employee.Active = true;
                unitOfWork.IEmployeeRepository.Update(employee);
                unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
