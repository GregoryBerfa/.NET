using CorrectionPanier.Models;
using CorrectionPanier.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorrectionPanier.Controllers
{
    public class CategorieController : Controller
    {
        // GET: Categorie
        public ActionResult Index()
        {
            InitCategories();
            CategorieIndexVM viewModel = new CategorieIndexVM();
            viewModel.ListeCategories = Categorie.GetCateogries();
            return View(viewModel);
        }

        public ActionResult AddCategorie()
        {
            InitCategories();
            return View();
        }

        [HttpPost]
        public ActionResult AddCategoriePost(Categorie categorie)
        {
            InitCategories();
            if (categorie.Id == 0)
            {
                categorie.Save();
            }
            else
            {
                categorie.Update();
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult EditCategorie(int id)
        {
            InitCategories();
            EditCategorieVM viewModel = new EditCategorieVM();
            viewModel.categorie = Categorie.GetCategorieById(id);
            return View(viewModel);
        }
        private void InitCategories()
        {
            ViewBag.categories = Categorie.GetCateogries();
        }
    }
}