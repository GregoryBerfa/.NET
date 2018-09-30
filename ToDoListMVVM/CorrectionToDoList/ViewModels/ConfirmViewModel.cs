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
    class ConfirmViewModel : ViewModelBase
    {
        private string listeSource;
        private string listeCible;
        private ObservableCollection<string> listeListe;

        public Tache tache;
        public Window window;

        public string ListeSource { get => listeSource; set { listeSource = value; RaisePropertyChanged(); } }
        public string ListeCible { get => listeCible; set { listeCible = value; RaisePropertyChanged(); } }

        public ICommand CommandConfirm { get; set; }
        public ObservableCollection<string> ListeListe { get => listeListe; set => listeListe = value; }

        public ConfirmViewModel()
        {
            ListeListe = Tache.getListes();
            CommandConfirm = new RelayCommand(CommandConfirmMethod);
        }

        public void CommandConfirmMethod()
        {
            tache.Delete(ListeSource);
            tache.Move(ListeCible);
            window.Close();
        }
    }
}
