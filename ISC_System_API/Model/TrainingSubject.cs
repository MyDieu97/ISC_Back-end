using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("TRAINING_SUBJECT")]
    public class TrainingSubject
    {
        public int SubjectId { get; set; }
        public int TrainingId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject SUBJECTS { get; set; }

        [ForeignKey("TrainingId")]
        public virtual SpecializedTraining SPECIALIZETRAININGS { get; set; }
    }
}
