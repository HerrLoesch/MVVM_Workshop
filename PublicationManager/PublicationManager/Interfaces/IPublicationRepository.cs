using System.Collections.Generic;
using PublicationManager.Domain;

namespace PublicationManager.Interfaces
{
    public interface IPublicationRepository
    {
        IEnumerable<Publication> GetPublications();
    }
}