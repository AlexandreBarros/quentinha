namespace QuentinhaCarioca.Root
{
    using System;
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public IndividualUser User { get; set; }
        public LegalUser LegalUser { get; set; }
        public bool Active { get; set; }
    }
}
