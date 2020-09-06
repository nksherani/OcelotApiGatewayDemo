using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models.EFCoreModels
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}
