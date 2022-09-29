using System;
using System.Collections.Generic;

#nullable disable

namespace EmpOvertime1.Models
{
    public partial class ObjectType
    {
        public ObjectType()
        {
            Overtimes = new HashSet<Overtime>();
            Users = new HashSet<User>();
        }

        public int TypeId { get; set; }
        public string TypeValue { get; set; }
        public int? ObjectId { get; set; }

        public virtual ApplicationObjectType Object { get; set; }
        public virtual ICollection<Overtime> Overtimes { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
