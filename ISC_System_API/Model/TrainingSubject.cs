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
        public virtual Subject Subject { get; set; }

        public virtual SpecializedTraining SpecializedTraining { get; set; }
    }
}
