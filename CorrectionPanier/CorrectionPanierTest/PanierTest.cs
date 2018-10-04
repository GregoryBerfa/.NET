using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorrectionPanier.Models;

namespace CorrectionPanierTest
{
    /// <summary>
    /// Description résumée pour PanierTest
    /// </summary>
    [TestClass]
    public class PanierTest
    {
        [TestMethod]
        public void CalculeTotal_Test()
        {
            List<Produit> ListeProduits = new List<Produit>();
            ListeProduits.Add(new Produit { Libelle = "fP1", Prix = 10 });
            ListeProduits.Add(new Produit { Libelle = "fP2", Prix = 20 });
            Assert.AreEqual(30, Panier.CalculeTotal(ListeProduits));
        }
    }
}
