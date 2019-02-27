using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("EXAMINATIONSUBJECTS")]
    public class ExaminationSubject
    {
        [Key]
        [Column("SUBJECTID")]
        public int Id { get; set; }

        [Column("SUBJECTNAME")]
        public string Name { get; set; }

        public virtual ICollection<SubjectEntranceTest> SUBJECTS_ENTRANCETESTS { get; set; }
    }
}
