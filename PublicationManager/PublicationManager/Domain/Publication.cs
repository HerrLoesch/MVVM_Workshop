using System;

namespace PublicationManager.Domain
{
    public class Publication
    {
        public Publication()
        {
            
        }

        public Publication(Publication publication)
        {
            this.Title = publication.Title;
            this.PublicationDate = PublicationDate;
            this.Medium = publication.Medium;
            this.Comment = publication.Comment;
        }

        public string Title { get; set; }

        public DateTime PublicationDate { get; set; }

        public Medium Medium { get; set; }

        public string Comment { get; set; }
    }
}