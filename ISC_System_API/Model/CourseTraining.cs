using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("COURSE_TRAINING")]
    public class CourseTraining
    {
        public int CourseId { get; set; }
        public int TrainingId { get; set; }

        [ForeignKey("CourseId")]
        public virtual ICollection<Course> COURSES { get; set; }
        [ForeignKey("TrainingId")]
        public virtual SpecializedTraining SPECIALIZEDTRAININGS { get; set; }

    }
}
