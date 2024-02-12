using System;
using System.Collections.Generic;

namespace Phase3Project3.Models
{
    public partial class Student1
    {
        public string? StudentName { get; set; }
        public int StudentRollNo { get; set; }
        public int? StudentMarks { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
