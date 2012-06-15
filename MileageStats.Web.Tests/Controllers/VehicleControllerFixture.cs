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
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using MileageStats.Domain.Contracts;
using MileageStats.Domain.Handlers;
using MileageStats.Domain.Models;
using MileageStats.Model;
using MileageStats.Web.Controllers;
using MileageStats.Web.Models;
using MileageStats.Web.Tests.Mocks;
using Moq;
using Xunit;
using User = MileageStats.Domain.Models.User;
using VehiclePhoto = MileageStats.Model.VehiclePhoto;

namespace MileageStats.Web.Tests.Controllers
{
    public class VehicleControllerFixture
    {
        private const int NoVehicleSelectedId = 0;
        private const int DefaultVehicleId = 99;

        public VehicleControllerFixture()
        {
            serviceLocator = new Mock<IServiceLocator>();

            chartDataServiceMock = new Mock<IChartDataService>();

            countryServicesMock = new Mock<ICountryServices>();
            countryServicesMock
                .Setup(r => r.GetCountriesAndRegionsList())
                .Returns(() => new ReadOnlyCollection<string>(new[] { "a", "b" }));

            defaultUser = new User { AuthorizationId = "TestClaimsIdentifier", UserId = 5 };
            defaultUserInfo = new UserInfo
                                  {
                                      ClaimsIdentifier = defaultUser.AuthorizationId,
                                      UserId = defaultUser.UserId
                                  };

            userServicesMock = new Mock<IUserServices>();
            userServicesMock
                .Setup(s => s.GetUserByClaimedIdentifier(defaultUser.AuthorizationId))
                .Returns(defaultUser);
        }

        private Mock<ICountryServices> countryServicesMock { get; set; }
        private Mock<IUserServices> userServicesMock { get; set; }
        private Mock<IChartDataService> chartDataServiceMock { get; set; }
        private Mock<IServiceLocator> serviceLocator { get; set; }
        private UserInfo defaultUserInfo { get; set; }
        private User defaultUser { get; set; }

        [Fact]
        public void WhenUpdatingVehicleSortOrder_InvokesHandler()
        {
            Mock<UpdateVehicleSortOrder> handler = MockHandlerFor(() => new Mock<UpdateVehicleSortOrder>(null));

            const string newOrder = "3,2,1";
            var sortOrder = new UpdateVehicleSortOrderViewModel { SortOrder = newOrder };

            TestableVehicleController controller = GetTestableVehicleController();
            controller.UpdateSortOrder(sortOrder);

            handler.Verify(x => x.Execute(defaultUserInfo.UserId, new[] { 3, 2, 1 }));
        }

        [Fact]
        public void WhenRequestingDashboard_ThenInvokeHandlers()
        {
            var list = MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Returns(new VehicleModel[]{})
                            .Verifiable("handler wasn't invoked.")
                );

            var reminders = MockHandlerFor(
                () => new Mock<GetImminentRemindersForUser>(null, null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId, It.IsAny<DateTime>(), NoVehicleSelectedId))
                            .Verifiable("handler wasn't invoked.")
                );

            var statistics = MockHandlerFor(
                () => new Mock<GetFleetSummaryStatistics>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Verifiable("handler wasn't invoked.")
                );

            TestableVehicleController controller = GetTestableVehicleController();

            ActionResult result = controller.List();

            Assert.IsType<ViewResult>(result);

            list.Verify();
            reminders.Verify();
            statistics.Verify();
        }

        [Fact]
        public void WhenRequestingDashboard_ThenViewModelContainsImminentReminders()
        {
            var vehicle1 = new Vehicle { VehicleId = 1 };
            var vehicle2 = new Vehicle { VehicleId = 2 };

            var reminders = new[]
                                {
                                    new ImminentReminderModel(vehicle1, new Reminder {ReminderId = 45}, false),
                                    new ImminentReminderModel(vehicle2, new Reminder {ReminderId = 67}, true),
                                };

            MockHandlerFor(
                () => new Mock<GetImminentRemindersForUser>(null, null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId, It.IsAny<DateTime>(), NoVehicleSelectedId))
                            .Returns(reminders)
                );

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Returns(new VehicleModel[]{})
                );

            MockHandlerFor(
                () => new Mock<GetFleetSummaryStatistics>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                );

            var controller = GetTestableVehicleController();

            var result = controller.List();
            var model = result.Extract<DashboardViewModel>();

            Assert.Equal(2, model.ImminentReminders.Count());

            ImminentReminderModel[] list = model.ImminentReminders.ToArray();

            Assert.Equal(45, list[0].Reminder.ReminderId);
            Assert.Equal(67, list[1].Reminder.ReminderId);
        }

        [Fact]
        public void WhenRequestingDashboard_ThenViewModelContainsVehiclesList()
        {
            var vehicleList = new VehicleModel[] { };

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Returns(vehicleList)
                );

            MockHandlerFor(
                () => new Mock<GetImminentRemindersForUser>(null, null),
                mock => mock.Setup(h => h.Execute(defaultUser.UserId, It.IsAny<DateTime>(), NoVehicleSelectedId))
                );

            MockHandlerFor(
                () => new Mock<GetFleetSummaryStatistics>(null),
                mock => mock.Setup(h => h.Execute(defaultUser.UserId))
                );

            var controller = GetTestableVehicleController();

            var result = controller.List();
            var model = result.Extract<DashboardViewModel>();
            var actual = model.VehicleListViewModel.Vehicles.ToArray();

            Assert.NotNull(actual);
            Assert.False(model.VehicleListViewModel.IsCollapsed);
        }

        [Fact]
        public void WhenRequestingDashboard_ThenViewModelContainsFleetSummaryStatistics()
        {
            var fleetSummaryStatistics = new FleetStatistics(new VehicleStatisticsModel[0]);

            MockHandlerFor(
                () => new Mock<GetFleetSummaryStatistics>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Returns(fleetSummaryStatistics)
                );

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Returns(new VehicleModel[]{})
                );

            MockHandlerFor(
                () => new Mock<GetImminentRemindersForUser>(null, null),
                mock => mock.Setup(h => h.Execute(defaultUser.UserId, It.IsAny<DateTime>(), NoVehicleSelectedId))
                );

            var controller = GetTestableVehicleController();

            var result = controller.List();
            var model = result.Extract<DashboardViewModel>();

            Assert.NotNull(model);
            Assert.Same(fleetSummaryStatistics, model.FleetSummaryStatistics);
        }

        [Fact]
        public void WhenRequestingDashboard_ThenReturnsUser()
        {
            MockHandlers();

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.List();
            var model = result.Extract<DashboardViewModel>();

            Assert.NotNull(model);
            Assert.NotNull(model.User);
            Assert.Same(defaultUser, model.User);
        }

        [Fact]
        public void WhenRequestingDashboard_ThenCountryListIsAddedToViewBag()
        {
            MockHandlers();

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult response = controller.List();

            var result = (ViewResult)response;
            Assert.NotNull(result.ViewBag.CountryList);
        }

        [Fact]
        public void WhenJsonList_ThenReturnsVehicles()
        {
            var vehicles = new[]
                               {
                                   new VehicleModel(new Vehicle {Name = "test"}, new VehicleStatisticsModel())
                               };

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                mock => mock
                            .Setup(h => h.Execute(It.IsAny<int>()))
                            .Returns(vehicles)
                );

            TestableVehicleController controller = GetTestableVehicleController();

            JsonResult result = controller.JsonList();
            Assert.IsType<JsonResult>(result);

            var data = (IList<JsonVehicleViewModel>)result.Data;
            Assert.NotNull(data);

            Assert.Equal(vehicles.First().Name, data.First().Name);
        }

        [Fact]
        public void WhenJsonDetailsCalled_ThenReturnsVehicle()
        {
            var vehicle = new Vehicle
                              {
                                  VehicleId = DefaultVehicleId,
                                  Name = "test",
                                  MakeName = "make",
                                  ModelName = "model",
                                  Year = 2010,
                                  PhotoId = 12,
                                  SortOrder = 1,
                                  Fillups = new List<FillupEntry>()
                              };

            MockHandlerFor(
                () => new Mock<GetVehicleById>(null),
                x => x
                         .Setup(h => h.Execute(It.IsAny<int>(), DefaultVehicleId))
                         .Returns(new VehicleModel(vehicle, new VehicleStatisticsModel())));

            MockHandlerFor(
                () => new Mock<GetOverdueRemindersForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(DefaultVehicleId, It.IsAny<DateTime>(), 0))
                         .Returns(new List<ReminderSummaryModel> { new ReminderSummaryModel(new Reminder(), isOvedue: true) }));

            TestableVehicleController controller = GetTestableVehicleController();

            JsonResult result = controller.JsonDetails(DefaultVehicleId);
            var data = (JsonVehicleViewModel)result.Data;

            Assert.Equal(DefaultVehicleId, data.VehicleId);
            Assert.Equal("test", data.Name);
            Assert.Equal("make", data.MakeName);
            Assert.Equal("model", data.ModelName);
            Assert.Equal(2010, data.Year);
            Assert.Equal(12, data.PhotoId);
            Assert.Equal(1, data.SortOrder);
            Assert.NotEmpty(data.OverdueReminders);
        }

        [Fact]
        public void WhenJsonFleetStats_ThenReturnsFleetStatistics()
        {
            var fleetSummaryStatistics = new FleetStatistics(new VehicleStatisticsModel[0]);

            MockHandlerFor(
                () => new Mock<GetFleetSummaryStatistics>(null),
                x => x.Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(fleetSummaryStatistics)
                );

            TestableVehicleController controller = GetTestableVehicleController();
            JsonResult result = controller.JsonFleetStatistics();

            Assert.NotNull(result);

            Assert.Same(fleetSummaryStatistics, result.Data);
        }

        [Fact]
        public void WhenJsonDeleteIsCalled_ThenDeletesVehicle()
        {
            Mock<DeleteVehicle> handler = MockHandlerFor(
                () => new Mock<DeleteVehicle>(null),
                x => x.Setup(h => h.Execute(defaultUser.UserId, DefaultVehicleId))
                         .Verifiable());

            TestableVehicleController controller = GetTestableVehicleController();

            controller.JsonDelete(DefaultVehicleId);

            handler.Verify();
        }

        [Fact]
        public void WhenJsonMakesRequestedForDatafullYear_ThenReturnsAnyMakes()
        {
            const int yearSelected = 1984;

            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(yearSelected, null))
                         .Returns(YearsMakesAndModelsFor.YearWithMakes(yearSelected, "ManufacturerA")));

            TestableVehicleController controller = GetTestableVehicleController();

            JsonResult result = controller.MakesForYear(yearSelected);

            var makeList = (string[])result.Data;
            Assert.Contains("ManufacturerA", makeList);
            Assert.Equal(1, makeList.Count());
        }

        [Fact]
        public void WhenJsonMakesRequestedForDatalessYear_ThenReturnsNoMakes()
        {
            const int yearSelected = 1985;

            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(yearSelected, null))
                         .Returns(YearsMakesAndModelsFor.YearWithoutMakes(yearSelected)));

            TestableVehicleController controller = GetTestableVehicleController();

            JsonResult result = controller.MakesForYear(yearSelected);

            var makeList = (string[])result.Data;
            Assert.Equal(0, makeList.Count());
        }

        [Fact]
        public void WhenJsonModelRequestedForDatafullYearAndMakeRequested_ThenReturnsModels()
        {
            const int yearSelected = 1985;
            const string makeSelected = "ManufacturerA";

            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(yearSelected, makeSelected))
                         .Returns(YearsMakesAndModelsFor.MakeWithModels(yearSelected, makeSelected, "Model1", "Model2")));

            TestableVehicleController controller = GetTestableVehicleController();
            JsonResult result = controller.ModelsForMake(yearSelected, makeSelected);

            var modelList = (string[])result.Data;
            Assert.Equal(2, modelList.Count());
            Assert.Contains("Model1", modelList);
            Assert.Contains("Model2", modelList);
        }

        [Fact]
        public void WhenJsonModelsRequestedForDatalessYearAndMake_ThenReturnsModels()
        {
            const int yearSelected = 1985;
            const string makeSelected = "ManufacturerA";

            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(yearSelected, makeSelected))
                         .Returns(YearsMakesAndModelsFor.MakeWithModels(yearSelected, makeSelected)));

            TestableVehicleController controller = GetTestableVehicleController();

            JsonResult result = controller.ModelsForMake(yearSelected, makeSelected);

            var modelList = (string[])result.Data;
            Assert.Equal(0, modelList.Count());
        }

        [Fact]
        public void WhenAddActionExecuted_ThenResultPopulated()
        {
            MockVehicleList();
            MockDefaultYearMakeModel();
            TestableVehicleController controller = GetTestableVehicleController();

            var actual = controller.Add() as ViewResult;

            Assert.NotNull(actual);
            Assert.Equal(string.Empty, actual.ViewName);
        }

        [Fact]
        public void WhenAddActionExecuted_ThenViewModelContainsVehicleListViewModel()
        {
            MockVehicleList();
            MockDefaultYearMakeModel();

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Add();
            var model = result.Extract<VehicleAddViewModel>();

            Assert.NotNull(model);
        }

        [Fact]
        public void WhenAddActionExecuted_ThenVehicleListSetToCollapsed()
        {
            MockDefaultYearMakeModel();
            MockVehicleList();

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Add();
            var model = result.Extract<VehicleAddViewModel>();

            Assert.True(model.VehiclesList.IsCollapsed);
        }

        [Fact]
        public void WhenAddActionExecuted_ThenSelectListsPopulated()
        {
            var data = new Tuple<int[], string[], string[]>(
                new[] { 1, 2, 3, 4, 5 },
                new[] { "A", "B" },
                new[] { "i", "ii", "iii" }
                );

            MockVehicleList();

            MockHandlerFor(() => new Mock<GetYearsMakesAndModels>(null),
                           x => x
                                    .Setup(h => h.Execute(null, null))
                                    .Returns(data));

            TestableVehicleController controller = GetTestableVehicleController();
            var actual = (ViewResult)controller.Add();

            var yearsSelectList = (SelectList)actual.ViewData["Years"];
            Assert.NotNull(yearsSelectList);
            Assert.Equal(5, yearsSelectList.Count());

            var makesSelectList = (SelectList)actual.ViewData["Makes"];
            Assert.NotNull(makesSelectList);
            Assert.Equal(2, makesSelectList.Count());

            var modelsSelectList = (SelectList)actual.ViewData["Models"];
            Assert.NotNull(modelsSelectList);
            Assert.Equal(3, modelsSelectList.Count());
        }

        [Fact]
        public void WhenAddVehicleActionExecutedWithInvalidVehicle_ThenSelectListsPopulated()
        {
            var data = new Tuple<int[], string[], string[]>(
                new[] { 1, 2, 3, 4, 5 },
                new[] { "A", "B" },
                new[] { "i", "ii", "iii" }
                );

            MockVehicleList();

            MockHandlerFor(() => new Mock<GetYearsMakesAndModels>(null),
                           x => x
                                    .Setup(h => h.Execute(null, null))
                                    .Returns(data));

            TestableVehicleController controller = GetTestableVehicleController();
            controller.ModelState.AddModelError("bad", "bad");

            var actual =
                (ViewResult)controller.Add(new FormCollection { { "Save", "true" } }, new VehicleFormModel(), null);

            var yearsSelectList = (SelectList)actual.ViewData["Years"];
            Assert.NotNull(yearsSelectList);
            Assert.Equal(5, yearsSelectList.Count());

            var makesSelectList = (SelectList)actual.ViewData["Makes"];
            Assert.NotNull(makesSelectList);
            Assert.Equal(2, makesSelectList.Count());

            var modelsSelectList = (SelectList)actual.ViewData["Models"];
            Assert.NotNull(modelsSelectList);
            Assert.Equal(3, modelsSelectList.Count());
        }

        [Fact]
        public void WhenAddVehicleActionExecutedWithInvalidVehicle_ThenVehicleListSetToCollapsed()
        {
            MockVehicleList();
            MockDefaultYearMakeModel();

            TestableVehicleController controller = GetTestableVehicleController();
            controller.ModelState.AddModelError("bad", "bad");

            ActionResult result = controller.Add(new FormCollection { { "Save", "true" } }, new VehicleFormModel(), null);
            var model = result.Extract<VehicleAddViewModel>();

            Assert.True(model.VehiclesList.IsCollapsed);
        }

        [Fact]
        public void WhenAddVehicleActionExecutedWithInvalidVehicle_ViewModelContainsVehicleListViewModel()
        {
            MockVehicleList();
            MockDefaultYearMakeModel();

            TestableVehicleController controller = GetTestableVehicleController();
            controller.ModelState.AddModelError("bad", "bad");

            ActionResult result = controller.Add(new FormCollection { { "Save", "true" } }, new VehicleFormModel(), null);
            var model = result.Extract<VehicleAddViewModel>();

            Assert.NotNull(model);
        }

        [Fact]
        public void WhenAddVehicleActionExecutedWithValidVehicle_ThenRedirectsToDashboard()
        {
            var vehicleForm = new VehicleFormModel();

            MockVehicleList();
            MockDefaultYearMakeModel();

            MockHandlerFor(() => new Mock<CanAddVehicle>(null, null));
            MockHandlerFor(
                () => new Mock<CreateVehicle>(null, null),
                x => x.Setup(h => h.Execute(defaultUser.UserId, vehicleForm, null)));

            TestableVehicleController controller = GetTestableVehicleController();

            ActionResult result = controller.Add(new FormCollection { { "Save", "true" } }, vehicleForm, null);

            var redirect = (RedirectToRouteResult)result;

            Assert.Equal("Dashboard", redirect.RouteName);
        }

        [Fact]
        public void WhenAddVehicleActionExecutedWithValidVehicle_ThenVehicleIsCreated()
        {
            var vehicleForm = new VehicleFormModel();

            MockVehicleList();
            MockDefaultYearMakeModel();

            MockHandlerFor(() => new Mock<CanAddVehicle>(null, null));
            var handler = MockHandlerFor(
                () => new Mock<CreateVehicle>(null,null),
                x => x
                         .Setup(h => h.Execute(defaultUser.UserId, vehicleForm, null))
                         .Verifiable("handler not invoked"));

            TestableVehicleController controller = GetTestableVehicleController();
            controller.Add(new FormCollection { { "Save", "true" } }, vehicleForm, null);

            handler.Verify();
        }

        [Fact]
        public void WhenRequestingVehicleDetails_ThenSetsViewModel()
        {
            var vehicle = new Vehicle { VehicleId = DefaultVehicleId };
            var list = new[] { new VehicleModel(vehicle, new VehicleStatisticsModel()) };

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(list));

            MockHandlerFor(() => new Mock<GetOverdueRemindersForVehicle>(null));

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Details(DefaultVehicleId);

            var model = result.Extract<VehicleDetailsViewModel>();
            Assert.NotNull(model);
        }

        [Fact]
        public void WhenRequestingVehicleDetailsWithoutAValidVehicle_ThenThrows()
        {
            var list = new VehicleModel[] { };

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(list));

            MockHandlerFor(() => new Mock<GetOverdueRemindersForVehicle>(null));

            TestableVehicleController controller = GetTestableVehicleController();

            Assert.Throws<InvalidOperationException>(() => { controller.Details(DefaultVehicleId); });
        }

        [Fact]
        public void WhenRequestingVehicleDetails_ThenSetsVehicleListInViewModel()
        {
            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(DefaultVehicleId.StandardVehicleList()));

            MockHandlerFor(() => new Mock<GetOverdueRemindersForVehicle>(null));

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Details(DefaultVehicleId);
            var model = result.Extract<VehicleDetailsViewModel>();

            Assert.Equal(3, model.VehicleList.Vehicles.Count());
        }

        [Fact]
        public void WhenRequestingVehicleDetails_ThenSetsVehicleListToCollapsedView()
        {
            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(DefaultVehicleId.StandardVehicleList()));

            MockHandlerFor(() => new Mock<GetOverdueRemindersForVehicle>(null));

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Details(DefaultVehicleId);
            var model = result.Extract<VehicleDetailsViewModel>();

            Assert.True(model.VehicleList.IsCollapsed);
        }

        [Fact]
        public void WhenRequestingVehicleDetails_ThenSetsSelectedVehicle()
        {
            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(DefaultVehicleId.StandardVehicleList()));

            MockHandlerFor(() => new Mock<GetOverdueRemindersForVehicle>(null));

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Details(DefaultVehicleId);
            var model = result.Extract<VehicleDetailsViewModel>();

            Assert.Equal(DefaultVehicleId, model.Vehicle.VehicleId);
            Assert.Equal(DefaultVehicleId, model.VehicleList.SelectedVehicle.VehicleId);
        }

        [Fact]
        public void WhenRequestingVehicleDetails_ThenSetsRemindersList()
        {
            const int selectedVehicleId = 99;
            const int odometer = 15000;

            var vehicle = new VehicleModel(
                new Vehicle { VehicleId = selectedVehicleId },
                new VehicleStatisticsModel(0, 0, 0, 0, odometer, 0)
                );

            var reminder = new ReminderSummaryModel(new Reminder(), false);

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                m => m.Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(new[] { vehicle }));

            Mock<GetOverdueRemindersForVehicle> handler = MockHandlerFor(
                () => new Mock<GetOverdueRemindersForVehicle>(null),
                m => m.Setup(h => h.Execute(selectedVehicleId, It.IsAny<DateTime>(), odometer))
                         .Returns(new[] { reminder })
                         .Verifiable("Did not get overdue reminders.")
                );

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Details(selectedVehicleId);

            var model = result.Extract<VehicleDetailsViewModel>();

            handler.Verify();
            Assert.NotNull(model.OverdueReminders);
            Assert.Same(reminder, model.OverdueReminders.First());
        }

        [Fact]
        public void WhenEditGetFormActionExecuted_ThenVehicleListSetToCollapsed()
        {
            MockDefaultYearMakeModel();

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(defaultUser.UserId))
                         .Returns(DefaultVehicleId.StandardVehicleList()));

            TestableVehicleController controller = GetTestableVehicleController();

            ActionResult result = controller.Edit(DefaultVehicleId);
            var model = result.Extract<VehicleAddViewModel>();

            Assert.True(model.VehiclesList.IsCollapsed);
        }

        [Fact]
        public void WhenEditGetFormActionExecuted_ThenSelectListsPopulated()
        {
            var data = new Tuple<int[], string[], string[]>(
                new[] { 1, 2, 3, 4, 5 },
                new[] { "A", "B" },
                new[] { "i", "ii", "iii" }
                );

            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(null, null))
                         .Returns(data));

            MockVehicleListWithVehicles();

            TestableVehicleController controller = GetTestableVehicleController();
            var actual = (ViewResult)controller.Edit(DefaultVehicleId);

            var yearsSelectList = (SelectList)actual.ViewData["Years"];
            Assert.NotNull(yearsSelectList);
            Assert.Equal(5, yearsSelectList.Count());

            var makesSelectList = (SelectList)actual.ViewData["Makes"];
            Assert.NotNull(makesSelectList);
            Assert.Equal(2, makesSelectList.Count());

            var modelsSelectList = (SelectList)actual.ViewData["Models"];
            Assert.NotNull(modelsSelectList);
            Assert.Equal(3, modelsSelectList.Count());
        }

        [Fact]
        public void WhenPopulatingSelectList_ThenItemsHaveTextAndValueProperties()
        {
            var data = new Tuple<int[], string[], string[]>(
                new[] { 2011 },
                new[] { "Manufacturer" },
                new[] { "ModelA", "ModelB", "ModelC" }
                );

            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(null, null))
                         .Returns(data));

            MockVehicleListWithVehicles();

            TestableVehicleController controller = GetTestableVehicleController();
            var actual = (ViewResult)controller.Edit(DefaultVehicleId);

            var yearsSelectList = (SelectList)actual.ViewData["Years"];
            Assert.Equal("2011", yearsSelectList.First().Text);
            Assert.Equal("2011", yearsSelectList.First().Value);

            var makesSelectList = (SelectList)actual.ViewData["Makes"];
            Assert.Equal("Manufacturer", makesSelectList.First().Text);
            Assert.Equal("Manufacturer", makesSelectList.First().Value);

            var modelsSelectList = (SelectList)actual.ViewData["Models"];
            Assert.Equal("ModelB", modelsSelectList.Skip(1).First().Text);
            Assert.Equal("ModelB", modelsSelectList.Skip(1).First().Value);
        }

        [Fact]
        public void WhenEditVehicleActionExecutedWithValidVehicle_ThenRedirectsToDetails()
        {
            MockVehicleList();
            MockDefaultYearMakeModel();
            MockHandlerFor(() => new Mock<CanValidateVehicleYearMakeAndModel>(null));
            MockHandlerFor(() => new Mock<UpdateVehicle>(null, null));

            var vehicle = new VehicleFormModel { VehicleId = DefaultVehicleId, Name = "test" };
            var form = new FormCollection { { "Save", "true" } };

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Edit(form, vehicle, null);

            Assert.IsType<RedirectToRouteResult>(result);
            var redirect = (RedirectToRouteResult)result;

            Assert.Equal("Details", redirect.RouteValues["action"]);
            Assert.Equal("Vehicle", redirect.RouteValues["controller"]);
        }

        [Fact]
        public void WhenEditGetFormActionExecuted_ThenViewModelContainsVehicleListViewModel()
        {
            MockVehicleListWithVehicles();
            MockDefaultYearMakeModel();

            TestableVehicleController controller = GetTestableVehicleController();

            ActionResult result = controller.Edit(DefaultVehicleId);
            var model = result.Extract<VehicleAddViewModel>();

            Assert.IsType<VehicleAddViewModel>(model);
        }

        [Fact]
        public void WhenEditVehicleActionExecutedWithInValidVehicle_ViewModelContainsVehicleListViewModel()
        {
            MockVehicleListWithVehicles();
            MockDefaultYearMakeModel();

            TestableVehicleController controller = GetTestableVehicleController();
            controller.ModelState.AddModelError("bad", "bad");

            var vehicle = new VehicleFormModel { VehicleId = 1, Name = null };
            var form = new FormCollection { { "Save", "true" } };

            ActionResult result = controller.Edit(form, vehicle, null);
            var model = result.Extract<VehicleAddViewModel>();

            Assert.IsType<VehicleAddViewModel>(model);
        }

        [Fact]
        public void WhenEditVehicleActionExecutedWithInValidVehicle_ThenVehicleListSetToCollapsed()
        {
            MockVehicleListWithVehicles();
            MockDefaultYearMakeModel();

            TestableVehicleController controller = GetTestableVehicleController();
            controller.ModelState.AddModelError("bad", "bad");

            var vehicle = new VehicleFormModel { VehicleId = 1, Name = null };
            var form = new FormCollection { { "Save", "true" } };

            ActionResult result = controller.Edit(form, vehicle, null);
            var model = result.Extract<VehicleAddViewModel>();

            Assert.True(model.VehiclesList.IsCollapsed);
        }

        [Fact]
        public void WhenEditVehicleActionExecutedWithInvalidVehicle_ThenSelectListsPopulated()
        {
            const int year = 1984;
            const string make = "make";

            var data = new Tuple<int[], string[], string[]>(
                new[] { 1, 2, 3, 4, 5 },
                new[] { "A", "B" },
                new[] { "i", "ii", "iii" }
                );

            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(year, make))
                         .Returns(data));

            MockVehicleListWithVehicles();

            TestableVehicleController controller = GetTestableVehicleController();
            controller.ModelState.AddModelError("bad", "bad");

            var vehicleForm = new VehicleFormModel { VehicleId = DefaultVehicleId, Name = null, Year = year, MakeName = make };
            var form = new FormCollection { { "Save", "true" } };

            var actual = (ViewResult)controller.Edit(form, vehicleForm, null);

            var yearsSelectList = (SelectList)actual.ViewData["Years"];
            Assert.NotNull(yearsSelectList);
            Assert.Equal(5, yearsSelectList.Count());

            var makesSelectList = (SelectList)actual.ViewData["Makes"];
            Assert.NotNull(makesSelectList);
            Assert.Equal(2, makesSelectList.Count());

            var modelsSelectList = (SelectList)actual.ViewData["Models"];
            Assert.NotNull(modelsSelectList);
            Assert.Equal(3, modelsSelectList.Count());
        }

        [Fact]
        public void WhenVehicleDeleted_ThenRedirectsToDashboard()
        {
            MockHandlerFor(
                () => new Mock<DeleteVehicle>(null),
                mock => mock.Setup(h => h.Execute(defaultUser.UserId, DefaultVehicleId))
                );

            TestableVehicleController controller = GetTestableVehicleController();
            ActionResult result = controller.Delete(DefaultVehicleId);

            Assert.IsType<RedirectToRouteResult>(result);
            var redirect = (RedirectToRouteResult)result;

            Assert.Equal("Dashboard", redirect.RouteName);
        }

        [Fact]
        public void WhenVehicleDeleted_ThenCallsServicesDelete()
        {
            const int vehicleToDelete = 99;

            Mock<DeleteVehicle> handler = MockHandlerFor(
                () => new Mock<DeleteVehicle>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId, vehicleToDelete))
                            .Verifiable("delete handler was not invoke")
                );

            TestableVehicleController controller = GetTestableVehicleController();

            controller.Delete(vehicleToDelete);

            handler.Verify();
        }

        [Fact]
        public void WhenPhotoForValidPhoto_ThenPhotoReturned()
        {
            const int photoId = 33;

            MockHandlerFor(
                () => new Mock<GetVehiclePhoto>(null),
                x => x
                         .Setup(h => h.Execute(photoId))
                         .Returns(new VehiclePhoto
                                      {
                                          Image = new byte[] { },
                                          ImageMimeType = "something"
                                      }));

            TestableVehicleController controller = GetTestableVehicleController();
            var result = (FileStreamResult)controller.Photo(photoId);

            Assert.NotNull(result.FileStream);
        }

        [Fact]
        public void WhenPhotoForInvalidPhoto_ThenDefaultPhotoReturned()
        {
            const int photoId = 33;

            MockHandlerFor(
                () => new Mock<GetVehiclePhoto>(null),
                x => x
                         .Setup(h => h.Execute(photoId))
                         .Throws(new BusinessServicesException("BadImage")));

            TestableVehicleController controller = GetTestableVehicleController();

            Mock.Get(controller.HttpContext)
                .SetupGet(x => x.Request.ApplicationPath)
                .Returns("/Something");

            Mock.Get(controller.HttpContext)
                .Setup(x => x.Response.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns("/Something/Content/vehicle.png");

            var result = (FilePathResult)controller.Photo(photoId);
            Assert.Contains("Something/Content/vehicle.png", result.FileName);
        }

        private Mock<T> MockHandlerFor<T>(Func<Mock<T>> create, Action<Mock<T>> setup = null) where T : class
        {
            return serviceLocator.MockHandlerFor(create, setup);
        }

        private void MockHandlers()
        {
            MockStatistics();

            MockVehicleList();

            MockImminentReminders();
        }

        private void MockVehicleList()
        {
            var vm = new[] {  new VehicleModel(new Vehicle(), new VehicleStatisticsModel()) };

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Returns(vm)
                );
        }

        private void MockImminentReminders()
        {
            MockHandlerFor(
                () => new Mock<GetImminentRemindersForUser>(null, null),
                mock => mock.Setup(h => h.Execute(defaultUser.UserId, It.IsAny<DateTime>(), NoVehicleSelectedId))
                );
        }

        private void MockStatistics()
        {
            var fleetSummaryStatistics = new FleetStatistics(new VehicleStatisticsModel[0]);

            MockHandlerFor(
                () => new Mock<GetFleetSummaryStatistics>(null),
                mock => mock
                            .Setup(h => h.Execute(defaultUser.UserId))
                            .Returns(fleetSummaryStatistics)
                );
        }

        private void MockVehicleListWithVehicles()
        {
            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x.StandardSetup(defaultUser.UserId, DefaultVehicleId));
        }

        private void MockDefaultYearMakeModel()
        {
            MockHandlerFor(
                () => new Mock<GetYearsMakesAndModels>(null),
                x => x
                         .Setup(h => h.Execute(null, null))
                         .Returns(YearsMakesAndModelsFor.YearWithoutMakes(2010))
                );
        }

        // returns controller with mocks
        private TestableVehicleController GetTestableVehicleController()
        {
            var c = new TestableVehicleController(userServicesMock.Object, countryServicesMock.Object,
                                                  chartDataServiceMock.Object, serviceLocator.Object);
            c.SetFakeControllerContext();
            c.SetUserIdentity(new MileageStatsIdentity(defaultUserInfo.ClaimsIdentifier,
                                                       defaultUserInfo.DisplayName,
                                                       defaultUserInfo.UserId));

            c.InvokeInitialize(c.ControllerContext.RequestContext);

            return c;
        }
    }

    internal class TestableVehicleController : VehicleController
    {
        public TestableVehicleController(IUserServices userServices, ICountryServices countryService,
                                         IChartDataService chartDataService, IServiceLocator serviceLocator)
            : base(userServices, countryService, chartDataService, serviceLocator)
        {
        }

        public void InvokeInitialize(RequestContext context)
        {
            base.Initialize(context);
        }
    }
}