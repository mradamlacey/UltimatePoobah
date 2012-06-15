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
using MileageStats.AcceptanceTest.UIMaps.FillupPageClasses;
using MileageStats.AcceptanceTest.UIMaps.VehiclePageClasses;

namespace MileageStats.AcceptanceTest.Tests
{
    /// <summary>
    /// Summary description for FillupTests
    /// </summary>
    [CodedUITest]
    public class FillupTests
    {
        #region Test Methods
        [TestMethod]
        [Description("Verify Add a fill up on Test_Vehicle")]
        [Priority(1)]
        public void AddFillupWithAllFields()
        {
            //Close all current browser window
            Utility.CloseBrowser();

            //Clear Browser cookie
            BrowserWindow.ClearCookies();

            //Sign in
            this.Homepage.SignIn();

            //sleep 8 secs, waiting for js loading
            Playback.Wait(8000);

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

            //Click the Test_Vehicle Fill ups link to open its Fill up page
            this.DashboardPage.ClickTestVehicleFillupHyperlink();

            //Add a fill up
            this.FillupPage.AddFillupWithAllFields();

            //Verfiy the fill up is added
            this.FillupPage.AssertFillupIsAdded();
        }

        [TestMethod]
        [Description("Verify Add a fill up with required fields")]
        [Priority(2)]
        public void AddFillupWithRequiredFields()
        {
            //Add a fill up with required fields
            this.FillupPage.AddFillupWithRequiredFields();

            //Verfiy the fill up with required Fields is added
            this.FillupPage.AssertFillupWithRequiredFieldsIsAdd();

            //Naviage to dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //Refresh dashboard page
            this.DashboardPage.RefreshDashboardPage();
        }

        [TestMethod]
        [Description("Verify mpg value is calculated correctly")]
        [Priority(2)]
        public void VerifyMpgValue()
        {
            //Verify if the Test_Vehicle has already existed on dashboard page
            //if yes, delete it,  then create new one
            while (this.DashboardPage.TestVehicleIsExisted())
            {
                this.DashboardPage.ClickTestVehicleDetailsHyperlink();
                
                //Delete the Test_Vehicle
                this.VehiclePage.DeleteTestVehicle();

                //Refresh dashboard page
                this.DashboardPage.RefreshDashboardPage();
            }

            //Click the "+ Add Vehicle" link
            this.DashboardPage.ClickAddVehicleHyperlink();

            //Add New Vehicle
            this.VehiclePage.AddNewVehicle();

            //Click the Test_Vehicle Fill ups link to open its Fill up page
            this.DashboardPage.ClickTestVehicleFillupHyperlink();

            //Add a fill up
            this.FillupPage.AddFillupWithAllFields();

            //Add second fill up
            this.FillupPage.AddSecondFillupWithAllFields();

            //Navigate to dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //Verify the fill up value is calculated correctly
            Assert.IsTrue(this.DashboardPage.TestVehicleMPGValuePaneIsExisted());

            //Navigate to dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            //Refresh dashboard page
            this.DashboardPage.RefreshDashboardPage();
        }

        [TestMethod]
        [Description("Verify validation messages for input boxes on Add Fill up page")]
        [Priority(3)]
        public void AddFillupValidatedMessageTest()
        {

            //Click the Test_Vehicle Fill ups link to open its Fill up page
            this.DashboardPage.ClickTestVehicleFillupHyperlink();

            //Try to Add a fill up with null Values
            this.FillupPage.AddFillupWithNullValues();

            //Verify validation messages display
            this.FillupPage.AssertNullValuesMsg();

            //Try to Add a fill up with invalid Values
            this.FillupPage.AddFillupWithInvalidValues();

            //Verify validation messages display
            this.FillupPage.AssertInvalidValuesMsg();

            //Try to Add a fill up with out of range Values
            this.FillupPage.AddFillupWithOutofRangeValues();

            //Verify validation messages display
            this.FillupPage.AssertOutofRangeValuesMsg();

            //Sign Out
            this.DashboardPage.SignOut();

            //Clear Browser's cookie
            BrowserWindow.ClearCookies();

            //Close all current browser windows
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
        #endregion

        #region Fields
        private HomePage homePage;

        private DashboardPage dashboardPage;

        private FillupPage fillupPage;

        private VehiclePage vehiclePage;
        #endregion

    }
}
