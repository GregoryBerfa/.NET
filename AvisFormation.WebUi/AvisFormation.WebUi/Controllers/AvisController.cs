using AvisFormation.Data;
using AvisFormation.Logic;
using AvisFormation.WebUi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        [Authorize]
        public ActionResult LaisserUnAvis(string nomSeo)
        {
            var vm = new LaisserUnAvisViewModel();
            vm.NomSeo = nomSeo;
            using (var context = new AvisEntities())
            {
                var formationEntity = context.Formation.FirstOrDefault(f => f.NomSeo == nomSeo);
                if (formationEntity == null)
                    return RedirectToAction("Accueil", "Home");
                vm.FormationName = formationEntity.Nom;
            }
             return View(vm);
        }
        // public ActionResult SaveComment(string commentaire,string nom, string note,string nomSeo)
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveComment(SaveCommentViewModel comment)
        {
            using (var context = new AvisEntities())
            {
                var formationEntity = context.Formation.FirstOrDefault(f => f.NomSeo == comment.NomSeo);
                if (formationEntity == null)
                    return RedirectToAction("Accueil", "Home");

                Avis nouvelAvis = new Avis();
                nouvelAvis.DateAvis = DateTime.Now;

                var userId = User.Identity.GetUserId();

                var mgerUnicite = new UniqueAvisVerification();
                if(!mgerUnicite.EstAutoriseACommenter(userId,formationEntity.Id))
                {
                    TempData["Message"] = "Désolé, un seul avis par formation par compte utilisateur !";
                    return RedirectToAction("DetailsFormation", "Formation", new { nomSeo = comment.NomSeo });
                }

                var mger = new PersonneManager();
                nouvelAvis.Nom = mger.GetNomFromUserId(userId);

                if (comment.Commentaire.Length > 500)
                    comment.Commentaire = comment.Commentaire.Substring(0, 500);

                nouvelAvis.Description = comment.Commentaire;
                nouvelAvis.UserId = userId;

                double dNote = 0;

                if (!double.TryParse(comment.Note, NumberStyles.Any, CultureInfo.InvariantCulture, out dNote))
                {
                    throw new Exception("Impossible de parser la note " + comment.Note);
                }

                nouvelAvis.Note = dNote;
                nouvelAvis.IdFormation = formationEntity.Id;
               
                context.Avis.Add(nouvelAvis);
                context.SaveChanges();
            }
            return RedirectToAction("DetailsFormation","Formation",new { nomSeo = comment.NomSeo });
        }
    }
}