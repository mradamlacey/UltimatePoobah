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
using System.Web;
using System.Web.Security;
using MileageStats.Web.Authentication;
using MileageStats.Web.Tests.Mocks;
using Moq;
using Xunit;

namespace MileageStats.Web.Tests
{
    public class DefaultFormsAuthenticationFixture
    {
        [Fact]
        public void WhenSettingAuthenticationCookieFromTicket_ThenAddsToResponseCookie()
        {
            var cookies = new HttpCookieCollection();
            var formsAuth = new DefaultFormsAuthentication();
            var context = MvcMockHelpers.FakeHttpContext();
            var responseMock = Mock.Get(context.Response);
            responseMock.Setup(r => r.Cookies).Returns(cookies);

            formsAuth.SetAuthCookie(context, new FormsAuthenticationTicket("TestName", false, 55));

            Assert.NotNull(cookies[FormsAuthentication.FormsCookieName]);
            Assert.Equal("TestName",
                         FormsAuthentication.Decrypt(cookies[FormsAuthentication.FormsCookieName].Value).Name);
        }

        [Fact]
        public void WhenSettingAuthenticationCookieFromTicket_ThenSetsExpiryFromFormsAuthenticationTimeoutValue()
        {
            var cookies = new HttpCookieCollection();
            var formsAuth = new DefaultFormsAuthentication();
            var context = MvcMockHelpers.FakeHttpContext();
            var responseMock = Mock.Get(context.Response);
            responseMock.Setup(r => r.Cookies).Returns(cookies);
            
            formsAuth.SetAuthCookie(context, new FormsAuthenticationTicket("TestName", false, 55));

            var cookie = cookies[FormsAuthentication.FormsCookieName];
            var now = DateTime.Now;
            var formsTimeout = FormsAuthentication.Timeout;

            // assumes test can run +/- 1 minute
            Assert.True(cookie.Expires >= now.AddMinutes(formsTimeout.Minutes - 1));
            Assert.True(cookie.Expires <= now.AddMinutes(formsTimeout.Minutes + 1));
        }

        [Fact]
        public void WhenDecryptingAuthenticationTicket_TheReturnsTicket()
        {
            var formsAuth = new DefaultFormsAuthentication();
            var ticket = new FormsAuthenticationTicket("test", false, 10);
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var recoveredTicket = formsAuth.Decrypt(encryptedTicket);

            Assert.NotNull(recoveredTicket);
            Assert.Equal(ticket.Name, recoveredTicket.Name);
            Assert.Equal(ticket.Expiration, recoveredTicket.Expiration);
            Assert.Equal(ticket.IsPersistent, recoveredTicket.IsPersistent);
            Assert.Equal(ticket.IssueDate, recoveredTicket.IssueDate);
        }
    }
}