using System;
using System.Collections.Generic;

namespace Phase3Project3.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Student1s = new HashSet<Student1>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? TeacherName { get; set; }

        public virtual ICollection<Student1> Student1s { get; set; }
    }
}
