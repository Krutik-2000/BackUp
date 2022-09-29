using System;
using System.Collections.Generic;

#nullable disable

namespace EMS.Models
{
    public partial class TypeOfObject
    {
        public TypeOfObject()
        {
            Attendances = new HashSet<Attendance>();
            PersonalDetailDepartmentNavigations = new HashSet<PersonalDetail>();
            PersonalDetailGenderNavigations = new HashSet<PersonalDetail>();
            PersonalDetailMaritalStatusNavigations = new HashSet<PersonalDetail>();
            PersonalDetailPostNavigations = new HashSet<PersonalDetail>();
            Users = new HashSet<User>();
        }

        public int TypeId { get; set; }
        public string Value { get; set; }
        public int? ObjectId { get; set; }

        public virtual ObjectType Object { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<PersonalDetail> PersonalDetailDepartmentNavigations { get; set; }
        public virtual ICollection<PersonalDetail> PersonalDetailGenderNavigations { get; set; }
        public virtual ICollection<PersonalDetail> PersonalDetailMaritalStatusNavigations { get; set; }
        public virtual ICollection<PersonalDetail> PersonalDetailPostNavigations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
