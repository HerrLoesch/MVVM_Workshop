using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using Tynamix.ObjectFiller;

namespace PublicationManager.Services
{
    public class PublicationRepository : IPublicationRepository
    {
        public IEnumerable<Publication> GetAll()
        {
            return Randomizer<Publication>.Create(5);
        }
    }
}
