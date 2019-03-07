using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("SPECIALIZEDTRAININGS")]
    public class SpecializedTraining
    {
        [Key]
        [Column("TRAININGID")]
        public int TrainingId { get; set; }
        [Column("TRAININGNAME")]
        [StringLength(200)]
        public string Name { get; set; }

        [Column("NUMBERWEEK")]
        [Range(1,99)]
        public Nullable<short> NumberofWeeks { get; set; }       
    }
}
