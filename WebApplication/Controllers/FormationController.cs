using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult ToutesLesFormations()
        {
            List<Formation> listFormations = new List<Formation>();
            using (var context = new WebApEntities())
            {
                listFormations = context.Formation.ToList();
            }
            return View(listFormations);
        }

        public ActionResult DetailsFormation(string nomSeo)
        {
            var vm = new FormationAvisViewModel();
            using (var context = new WebApEntities())
            {
                var formationEntity = context.Formation.Where(f => f.NomSeo == nomSeo).FirstOrDefault();
                if(formationEntity == null)
                {
                    return RedirectToAction("Accueil", "Home");
                }
                vm.FormationNom = formationEntity.Nom;
                vm.FormationDescription = formationEntity.Description;
                vm.FormationNomSeo = nomSeo;
                vm.FormationUrl = formationEntity.Url;
                vm.Note = formationEntity.Avis.Average(a => a.Note);
                vm.NombreAvis = formationEntity.Avis.Count;
                vm.Avis = formationEntity.Avis.ToList();

            }

            return View(vm);
        }
    }
}