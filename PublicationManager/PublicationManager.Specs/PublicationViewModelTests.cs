using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicationManager.Domain;
using PublicationManager.Interfaces;
using PublicationManager.ViewModels;

namespace PublicationManager.Specs
{
    [TestClass]
    public class PublicationViewModelTests
    {
        [TestMethod]
        public void WhenPublicationsViewIsShown_ThanAllAvailablePublicationsAreVisible()
        {
            IPublicationRepository repository = A.Fake<IPublicationRepository>();
            A.CallTo(() => repository.GetAll()).Returns(new List<Publication>() {new Publication(), new Publication()});

            var sut = new PublicationsViewModel(repository);

            sut.Initialize();

            Assert.AreNotEqual(0, sut.Publications.Count());
        }
    }
}
