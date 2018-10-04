using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorrectionPanier.Models;

namespace CorrectionPanierTest
{
    /// <summary>
    /// Description résumée pour ProduitTest
    /// </summary>
    [TestClass]
    public class ProduitTest
    {
        [TestMethod]
        public void GetProduits_Test()
        {
            Assert.IsInstanceOfType(Produit.GetProduits(), typeof(List<Produit>));
        }

        [TestMethod]
        public void GetProduits_Valeur_Test()
        {
            Assert.IsNotNull(Produit.GetProduits());
        }

        [TestMethod]
        public void GetProduitByCategorie_Valeur_categorie2_produit1_Test()
        {
            Assert.AreEqual("p1", Produit.GetProduitByCategorie(2)[0].Libelle);
        }

        [TestMethod]
        public void GetProduitById_Test_valeur_produit1()
        {
            Assert.AreEqual("p1", Produit.GetProduitById(1).Libelle);
        }
    }
}
