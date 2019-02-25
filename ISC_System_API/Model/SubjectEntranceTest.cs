using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("SUBJECTS_ENTRANCETESTS")]
    public class SubjectEntranceTest
    {
        [Key]
        public int SUBJECTID { get; set; }
        public int ENTRANCETESTID { get; set; }
        [Required]
        public Nullable<int> PASSINGSCORE { get; set; }

        public virtual EntranceTest ENTRANCETEST { get; set; }
        public virtual ExaminationSubject EXAMINATIONSUBJECT { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
