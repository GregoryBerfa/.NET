using CorrectionPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrectionPanier.ViewModel
{
    public class ProduitIndexVM
    {
        public List<Produit> ListeProduits;
        
        public ProduitIndexVM()
        {
            ListeProduits = new List<Produit>();
        }
    }
}