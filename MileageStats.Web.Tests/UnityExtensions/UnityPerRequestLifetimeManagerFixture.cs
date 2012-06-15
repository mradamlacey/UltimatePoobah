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
using MileageStats.Web.UnityExtensions;
using Moq;
using Xunit;

namespace MileageStats.Web.Tests.UnityExtensions
{
    public class UnityPerRequestLifetimeManagerFixture
    {
        [Fact]
        public void WhenSetValueCalled_ThenStoredInHttpItemsContex()
        {
            var newValue = new object();
            var storeMock = new Mock<IPerRequestStore>();
            storeMock.Setup(s => s.SetValue(It.IsAny<object>(), newValue)).Verifiable();

            var lifetimeManager = new UnityPerRequestLifetimeManager(storeMock.Object);

            lifetimeManager.SetValue(newValue);

            storeMock.Verify();
        }

        [Fact]
        public void WhenGetValueCalled_ThenRetrievedFromHttpItemsContext()
        {
            var newValue = new object();
            var storeMock = new Mock<IPerRequestStore>();
            storeMock.Setup(s => s.GetValue(It.IsAny<object>())).Returns(newValue).Verifiable();

            var lifetimeManager = new UnityPerRequestLifetimeManager(storeMock.Object);

            lifetimeManager.SetValue(newValue);
            var returnedValue = lifetimeManager.GetValue();

            storeMock.Verify();
        }

        [Fact]
        public void WhenValueRemoved_ThenRemovedFromContext()
        {
            var newValue = new object();
            var storeMock = new Mock<IPerRequestStore>();
            storeMock.Setup(s => s.GetValue(It.IsAny<object>())).Returns(newValue);
            storeMock.Setup(s => s.RemoveValue(It.IsAny<object>())).Verifiable();

            var lifetimeManager = new UnityPerRequestLifetimeManager(storeMock.Object);

            lifetimeManager.SetValue(newValue);
            lifetimeManager.RemoveValue();

            storeMock.Verify();
        }

        [Fact]
        public void WhenRemovingDisposableValues_ThenDisposeInvoked()
        {
            var valueMock = new Mock<IDisposable>();
            valueMock.Setup(x => x.Dispose()).Verifiable();

            var storeMock = new Mock<IPerRequestStore>();
            storeMock.Setup(s => s.GetValue(It.IsAny<object>())).Returns(valueMock.Object);
            storeMock.Setup(s => s.RemoveValue(It.IsAny<object>())).Verifiable();

            var lifetimeManager = new UnityPerRequestLifetimeManager(storeMock.Object);

            lifetimeManager.SetValue(valueMock.Object);
            lifetimeManager.RemoveValue();

            valueMock.Verify();
        }

        [Fact]
        public void WhenDisposingLifetimeManager_DisposesValue()
        {
            var valueMock = new Mock<IDisposable>();
            valueMock.Setup(x => x.Dispose()).Verifiable();

            var storeMock = new Mock<IPerRequestStore>();
            storeMock.Setup(s => s.GetValue(It.IsAny<object>())).Returns(valueMock.Object);
            storeMock.Setup(s => s.RemoveValue(It.IsAny<object>())).Verifiable();

            var lifetimeManager = new UnityPerRequestLifetimeManager(storeMock.Object);

            lifetimeManager.SetValue(valueMock.Object);

            ((IDisposable) lifetimeManager).Dispose();

            valueMock.Verify();
        }

        [Fact]
        public void WhenRequestEnds_ThenRemovedFromContext()
        {
            var newValue = new object();
            var storeMock = new Mock<IPerRequestStore>();
            storeMock.Setup(s => s.GetValue(It.IsAny<object>())).Returns(newValue);
            storeMock.Setup(s => s.RemoveValue(It.IsAny<Object>())).Verifiable();

            var lifetimeManager = new UnityPerRequestLifetimeManager(storeMock.Object);

            lifetimeManager.SetValue(newValue);

            storeMock.Raise(a => a.EndRequest += null, EventArgs.Empty);

            storeMock.Verify();
        }
    }
}