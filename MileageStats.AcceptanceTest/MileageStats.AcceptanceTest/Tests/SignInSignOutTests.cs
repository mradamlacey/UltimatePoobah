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
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using MileageStats.AcceptanceTest.UIMaps.HomePageClasses;
using MileageStats.AcceptanceTest.UIMaps.DashboardPageClasses;


namespace MileageStats.AcceptanceTest
{
    /// <summary>
    /// Test Sign in/Sign out function with Default&New user
    /// </summary>
    [CodedUITest]
    public class SignInSignOutTests
    {
        #region Test Methods
        [TestMethod]
        [Description("Verify sign in to dashboard page, then sign out from dashboard with Default user")]
        [Priority(3)]
        public void SignInSignOutWithDefaultUser()
        {
            //Sign in
            this.Homepage.SignIn();

            //Verify if sign in is successful
            this.Homepage.AssertSignIn();

            //Sign out
            this.DashboardPage.SignOut();

            //Verify if sign out is successful
            this.Homepage.AssertSignOut();
        }

        [TestMethod]
        [Description("Verify sign in to dashboard page, then sign out from dashboard with New user")]
        [Priority(0)]
        public void SignInSignOutWithNewUser()
        {
            //Sign in
            this.Homepage.SignInWithNewUser();

            //Verify if sign in is successful
            this.Homepage.AssertSignIn();

            //Sign out
            this.DashboardPage.SignOut();

            //Verify if sign out is successful
            this.Homepage.AssertSignOut();
        }
        #endregion

        #region Additional test attributes
        //Use TestInitialize to run code before each test has run
        [TestInitialize()]
        [Description("Clear browser cookies and close all browser windows")]
        public void MyTestInitialize()
        {
            BrowserWindow.ClearCookies();
            Utility.CloseBrowser();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        [Description("Clear browser cookies and close all browser windows")]
        public void MyTestCleanup()
        {
            BrowserWindow.ClearCookies();
            Utility.CloseBrowser();
        }
        #endregion

        #region Properties
        public HomePage Homepage
        {
            get
            {
                if ((this.homePage == null))
                {
                    this.homePage = new HomePage();
                }

                return this.homePage;
            }
        }

        public DashboardPage DashboardPage
        {
            get
            {
                if ((this.dashboardPage == null))
                {
                    this.dashboardPage = new DashboardPage();
                }

                return this.dashboardPage;
            }
        }
        #endregion

        #region Fields
        private HomePage homePage;

        private DashboardPage dashboardPage;
        #endregion
    }
}
