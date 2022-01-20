using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Partners.Models
{
    public class Opgave
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("NAVN PÅ OPGAVE")]
        public string Navn { get; set; }
        [DisplayName("MIN. ALDER")]
        public int Min_alder { get; set; }
        [DisplayName("TILKNYTTER MEDARBEJDER")]
        public string Medarbejder { get; set; }
    }
}
