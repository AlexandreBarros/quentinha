namespace QuentinhaCarioca.Root
{
    using System;
    public class UserRole
    {
        public Guid UserRoleId { get; set; }
        public Role Role { get; set; }
        public IndividualUser User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }

    }
}
