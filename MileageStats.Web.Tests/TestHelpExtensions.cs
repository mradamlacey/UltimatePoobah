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
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using MileageStats.Domain.Handlers;
using MileageStats.Domain.Models;
using Moq;

namespace MileageStats.Web.Tests
{
    public static class TestHelpExtensions
    {
        public static T Extract<T>(this ActionResult result)
        {
            var viewResult = (ViewResult)result;
            return (T)viewResult.Model;
        }

        public static Mock<T> MockHandlerFor<T>(this Mock<IServiceLocator> serviceLocator, Func<Mock<T>> create, Action<Mock<T>> setup = null) where T : class
        {
            var mock = create();

            if (setup != null) setup(mock);

            serviceLocator
                .Setup(s => s.GetInstance<T>())
                .Returns(mock.Object);

            return mock;

        }

        public static void StandardSetup(this Mock<GetVehicleListForUser> mock, int userId, int vehicleId, int selectedVehicledId = 0)
        {
            mock.Setup(h => h
                .Execute(userId))
                .Returns(vehicleId.StandardVehicleList(selectedVehicledId));
        }

        public static IEnumerable<VehicleModel> StandardVehicleList(this int startingVehicleId, int selectedVehicledId = 0)
        {
            return new[]
                        {
                            new VehicleModel(new Model.Vehicle{VehicleId = startingVehicleId}, new VehicleStatisticsModel()),  
                            new VehicleModel(new Model.Vehicle{VehicleId = startingVehicleId + 1}, new VehicleStatisticsModel()),  
                            new VehicleModel(new Model.Vehicle{VehicleId = startingVehicleId + 2}, new VehicleStatisticsModel()),  
                        };
        }
    }
}
