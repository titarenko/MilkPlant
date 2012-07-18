using System.Collections.Generic;
using System.Web.Mvc;
using FizzWare.NBuilder;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;
using MilkPlant.WebUi.Controllers;
using NSubstitute;
using NUnit.Framework;
using FluentAssertions;

namespace MilkPlant.WebUi.Tests.Controllers
{
    [TestFixture]
    public class ProductsControllerTests
    {
        [Test]
        public void BestSellers_Should_Render10BestSellersUsingProductAnalytics()
        {
            // arrange
            var analytics = Substitute.For<IProductAnalytics>();
            analytics.GetBestSellers(Arg.Any<int>()).Returns(
                callInfo => Builder<BestSeller>
                                .CreateListOfSize(callInfo.Arg<int>())
                                .All()
                                .With(x => x.Name = "Best")
                                .Build());
            var controller = new ProductsController(analytics);

            // act
            var result = (ViewResult) controller.BestSellers();
            var model = (IEnumerable<BestSeller>) result.Model;

            // assert
            model.Should().HaveCount(10);
            model.Should().OnlyContain(x => x.Name == "Best");
        }
    }
}