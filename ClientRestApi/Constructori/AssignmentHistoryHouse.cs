using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Constructori
{
    public class AssignmentHistoryHouse
    {
        public int Id { get; set; }
        public int ConstructorCaseId { get; set; }
        public int? CasaId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Action { get; set; } // "assign" or "unassign"
        public string EstimatedTime { get; set; } // Adăugat pentru timpul estimat
    }
}
