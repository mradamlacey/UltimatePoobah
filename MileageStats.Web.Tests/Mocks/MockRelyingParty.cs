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
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using MileageStats.Web.Authentication;
using Moq;

namespace MileageStats.Web.Tests.Mocks
{
    internal class MockRelyingParty : IOpenIdRelyingParty
    {
        private readonly IAuthenticationResponse response;

        public MockRelyingParty()
        {
            var mock = new Mock<IAuthenticationResponse>();
            mock.SetupGet(r => r.Status).Returns(AuthenticationStatus.Authenticated);
            this.response = mock.Object;
        }

        IAuthenticationResponse IOpenIdRelyingParty.GetResponse()
        {
            return this.response;
        }

        public ActionResult RedirectToProvider(string providerUrl, string returnUrl, FetchRequest fetch)
        {
            return new EmptyResult();
        }

        public Mock<IAuthenticationResponse> ResponseMock
        {
            get { return Mock.Get(this.response); }
        }
    }
}