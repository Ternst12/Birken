using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Partners.Models
{
    public class Medarbejder
    {   
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public string By { get; set; }
        public string Postnummer { get; set; }
        public string Telefonnummer { get; set; }
        [DisplayName("E-mail")]
        public string E_mail { get; set; }
        public int Alder { get; set; }
    }
}
