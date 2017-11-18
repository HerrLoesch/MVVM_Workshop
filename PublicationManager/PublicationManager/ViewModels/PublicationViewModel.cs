using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class PublicationViewModel : ViewModelBase
    {
        private readonly IPublicationRepository publicationRepository;

        private ICommand cancelEditModeCommand;
        private bool isInEditMode;
        private IEnumerable<PublicationDetailsViewModel> publications;
        private PublicationDetailsViewModel selectedPublication;
        private ICommand startEditModeCommand;
        private PublicationDetailsViewModel selectedPublicationBeforeEditing;
        private ICommand initializationCommand;

        public PublicationViewModel()
        {
            Publications = Randomizer<PublicationDetailsViewModel>.Create(10);
            SelectedPublication = new PublicationDetailsViewModel(Publications.First());
        }

        public PublicationViewModel(IPublicationRepository publicationRepository)
        {
            this.publicationRepository = publicationRepository;
        }

        public IEnumerable<PublicationDetailsViewModel> Publications
        {
            get => publications;
            private set => Set(ref publications, value);
        }

        public PublicationDetailsViewModel SelectedPublication
        {
            get => selectedPublication;
            set => Set(ref selectedPublication, value);
        }

        public ICommand StartEditModeCommand => startEditModeCommand ??
                                                (startEditModeCommand = new RelayCommand(StartEditing));

        public ICommand CancelEditModeCommand => cancelEditModeCommand ??
                                                 (cancelEditModeCommand = new RelayCommand(CancelEditing));

        private void StartEditing()
        {
            IsInEditMode = true;
            this.selectedPublicationBeforeEditing = new PublicationDetailsViewModel(this.SelectedPublication);
        }

        private void CancelEditing()
        {
            this.SelectedPublication = new PublicationDetailsViewModel(this.selectedPublicationBeforeEditing);
            IsInEditMode = false;
        }

        public bool IsInEditMode
        {
            get { return isInEditMode; }
            set { Set(ref isInEditMode, value); }
        }

        private void Initialize()
        {
            Publications = publicationRepository.GetPublications().Select(x => new PublicationDetailsViewModel(x)).ToList();
            SelectedPublication = new PublicationDetailsViewModel(Publications.FirstOrDefault());
        }

        public ICommand InitializationCommand => initializationCommand ?? (initializationCommand = new RelayCommand(Initialize));
    }
}