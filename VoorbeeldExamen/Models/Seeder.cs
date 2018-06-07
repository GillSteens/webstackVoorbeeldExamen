using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VoorbeeldExamen.Models
{
    public class Seeder : DropCreateDatabaseAlways<VBEXDBContext>
    {
        protected override void Seed(VBEXDBContext context)
        {
            

            Vestiging v1 = new Vestiging { Naam = "Design & Technologie" };
            Vestiging v2 = new Vestiging { Naam = "Rits" };
            Vestiging v3 = new Vestiging { Naam = "MMM" };

            context.Vestigings.Add(v1);
            context.Vestigings.Add(v2);
            context.Vestigings.Add(v3);

            Personeel p1 = new Personeel { Username = "SS", Voornaam = "Steven", Achternaam = "Stillekes", Wachtwoord = "admin", WachtwoordControle = "admin" };
            Personeel p2 = new Personeel { Username = "AA", Voornaam = "Alex", Achternaam = "Anus", Wachtwoord = "admin", WachtwoordControle = "admin" };
            Personeel p3 = new Personeel { Username = "KK", Voornaam = "Karel", Achternaam = "Kaka", Wachtwoord = "admin", WachtwoordControle = "admin" };

            p1.Vestiging = v1;
            p2.Vestiging = v2;
            p3.Vestiging = v3;

            context.Personeels.Add(p1);
            context.Personeels.Add(p2);
            context.Personeels.Add(p3);

            Project pr1 = new Project { ProjectNaam = "PROJ_BE01", Status = Project.EStatus.AANGEMAAKT, HuidigBudget = 9999 };
            Project pr2 = new Project { ProjectNaam = "PROJ_BE02", Status = Project.EStatus.BEEINDIGD, HuidigBudget = 8888 };
            Project pr3 = new Project { ProjectNaam = "PROJ_BE03", Status = Project.EStatus.BEVROREN, HuidigBudget = 7777 };
            Project pr4 = new Project { ProjectNaam = "PROJ_BE04", Status = Project.EStatus.BEZIG, HuidigBudget = 6666 };
            Project pr5 = new Project { ProjectNaam = "PROJ_BE05", Status = Project.EStatus.OPSTART, HuidigBudget = 5555 };

            pr1.ProjectLeden = new List<Personeel> {p1,p2,p3 };
            pr2.ProjectLeden = new List<Personeel> {p1 };
            pr3.ProjectLeden = new List<Personeel> {p1,p2 };
            pr4.ProjectLeden = new List<Personeel> {p2,p3 };
            pr5.ProjectLeden = new List<Personeel> {p3 };

            context.Projects.Add(pr1);
            context.Projects.Add(pr2);
            context.Projects.Add(pr3);
            context.Projects.Add(pr4);
            context.Projects.Add(pr5);
            

            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            base.Seed(context);
        }
    }
}