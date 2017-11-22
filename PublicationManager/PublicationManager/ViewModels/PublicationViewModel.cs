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
        private IEnumerable<PublicationEntityViewModel> publications;
        private PublicationEntityViewModel selectedPublication;
        private ICommand initializationCommand;
        private bool isInEditMode = false;

        public PublicationViewModel()
        {
            if (IsInDesignMode)
            {
                Publications = Randomizer<PublicationEntityViewModel>.Create(10);
                SelectedPublication = Publications.First();
            }
        }

        public PublicationViewModel(IPublicationRepository repository)
        {
            publicationRepository = repository;
            InitializationCommand = new RelayCommand(Initialize);
            StartEdditingCommand = new RelayCommand(() => this.IsInEditMode = true);
        }

        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set { Set(ref isInEditMode, value); }
        }

        public ICommand InitializationCommand
        {
            get; set;
        }

        public void Initialize()
        {
            Publications = publicationRepository.GetAll().Select(x => new PublicationEntityViewModel(x)).ToList();
            SelectedPublication = Publications.FirstOrDefault();
        }

        public ICommand StartEdditingCommand { get; set; }

        public IEnumerable<PublicationEntityViewModel> Publications
        {
            get { return publications; }
            set
            {
                Set(ref publications, value);
            }
        }

        public PublicationEntityViewModel SelectedPublication
        {
            get { return selectedPublication; }
            set
            {
                Set(ref selectedPublication, value);
            }
        }
    }
}