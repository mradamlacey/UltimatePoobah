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
using MileageStats.Domain.Models;

using Xunit;

namespace MileageStats.Web.Tests
{
    public class UserContextFixture
    {
        [Fact]
        public void WhenContextConvertedToString_ThenCanBeRecovered()
        {
            var userContext = new UserInfo()
                                  {
                                      ClaimsIdentifier = "TestClaimsIdentifier",
                                      DisplayName = "TestDisplayName",
                                      UserId = 55
                                  };

            UserInfo recoveredInfo = UserInfo.FromString(userContext.ToString());

            Assert.Equal(userContext.ClaimsIdentifier, recoveredInfo.ClaimsIdentifier);
            Assert.Equal(userContext.DisplayName, recoveredInfo.DisplayName);
            Assert.Equal(userContext.UserId, recoveredInfo.UserId);
        }
    }
}