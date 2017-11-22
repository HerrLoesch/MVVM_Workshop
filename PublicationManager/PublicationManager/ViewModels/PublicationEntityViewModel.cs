using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter valid title.")]
        [MinLength(3, ErrorMessage = "Please enter a title with at least three characters.")]
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
            var error = string.Empty;
            var value = GetPropertyValue(propertyName, this);
            var validationResults = new List<ValidationResult>();

            var validationContext = new ValidationContext(this, null, null) { MemberName = propertyName };
            var isValid = Validator.TryValidateProperty(value, validationContext, validationResults);

            if (!isValid)
            {
                var results = validationResults.Where(x => x.ErrorMessage != null).ToList();
                foreach (var validationResult in results)
                {
                    error += validationResult.ErrorMessage + Environment.NewLine;
                }
            }
            
            return error;
        }

        private object GetPropertyValue(string propertyName, PublicationEntityViewModel publicationEntityViewModel)
        {
            return publicationEntityViewModel.GetType().GetProperty(propertyName).GetValue(publicationEntityViewModel);
        }

        public string Error { get { return null; } }
    }
}
