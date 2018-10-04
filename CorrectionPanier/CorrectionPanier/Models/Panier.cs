using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrectionPanier.Models
{
    public class Panier
    {
        private int id;
        private List<Produit> listeproduits;

        public int Id { get => id; set => id = value; }
        public List<Produit> Listeproduits { get => listeproduits; set => listeproduits = value; }

        public static decimal CalculeTotal(List<Produit> listeproduits)
        {
            decimal total = 0;
            foreach(Produit p in listeproduits)
            {
                total += p.Prix;
            }
            return total;
        }
    }
}