using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("STUDENTS")]
    public class Student
    {
        [Key]
        [Column("IDSTUDENT")]
        public int Id { get; set; }

        [Column("UNIVERSITYID")]
        public Nullable<int> UniverId { get; set; }

        public Nullable<int> MAJORID { get; set; }

        public Nullable<int> USERID { get; set; }

        public Nullable<bool> CERTIFICATION { get; set; }
        
        [Column("DATEREADYTOWORK")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> READYWORKDATE { get; set; }

        [Required]
        public Nullable<bool> DEPOSITS { get; set; }

        public virtual ICollection<LearningResult> LEARNINGRESULTS { get; set; }

        [ForeignKey("MAJORID")]
        public virtual Major MAJOR { get; set; }

        [ForeignKey("UniverId")]
        public virtual University UNIVERSITY { get; set; }

        [ForeignKey("USERID")]
        public virtual User USER { get; set; }

        public virtual ICollection<Worktrack> WORKTRACKS { get; set; }
    }

    public class StudentInfo
    {
        public int Id { get; set; }

        public Nullable<int> USERID { get; set; }

        public Nullable<bool> CERTIFICATION { get; set; }

        [Column("DATEREADYTOWORK")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> READYWORKDATE { get; set; }

        [Required]
        public Nullable<bool> DEPOSITS { get; set; }

        public virtual Major MAJOR { get; set; }

        public virtual University UNIVERSITY { get; set; }

        public virtual User USER { get; set; }
    }
}
