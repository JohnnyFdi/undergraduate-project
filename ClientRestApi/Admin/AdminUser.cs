using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ClientRestApi.Contracte;

namespace ClientRestApi.Admin
{
    public class AdminUser
    {
        [Key]
        public int AdminId { get; set; }
        public string Role { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ContracteApartamente ContracteApartamente { get; set; }

    }
}
