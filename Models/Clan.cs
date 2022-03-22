
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Clan")]
    public class Clan
    {
        

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Ime")]
        [DataType(DataType.Text)]
        public string Ime { get; set; }

        [Column("Prezime")]
        [DataType(DataType.Text)]
        public string Prezime { get; set; }

        [Column("Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        

        [Column("Lozinka")]
        [DataType(DataType.Text)]
        public string Lozinka { get; set; }

        public List<Termin> termini{get; set;}
        public Teretana teretana{get; set;}


         [Required]
        public bool trener{get; set;}





    }
}