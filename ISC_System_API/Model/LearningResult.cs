using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model
{
    [Table("LEARNINGRESULT")] 
    public class LearningResult
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Nullable<int> CLASSID { get; set; }
        [Required]
        public Nullable<int> IDSTUDENT { get; set; }
        public Nullable<double> AVGSCORE { get; set; }

        public virtual Class CLASS { get; set; }
        public virtual Student STUDENT { get; set; }
    }
}
