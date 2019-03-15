using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class LearningResultInfo
    {
        public int Id { get; set; }
        public Nullable<double> AVGSCORE { get; set; }
        public int ClassId { get; set; }
        public int StudenId { get; set; }
        public string ClassName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
    }
}
