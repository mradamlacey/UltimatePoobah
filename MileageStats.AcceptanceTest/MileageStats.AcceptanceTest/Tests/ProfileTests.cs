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
using MileageStats.AcceptanceTest.UIMaps.ProfilePageClasses;


namespace MileageStats.AcceptanceTest.Tests
{
    /// <summary>
    /// Summary description for ProfileTests
    /// </summary>
    [CodedUITest]
    public class ProfileTests
    {
        #region Test Methods
        [TestMethod]
        [Description("Edit user's profile")]
        [Priority(1)]
        public void EditProfile()
        {
            //Close all current browser window
            Utility.CloseBrowser();

            //Clear Browser cookie
            BrowserWindow.ClearCookies();
            
            //Sign in
            this.Homepage.SignIn();

            //Clicking profile link to open profile page
            this.DashboardPage.ClickProfileHyperlink();

            //Edit profile
            this.ProfilePage.EditProfile();

            //Verify the new user name displays on dashboard page
            Assert.IsTrue(this.DashboardPage.WelcomeNewUserIsExisted());
        }

        [TestMethod]
        [Description("Edit user's profile without postal code value")]
        [Priority(2)]
        public void EditProfileWithNullPostalCode()
        {
            //Clicking profile link to navigate to profile page
            this.DashboardPage.ClickProfileHyperlink();

            //Edit profile
            this.ProfilePage.EditProfilewithNullPostalCode();

            //Verify the welcome new user2 displays on top of dashboard page
            Assert.IsTrue(this.DashboardPage.WelcomeNewUser2IsExisted());
        }

        [TestMethod]
        [Description("Verify validation message for user display name and postal code InputBox")]
        [Priority(3)]
        public void EditProfileValidateMessageTest()
        {
            //Clicking profile link to navigate to profile page
            this.DashboardPage.ClickProfileHyperlink();

            //Try to Edit Profile with null name
            this.ProfilePage.EditProfileWithNullName();

            //Verify validate message is displayed
            this.ProfilePage.AssertRequiredMsg();

            //Try to Edit Profile with wihg invalid name
            this.ProfilePage.EditProfileWithJunkCharsName();

            //Verify validate message is displayed
            this.ProfilePage.AssertCharValidatedMsg();

            //Try to Edit Profile with invalid US postal code
            this.ProfilePage.EditProfileWithInvalidUSPostalCode();

            //Verify validate message is displayed
            this.ProfilePage.AssertInvalidUSPostalCodeMsg();

            //Try to Edit Profile with invalid ZHS postal code
            this.ProfilePage.EditProfileWithInvalidZHSPostalCode();

            //Verify validate message is displayed
            this.ProfilePage.AssertInvalidZHSPostalCodeMsg();

            //Sign out
            this.DashboardPage.SignOut();

            //Clear Browser cookie
            BrowserWindow.ClearCookies();

            //Close all current browser window
            Utility.CloseBrowser();
        }
        #endregion

        //#region Additional test attributes
        //[TestInitialize()]
        //[Description("Clear Browser cookies and Close all Browser windows before every test case run")]
        //public void MyTestInitialize()
        //{
        //    //Utility.CloseBrowser();
        //    //BrowserWindow.ClearCookies();
        //}

        ////////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //[Description("Clear Browser cookies and Close all Browser windows after every test case run")]
        //public void MyTestCleanup()
        //{
        //    //Utility.CloseBrowser();
        //    //BrowserWindow.ClearCookies();
        //}
        //#endregion

        #region Properties
        public HomePage Homepage
        {
            get
            {
                if (this.homePage == null)
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
                if (this.dashboardPage == null)
                {
                    this.dashboardPage = new DashboardPage();
                }

                return this.dashboardPage;
            }
        }

        public ProfilePage ProfilePage
        {
            get 
            {
                if (this.profilePage == null)
                {
                    this.profilePage = new ProfilePage();
                }
                return this.profilePage;
            }
        }
        #endregion

        #region Fields
        private HomePage homePage;

        private DashboardPage dashboardPage;

        private ProfilePage profilePage;
        #endregion
    }
}
