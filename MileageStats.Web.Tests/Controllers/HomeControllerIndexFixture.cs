//===================================================================================
// Microsoft patterns & practices
// Silk : Web Client Guidance
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using MileageStats.Domain.Contracts;
using MileageStats.Domain.Models;
using MileageStats.Web.Controllers;
using MileageStats.Web.Models;
using MileageStats.Web.Tests.Mocks;
using Moq;
using Xunit;

namespace MileageStats.Web.Tests.Controllers
{
    public class HomeControllerIndexFixture
    {
        private Mock<IChartDataService> chartDataServiceMock;
        private Mock<ICountryServices> countryServicesMock;
        private User user;
        private Mock<IUserServices> userServicesMock;

        public HomeControllerIndexFixture()
        {
            InitializeFixture();
        }

        private void InitializeFixture()
        {
            user = new User();
            userServicesMock = new Mock<IUserServices>();
            userServicesMock.Setup(r => r.GetUserByClaimedIdentifier(It.IsAny<string>())).Returns(user);
            chartDataServiceMock = new Mock<IChartDataService>();

            countryServicesMock = new Mock<ICountryServices>();
            countryServicesMock.Setup(r => r.GetCountriesAndRegionsList()).Returns(
                () => new ReadOnlyCollection<string>(new List<string> {"a", "b"}));
        }

        [Fact]
        public void WhenRequestingIndex_ThenReturnsView()
        {
            var controller = new HomeController(
                userServicesMock.Object,
                chartDataServiceMock.Object);
            controller.SetFakeControllerContext();

            ActionResult result = controller.Index();

            Assert.IsType<ViewResult>(result);
            Assert.Equal(String.Empty, ((ViewResult) result).ViewName);
        }

        [Fact]
        public void WhenRequestingIndexWhileAuthenticated_ThenRedirectsToDashboard()
        {
            var controller = new HomeController(
                userServicesMock.Object,
                chartDataServiceMock.Object);

            controller.SetFakeControllerContext();
            controller.SetUserIdentity(new MileageStatsIdentity("TestName", "TestDisplayName", 1));
            Mock<HttpRequestBase> requestMock = Mock.Get(controller.Request);
            requestMock.Setup(r => r.IsAuthenticated).Returns(true);

            ActionResult result = controller.Index();

            Assert.IsType<RedirectToRouteResult>(result);
            var redirect = (RedirectToRouteResult) result;

            Assert.Equal("Dashboard", redirect.RouteName);
        }
    }
}