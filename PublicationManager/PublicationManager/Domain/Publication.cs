using System;

namespace PublicationManager.Domain
{
    public class Publication
    {
        public string Title { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Comment { get; set; }

        public Medium Medium { get; set; }
    
    }
}
