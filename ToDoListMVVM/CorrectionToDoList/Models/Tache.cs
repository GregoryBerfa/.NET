using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectionToDoList.Models
{
    public class Tache : ObservableObject
    {
        private string titre;
        private string description;
        private string priorite;


        public static ObservableCollection<Tache> ListeTacheAFaire = new ObservableCollection<Tache>();
        public static ObservableCollection<Tache> ListeTacheEnCours = new ObservableCollection<Tache>();
        public static ObservableCollection<Tache> ListeTacheTerminees = new ObservableCollection<Tache>();

        public Tache()
        {

        }

        public Tache(string titre, string description, string priorite)
        {
            Priorite = priorite ;
            Description = description ;
            Titre = titre;
        }

        public string Priorite { get => priorite; set { priorite = value; RaisePropertyChanged(); } }
        public string Description { get => description; set { description = value; RaisePropertyChanged(); } }
        public string Titre { get => titre; set { titre = value; RaisePropertyChanged(); } }

        public static ObservableCollection<string> getPriorities()
        {
            ObservableCollection<string> priorities = new ObservableCollection<string>() { "Faible", "Moyen", "Elevé"};
            return priorities;
        }

        public static ObservableCollection<string> getListes()
        {
            ObservableCollection<string> listes = new ObservableCollection<string>() { "afaire", "encours", "terminee" };
            return listes;
        }

        public void Save()
        {
            ListeTacheAFaire.Add(this);
        }

        public void Update(string titre, string description, string priorite)
        {
            Priorite = priorite;
            Description = description;
            Titre = titre;
        }

        public void Delete(string nomListe)
        {
            switch(nomListe)
            {
                case "encours":
                    ListeTacheEnCours.Remove(this);
                    break;
                case "afaire":
                    ListeTacheAFaire.Remove(this);
                    break;
                case "terminee":
                    ListeTacheTerminees.Remove(this);
                    break;

            }
        }
        public void Move(string nomListe)
        {
            switch (nomListe)
            {
                case "encours":
                    ListeTacheEnCours.Add(this);
                    break;
                case "afaire":
                    ListeTacheAFaire.Add(this);
                    break;
                case "terminee":
                    ListeTacheTerminees.Add(this);
                    break;

            }
        }

        public override string ToString()
        {
            return "Titre: " + Titre + "\n"+"Description: "+Description+"\n"+"Priorité : "+Priorite;
        }
    }
}
