using System.Collections.Generic;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using Tynamix.ObjectFiller;

namespace PublicationManager.Services
{
    public class DummyRepository : IPublicationRepository
    {
        public IEnumerable<Publication> GetPublications()
        {
            return Randomizer<Publication>.Create(10);
        }
    }
}
