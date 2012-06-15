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
using System.Web.Mvc;
using MileageStats.Domain.Handlers;
using MileageStats.Domain.Models;
using MileageStats.Model;
using MileageStats.Web.Helpers;
using MileageStats.Web.Models;
using Moq;
using Xunit;

namespace MileageStats.Web.Tests.Helpers
{
    public class VehicleHelperFixture
    {
        private readonly HtmlHelper _helper;
        private readonly ViewContext _viewContext;
        private readonly IViewDataContainer _viewDataContainer;

        public VehicleHelperFixture()
        {
            _viewDataContainer = new Mock<IViewDataContainer>().Object;
            _viewContext = new Mock<ViewContext>().Object;
            _helper = new HtmlHelper(_viewContext, _viewDataContainer);
        }

        [Fact]
        public void WhenEfficiencyLessThanThousand_ThenNumberFormatsCorrectly()
        {
            var fillups = new[]
                              {
                                  new FillupEntry {Distance = 0, TotalUnits = 0},
                                  new FillupEntry {Distance = 1500, TotalUnits = 10},
                              };
            var vehicle = new VehicleModel(new Vehicle(), CalculateStatistics.Calculate(fillups));

            var actual = _helper.AverageFuelEfficiencyText(vehicle);
            var expected = MvcHtmlString.Create("150");

            Assert.Equal(expected.ToHtmlString(), actual.ToHtmlString());
        }

        [Fact]
        public void WhenEfficiencyGreaterThanThousand_ThenNumberFormatsCorrectly()
        {
            var fillups = new[]
                              {
                                  new FillupEntry {Distance = 0, TotalUnits = 0},
                                  new FillupEntry {Distance = 15000, TotalUnits = 10},
                              };
            var vehicle = new VehicleModel(new Vehicle(), CalculateStatistics.Calculate(fillups));

            var actual = _helper.AverageFuelEfficiencyText(vehicle);
            var expected = MvcHtmlString.Create("1,500");
            Assert.Equal(expected.ToHtmlString(), actual.ToHtmlString());
        }

        [Fact]
        public void WhenEfficiencyGreaterThan99Thousand_ThenNumberFormatsCorrectly()
        {
            var fillups = new[]
                              {
                                  new FillupEntry {Distance = 0, TotalUnits = 0},
                                  new FillupEntry {Distance = 150000, TotalUnits = 10},
                              };
            var vehicle = new VehicleModel(new Vehicle(), CalculateStatistics.Calculate(fillups));

            var actual = _helper.AverageFuelEfficiencyText(vehicle);
            var expected = MvcHtmlString.Create("15.0k");
            Assert.Equal(expected.ToHtmlString(), actual.ToHtmlString());
        }

        [Fact]
        public void WhenEfficiencyLessThanHundred_ThenMagnitudeFormatsCorrectly()
        {
            var fillups = new[]
                              {
                                  new FillupEntry {Distance = 0, TotalUnits = 0},
                                  new FillupEntry {Distance = 888, TotalUnits = 10},
                              };
            var vehicle = new VehicleModel(new Vehicle(), CalculateStatistics.Calculate(fillups));

            var actual = _helper.AverageFuelEfficiencyMagnitude(vehicle);
            var expected = string.Empty;
            Assert.Equal(expected, actual.ToHtmlString());
        }

        [Fact]
        public void WhenEfficiencyGreaterThanHundred_ThenMagnitudeFormatsCorrectly()
        {
            var fillups = new[]
                              {
                                  new FillupEntry {Distance = 0, TotalUnits = 0},
                                  new FillupEntry {Distance = 8888, TotalUnits = 10},
                              };
            var vehicle = new VehicleModel(new Vehicle(), CalculateStatistics.Calculate(fillups));

            var actual = _helper.AverageFuelEfficiencyMagnitude(vehicle);
            var expected = MvcHtmlString.Create("hundreds");
            Assert.Equal(expected.ToHtmlString(), actual.ToHtmlString());
        }

        [Fact]
        public void WhenEfficiencyGreaterThanThousand_ThenMagnitudeFormatsCorrectly()
        {
            var fillups = new[]
                              {
                                  new FillupEntry {Distance = 0, TotalUnits = 0},
                                  new FillupEntry {Distance = 888800, TotalUnits = 10},
                              };
            var vehicle = new VehicleModel(new Vehicle(), CalculateStatistics.Calculate(fillups));

            var actual = _helper.AverageFuelEfficiencyMagnitude(vehicle);
            var expected = MvcHtmlString.Create("thousands");
            Assert.Equal(expected.ToHtmlString(), actual.ToHtmlString());
        }

        [Fact]
        public void WhenNoVehicleSelectedAndNotCollapsed_ThenNoCssClassApplied()
        {
            var vehicle = new VehicleModel(new Vehicle(), new VehicleStatisticsModel());
            var list = new VehicleListViewModel(new[] { vehicle }){ IsCollapsed = false };

            var actual = _helper.CssClassForTile(list, vehicle);

            Assert.Equal(string.Empty, actual);
        }

        [Fact]
        public void WhenNoVehicleSelectedAndCollapsed_ThenNoCssClassApplied()
        {
            var vehicle = new VehicleModel(new Vehicle(), new VehicleStatisticsModel());
            var list = new VehicleListViewModel(new[] { vehicle }, 0) { IsCollapsed = true };

            var actual = _helper.CssClassForTile(list, vehicle);

            Assert.Equal(string.Empty, actual);
        }

        [Fact]
        public void WhenVehicleNotSelectedAndCollapsed_ThenCssClassApplied()
        {
            var notSelected = new VehicleModel(new Vehicle { VehicleId = 1 }, new VehicleStatisticsModel());
            var selected = new VehicleModel(new Vehicle { VehicleId = 2 }, new VehicleStatisticsModel());

            var list = new VehicleListViewModel(new[] { notSelected, selected }, 2) { IsCollapsed = true };


            var actual = _helper.CssClassForTile(list, notSelected);

            Assert.Equal("compact", actual);
        }

        [Fact]
        public void WhenVehicleSelectedAndNotCollapsed_ThenNoCssClassApplied()
        {
            var notSelected = new VehicleModel(new Vehicle { VehicleId = 1 }, new VehicleStatisticsModel());
            var selected = new VehicleModel(new Vehicle { VehicleId = 2 }, new VehicleStatisticsModel());

            var list = new VehicleListViewModel(new[] { notSelected, selected }, 2) { IsCollapsed = true };

            var actual = _helper.CssClassForTile(list, selected);

            Assert.Equal(string.Empty, actual);
        }
    }
}