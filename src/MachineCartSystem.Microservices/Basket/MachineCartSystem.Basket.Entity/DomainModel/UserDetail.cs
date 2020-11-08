using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineCartSystem.Entity.DomainModel
{
    public partial class UserDetail
    {
        public long UserDetaildId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
