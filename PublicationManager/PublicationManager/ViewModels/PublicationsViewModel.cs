using System.Collections.Generic;
using PublicationManager.Domain;
using PublicationManager.Interfaces;

namespace PublicationManager.ViewModels
{
    public class PublicationsViewModel
    {
        private IPublicationRepository publicationRepository;

        public PublicationsViewModel(IPublicationRepository repository)
        {
            publicationRepository = repository;
        }

        public void Initialize()
        {
            Publications = publicationRepository.GetAll();
        }

        public IEnumerable<Publication> Publications { get; set; }
    }
}