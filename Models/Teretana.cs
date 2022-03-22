using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Table("Teretana")]
    public class Teretana
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        [DataType(DataType.Text)]
        public string Naziv { get; set; }

        [Column("Adresa")]
        public string Adresa { get; set; }

        [Column("KontakTelefon")]
        public string KontakTelefon { get; set; }

        [Column("Email")]
        public string Email { get; set; }  
        
        public List<Vrsta> vrste { get; set; }
        public List<Clan> clanovi{get; set;}
        
        public List<Termin> termini{get; set;}



    }
}