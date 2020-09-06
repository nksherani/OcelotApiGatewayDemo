using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models.AccountViewModels
{
    public class ClientViewModel
    {
        [Required]
        public string client_id { get; set; }
        [Required]
        public string client_secret { get; set; }
    }
}
