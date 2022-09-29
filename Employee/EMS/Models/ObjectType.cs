using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Models
{
    public partial class ObjectType
    {
        public ObjectType()
        {
            TypeOfObjects = new HashSet<TypeOfObject>();
        }

        public int ObjectId { get; set; }
        public string Value { get; set; }

        public virtual ICollection<TypeOfObject> TypeOfObjects { get; set; }
    }
}
