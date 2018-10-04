using CorrectionPanier.Models;
using CorrectionPanier.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorrectionPanier.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Produit
        public ActionResult Index()
        {
            InitCategories();
            ProduitIndexVM viewModel = new ProduitIndexVM();
            viewModel.ListeProduits = Produit.GetProduits();
            return View(viewModel);
        }
        public ActionResult GetByCategorie(int id)
        {
            InitCategories();
            ProduitIndexVM viewModel = new ProduitIndexVM();
            viewModel.ListeProduits = Produit.GetProduitByCategorie(id);
            return View("Index",viewModel);
        }

        public ActionResult AddProduit()
        {
            InitCategories();
            AddProduitVM viewModel = new AddProduitVM();
            viewModel.ListeCateogries = Categorie.GetCateogries(); 
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddProduitPost([Bind(Include ="Libelle, Prix")]Produit produit, int categorie)
        {
            InitCategories();
            produit.Categorie = Categorie.GetCategorieById(categorie);
            produit.Save();
            return RedirectToAction("Index");
        }

        private void InitCategories()
        {
            ViewBag.categories = Categorie.GetCateogries();
        }

        public ActionResult AddPanier(int id)
        {
            Produit p = Produit.GetProduitById(id);
            HttpCookie cookie = Request.Cookies["panier"];
            if(cookie == null)
            {
                cookie = new HttpCookie("panier");
                List<Produit> produitPanier = new List<Produit>();
                produitPanier.Add(p);
                cookie["listeproduits"] = JsonConvert.SerializeObject(produitPanier);
            }
            else
            {
                List<Produit> produitPanier = JsonConvert.DeserializeObject<List<Produit>>(cookie["listeproduits"]);
                produitPanier.Add(p);
                cookie["listeproduits"] = JsonConvert.SerializeObject(produitPanier);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Panier");
        }

        public ActionResult Panier()
        {
            InitCategories();
            PanierVM viewModel = new PanierVM();
            HttpCookie cookie = Request.Cookies["panier"];
            if (cookie != null)
            {
                viewModel.ListeProduits = JsonConvert.DeserializeObject<List<Produit>>(cookie["listeproduits"]);
                viewModel.Total = Models.Panier.CalculeTotal(viewModel.ListeProduits);
            }
            return View(viewModel);
        }
    }
}