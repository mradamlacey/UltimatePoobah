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
using System.Security.Principal;
using System.Web.Mvc;
using Moq;

namespace MileageStats.Web.Tests.Mocks
{
    internal static class ControllerMockHelpers
    {
        /// <summary>
        /// Sets the controller User to a GenericPrincipal with the supplied identity
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="identity"></param>
        /// <remarks>
        /// Assumes that the Controller.HttpContext is a Mock/></remarks>
        public static void SetUserIdentity(this Controller controller, IIdentity identity)
        {
            Mock.Get(controller.HttpContext).Setup(x => x.User).Returns(new GenericPrincipal(identity, null));
        }
    }
}