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
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MileageStats.Domain.Contracts;
using MileageStats.Domain.Models;
using MileageStats.Web.Authentication;
using MileageStats.Web.Controllers;
using MileageStats.Web.Models;
using MileageStats.Web.Tests.Mocks;
using Moq;
using Xunit;

namespace MileageStats.Web.Tests.Controllers
{
    public class ProfileControllerFixture
    {
        private readonly Mock<ICountryServices> countryServicesMock;
        private readonly User currentUser;
        private readonly Mock<IFormsAuthentication> formsAuthenticationMock;
        private readonly ProfileController profileController;
        private readonly Mock<IUserServices> userServicesMock;
        private User modifiedUser;

        public ProfileControllerFixture()
        {
            currentUser = new User {UserId = 1};
            formsAuthenticationMock = new Mock<IFormsAuthentication>();
            userServicesMock = new Mock<IUserServices>();

            userServicesMock
                .Setup(r => r.GetUserByClaimedIdentifier(It.IsAny<string>()))
                .Returns(currentUser);

            userServicesMock.Setup(r => r.UpdateUser(It.IsAny<User>()))
                .Callback((User u) => { modifiedUser = u; }).Verifiable();

            countryServicesMock = new Mock<ICountryServices>();
            countryServicesMock
                .Setup(r => r.GetCountriesAndRegionsList())
                .Returns(() => new ReadOnlyCollection<string>(new List<string> {"a", "b"}));

            profileController = new ProfileController(
                userServicesMock.Object,
                countryServicesMock.Object,
                formsAuthenticationMock.Object);

            profileController.SetFakeControllerContext();
            profileController.SetUserIdentity(new MileageStatsIdentity("CleverClaimsId", "Test display name", 1));
        }

        [Fact]
        public void WhenDriverGoesToEditProfilePage_ThenEditFormIsDisplayedWithCurrentUserData()
        {
            ActionResult response = profileController.Edit();

            Assert.IsType<ViewResult>(response);
            var result = (ViewResult) response;
            var viewModel = result.Model as User;
            Assert.NotNull(viewModel);
            Assert.Equal(currentUser.DisplayName, viewModel.DisplayName);
        }

        [Fact]
        public void WhenDriverGoesToEditProfilePage_ThenCountryListIsAddedToViewBag()
        {
            ActionResult response = profileController.Edit();

            Assert.IsType<ViewResult>(response);
            var result = (ViewResult) response;
            Assert.NotNull(result.ViewBag.CountryList);
        }

        [Fact]
        public void WhenDriverEditsProfile_ThenProfileIsDisplayed()
        {
            var updatedUser = new User {DisplayName = "Updated name", AuthorizationId = "CleverClaimsId", UserId = 1};

            ActionResult response = profileController.Edit(updatedUser);

            Assert.IsType<RedirectToRouteResult>(response);

            var result = (RedirectToRouteResult) response;
            Assert.Equal("Dashboard", result.RouteName);
        }

        [Fact]
        public void WhenDriverEditsProfile_ThenRepositoryIsUpdated()
        {
            var updatedUser = new User {DisplayName = "Updated name", AuthorizationId = "CleverClaimsId", UserId = 1};

            ActionResult response = profileController.Edit(updatedUser);

            userServicesMock.Verify(r => r.UpdateUser(It.IsAny<User>()));
            Assert.Same(updatedUser, modifiedUser);
        }

        [Fact]
        public void WhenDriverEditsProfile_ThenAuthenticationTicketIsSet()
        {
            var updatedUser = new User {DisplayName = "Updated name", AuthorizationId = "CleverClaimsId", UserId = 1};

            profileController.Edit(updatedUser);

            formsAuthenticationMock.Verify(
                a => a.SetAuthCookie(It.IsAny<HttpContextBase>(), It.IsAny<FormsAuthenticationTicket>()), Times.Once());
        }

        [Fact]
        public void WhenDriverEditsProfile_ThenHasRegisteredIsTrue()
        {
            var updatedUser = new User {DisplayName = "Updated name", AuthorizationId = "CleverClaimsId", UserId = 1};

            profileController.Edit(updatedUser);

            Assert.True(updatedUser.HasRegistered);
        }

        [Fact]
        public void WhenDriverEditsProfile_ThenAuthenticationTicketIsSetWithUpdatedUserData()
        {
            FormsAuthenticationTicket newTicket = null;
            formsAuthenticationMock
                .Setup(a => a.SetAuthCookie(It.IsAny<HttpContextBase>(), It.IsAny<FormsAuthenticationTicket>()))
                .Callback<HttpContextBase, FormsAuthenticationTicket>((c, a) => { newTicket = a; });

            var updatedUser = new User {DisplayName = "Updated name", AuthorizationId = "CleverClaimsId", UserId = 1};

            profileController.Edit(updatedUser);

            Assert.Equal(updatedUser.AuthorizationId, newTicket.Name);
            UserInfo userInfo = UserInfo.FromString(newTicket.UserData);
            Assert.NotNull(userInfo);
            Assert.Equal(updatedUser.AuthorizationId, userInfo.ClaimsIdentifier);
            Assert.Equal(updatedUser.DisplayName, userInfo.DisplayName);
            Assert.Equal(updatedUser.UserId, userInfo.UserId);
        }

        [Fact]
        public void WhenDriverAttemptsToEditOtherUsersProfile_ThenThrows()
        {
            var updatedUser = new User {UserId = 2, DisplayName = "Other User", AuthorizationId = "AnotherClaimsId"};

            Assert.Throws<SecurityException>(() => { ActionResult response = profileController.Edit(updatedUser); });

            userServicesMock.Verify(r => r.UpdateUser(It.IsAny<User>()), Times.Never());
        }

        [Fact]
        public void WhenRequestingEditForm_ThenViewModelContainsUser()
        {
            var result = (ViewResult) profileController.Edit();
            var model = (User) result.Model;

            Assert.NotNull(model);
        }

        [Fact]
        public void WhenRequestingEditForm_ThenViewBagContainsCountriesList()
        {
            var result = profileController.Edit() as ViewResult;

            Assert.NotNull(result.ViewBag.CountryList);
        }

        [Fact]
        public void WhenEditingValidProfile_ThenRedirectsToIndex()
        {
            var updatedUser = new User {UserId = 1};
            var result = profileController.Edit(updatedUser) as RedirectToRouteResult;

            Assert.Equal("Dashboard", result.RouteName);
        }

        [Fact]
        public void WhenEditingInvalidProfile_ThenViewBagContainsCountriesList()
        {
            profileController.ModelState.AddModelError("bad", "bad");
            var updatedUser = new User
                                  {
                                      DisplayName = "InvalidDisplayName__InvalidDisplayName__InvalidDisplayName__",
                                      AuthorizationId = "CleverClaimsId",
                                      UserId = 1
                                  };
            var result = profileController.Edit(updatedUser) as ViewResult;

            Assert.NotNull(result.ViewBag.CountryList);
        }

        [Fact]
        public void WhenCompletingRegistration_ThenUserUpdated()
        {
            var testUser = new User
                               {
                                   UserId = 1,
                                   DisplayName = "DisplayName",
                                   PostalCode = "12345",
                                   Country = "United States"
                               };

            userServicesMock
                .Setup(r => r.GetUserByClaimedIdentifier(It.IsAny<string>()))
                .Returns(testUser);

            var controller = new ProfileController(
                userServicesMock.Object,
                countryServicesMock.Object,
                formsAuthenticationMock.Object);

            controller.SetFakeControllerContext();
            controller.SetUserIdentity(new MileageStatsIdentity("TestName", "TestDisplayName", 1));

            ActionResult response = controller.CompleteRegistration(testUser);

            userServicesMock
                .Verify(x => x.UpdateUser(testUser), Times.Once());

            formsAuthenticationMock
                .Verify(x => x.SetAuthCookie(It.IsAny<HttpContextBase>(), It.IsAny<FormsAuthenticationTicket>()),
                        Times.Once());

            var result = (RedirectToRouteResult) response;
            Assert.Equal("Dashboard", result.RouteName);
        }

        [Fact]
        public void WhenCompletingRegistrationWithInvalidUser_ThenViewReturned()
        {
            var user = new User {UserId = 1, DisplayName = new string('X', 200)};

            userServicesMock
                .Setup(r => r.GetUserByClaimedIdentifier(It.IsAny<string>()))
                .Returns(user);

            var controller = new ProfileController(
                userServicesMock.Object,
                countryServicesMock.Object,
                formsAuthenticationMock.Object);

            controller.SetFakeControllerContext();
            controller.ModelState.AddModelError("DisplayName", "Too long");

            controller.SetUserIdentity(new MileageStatsIdentity("TestName", "TestDisplayName", 1));

            ActionResult actual = controller.CompleteRegistration(user);

            Assert.IsType<ViewResult>(actual);
            var viewResult = (ViewResult) actual;
            Assert.NotNull(viewResult.ViewBag.CountryList);
            var model = (User) viewResult.Model;
            Assert.NotNull(model);
            Assert.Same(user, model);
        }

        [Fact]
        public void WhenCompletingRegistrationWithDifferentUser_ThenThrows()
        {
            var user = new User {UserId = 2};
            var actualUser = new User {UserId = 1};

            userServicesMock.Setup(r => r.GetUserByClaimedIdentifier(It.IsAny<string>())).Returns(actualUser);

            var controller = new ProfileController(
                userServicesMock.Object,
                countryServicesMock.Object,
                formsAuthenticationMock.Object);

            controller.SetFakeControllerContext();
            controller.SetUserIdentity(new MileageStatsIdentity("TestName", "TestDisplayName", 1));

            Assert.Throws<SecurityException>(() => { controller.CompleteRegistration(user); });
        }
    }
}