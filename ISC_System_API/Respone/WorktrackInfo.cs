using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class WorktrackInfo
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string CompanyName { get; set; }
        public string StudentName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public Nullable<byte> Status { get; set; }
        public string Note { get; set; }
    }
}
