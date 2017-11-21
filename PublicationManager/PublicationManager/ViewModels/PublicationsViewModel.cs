using System.Collections.Generic;
using System.Linq;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class PublicationsViewModel
    {
        private IPublicationRepository publicationRepository;

        public PublicationsViewModel()
        {
            Publications = Randomizer<Publication>.Create(10);
        }

        public PublicationsViewModel(IPublicationRepository repository)
        {
            publicationRepository = repository;
        }

        public void Initialize()
        {
            Publications = publicationRepository.GetAll();
            SelectedPublication = Publications.FirstOrDefault();
        }

        public IEnumerable<Publication> Publications { get; set; }

        public Publication SelectedPublication { get; set; }
    }
}