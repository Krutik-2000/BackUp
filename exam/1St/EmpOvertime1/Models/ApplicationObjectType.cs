using System;
using System.Collections.Generic;

#nullable disable

namespace EmpOvertime1.Models
{
    public partial class ApplicationObjectType
    {
        public ApplicationObjectType()
        {
            ObjectTypes = new HashSet<ObjectType>();
        }

        public int ObjectId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ObjectType> ObjectTypes { get; set; }
    }
}
