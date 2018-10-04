using CorrectionPanier.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CorrectionPanier.Models
{
    public class Produit
    {
        private int id;
        private string libelle;
        private decimal prix;
        private Categorie categorie;

        

        public int Id { get => id; set => id = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public Categorie Categorie { get => categorie; set => categorie = value; }

        public Produit()
        {
        }

        public Produit(int id, string libelle, decimal prix)
        {
            Id = id;
            Libelle = libelle;
            Prix = prix;
        }

        public void Save()
        {
            string requete = "insert into produit(libelle, prix) OUTPUT INSERTED.ID values(@libelle, @prix)";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            Connection.Instance.Open();
            command.Parameters.AddWithValue("@libelle", Libelle);
            command.Parameters.AddWithValue("@prix", Prix);
            Int32 lastInsertId = (Int32)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            Id = lastInsertId;
            SaveCategorie();
        }

        public void SaveCategorie()
        {
            string requete2 = "Insert into categorie_produit(idproduit, idcategorie) values (@idproduit, @idcategorie)";
            SqlCommand command2 = new SqlCommand(requete2, Connection.Instance);
            Connection.Instance.Open();
            command2.Parameters.AddWithValue("@idproduit", Id);
            command2.Parameters.AddWithValue("@idcategorie", Categorie.Id);
            command2.ExecuteNonQuery();
            command2.Dispose();
            Connection.Instance.Close();
        }

        public static List<Produit> GetProduits()
        {
            List<Produit> ListeProduits = new List<Produit>();
            string requete = "SELECT * FROM produit";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            Connection.Instance.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Produit p = new Produit(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetDecimal(2));
                ListeProduits.Add(p);
            }
            command.Dispose();
            Connection.Instance.Close();

            return ListeProduits;
        }

        public static List<Produit> GetProduitByCategorie(int id)
        {
            List<Produit> ListeProduits = new List<Produit>();
            List<int> Idproduits = new List<int>();
            string requete = "SELECT * FROM categorie_produit where idcategorie = @idcategorie";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            command.Parameters.AddWithValue("@idcategorie", id);
            Connection.Instance.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Idproduits.Add(dataReader.GetInt32(1));
            }
            command.Dispose();
            dataReader.Close();
            Connection.Instance.Close();
            foreach(int idproduit in Idproduits)
            {
                Produit p = GetProduitById(idproduit);
                ListeProduits.Add(p);
            }
            return ListeProduits;
        }

        public static Produit GetProduitById(int id)
        {
            string requete = "SELECT * FROM produit where id = @id";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            command.Parameters.AddWithValue("@id", id);
            Connection.Instance.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            Produit p = new Produit(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetDecimal(2));
            command.Dispose();
            dataReader.Close();
            Connection.Instance.Close();
            return p;
        }

       
    }
}