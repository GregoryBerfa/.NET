using CorrectionPanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrectionPanier.ViewModel
{
    public class PanierVM
    {
        public List<Produit> ListeProduits;
        public decimal Total;

        public PanierVM()
        {
            ListeProduits = new List<Produit>();
        }
    }
}