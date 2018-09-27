using AvisFormation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logic
{
    public class UserPersonnalInfoManager
    {
        public void InsertPersonnalInfo(string id, string nom)
        {
            using (var context = new AvisEntities())
            {
               var personEntity = context.Personne.FirstOrDefault(p=>p.Id == id);
                if(personEntity == null)
                {
                    var p = new Personne();
                    p.Id = id;
                    p.Nom = nom;
                    context.Personne.Add(p);
                    context.SaveChanges();
                }
            }
        }

        public string GetNomFromId(string id)
        {
            using (var context = new AvisEntities())
            {
                var personEntity = context.Personne.FirstOrDefault(p => p.Id == id);
                if (personEntity == null)
                {
                    return "Anonyme";
                }
                return personEntity.Nom;

            }
        }
    }
}
