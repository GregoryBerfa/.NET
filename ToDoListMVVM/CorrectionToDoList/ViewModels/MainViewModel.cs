using CorrectionToDoList.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CorrectionToDoList.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private string titreTache;
        private string descriptionTache;
        private string prioriteTache;

        private Tache selectedTache;
        private ObservableCollection<string> listePriorite;

        private ObservableCollection<Tache> listeTacheAFaire;
        private ObservableCollection<Tache> listeTacheEnCours;
        private ObservableCollection<Tache> listeTacheTerminees;


        public string TitreTache { get => titreTache; set { titreTache = value; RaisePropertyChanged(); } }
        public string DescriptionTache { get => descriptionTache; set { descriptionTache = value; RaisePropertyChanged(); } }
        public string PrioriteTache { get => prioriteTache; set { prioriteTache = value; RaisePropertyChanged(); } }
        public ObservableCollection<string> ListePriorite { get => listePriorite; set => listePriorite = value; }
        public ObservableCollection<Tache> ListeTacheAFaire { get => listeTacheAFaire; set => listeTacheAFaire = value; }
        public ObservableCollection<Tache> ListeTacheEnCours { get => listeTacheEnCours; set => listeTacheEnCours = value; }
        public ObservableCollection<Tache> ListeTacheTerminees { get => listeTacheTerminees; set => listeTacheTerminees = value; }

        public ICommand CommandSave { get; set; }
        public ICommand CommandEdit { get; set; }
        public ICommand CommandDeleteAfaire { get; set; }
        public ICommand CommandDeleteEnCours { get; set; }
        public ICommand CommandDeleteTerminee { get; set; }
        public ICommand CommandDetail { get; set; }
        public ICommand CommandMoveFromAfaire { get; set; }
        public ICommand CommandMoveFromEnCours { get; set; }
        public ICommand CommandMoveFromTerminee { get; set; }

        public Tache SelectedTache { get => selectedTache; set { selectedTache = value; RaisePropertyChanged(); } }

        public MainViewModel()
        {
            ListePriorite = Tache.getPriorities();
            ListeTacheAFaire = Tache.ListeTacheAFaire;
            ListeTacheEnCours = Tache.ListeTacheEnCours;
            ListeTacheTerminees = Tache.ListeTacheTerminees;
            CommandSave = new RelayCommand<Tache>(CommandSaveMethod);
            CommandEdit = new RelayCommand<Tache>(CommandEditMethod);
            CommandDeleteAfaire = new RelayCommand<Tache>(CommandDeleteMethodAfaire);
            CommandDeleteEnCours = new RelayCommand<Tache>(CommandDeleteMethodEnCours);
            CommandDeleteTerminee = new RelayCommand<Tache>(CommandDeleteMethodTerminee);
            CommandDetail = new RelayCommand<Tache>(CommandDetailMethod);
            CommandMoveFromAfaire = new RelayCommand<Tache>(CommandMoveFromAfaireMethod);
            CommandMoveFromEnCours = new RelayCommand<Tache>(CommandMoveFromEnCoursMethod);
            CommandMoveFromTerminee = new RelayCommand<Tache>(CommandMoveFromTermineeMethod);
        }

        public void CommandSaveMethod(Tache tache)
        {
            if(tache == null)
            {
                Tache t = new Tache(TitreTache, DescriptionTache, PrioriteTache);
                t.Save();
            }
            else
            {
                tache.Update(TitreTache, DescriptionTache, PrioriteTache);
            }
            clear();
        }

        public void CommandEditMethod(Tache tache)
        {
            if(tache != null)
            {
                SelectedTache = tache;
                TitreTache = tache.Titre;
                DescriptionTache = tache.Description;
                PrioriteTache = tache.Priorite;
            }
            else
            {
                MessageBox.Show("Merci de choisir un element");
            }
           
        }
        public void CommandDeleteMethodAfaire(Tache tache)
        {
            deleteCommun(tache, "afaire");
        }

        public void CommandDeleteMethodEnCours(Tache tache)
        {
            deleteCommun(tache, "encours");
        }

        public void CommandDeleteMethodTerminee(Tache tache)
        {
            deleteCommun(tache, "terminee");
        }

        public void deleteCommun(Tache tache,string liste)
        {
            if (tache != null)
            {
                tache.Delete(liste);
            }
            else
            {
                MessageBox.Show("Merci de choisir un element");
            }
            clear();
            
        }

        public void CommandDetailMethod(Tache tache)
        {
            if(tache != null)
            {
                MessageBox.Show(tache.ToString());
            }
            else
            {
                MessageBox.Show("Merci de choisir un element");
            }
        }
        
        public void CommandMoveFromAfaireMethod(Tache tache)
        {
            OpenConfirm(tache, "afaire");
        }

        public void CommandMoveFromEnCoursMethod(Tache tache)
        {
            OpenConfirm(tache, "encours");
        }

        public void CommandMoveFromTermineeMethod(Tache tache)
        {
            OpenConfirm(tache, "terminee");
        }

        public void OpenConfirm(Tache tache, string liste)
        {
            
            if (tache != null)
            {
                ConfirmWindow window = new ConfirmWindow(tache, liste);
                window.Show();
            }
            else
            {
                MessageBox.Show("Merci de choisir un element");
            }
        }

        public void clear()
        {
            TitreTache = "";
            PrioriteTache = null;
            DescriptionTache = "";
            SelectedTache = null;
        }
    }
}
