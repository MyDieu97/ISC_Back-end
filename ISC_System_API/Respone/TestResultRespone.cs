using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class TestResultRespone
    {
        public int TestResultId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Score { get; set; }
        public string SubjectName { get; set; }
        public DateTime TestDate { get; set; }
        public string CourseName { get; set; }
    }
}
