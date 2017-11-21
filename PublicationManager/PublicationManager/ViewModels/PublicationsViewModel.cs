﻿using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using Tynamix.ObjectFiller;

namespace PublicationManager.ViewModels
{
    public class PublicationsViewModel : ViewModelBase
    {
        private IPublicationRepository publicationRepository;
        private IEnumerable<Publication> publications;
        private Publication selectedPublication;

        public PublicationsViewModel()
        {
            if (IsInDesignMode)
            {
                Publications = Randomizer<Publication>.Create(10);
            }
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

        public IEnumerable<Publication> Publications
        {
            get { return publications; }
            set
            {
                Set(ref publications, value);
            }
        }

        public Publication SelectedPublication
        {
            get { return selectedPublication; }
            set
            {
                Set(ref selectedPublication, value);
            }
        }
    }
}