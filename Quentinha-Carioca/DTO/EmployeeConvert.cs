namespace QuentinhaCarioca.DTO
{
    using QuentinhaCarioca.Root;
    using QuentinhaCarioca.Root.ViewModel;

    public static class EmployeeConvert
    {
        public static Employee ConvertToEmployee(this EmployeeRequest model)
        {
            Employee entity = new Employee();
            var legalUser   = new LegalUser { LegalUserId = model.LegalUserId };
            var user        = new IndividualUser
            {
                FirstName       = model.FirstName
                , LastName      = model.LastName
                , PasswordHash  = model.PasswordHash
                , UserName      = model.UserName
                , Contacts     = new System.Collections.Generic.List<Contact>()
            };
            user.Contacts.AddRange(model.Contacts);
            entity.LegalUser = legalUser;
            entity.User = user;
            return entity;

        }

    }
}
