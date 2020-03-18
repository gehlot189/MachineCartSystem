using System;

namespace MachineCartSystem.Entity.UserInfo
{
    public class UserDetailVM
    {
        public long UserDetaildId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
