using CorrectionPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrectionPanier.ViewModel
{
    public class CategorieIndexVM
    {
        public List<Categorie> ListeCategories;

        public CategorieIndexVM()
        {
            ListeCategories = new List<Categorie>();
        }
    }
}