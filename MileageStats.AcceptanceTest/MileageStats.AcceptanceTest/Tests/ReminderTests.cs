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
using MileageStats.AcceptanceTest.UIMaps.ReminderPageClasses;
using MileageStats.AcceptanceTest.UIMaps.VehiclePageClasses;

namespace MileageStats.AcceptanceTest.Tests
{
    /// <summary>
    /// Summary description for ReminderTests
    /// </summary>
    [CodedUITest]
    public class ReminderTests
    {
        #region Test Methods
        [TestMethod]
        [Description("Add reminder on vehicle Test_Vehicle")]
        [Priority(1)]
        public void AddReminder()
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

            //Click the Test_Vehicle Reminders link to open its Reminder page
            this.DashboardPage.ClickTestVehicleRemindersHyperlink();

            //Add a reminder
            this.ReminderPage.AddReminder();

            //Verfiy if the reminder is added
            this.ReminderPage.AssertReminderIsAdded();
        }

        [TestMethod]
        [Description("Verify fulfill reminder")]
        [Priority(2)]
        public void FulfillReminder()
        {
            //Navigate to dashboard page
            this.DashboardPage.NavigateToDashboardpage();

            this.DashboardPage.ClickTestVehicleRemindersHyperlink();

            //Sleep 3 secs, waiting for page is ready
            Playback.Wait(3000);

            //If the reminder which we want to add has already existed on reminder page, 
            //Then fulfill it. 
            if (this.ReminderPage.ReminderIsExisted())
            {
                this.ReminderPage.FulfillReminder();               
            }
           
            //Verify the reminder is fulfilled
            this.ReminderPage.AssertReminderIsNotExisted();
        }

        [TestMethod]
        [Description("Verify add reminder with title and due date only")]
        [Priority(3)]
        public void AddReminderWithTitleDueDateOnly()
        {
            //Add a new Reminder with title and DueDate
            this.ReminderPage.AddReminderWithTitleDueDate();

            //Verfiy the reminder is added
            this.ReminderPage.AssertOnlyTitleDateReminderIsAdded();

            //Navigate to Dashboard page
            this.DashboardPage.NavigateToDashboardpage();
        }

        [TestMethod]
        [Description("Verify add reminder with title and due Odometer reads only")]
        [Priority(3)]
        public void AddReminderWithTitleDueDistanceOnly()
        {
            //Click the Test_Vehicle Reminders link to open its Reminder page
            this.DashboardPage.ClickTestVehicleRemindersHyperlink();
            

            //Add a reminder with title and Due Odometer reads
            this.ReminderPage.AddReminderWithTitleDueOdometerReads();

            //Verfiy the reminder is added
            this.ReminderPage.AssertOnlyTitleOdometerReadsReminderIsAdded();

            //Navigate to Dashboard page
            this.DashboardPage.NavigateToDashboardpage();
        }

        [TestMethod]
        [Description("Verify validate message for InputBoxes on add reminder page")]
        [Priority(3)]
        public void AddReminderValidatedMessageTest()
        {
            //Click the Test_Vehicle Reminders link to open its Reminder page
            this.DashboardPage.ClickTestVehicleRemindersHyperlink();
            
            //Try to add reminder with junk char
            this.ReminderPage.AddReminderWithJunkChar();

            //Verify validation messages display
            this.ReminderPage.AssertJunkCharValidateMsg();

            //Try to add reminder with invalid values
            this.ReminderPage.AddReminderWithInvalidDueDate();

            //Verify validation messages display
            this.ReminderPage.AssertInvalidDueDateValidatedMsg();

            //Try to add reminder with invalid due odometer values
            this.ReminderPage.addReminderWithInvalidDueOdometerReads();

            //Verify validation messages display
            this.ReminderPage.AssertInvalidDueOdometerReadsValidatedMsg();

            //Try to add reminder with null title
            this.ReminderPage.AddReminderWithNullTitle();

            //Verify validation messages display
            this.ReminderPage.AssertNullTitleValidateMsg();

            //Sign Out
            this.DashboardPage.SignOut();

            //Clear Browser cookie
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

        private ReminderPage reminderPage;

        private VehiclePage vehiclePage;
        #endregion
    }
}
