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
using MileageStats.Model;
using MileageStats.Web.Controllers;
using MileageStats.Web.Models;
using MileageStats.Web.Tests.Mocks;
using Moq;
using Xunit;
using User = MileageStats.Domain.Models.User;

namespace MileageStats.Web.Tests.Controllers
{
    public class ReminderControllerFixture
    {
        private const int defaultVehicleId = 99;
        private readonly User _defaultUser;

        private readonly Mock<IUserServices> _mockUserServices;
        private readonly Mock<IServiceLocator> _serviceLocator;

        public ReminderControllerFixture()
        {
            _serviceLocator = new Mock<IServiceLocator>();

            _defaultUser = new User { AuthorizationId = "TestClaimsIdentifier", UserId = 5 };

            _mockUserServices = new Mock<IUserServices>();
            _mockUserServices
                .Setup(s => s.GetUserByClaimedIdentifier(_defaultUser.AuthorizationId))
                .Returns(_defaultUser);
        }

        [Fact]
        public void WhenListReminderGetWithValidVehicleId_ThenReturnsView()
        {
            var vehicles = new[]
                               {
                                   new VehicleModel(new Vehicle {VehicleId = defaultVehicleId},
                                                             new VehicleStatisticsModel())
                               };

            var reminders = new[]
                                {
                                   new Reminder {ReminderId = 1},
                                   new Reminder {ReminderId = 2}
                                };

            MockHandlerFor(
                () => new Mock<GetUnfulfilledRemindersForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId, 0))
                         .Returns(reminders));

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId))
                         .Returns(vehicles));

            ReminderController controller = GetTestableReminderController();
            ActionResult result = controller.List(defaultVehicleId);

            var model = result.Extract<ReminderDetailsViewModel>();

            Assert.Equal(vehicles.Length, model.VehicleList.Vehicles.List.Count());
            Assert.Same(vehicles[0], model.VehicleList.Vehicles.SelectedItem);
            Assert.Equal(reminders.Length, model.Reminders.List.Count());
            Assert.Equal(reminders[0].ReminderId, model.Reminders.SelectedItem.ReminderId);
        }

        [Fact]
        public void WhenAddReminderGetWithValidVehicleId_ThenReturnsView()
        {
            MockDefaultHandlers();

            ReminderController controller = GetTestableReminderController();

            ActionResult result = controller.Add(defaultVehicleId);

            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void WhenAddReminderPostWithNullReminder_ThenReturnsToCreatePage()
        {
            MockDefaultHandlers();

            ReminderController controller = GetTestableReminderController();

            ActionResult result = controller.Add(defaultVehicleId, null);

            Assert.IsType(typeof(ViewResult), result);
        }

        [Fact]
        public void WhenAddReminderPostWithInvalidReminder_ThenReturnsToCreatePage()
        {
            MockDefaultHandlers();

            ReminderController controller = GetTestableReminderController();
            controller.ModelState.AddModelError("test", "test error");

            var reminderForm = new ReminderFormModel();
            ActionResult result = controller.Add(defaultVehicleId, reminderForm);

            Assert.IsType(typeof(ViewResult), result);
        }

        [Fact]
        public void WhenAddRemindersWithValidReminder_ThenUpdatesVehicleInRepository()
        {
            var formModel = new ReminderFormModel();

            MockDefaultHandlers();

            MockHandlerFor(
                () => new Mock<CanAddReminder>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, formModel))
                         .Returns(new ValidationResult[] { }));

            var handler = MockHandlerFor(
                () => new Mock<AddReminderToVehicle>(null, null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId, formModel))
                         .Verifiable("add handler not called"));

            var controller = GetTestableReminderController();
            controller.Add(defaultVehicleId, formModel);

            handler.Verify();
        }

        [Fact]
        public void WhenAddReminderWithValidReminder_ThenReturnsToReminderDetailsView()
        {
            var formModel = new ReminderFormModel();

            MockDefaultHandlers();

            MockHandlerFor(
                () => new Mock<CanAddReminder>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, formModel))
                         .Returns(new ValidationResult[] { }));

            MockHandlerFor(
                () => new Mock<AddReminderToVehicle>(null, null),
                x => x.Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId, formModel)));

            ReminderController controller = GetTestableReminderController();
            var result = (RedirectToRouteResult)controller.Add(defaultVehicleId, formModel);

            Assert.NotNull(result);
            Assert.Equal("Details", result.RouteValues["action"]);
            Assert.Equal("Reminder", result.RouteValues["controller"]);
        }

        [Fact]
        public void WhenDeletingReminder_ThenReturnsToDashboardPage()
        {
            const int reminderId = 123;

            var reminder = new Reminder
                               {
                                   ReminderId = reminderId,
                                   Title = "TestReminder",
                                   DueDate = DateTime.UtcNow,
                                   DueDistance = 5
                               };

            MockHandlerFor(
                () => new Mock<GetReminder>(null),
                x => x
                         .Setup(h => h.Execute(reminderId))
                         .Returns(reminder));

            MockHandlerFor(
                () => new Mock<DeleteReminder>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, reminderId)));

            ReminderController controller = GetTestableReminderController();

            var result = (RedirectToRouteResult)controller.Delete(reminder.ReminderId);
            Assert.NotNull(result);
            Assert.Equal("List", result.RouteValues["action"]);
            Assert.Equal("Reminder", result.RouteValues["controller"]);
        }

        [Fact]
        public void WhenDeletingReminder_ThenRepositoryDeleteCalled()
        {
            const int reminderId = 123;

            var reminder = new Reminder
                               {
                                   ReminderId = reminderId,
                                   Title = "TestReminder",
                                   DueDate = DateTime.UtcNow,
                                   DueDistance = 5
                               };

            MockHandlerFor(
                () => new Mock<GetReminder>(null),
                x => x
                         .Setup(h => h.Execute(reminderId))
                         .Returns(reminder));

            Mock<DeleteReminder> handler = MockHandlerFor(
                () => new Mock<DeleteReminder>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, reminderId))
                         .Verifiable("delete handler not called"));

            ReminderController controller = GetTestableReminderController();

            controller.Delete(reminder.ReminderId);

            handler.Verify();
        }

        [Fact]
        public void WhenOverdueList_ThenReturnsModel()
        {
            ReminderController controller = GetTestableReminderController();

            controller.HttpContext.Request.SetAjaxRequest();
            controller.HttpContext.Request.SetJsonRequest();

            var dueDate = new DateTime(2010, 12, 1, 0, 0, 0, DateTimeKind.Utc);
            var reminders = new[]
                                {
                                    new ReminderModel
                                        {
                                            ReminderId = 1,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder1",
                                            DueDate = dueDate
                                        },
                                    new ReminderModel
                                        {
                                            ReminderId = 2,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder2",
                                            DueDistance = 1000
                                        },
                                    new ReminderModel
                                        {
                                            ReminderId = 3,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder3",
                                            DueDate = dueDate,
                                            DueDistance = 1000
                                        },
                                };

            MockHandlerFor(
                () => new Mock<GetOverdueRemindersForUser>(null, null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId))
                         .Returns(reminders));

            MockHandlerFor(
                () => new Mock<GetVehicleById>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId))
                         .Returns(new VehicleModel(
                                      new Vehicle { VehicleId = defaultVehicleId, Name = "Vehicle" },
                                      new VehicleStatisticsModel())));

            var result = (JsonResult)controller.OverdueList();
            var model = (JsonRemindersOverdueListViewModel)result.Data;
            var list = new List<OverdueReminderViewModel>(model.Reminders);

            Assert.Equal(reminders.Length, model.Reminders.Count());

            Assert.Equal("Reminder1 | Vehicle @ 12/1/2010", list[0].FullTitle);
            Assert.Equal("Reminder2 | Vehicle @ 1000", list[1].FullTitle);
            Assert.Equal("Reminder3 | Vehicle @ 12/1/2010 or 1000", list[2].FullTitle);
        }

        [Fact]
        public void WhenOverdueListWhenNoReminders_ThenReturnsModelWithEmptyCollection()
        {
            ReminderController controller = GetTestableReminderController();

            controller.HttpContext.Request.SetAjaxRequest();
            controller.HttpContext.Request.SetJsonRequest();

            MockHandlerFor(
                () => new Mock<GetOverdueRemindersForUser>(null, null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId))
                         .Returns(new ReminderModel[] { }));

            MockHandlerFor(
                () => new Mock<GetVehicleById>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId))
                         .Returns(new VehicleModel(
                                      new Vehicle { VehicleId = defaultVehicleId, Name = "Vehicle" },
                                      new VehicleStatisticsModel())));

            var result = (JsonResult)controller.OverdueList();
            var model = (JsonRemindersOverdueListViewModel)result.Data;
            var list = new List<OverdueReminderViewModel>(model.Reminders);

            Assert.Equal(0, list.Count());
        }

        [Fact]
        public void WhenOverdueListInvalidUser_ThenThrows()
        {
            ReminderController controller = GetTestableReminderController();

            controller.HttpContext.Request.SetAjaxRequest();
            controller.HttpContext.Request.SetJsonRequest();

            MockHandlerFor(
                () => new Mock<GetOverdueRemindersForUser>(null, null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId))
                         .Throws(new BusinessServicesException("Unable to get overdue reminders.")));

            MockHandlerFor(
                () => new Mock<GetVehicleById>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId))
                         .Returns(new VehicleModel(
                                      new Vehicle { VehicleId = defaultVehicleId, Name = "Vehicle" },
                                      new VehicleStatisticsModel())));

            Assert.Throws<BusinessServicesException>(() => { controller.OverdueList(); });
        }

        [Fact]
        public void WhenOverdueListWithNonAjaxCall_ThenReturnsEmpty()
        {
            ReminderController controller = GetTestableReminderController();

            controller.HttpContext.Request.SetJsonRequest();
            // no ajax set on context

            var dueDate = new DateTime(2010, 12, 1, 0, 0, 0, DateTimeKind.Utc);
            var reminders = new[]
                                {
                                    new ReminderModel
                                        {
                                            ReminderId = 1,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder1",
                                            DueDate = dueDate
                                        },
                                    new ReminderModel
                                        {
                                            ReminderId = 2,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder2",
                                            DueDistance = 1000
                                        },
                                    new ReminderModel
                                        {
                                            ReminderId = 3,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder3",
                                            DueDate = dueDate,
                                            DueDistance = 1000
                                        },
                                };

            MockHandlerFor(
                () => new Mock<GetOverdueRemindersForUser>(null, null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId))
                         .Returns(reminders));

            MockHandlerFor(
                () => new Mock<GetVehicleById>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId))
                         .Returns(new VehicleModel(
                                      new Vehicle { VehicleId = defaultVehicleId, Name = "Vehicle" },
                                      new VehicleStatisticsModel())));

            ActionResult result = controller.OverdueList();

            Assert.IsType<EmptyResult>(result);
        }

        [Fact]
        public void WhenOverdueListWithNonJsonCall_ThenReturnsEmpty()
        {
            ReminderController controller = GetTestableReminderController();

            controller.HttpContext.Request.SetAjaxRequest();
            // no json set on context

            var dueDate = new DateTime(2010, 12, 1, 0, 0, 0, DateTimeKind.Utc);
            var reminders = new[]
                                {
                                    new ReminderModel
                                        {
                                            ReminderId = 1,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder1",
                                            DueDate = dueDate
                                        },
                                    new ReminderModel
                                        {
                                            ReminderId = 2,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder2",
                                            DueDistance = 1000
                                        },
                                    new ReminderModel
                                        {
                                            ReminderId = 3,
                                            VehicleId = defaultVehicleId,
                                            Title = "Reminder3",
                                            DueDate = dueDate,
                                            DueDistance = 1000
                                        },
                                };

            MockHandlerFor(
                () => new Mock<GetOverdueRemindersForUser>(null, null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId))
                         .Returns(reminders));

            MockHandlerFor(
                () => new Mock<GetVehicleById>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId))
                         .Returns(new VehicleModel(
                                      new Vehicle { VehicleId = defaultVehicleId, Name = "Vehicle" },
                                      new VehicleStatisticsModel())));

            ActionResult result = controller.OverdueList();

            Assert.IsType<EmptyResult>(result);
        }

        [Fact]
        public void WhenRetrievingJsonImminentReminders_ThenImminentReminders()
        {
            ReminderController controller = GetTestableReminderController();

            var dueDate = new DateTime(2010, 12, 1, 0, 0, 0, DateTimeKind.Utc);
            var reminders = new[]
                                {
                                    new ImminentReminderModel(new Vehicle(),
                                                                  new Reminder
                                                                      {
                                                                          ReminderId = 1,
                                                                          VehicleId = defaultVehicleId,
                                                                          Title = "Reminder1",
                                                                          DueDate = dueDate
                                                                      }, isOverdue: true),
                                    //new ReminderFormModel {ReminderId = 2, VehicleId = defaultVehicleId, Title = "Reminder2", DueDistance = 1000},
                                    //new ReminderFormModel {ReminderId = 3, VehicleId = defaultVehicleId, Title = "Reminder3", DueDate = dueDate, DueDistance = 1000},
                                };

            MockHandlerFor(
                () => new Mock<GetImminentRemindersForUser>(null, null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, It.IsAny<DateTime>(), 0))
                         .Returns(reminders));

            MockHandlerFor(
                () => new Mock<GetVehicleById>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId))
                         .Returns(new VehicleModel(
                                      new Vehicle { VehicleId = defaultVehicleId, Name = "Vehicle" },
                                      new VehicleStatisticsModel())));

            JsonResult result = controller.JsonImminentReminders();

            Assert.NotNull(result);

            var actualModel = result.Data as IEnumerable<ImminentReminderModel>;
            Assert.NotNull(actualModel);
            Assert.Equal(reminders.Count(), actualModel.Count());
        }

        [Fact]
        public void WhenGettingJsonList_ThenJsonRemindersViewModelReturned()
        {
            var vehicles = new[]
                               {
                                   new VehicleModel(new Vehicle {VehicleId = defaultVehicleId},
                                                             new VehicleStatisticsModel())
                               };

            var reminders = new[]
                                {
                                    new Reminder {ReminderId = 1, Title = "test reminder"},
                                    new Reminder {ReminderId = 2}
                                };

            MockHandlerFor(
                () => new Mock<GetUnfulfilledRemindersForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId, 0))
                         .Returns(reminders));

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId))
                         .Returns(vehicles));

            ReminderController controller = GetTestableReminderController();

            JsonResult result = controller.JsonList(defaultVehicleId);

            JsonResult jsonResult = result;
            Assert.NotNull(jsonResult);
            var data = jsonResult.Data as JsonRemindersViewModel;
            Assert.NotNull(data);
            Assert.NotNull(data.Reminders);
            Assert.Equal(reminders.Count(), data.Reminders.Count);
            Assert.Equal("test reminder", data.Reminders[0].Title);
        }

        [Fact]
        public void WhenCallingJsonFulfill_ThenDelegatesToBusinessServices()
        {
            const int reminderId = 321;

            Mock<FulfillReminder> handler = MockHandlerFor(
                () => new Mock<FulfillReminder>(null),
                x => x
                         .Setup(h => h.Execute(reminderId))
                         .Verifiable("fulfil hanlder was not called"));

            ReminderController controller = GetTestableReminderController();

            controller.JsonFulfill(reminderId);

            handler.Verify();
        }

        private ReminderController GetTestableReminderController()
        {
            var controller = new ReminderController(_mockUserServices.Object, _serviceLocator.Object);
            controller.SetFakeControllerContext();
            controller.SetUserIdentity(new MileageStatsIdentity(_defaultUser.AuthorizationId,
                                                                _defaultUser.DisplayName,
                                                                _defaultUser.UserId));
            return controller;
        }

        private Mock<T> MockHandlerFor<T>(Func<Mock<T>> create, Action<Mock<T>> setup = null) where T : class
        {
            return _serviceLocator.MockHandlerFor(create, setup);
        }

        private void MockDefaultHandlers()
        {
            MockHandlerFor(
                () => new Mock<GetUnfulfilledRemindersForVehicle>(null),
                x => x
                         .Setup(h => h.Execute(_defaultUser.UserId, defaultVehicleId, 0))
                         .Returns(new Reminder[] { }));

            MockHandlerFor(
                () => new Mock<GetVehicleListForUser>(null),
                x => x.StandardSetup(_defaultUser.UserId, defaultVehicleId, defaultVehicleId));
        }
    }
}