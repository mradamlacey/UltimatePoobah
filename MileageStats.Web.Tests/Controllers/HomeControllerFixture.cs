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
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class HomeControllerFixture
    {
        private Mock<IChartDataService> chartDataServiceMock;
        private Mock<ICountryServices> countryServicesMock;
        private User user;
        private Mock<IUserServices> userServicesMock;

        public HomeControllerFixture()
        {
            InitializeFixture();
        }

        private void InitializeFixture()
        {
            user = new User {UserId = 1};
            userServicesMock = new Mock<IUserServices>();
            userServicesMock.Setup(r => r.GetUserByClaimedIdentifier(It.IsAny<string>())).Returns(user);
            chartDataServiceMock = new Mock<IChartDataService>();

            countryServicesMock = new Mock<ICountryServices>();
            countryServicesMock.Setup(r => r.GetCountriesAndRegionsList()).Returns(
                () => new ReadOnlyCollection<string>(new List<string> {"a", "b"}));
        }

        [Fact]
        public void WhenJsonGetFleetStatisticSeries_ThenReturnsJsonData()
        {
            var user = new User {UserId = 1, AuthorizationId = "AuthorizationId", DisplayName = "DisplayName"};

            userServicesMock.Setup(r => r.GetUserByClaimedIdentifier(It.IsAny<string>())).Returns(user);

            var target = new HomeController(
                userServicesMock.Object,
                chartDataServiceMock.Object);

            target.SetFakeControllerContext();
            target.SetUserIdentity(new MileageStatsIdentity(this.user.AuthorizationId,
                                                            this.user.DisplayName,
                                                            this.user.UserId));

            var series = new StatisticSeries();

            chartDataServiceMock.Setup(x => x.CalculateSeriesForUser(user.UserId, null, null)).Returns(
                series);

            ActionResult actual = target.JsonGetFleetStatisticSeries();

            var actualJsonResult = actual as JsonResult;
            Assert.NotNull(actualJsonResult);
            Assert.Same(series, actualJsonResult.Data);
        }
    }
}