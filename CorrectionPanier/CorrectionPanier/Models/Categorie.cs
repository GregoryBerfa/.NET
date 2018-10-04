using CorrectionPanier.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CorrectionPanier.Models
{
    public class Categorie
    {
        private int id;
        private string label;

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }

        public Categorie()
        {

        }

        public Categorie(int id, string label)
        {
            Id = id;
            Label = label;
        }

        public void Save()
        {
            string requete = "insert into categorie(label) OUTPUT INSERTED.ID values(@label)";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            Connection.Instance.Open();
            command.Parameters.AddWithValue("@label", Label);
            Int32 lastInsertId = (Int32)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            Id = lastInsertId;
        }

        public void Update()
        {
            string requete = "UPDATE categorie set label = @label where id=@id";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            Connection.Instance.Open();
            command.Parameters.AddWithValue("@label", Label);
            command.Parameters.AddWithValue("@id", Id);
            command.ExecuteNonQuery();
            command.Dispose();
            Connection.Instance.Close();
          
        }

        public static List<Categorie> GetCateogries()
        {
            List<Categorie> ListeCategories = new List<Categorie>();
            string requete = "SELECT * FROM categorie";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            Connection.Instance.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Categorie c = new Categorie(dataReader.GetInt32(0), dataReader.GetString(1));
                ListeCategories.Add(c);
            }
            command.Dispose();
            Connection.Instance.Close();
            return ListeCategories;
        }

        public static Categorie GetCategorieById(int id)
        {
            string requete = "SELECT * FROM categorie where id = @id";
            SqlCommand command = new SqlCommand(requete, Connection.Instance);
            command.Parameters.AddWithValue("@id", id);
            Connection.Instance.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            Categorie c = new Categorie(dataReader.GetInt32(0), dataReader.GetString(1));
            command.Dispose();
            Connection.Instance.Close();
            return c;
        }
    }
}