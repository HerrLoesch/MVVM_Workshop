using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using PublicationManager.MVVM;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class PublicationViewModel : ViewModelBase
    {
        private IPublicationRepository publicationRepository;
        private IEnumerable<Publication> publications;
        private Publication selectedPublication;
        private ICommand initializationCommand;

        public PublicationViewModel()
        {
            if (IsInDesignMode)
            {
                Publications = Randomizer<Publication>.Create(10);
                SelectedPublication = Publications.First();
            }
        }

        public PublicationViewModel(IPublicationRepository repository)
        {
            publicationRepository = repository;
            InitializationCommand = new RelayCommand(Initialize);
        }

        public ICommand InitializationCommand
        {
            get; set;
        }

        public void Initialize()
        {
            Publications = publicationRepository.GetAll();
            SelectedPublication = Publications.FirstOrDefault();
        }

        public IEnumerable<Publication> Publications
        {
            get { return publications; }
            set
            {
                Set(ref publications, value);
            }
        }

        public Publication SelectedPublication
        {
            get { return selectedPublication; }
            set
            {
                Set(ref selectedPublication, value);
            }
        }
    }
}