using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("CLASSES")]
    public class Class
    {
        [Key]
        [Column("CLASSID")]
        public int Id { get; set; }
        [Required]
        public Nullable<int> COURSEID { get; set; }
        public Nullable<int> SUBJECTID { get; set; }
        [Column("CLASSNAME")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column("PERCENTBANNEDTEST")] 
        public Nullable<double> PercentBan { get; set; } 
        public Nullable<double> PASSINGSCORE { get; set; }
        public virtual ICollection<LearningResult> LEARNINGRESULTs { get; set; }
        public virtual Cours COURS { get; set; }
        public virtual Subject SUBJECT { get; set; }
        public virtual ICollection<LecturerClasses> LECTURER_CLASSES { get; set; }
    }
}
