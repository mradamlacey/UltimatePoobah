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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MileageStats.Web.Models;
using Xunit;

namespace MileageStats.Web.Tests
{
    public class MileageStatsIdentityFixture
    {
        [Fact]
        public void WhenSerialized_ThenCanBeDeSerialized()
        {
            var formatter = new BinaryFormatter();
            var identity = new MileageStatsIdentity("Name", "DisplayName", 1);
            MileageStatsIdentity recoveredIdentity = null;

            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, identity);
                stream.Seek(0, SeekOrigin.Begin);
                recoveredIdentity = (MileageStatsIdentity) formatter.Deserialize(stream);
            }

            Assert.NotNull(recoveredIdentity);
            Assert.Equal(identity.Name, recoveredIdentity.Name);
            Assert.Equal(identity.DisplayName, recoveredIdentity.DisplayName);
            Assert.Equal(identity.UserId, recoveredIdentity.UserId);
        }
    }
}