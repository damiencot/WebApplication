using Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        public ActionResult LaisserUnAvis(string nomSeo)
        {
            var vm = new LaisserUnAvisViewModel();
            vm.NomSeo = nomSeo;
            using (var context = new WebApEntities())
            {
                var formationEntity = context.Formation.FirstOrDefault(f => f.NomSeo == nomSeo);
                if (formationEntity == null)
                {
                    return RedirectToAction("Accueil", "Home");
                }
                vm.FormationNom = formationEntity.Nom;
            }
            return View(vm);
        }

        //public ActionResult SaveComment(string commentaire, string nom, string note, string nomSeo)

        [HttpPost]
        public ActionResult SaveComment(SaveCommentViewModel comment)
        {
            Avis nouvelAvis = new Avis();
            nouvelAvis.DateAvis = DateTime.Now;
            nouvelAvis.Description = comment.Commentaire;
            nouvelAvis.Nom = comment.NomPersonne;

            double dnote = 0;

            if(!double.TryParse(comment.Note, NumberStyles.Any, CultureInfo.InvariantCulture, out dnote))
            {
                throw new Exception("Impossible de parser la note" + comment.Note);
            }
            nouvelAvis.Note = dnote; 
            using (var context = new WebApEntities())
            {

                var formationEntity = context.Formation.FirstOrDefault(f => f.NomSeo == comment.NomSeo);
                if (formationEntity == null)
                {
                    return RedirectToAction("Accueil", "Home");
                }
                nouvelAvis.IdFormation = formationEntity.Id;

                context.Avis.Add(nouvelAvis);
                context.SaveChanges();
            }

            return RedirectToAction("DetailsFormation", "Formation", new { nomSeo = comment.NomSeo });

        }
    }
}