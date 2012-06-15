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

namespace MileageStats.Web.Tests.Controllers
{
    static class YearsMakesAndModelsFor
    {
        public static Tuple<int[], string[], string[]> YearWithoutMakes(int year)
        {
            return new Tuple<int[], string[], string[]>(new int[] { year }, new string[] { }, new string[] { });
        }

        public static Tuple<int[], string[], string[]> YearWithMakes(int year, params string[] makes)
        {
            return new Tuple<int[], string[], string[]>(new int[] { year }, makes, new string[] { });
        }

        public static Tuple<int[], string[], string[]> MakeWithModels(int year, string makeSelected, params string[] models)
        {
            return new Tuple<int[], string[], string[]>(new int[] { year }, new string[] { makeSelected }, models);
        }
    }
}