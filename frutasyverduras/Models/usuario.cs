using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace frutasyverduras.Models
{
    public class usuario
    {
        
        public string nombre { get; set; }

        public string celular { get; set; }


        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string email { get; set; }

        public string ciudad { get; set; }

        public string fecharegistro { get; set; }
    }
}