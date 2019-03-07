using ISC_System_API.Respone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Model.Respone
{
    public class SpecTrainingInfo
    {
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public Int16? NumberofWeeks { get; set; }
        public List<Subject>  listSubjects { get; set; }
    }
}
