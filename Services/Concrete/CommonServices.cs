namespace Services.Concrete
{
    using QuentinhaCarioca.Root;
    using Repository;
    using Services.Abstract;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class CommonServices : ICommonServices
    {
        #region HEADER 

        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public CommonServices()
        {
            Setup();
        }

        #endregion

        public List<State> GetStates()
        {
            try
            {
                return unitOfWork.IStateRepository.All().OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<City> GetCities(int stateId)
        {
            try
            {
                Expression<Func<City, bool>> expression = city => city.StateId == stateId;
                return unitOfWork.ICityRepository.All(expression).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public City GetCity(int cityId)
        {
            Expression<Func<City, bool>> expression = city => city.CityId == cityId;
            var result =  unitOfWork.ICityRepository.FirstOrDefault(expression);
            return result;
        }

    }
}
