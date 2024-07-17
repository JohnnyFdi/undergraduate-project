using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ClientRestApi.House_Config;
using ClientRestApi.Contracte;

namespace ClientRestApi
{

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }


        // Proprietatea de colecție de tip ConfigCasa
        public ICollection<ConfigCasa> ConfigCasas { get; set; }

        public ContracteApartamente ContracteApartamente { get; set; }
    }


}