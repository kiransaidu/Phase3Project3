using System;
using System.Collections.Generic;

namespace Phase3Project3.Models
{
    public partial class Class
    {
        public Class()
        {
            Student1s = new HashSet<Student1>();
        }

        public int ClassId { get; set; }
        public string? ClassName { get; set; }

        public virtual ICollection<Student1> Student1s { get; set; }
    }
}
