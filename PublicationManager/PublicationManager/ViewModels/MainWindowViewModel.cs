using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PublicationManager.Infrastructure;
using PublicationManager.Interfaces;

namespace PublicationManager.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private INavigationManager navigationManager;

        public MainWindowViewModel(INavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;

            ShowPublicationsCommand = new RelayCommand(ShowPublications);
            ShowMediaCommand = new RelayCommand(ShowMedia);
        }

        private void ShowPublications()
        {
            navigationManager.NavigateTo(ViewNames.PublicationView);
        }

        private void ShowMedia()
        {
            navigationManager.NavigateTo(ViewNames.MediumView);
        }

        public ICommand ShowPublicationsCommand { get; set; }

        public ICommand ShowMediaCommand { get; set; }
    }
}
