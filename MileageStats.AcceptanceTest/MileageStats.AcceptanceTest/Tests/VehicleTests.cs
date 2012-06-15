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
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using MileageStats.AcceptanceTest.UIMaps.HomePageClasses;
using MileageStats.AcceptanceTest.UIMaps.DashboardPageClasses;
using MileageStats.AcceptanceTest.UIMaps.VehiclePageClasses;
using MileageStats.AcceptanceTest.UIMaps.ProfilePageClasses;
using MileageStats.AcceptanceTest.UIMaps.FillupPageClasses;
using MileageStats.AcceptanceTest.UIMaps.ReminderPageClasses;

namespace MileageStats.AcceptanceTest.Tests
{
    /// <summary>
    /// Test cases related with vehicle operations
    /// </summary>
    [CodedUITest]
    public class VehicleTests
    {
        #region Test Methods
        [TestMethod]
        [Description("Add vehicle with all fields")]
        [Priority(1)]
        public void AddVehicleWithAllFields()
        {
            //Close current browser window
            Utility.CloseBrowser();

            //Clear browser cookie
            BrowserWindow.ClearCookies();

            //Sign in
            this.Homepage.SignIn();

            //Verify if the Test_Vehicle has already existed on dashboard page
            //if yes, delete it, then create new one
            while (this.DashboardPage.TestVehicleIsExisted())
            {
                //Click the Test_Vehicle Details link
                this.DashboardPage.ClickTestVehicleDetailsHyperlink();

                //Delete the Test_Vehicle 
                this.VehiclePage.DeleteTestVehicle();

                //Refresh Dashboard page
                this.DashboardPage.RefreshDashboardPage();
            }

            //Click '+ Add Vehicle' link
            this.DashboardPage.ClickAddVehicleHyperlink();

            //Add New Vehicle
            this.VehiclePage.AddNewVehicle();

            //Verify if the new added vehicle displays on dashboard page
            Assert.IsTrue(this.DashboardPage.TestVehicleIsExisted());
        }

        [TestMethod]
        [Description("Verify edit vehicle with new name, year, make, model values")]
        [Priority(2)]
        public void EditVehicleWithOptionalFields()
        {
            //Verify if the Edited_Vehicle has already existed on dashboard page
            //if yes, delete it.
            while (this.DashboardPage.EditedVehicleIsExisted())
            {
                //Click the Edited_Vehicle Details link
                this.DashboardPage.ClickEditedVehicleDetailsHyperlink();

                //Delete the Edited_Vehicle 
                this.VehiclePage.DeleteEditedVehicle();

                //Refresh Dashboard page
                this.DashboardPage.RefreshDashboardPage();
            }

            //Verify if the Test_Vehicle has already existed on dashboard page
            //if no, create new one, then edit it
            if (!this.DashboardPage.TestVehicleIsExisted())
            {
                //Click '+ Add Vehicle' link
                this.DashboardPage.ClickAddVehicleHyperlink();

                //Add new vehicle
                this.VehiclePage.AddNewVehicle();

                //Waiting for js loading
                Playback.Wait(8000);
            }

            //Click the Test_Vehicle Details link
            this.DashboardPage.ClickTestVehicleDetailsHyperlink();

            //Edit the Test_Vehicle
            this.VehiclePage.EditVehicle();

            //Verify if the Test_Vehicle is updated
            this.VehiclePage.AssertVehicleIsUpdated();

            //Navigate to dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //Sleep 8 sec, Waiting for javascript's loading
            Playback.Wait(8000);
        }

        [TestMethod]
        [Description("Verify add vehicle with name only")]
        [Priority(2)]
        public void AddVehicleWithRequiredFields()
        {

            //Verify if the Test_Vehicle001 has already existed on dashboard page
            //if yes, delete, then create new one
            while (this.DashboardPage.TestVehicle001IsExisted())
            {
                //Click the Test_Vehicle001 Details link
                this.DashboardPage.ClickTestVehicle001DetailsHyperlink();

                //Delete Test_Vehicle001
                this.VehiclePage.DeleteTestVehicle001();

                //Refresh Dashboard page
                this.DashboardPage.RefreshDashboardPage();
            }

            //Click '+ Add Vehicle' link
            this.DashboardPage.ClickAddVehicleHyperlink();

            //Add vehicle with name only
            this.VehiclePage.AddVehicleWithNameOnly();

            //Verify if the Test_Vehicle001 displays on dashboard page
            Assert.IsTrue(this.DashboardPage.TestVehicle001IsExisted());
        }

        [TestMethod]
        [Description("Verify Delete vehicle")]
        [Priority(2)]
        public void DeleteVehicle()
        {
            //Verify if the Edited_Vehicle has already existed on dashboard page 
            //If yes, delete it.
            while (this.DashboardPage.EditedVehicleIsExisted())
            {
                //Click the Edited_Vehicle Details link
                this.DashboardPage.ClickEditedVehicleDetailsHyperlink();

                //Delete the Vehicle
                this.VehiclePage.DeleteEditedVehicle();

                //Refresh Dashboard page
                this.DashboardPage.RefreshDashboardPage();
            }

            while (this.DashboardPage.TestVehicle001IsExisted())
            {
                //Click the Test_Vehicle001 Details link
                this.DashboardPage.ClickTestVehicle001DetailsHyperlink();

                //Delete the Vehicle
                this.VehiclePage.DeleteTestVehicle001();

                //Refresh Dashboard page
                this.DashboardPage.RefreshDashboardPage();
            }
                         
            //Verify the Edited_Vehicle/Test_Vehicle001 aren't displayed on dashboard page
            Assert.IsFalse(this.DashboardPage.EditedVehicleIsExisted() && this.DashboardPage.TestVehicle001IsExisted());
        }

        [TestMethod]
        [Description("Verify validate message for vehicle name and photo box")]
        [Priority(3)]
        public void AddVehicleValidatedMessageTest()
        {
            //Click '+ Add Vehicle' Link
            this.DashboardPage.ClickAddVehicleHyperlink();

            //Try to add vehicle without name
            this.VehiclePage.AddVehicleWithoutName();

            //Verify the validated message displays
            this.VehiclePage.AssertRequiredMsg();
            
            //Try to Add vehicle with junk chars name
            this.VehiclePage.AddVehicleWithJunkChars();

            //Verify the validated message displays
            this.VehiclePage.AssertCharValidateMsg();
            
            //Try to Add vehicle with big photo
            this.VehiclePage.AddVehicleWithBigPhoto();

            //Verify the validated message displays
            this.VehiclePage.AssertPhotoValidateMsg();

            //Navigate to Dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //sign out
            this.DashboardPage.SignOut();

            //Clear Browser cookie
            BrowserWindow.ClearCookies();

            //Close Browser Window
            Utility.CloseBrowser();
        }

        [TestMethod]
        [Description("Verify the Alt property of image in home page")]
        [Priority(3)]
        public void VerifyAltPropertyForHomePageImages()
        {
            //Open MileageStats Homepage
            this.Homepage.OpenHomePage();

            //Verify image's Alt Property
            this.Homepage.AssertImageAltProperty();

            //Close Browser Window
            Utility.CloseBrowser();
        }

        [TestMethod]
        [Description("Verify the MaxLength Property of all InputBox in MileageStats app")]
        [Priority(3)]
        public void VerifyMaxLengthPropertyForAllInputBox()
        {
            #region Verify InputBox in Homepage & Mock page
            //Open MileageStats Homepage
            this.Homepage.OpenHomePage();

            //Verify the MaxLength Property of ProviderUrl box equals 200
            this.Homepage.AssertMaxLengthProperty();

            //Navigate to MileageStats Mock Authentication Page
            this.Homepage.ClickSignInButtonOnHomepage();

            //Verify the MaxLength Property of Claimed Identifier box equals 200
            this.Homepage.AssertMaxLengthProperty1();
            #endregion

            #region Verify Vehicle name box

            //Click the Sign in button on Mock page
            this.Homepage.ClickSigninButtonOnMockPage();

            //Sleep 2 secs, waiting for js loading
            Playback.Wait(2000);

            //Click 'Add Vehicle' link
            this.DashboardPage.ClickAddVehicleHyperlink();

            //Verify the MaxLength Property of vehicle name box equals 20
            this.VehiclePage.AssertMaxLengthProperty();

            //Create a new vehicle
            this.VehiclePage.AddNewVehicle();
            #endregion

            #region Verify InputBox on add fill up page
            //Click the Test_Vehicle Fill ups link
            this.DashboardPage.ClickTestVehicleFillupHyperlink();

            //Click the Add Fill up button
            this.FillupPage.ClickAddButton();

            //VVerify the MaxLength Property of InputBox in add Fill up page
            this.FillupPage.AssertMaxLengthProperty();
            #endregion

            #region Verify InputBox on reminder page
            //Navigate back to Dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //Click the Test_Vehicle Reminders link to open its Reminder page
            this.DashboardPage.ClickTestVehicleRemindersHyperlink();

            //Click the Add reminder button
            this.ReminderPage.ClickReminderButton();

            //Verify the MaxLength Property of InputBox in Add Reminder page 
            this.ReminderPage.AssertMaxLengthProperty();
            #endregion

            #region Verify InputBox on profile page
            //Navigate to Dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //Click profile link to open profile page
            this.DashboardPage.ClickProfileHyperlink();

            //Verify the MaxLength property of InputBoxe in edit profile page.
            this.ProfilePage.AssertMaxLengthProperty();
            #endregion

            //Navigate to Dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //Sleep 2 sec, Waiting for javascript's loading
            Playback.Wait(2000);

            //Sign out
            this.DashboardPage.SignOut();

            //Clear Browser cookie
            BrowserWindow.ClearCookies();

            //Close all current browser window
            Utility.CloseBrowser();
        }
        #endregion

        //#region Additional test attributes, 
        //We run all test cases in VehicleTest.cs as a group. Initialize Operation isn't needed anymore.
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

        public VehiclePage VehiclePage
        {
            get
            {
                if ((this.vehiclePage == null))
                {
                    this.vehiclePage = new VehiclePage();
                }

                return this.vehiclePage;
            }
        }

        public FillupPage FillupPage
        {
            get
            {
                if ((this.fillupPage == null))
                {
                    this.fillupPage = new FillupPage();
                }

                return this.fillupPage;
            }
        }

        public ReminderPage ReminderPage
        {
            get
            {
                if ((this.reminderPage == null))
                {
                    this.reminderPage = new ReminderPage();
                }

                return this.reminderPage;
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

        private VehiclePage vehiclePage;

        private FillupPage fillupPage;

        private ReminderPage reminderPage;

        private ProfilePage profilePage;
        #endregion
    }
}
