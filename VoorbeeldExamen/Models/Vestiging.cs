using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VoorbeeldExamen.Models
{
    [Table("Vestiging")]
    public class Vestiging
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
    }
}