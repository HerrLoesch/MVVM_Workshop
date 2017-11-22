using System;
using System.Collections.Generic;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using PublicationManager.Domain;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class PublicationEntityViewModel : ObservableObject, IDataErrorInfo
    {
        private string title;
        private DateTime publicationDate;
        private string comment;
        private Medium selectedMedium;
        private IEnumerable<Medium> media;
        private bool hasErros;

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

        public string this[string columnName]
        {
            get { return ValidateProperty(columnName); }
        }

        private string ValidateProperty(string propertyName)
        {
            if (propertyName == nameof(Title) && string.IsNullOrWhiteSpace(Title))
            {
                HasErros = true;
                return "No title was given.";
            }

            HasErros = false;

            return string.Empty;
        }

        public bool HasErros
        {
            get { return hasErros; }
            set { Set(ref hasErros, value); }
        }

        public string Error { get { return null; } }
    }
}
