using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Constructori
{
    public class AssignmentHistory
    {
        public int Id { get; set; }
        public int ConstructorId { get; set; }
        public int? ProiectId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Action { get; set; } // "assign" or "unassign"
        public string EstimatedTime { get; set; } // Adăugat pentru timpul estimat
    }
}
