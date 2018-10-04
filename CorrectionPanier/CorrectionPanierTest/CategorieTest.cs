using System;
using System.Collections.Generic;
using CorrectionPanier.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrectionPanierTest
{
    [TestClass]
    public class CategorieTest
    {
        [TestMethod]
        public void GetCategorie_Test_Type()
        {
            Assert.IsInstanceOfType(Categorie.GetCateogries(), typeof(List<Categorie>));
        }

        [TestMethod]
        public void GetCategorie_Test()
        {
            List<Categorie> ListeCategorie = Categorie.GetCateogries();
            Assert.IsNotNull(ListeCategorie);
        }

        [TestMethod]
        public void GetCategorieById_Test()
        {
            Assert.IsNotNull(Categorie.GetCategorieById(1));
        }

        [TestMethod]
        public void GetCategorieById_Valeur_Test()
        {
            Assert.AreEqual("informatique", Categorie.GetCategorieById(1).Label);
        }

    }
}
