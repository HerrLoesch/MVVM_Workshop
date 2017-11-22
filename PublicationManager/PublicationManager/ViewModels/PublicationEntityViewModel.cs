using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using PublicationManager.Domain;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class PublicationEntityViewModel : ObservableObject
    {
        private string title;
        private DateTime publicationDate;
        private string comment;
        private Medium selectedMedium;
        private IEnumerable<Medium> media;

        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set { Set(ref publicationDate, value); }
        }

        public string Comment
        {
            get { return comment; }
            set { Set(ref comment, value); }
        }

        public Medium SelectedMedium
        {
            get { return selectedMedium; }
            set { Set(ref selectedMedium, value); }
        }

        public IEnumerable<Medium> Media
        {
            get { return media; }
            set { Set(ref media, value); }
        }

        public PublicationEntityViewModel()
        {
            SetPublication(Randomizer<Publication>.Create());
        }

        public PublicationEntityViewModel(Publication publication)
        {
            SetPublication(publication);
        }

        private void SetPublication(Publication publication)
        {
            SelectedMedium = publication.Medium;
            Title = publication.Title;
            PublicationDate = publication.PublicationDate;
            Comment = publication.Comment;
        }
    }
}
