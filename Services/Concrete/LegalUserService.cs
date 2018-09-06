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

    public class LegalUserService : ILegalUserService
    {
        private ICommonServices cmSrv;
        private IAddressContactService acSrv;

        #region HEADER 

        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork { set => unitOfWork = value; }

        private void Setup() => unitOfWork = unitOfWork ?? new UnitOfWork();

        public LegalUserService(ICommonServices cmSrv, IAddressContactService acSrv)
        {
            Setup();
            this.acSrv = acSrv;
            this.cmSrv = cmSrv;
        }

        #endregion

        #region LEGALUSER
        public LegalUser Create(LegalUser entity)
        {
            try
            {
                entity.LegalUserId              = Guid.NewGuid();
                entity.NormalizedLegalName      = entity.LegalName.ToUpper();
                entity.NormalizedExhibitionName = entity.ExhibitionName.ToUpper();
                entity.CreationDate = DateTime.Now;

                entity.Employees.ForEach((x) =>
                {
                    x.User.IndividualUserId = Guid.NewGuid();
                    x.EmployeeId        = x.User.IndividualUserId;
                    x.User.CreationDate = DateTime.Now;
                    x.User.FirstName    = x.User.UserName;
                    x.User.LastName     = x.User.UserName;
                    x.User.NormalizedUserName = x.User.UserName.ToUpper();
                    x.LegalUser         = entity;
                    x.User.Contacts.First().ContactId       = Guid.NewGuid();
                    x.User.Contacts.First().CreationDate    = DateTime.Now;
                    unitOfWork.IEmployeeRepository.Add(x);
                });

                entity.Settings.LegalUser = entity;
                entity.Settings.LegalUserSettingsId = Guid.NewGuid();
                unitOfWork.ILegalUserSettingsRepository.Add(entity.Settings);

                cmSrv.UnitOfWork = unitOfWork;
                acSrv.UnitOfWork = unitOfWork;

                var city = cmSrv.GetCity(entity.Addresses.First().City.CityId);
                unitOfWork.ICityRepository.Attach(city);
                entity.Addresses.ForEach(
                    (x) =>
                    {
                        x.City = city;
                        x.AddressId = Guid.NewGuid();
                        x.CreationDate = DateTime.Now;
                    });

                entity.Contacts.First().ContactId = Guid.NewGuid();
                entity.Contacts.First().CreationDate = DateTime.Now;
                
                int classLength = entity.Items["Items"].Count;
                if (classLength > 0)
                {
                    for (int i = 0; i < classLength; i++)
                    {
                        var classe = GetRestaurantClass(entity.Items["Items"][i].ToString());
                        unitOfWork.ILegalUserRestaurantClassesRepository.Add(new LegalUserRestaurantClasses { Class = classe, LegalUser = entity, LegalUserRestaurantClassesId = Guid.NewGuid() });

                    }
                }
                unitOfWork.ILegalUserRepository.Add(entity);
                unitOfWork.Commit();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Edit(LegalUser entity)
        {
            try
            {
                Expression<Func<LegalUser, bool>> expression = x => x.LegalUserId == entity.LegalUserId;
                string[] related = { "Addresses", "Contacts" };
                var legalUser = unitOfWork.ILegalUserRepository.FirstOrDefault(expression, related);
                if (legalUser == null)
                    throw new ArgumentNullException("Registro não localizado");

                legalUser.Active = entity.Active;
                legalUser.CNPJ = entity.CNPJ;
                legalUser.ExhibitionName = entity.ExhibitionName;
                legalUser.InscEst = entity.InscEst;
                legalUser.InscMun = entity.InscMun;
                legalUser.LegalName = entity.LegalName;
                legalUser.NormalizedExhibitionName = entity.ExhibitionName.ToUpper();
                legalUser.NormalizedLegalName = entity.LegalName.ToUpper();
                legalUser.UrlData = entity.UrlData;

                acSrv.UnitOfWork = unitOfWork;
                if (entity.Contacts != null && entity.Contacts.Count > 0)
                {
                    var toAdd = entity.Contacts.Except(legalUser.Contacts, new ContactComparer()).ToList();
                    var toUpdate = entity.Contacts.Intersect(legalUser.Contacts, new ContactComparer()).ToList();
                    var toExclude = legalUser.Contacts.Except(entity.Contacts, new ContactComparer()).ToList();

                    toAdd.ForEach(
                        (x) =>
                        {
                            x.ContactId = Guid.NewGuid();
                            x.CreationDate = DateTime.Now;
                            legalUser.Contacts.Add(x);
                        });
                    toUpdate.ForEach((x) => { acSrv.UpdateContact(x, false); });
                    toExclude.ForEach(
                        (x) => { acSrv.RemoveContact(x.ContactId.ToString(), false); });
                }
                if (entity.Addresses != null && entity.Addresses.Count > 0)
                {
                    var toAdd = entity.Addresses.Except(legalUser.Addresses, new AddressComparer()).ToList();
                    var toUpdate = entity.Addresses.Intersect(legalUser.Addresses, new AddressComparer()).ToList();
                    var toExclude = legalUser.Addresses.Except(entity.Addresses, new AddressComparer()).ToList();
                    cmSrv.UnitOfWork = unitOfWork;
                    toAdd.ForEach(
                        (x) =>
                        {
                            var city = cmSrv.GetCity(x.City.CityId);
                            x.AddressId = Guid.NewGuid();
                            x.CreationDate = DateTime.Now;
                            x.City = city;
                            legalUser.Addresses.Add(x);
                        });
                    toUpdate.ForEach((x) => { acSrv.UpdateAddress(x, false); });
                    toExclude.ForEach((x) => { acSrv.RemoveAddress(x.AddressId.ToString(), false); });
                }
                unitOfWork.ILegalUserRepository.Update(legalUser);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<LegalUserResponse> GetAll(int? indexPage, int pageSize)
        {
            try
            {
                string[] related = { "Addresses", "Contacts", "Reviews" };
                return unitOfWork.ILegalUserRepository.All(indexPage.Value, pageSize, related).Select(x => new LegalUserResponse
                {
                    LegalUserId = x.LegalUserId
                    ,LegalName = x.LegalName
                    ,ExhibitionName = x.ExhibitionName
                    ,CNPJ = x.CNPJ
                    ,Active = x.Active
                    ,Logo = x.UrlData
                    , Address = $"{x.Addresses.First().Street}, {x.Addresses.First().Number} , {x.Addresses.First().AddOn}"
                    , Contact = $"Tel:{x.Contacts.First().Phone}, Cel:{x.Contacts.First().CellPhone} , E-mail:{x.Contacts.First().Email}"
                    , Reviews = x.Reviews != null && x.Reviews.Count > 0 ? (x.Reviews.Sum(y => y.Review)/x.Reviews.Count()).ToString() : "0"
                    ,CreationDate = x.CreationDate
                    ,DetachmentDate = x.DetachmentDate
                }).ToList();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LegalUser Get(string identifier)
        {
            try
            {
                string[] related = { "Addresses", "Contacts", "Employees", "Classes" };
                Expression<Func<LegalUser, bool>> expression = x => x.LegalUserId == Guid.Parse(identifier);
                var legalUser = unitOfWork.ILegalUserRepository.FirstOrDefault(expression, related);
                if (legalUser != null)
                {
                    acSrv.UnitOfWork = unitOfWork;
                    legalUser.Addresses.ForEach((x) =>
                    {
                        x = acSrv.GetAddress(x.AddressId.ToString());
                    });
                }
                return legalUser;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Remove(string identifier)
        {
            try
            {
                Expression<Func<LegalUser, bool>> expression = x => x.LegalUserId == Guid.Parse(identifier);
                var legalUser = unitOfWork.ILegalUserRepository.FirstOrDefault(expression);
                if (legalUser == null)
                    throw new ArgumentNullException("LOJISTA NÃO LOCALIZADO");

                legalUser.DetachmentDate = DateTime.Now;
                unitOfWork.ILegalUserRepository.Update(legalUser);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        #endregion
        
        #region LEGALUSERSETTINGS
        public void CreateLegalSettings(LegalUserSettings entity)
        {
            try
            {
                var legalUser = Get(entity.LegalUser.LegalUserId.ToString());
                if (legalUser == null)
                    throw new ArgumentNullException("LOJISTA NÃO LOCALIZADO");

                entity.LegalUser = legalUser;
                entity.LegalUserSettingsId = Guid.NewGuid();
                unitOfWork.ILegalUserSettingsRepository.Add(entity);
                unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LegalUserSettings GetLegalUserSettings(string identifier)
        {
            try
            {
                Expression<Func<LegalUserSettings, bool>> expression = x => x.LegalUser.LegalUserId == Guid.Parse(identifier);
                string[] related = { "LegalUser" };
                return unitOfWork.ILegalUserSettingsRepository.FirstOrDefault(expression, related);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditLegalSettings(LegalUserSettings entity)
        {
            try
            {
                string[] related = { "LegalUser" };
                Expression<Func<LegalUserSettings, bool>> expression = x => x.LegalUserSettingsId == entity.LegalUserSettingsId;
                var settings = unitOfWork.ILegalUserSettingsRepository.FirstOrDefault(expression, related);
                if (settings == null)
                    throw new ArgumentNullException("CONFIGURAÇÃO NÃO LOCALIZADA");

                settings.DeliveryCoust = entity.DeliveryCoust;
                settings.FridayEndHour = entity.FridayEndHour;
                settings.FridayIsWorkDay = entity.FridayIsWorkDay;
                settings.FridayStartHour = entity.FridayStartHour;
                settings.IsOpen = entity.IsOpen;
                settings.MondayEndHour = entity.MondayEndHour;
                settings.MondayIsWorkDay = entity.MondayIsWorkDay;
                settings.MondayStartHour = entity.MondayStartHour;
                settings.SaturdayEndHour = entity.SaturdayEndHour;
                settings.SaturdayIsWorkDay = entity.SaturdayIsWorkDay;
                settings.SaturdayStartHour = entity.SaturdayStartHour;
                settings.SundayEndHour = entity.SundayEndHour;
                settings.SundayIsWorkDay = entity.SundayIsWorkDay;
                settings.SundayStartHour = entity.SundayStartHour;
                settings.ThursdayEndHour = entity.ThursdayEndHour;
                settings.ThursdayIsWorkDay = entity.ThursdayIsWorkDay;
                settings.ThursdayStartHour = entity.ThursdayStartHour;
                settings.TuesdayEndHour = entity.TuesdayEndHour;
                settings.TuesdayIsWorkDay = entity.TuesdayIsWorkDay;
                settings.TuesdayStartHour = entity.TuesdayStartHour;
                settings.WednesdayEndHour = entity.WednesdayEndHour;
                settings.WednesdayIsWorkDay = entity.WednesdayIsWorkDay;
                settings.WednesdayStartHour = entity.WednesdayStartHour;

                unitOfWork.ILegalUserSettingsRepository.Update(settings);
                unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region RESTAURANTE CLASS

        public List<RestaurantClasses> RestaurantClassList()
        {
            try
            {
                return unitOfWork.IResturantClassesRepository.All().OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public RestaurantClasses GetRestaurantClass(string identifier)
        {
            try
            {
                Expression<Func<RestaurantClasses, bool>> expression = x => x.RestaurantClassesId == Guid.Parse(identifier);
                return unitOfWork.IResturantClassesRepository.FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion


    }
}
