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
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using MileageStats.Domain.Contracts;
using MileageStats.Domain.Handlers;
using MileageStats.Domain.Models;
using MileageStats.Web.Controllers;
using MileageStats.Web.Models;
using MileageStats.Web.Tests.Mocks;
using Moq;
using Xunit;
using FillupEntry = MileageStats.Model.FillupEntry;
using Vehicle = MileageStats.Model.Vehicle;

namespace MileageStats.Web.Tests.Controllers
{
    public class FillupControllerFixture
    {
        private const int NoVehicleSelectedId = 0;
        private readonly Mock<IUserServices> userServicesMock;
        private readonly UserInfo defaultUserInfo;
        private readonly Mock<IServiceLocator> serviceLocator;

        const int defaultFillupId = 55;
        const int defaultVehicleId = 99;

        public FillupControllerFixture()
        {
            serviceLocator = new Mock<IServiceLocator>();
            userServicesMock = new Mock<IUserServices>();
            defaultUserInfo = new UserInfo { ClaimsIdentifier = "TestClaimsIdentifier", UserId = 5 };
        }

        [Fact]
        public void WhenRequestingFillup_ThenReturnsFillupView()
        {
            var controller = GetTestableFillupController();

            MockFillupForDefaultVehicle();

            MockHandlerFor(() => new Mock<GetVehicleListForUser>(null));

            MockEmptyFillupsForDefaultVehicle();

            var result = controller.Details(defaultFillupId) as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void WhenRequestingFillup_ThenReturnsProvidesViewModelToView()
        {
            MockFillupForDefaultVehicle();

            MockHandlerFor(() => new Mock<GetVehicleListForUser>(null));

            MockEmptyFillupsForDefaultVehicle();

            var controller = GetTestableFillupController();
            var result = controller.Details(defaultFillupId);
            var model = result.Extract<FillupDetailsViewModel>();

            Assert.NotNull(model);
        }

        [Fact]
        public void WhenRequestingFillup_ThenReturnsProvidesFillupsInViewModel()
        {
            var fillupEntries = new[]
                                    {
                                        new Model.FillupEntry {VehicleId = defaultVehicleId},
                                        new Model.FillupEntry {VehicleId = defaultVehicleId}
                                    };

            MockFillupForDefaultVehicle();

            MockHandlerFor(() => new Mock<GetVehicleListForUser>(null));

            MockHandlerFor(
                () => new Mock<GetFillupsForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(defaultVehicleId))
                         .Returns(new List<Model.FillupEntry>(fillupEntries)));

            var controller = GetTestableFillupController();

            var result = controller.Details(defaultFillupId);
            var model = result.Extract<FillupDetailsViewModel>();

            Assert.NotNull(model.Fillups);
            Assert.Equal(fillupEntries.Count(), model.Fillups.Count());
            Assert.Contains(fillupEntries.ElementAt(0), model.Fillups);
        }

        [Fact]
        public void WhenRequestingVehicleFillups_ReturnsViewWithViewResult()
        {
            MockVehicleListWithVehicles(defaultVehicleId);
            MockFillupsForDefaultVehicle();

            var controller = GetTestableFillupController();

            var actual = (ViewResult)controller.List(defaultVehicleId);
            var model = actual.Extract<FillupDetailsViewModel>();

            Assert.NotNull(actual);
            Assert.NotNull(model);
        }

        [Fact]
        public void WhenRequestingVehicleFillups_ReturnsViewWithPopulatedViewModel()
        {
            MockVehicleListWithVehicles(defaultVehicleId);
            MockFillupsForDefaultVehicle();

            var controller = GetTestableFillupController();

            var result = controller.List(defaultVehicleId);
            var model = result.Extract<FillupDetailsViewModel>();
            Assert.Equal(3, model.Fillups.Count());
        }

        [Fact]
        public void WhenRequestingVehicleFillups_ReturnsViewWithFillupDatesDescending()
        {
            var fillups = new[]
                              {
                                  new FillupEntry {Date = DateTime.UtcNow.AddDays(-7)},
                                  new FillupEntry {Date = DateTime.UtcNow}
                              };

            MockHandlerFor(
                () => new Mock<GetFillupsForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(defaultVehicleId))
                         .Returns(fillups));

            MockVehicleListWithVehicles(defaultVehicleId);

            var controller = GetTestableFillupController();
            var result = controller.List(defaultVehicleId);
            var model = result.Extract<FillupDetailsViewModel>();
            var entries = model.Fillups;

            Assert.True(entries.ElementAt(0).Date > entries.ElementAt(1).Date);
        }

        [Fact]
        public void WhenAddingFillupGet_ShowsFillupEntryView()
        {
            MockVehicleListWithVehicles(defaultVehicleId);
            MockFillupsForDefaultVehicle();

            var controller = GetTestableFillupController();

            var result = controller.Add(defaultVehicleId);

            Assert.IsType(typeof(ViewResult), result);
        }

        [Fact]
        public void WhenAddingFillupGet_ProvidesPrePopulatedModel()
        {
            // this test has some unnessary setup, just to reflect what is happening with data access
            // ultimately, the data access should be improved to remove the extra calls to the db

            var fillups = new List<FillupEntry>
                           {
                               new FillupEntry
                                   {
                                       VehicleId = defaultVehicleId, 
                                       FillupEntryId = defaultFillupId,
                                       Odometer = 500
                                   },
                           };

            // this is where the actual odometer reading originates
            var statistics = CalculateStatistics.Calculate(fillups);

            // fillups is not required on the vehicle for this test to pass
            var vehicles = new List<VehicleModel>
                               {
                                   new VehicleModel(new Vehicle {VehicleId = defaultVehicleId, Fillups = fillups}, statistics )
                               };

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUserInfo.UserId))
                         .Returns(vehicles));

            // this test will pass even if this handler returns the wrong set of fillups
            MockHandlerFor(
                () => new Mock<GetFillupsForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(defaultVehicleId))
                         .Returns(fillups));

            var controller = GetTestableFillupController();

            var result = controller.Add(defaultVehicleId);
            var model = result.Extract<FillupAddViewModel>();

            Assert.NotNull(model);
            Assert.Equal(500, model.FillupEntry.Odometer);
        }

        [Fact]
        public void WhenAddingFillupPostExecutes_SendsToServicesTier()
        {
            var fillupEntry = new FillupEntryFormModel
                                  {
                                      VehicleId = defaultVehicleId,
                                      Date = DateTime.Now,
                                      Odometer = 50,
                                      PricePerUnit = 1.25d,
                                      TotalUnits = 10.0d
                                  };

            MockHandlerFor(
                () => new Mock<CanAddFillup>(null, null),
                x => x
                         .Setup(h => h.Execute(defaultUserInfo.UserId, defaultVehicleId, fillupEntry))
                         .Returns(new ValidationResult[] { }));

            var handler = MockHandlerFor(
                () => new Mock<AddFillupToVehicle>(null, null),
                x => x
                         .Setup(h => h.Execute(defaultUserInfo.UserId, defaultVehicleId, fillupEntry))
                         .Verifiable("handler was not invoked"));

            MockVehicleListWithVehicles(defaultVehicleId);

            var controller = GetTestableFillupController();
            controller.Add(defaultVehicleId, fillupEntry);

            handler.Verify();
        }

        [Fact]
        public void WhenAddingFillupPostExecutes_RedirectsToFillupList()
        {
            var fillupEntry = new FillupEntryFormModel
            {
                VehicleId = defaultVehicleId,
                Date = DateTime.Now,
                Odometer = 50,
                PricePerUnit = 1.25d,
                TotalUnits = 10.0d
            };

            MockHandlerFor(
                () => new Mock<CanAddFillup>(null, null),
                x => x
                         .Setup(h => h.Execute(defaultUserInfo.UserId, defaultVehicleId, fillupEntry))
                         .Returns(new ValidationResult[] { }));

            MockHandlerFor(() => new Mock<AddFillupToVehicle>(null, null));

            MockVehicleListWithVehicles(defaultVehicleId);

            var controller = GetTestableFillupController();
            controller.Add(defaultVehicleId, fillupEntry);
            var result = (RedirectToRouteResult)controller.Add(defaultVehicleId, fillupEntry);

            Assert.NotNull(result);
            Assert.Equal("List", result.RouteValues["action"]);
            Assert.Equal("Fillup", result.RouteValues["controller"]);
        }

        // returns controller with mocks
        private FillupController GetTestableFillupController()
        {
            var controller = new FillupController(userServicesMock.Object, serviceLocator.Object);
            controller.SetFakeControllerContext();
            controller.SetUserIdentity(new MileageStatsIdentity("TestUser", defaultUserInfo.DisplayName,
                                                                       defaultUserInfo.UserId));
            return controller;
        }

        Mock<T> MockHandlerFor<T>(Func<Mock<T>> create, Action<Mock<T>> setup = null) where T : class
        {
            return serviceLocator.MockHandlerFor(create, setup);
        }

        private void MockVehicleListWithVehicles(int selectedVehicle)
        {
            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUserInfo.UserId))
                         .Returns(defaultVehicleId.StandardVehicleList()));
        }

        private void MockFillupsForDefaultVehicle()
        {
            var list = new List<FillupEntry>
                           {
                               new FillupEntry {VehicleId = defaultVehicleId, FillupEntryId = defaultFillupId},
                               new FillupEntry {VehicleId = defaultVehicleId, FillupEntryId = defaultFillupId + 1},
                               new FillupEntry {VehicleId = defaultVehicleId, FillupEntryId = defaultFillupId + 2},
                           };

            MockHandlerFor(
                () => new Mock<GetFillupsForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(defaultVehicleId))
                         .Returns(list));
        }

        private void MockEmptyFillupsForDefaultVehicle()
        {
            MockHandlerFor(
                () => new Mock<GetFillupsForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(defaultVehicleId))
                         .Returns(new List<Model.FillupEntry>()));
        }

        private void MockFillupForDefaultVehicle()
        {
            MockHandlerFor(
                () => new Mock<GetFillupById>(null),
                x => x
                         .Setup(h => h.Execute(defaultFillupId))
                         .Returns(new Model.FillupEntry { VehicleId = defaultVehicleId }));
        }
    }
}