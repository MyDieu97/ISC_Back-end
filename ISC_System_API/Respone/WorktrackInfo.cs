using ISC_System_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API.Respone
{
    public class WorktrackInfo
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public Nullable<byte> Status { get; set; }
        public string Note { get; set; }
        public virtual Company Company { get; set; }
        public virtual Student Student { get; set; }
        public virtual User User { get; set; }
    }
}
