using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VoorbeeldExamen.Models
{
    [Table("Project")]
    public class Project
    {
        public enum EStatus { AANGEMAAKT, OPSTART, BEZIG, BEEINDIGD, BEVROREN}
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None), ProjValidation]
        public string ProjectNaam { get; set; }
        public EStatus Status { get; set; }
        public double HuidigBudget { get; set; }
        public virtual List<Personeel>  ProjectLeden { get; set; }
        
    }
}