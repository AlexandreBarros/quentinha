namespace Services.Concrete
{
    using QuentinhaCarioca.Root;
    using Repository;
    using Services.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    public class OrderService
    {
        #region HEADER 

        private readonly ILegalUserService legalUserSrv;
        private readonly IIndividualUserService userSrv;  
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public OrderService(ILegalUserService lserv, IIndividualUserService iserv)
        {
            this.legalUserSrv = lserv;
            this.userSrv = iserv;
            Setup();
        }

        #endregion

        public Order Create(Order entity)
        {
            {
                entity.CreationDate = DateTime.Now;
                entity.OrderId = Guid.NewGuid();

                return new Order();
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }



    }
}
