using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VoorbeeldExamen.Models
{
    [Table("Personeel")]
    public class Personeel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required, DataType(DataType.Password)]
        public string Wachtwoord { get; set; }
        [NotMapped, Required, DataType(DataType.Password), Compare("Wachtwoord")]
        public string WachtwoordControle { get; set; }
        [ForeignKey("Vestiging")]
        public virtual int IdVestiging { get; set; }
        public virtual Vestiging Vestiging{ get; set; }
        public virtual List<Project> Projecten { get; set; }
    }
}