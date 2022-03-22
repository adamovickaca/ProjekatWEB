using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Termin")]
    public class Termin
    {
    
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Vreme")]
        public DateTime Vreme{get;set;}

        [Column("Dan")]
        public string Dan { get; set; }

         [Column("SlobodnaMesta")]
        public int SlobodnaMesta{get;set;}

        [Column("Zauzeto")]
        public Boolean Zauzeto{get;set;}

        [JsonIgnore]
        public Clan trener{get; set;}
        
        [JsonIgnore]
        public Teretana teretana{get; set;}

        [JsonIgnore]
        public Trening trening{get;set;}

        //[JsonIgnore]
         //public List<Clan> clan{get; set;}

    











    }
}
