using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using PublicationManager.ViewModels;

namespace PublicationManager.Specs
{
    [TestClass]
    public class PublicationViewModelTests
    {
        private PublicationViewModel sut;
        private Publication firstPublication;

        [TestInitialize]
        public void Initialize()
        {
            var repository = A.Fake<IPublicationRepository>();
            firstPublication = new Publication();
            A.CallTo(() => repository.GetAll()).Returns(new List<Publication>() { firstPublication, new Publication(), new Publication() });

            sut = new PublicationViewModel(repository);
            sut.MonitorEvents();

            sut.Initialize();
        }

        [TestMethod]
        public void WhenPublicationsViewIsShown_ThanAllAvailablePublicationsAreVisible()
        {
            sut.Publications.Should().NotBeEmpty();
            sut.ShouldRaisePropertyChangeFor(x => x.Publications);
        }

        [TestMethod]
        public void WhenPublicationsViewIsShown_ThanTheFirstElementInThePublicationsListIsSelected()
        {
            sut.SelectedPublication.ShouldBeEquivalentTo(firstPublication);
            sut.ShouldRaisePropertyChangeFor(x => x.SelectedPublication);
        }
    }
}
