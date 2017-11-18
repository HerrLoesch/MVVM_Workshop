using System.Globalization;
using System.Windows;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicationManager.MVVM;

namespace PublicationManager.Tests.Utility
{
    [TestClass]
    public class ExtendedBooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void ConvertsFalseToCollapsedIfSetToNormalMode()
        {
            var sut = new ExtendedBooleanToVisibilityConverter();
            sut.Mode = ExtendedBooleanToVisibilityConverter.ConversionMode.Normal;

            var result = sut.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture);
            result.Should().Be(Visibility.Collapsed);
        }

        [TestMethod]
        public void ConvertsTrueToVisibileIfSetToNormalMode()
        {
            var sut = new ExtendedBooleanToVisibilityConverter();
            sut.Mode = ExtendedBooleanToVisibilityConverter.ConversionMode.Normal;

            var result = sut.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture);
            result.Should().Be(Visibility.Visible);
        }

        [TestMethod]

        public void ConvertsFalseToVisibleIfSetToInverseMode()
        {
            var sut = new ExtendedBooleanToVisibilityConverter();
            sut.Mode = ExtendedBooleanToVisibilityConverter.ConversionMode.Inverse;

            var result = sut.Convert(false, typeof(Visibility), null, CultureInfo.CurrentCulture);
            result.Should().Be(Visibility.Visible);
        }

        [TestMethod]
        public void ConvertsTrueToCollapsedIfSetToInverseMode()
        {
            var sut = new ExtendedBooleanToVisibilityConverter();
            sut.Mode = ExtendedBooleanToVisibilityConverter.ConversionMode.Inverse;

            var result = sut.Convert(true, typeof(Visibility), null, CultureInfo.CurrentCulture);
            result.Should().Be(Visibility.Collapsed);
        }
    }
}
