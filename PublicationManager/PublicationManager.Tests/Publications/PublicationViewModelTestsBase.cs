using System;
using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using PublicationManager.ViewModels;
using Tynamix.ObjectFiller;

namespace PublicationManager.Tests.Publications
{
    [TestClass]
    public abstract class PublicationViewModelTestsBase
    {
        protected IPublicationRepository publicationRepository;
        protected PublicationViewModel sut;

        [TestInitialize]
        public void Initialize()
        { 
            publicationRepository = A.Fake<IPublicationRepository>();
            A.CallTo(() => publicationRepository.GetPublications()).Returns(Randomizer<Publication>.Create(2));
            
            sut = new PublicationViewModel(publicationRepository);
            sut.MonitorEvents();

            Act();
        }

        protected abstract void Act();
    }
}