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
        public virtual Cours Cours { get; set; }

        public virtual SpecializedTraining SpecializedTraining { get; set; }
        
    }
}
