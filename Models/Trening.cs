using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
[Table("Trening")]
    public class Trening
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        [DataType(DataType.Text)]
        public string Naziv { get; set; }

         [Column("Trajanje")]
        public int Trajanje { get; set; }

        [Required]
		public string SlikaPath { get; set; }

        [Required]
		[MaxLength(300)]
		public string Opis { get; set; }


        [JsonIgnore]
        public List<Termin> termini { get; set; }
        
        [JsonIgnore]
        public Vrsta vrsta { get; set; }


    }
}

