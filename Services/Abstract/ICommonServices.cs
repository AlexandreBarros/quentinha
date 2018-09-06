namespace Services.Abstract
{
    using QuentinhaCarioca.Root;
    using Repository;
    using System.Collections.Generic;
    public interface ICommonServices
    {
        IUnitOfWork UnitOfWork { set; }
        List<State> GetStates();
        List<City> GetCities(int stateId);
        City GetCity(int cityId);
    }
}
