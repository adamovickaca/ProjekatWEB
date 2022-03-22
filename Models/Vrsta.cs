 using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
[Table("Vrsta")]
    public class Vrsta //grupni/indiv
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

         [Column("Naziv")]
        public string Naziv { get; set; }

        [JsonIgnore]
        public Teretana teretana{get; set;}

        public List<Trening> treninzi{get; set;}


    }
}
