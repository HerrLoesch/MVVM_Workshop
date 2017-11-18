using System;
using GalaSoft.MvvmLight;
using PublicationManager.Domain;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class PublicationDetailsViewModel : ObservableObject
    {
        private Publication publication;

        public string Title
        {
            get { return publication.Title; }
            set { this.publication.Title = value; }
        }

        public DateTime PublicationDate
        {
            get { return publication.PublicationDate; }
            set { publication.PublicationDate = value; }
        }

        public string Comment
        {
            get { return publication.Comment; }
            set { publication.Comment = value; }
        }

        public string Publisher => publication.Medium.Publisher;

        public string MediumName => publication.Medium.Name;

        public PublicationDetailsViewModel(Publication publication)
        {
            this.publication = publication;
        }

        public PublicationDetailsViewModel(PublicationDetailsViewModel otherViewModel)
        {
            this.publication = new Publication(otherViewModel.publication);
        }

        public PublicationDetailsViewModel()
        {
            this.publication = Randomizer<Publication>.Create();
        }
    }
}
