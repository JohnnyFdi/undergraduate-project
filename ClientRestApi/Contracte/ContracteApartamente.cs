using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.Admin;

namespace ClientRestApi.Contracte
{
    public class ContracteApartamente
    {
        [Key]
        public int ContractApId { get; set; }
        public int AdminId { get; set; }

        public int UserId { get; set; }

        public int ApartamentId { get; set; }

        public DateTime DataSemnarii { get; set; }

        public int Costuri { get; set; }

        public int PretVanzare { get; set; }

        public AdminUser AdminUser { get; set; }

        public User User { get; set; }

        public Apartament Apartament { get; set; }
    }
}
