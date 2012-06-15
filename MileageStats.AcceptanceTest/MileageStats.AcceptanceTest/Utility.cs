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
namespace MileageStats.AcceptanceTest
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Xml;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using MileageStats.AcceptanceTest.UIMaps.DashboardPageClasses;



    public static class Utility
    {
        #region Variables for TestMethods
        public static string newVehicleName = "Test_Vehicle";
        public static string editVehicleName = "Edited_Vehicle";
        public static string photoName = "VehiclePhoto.jpg";
        public static string bigPhotoName = "BigPhoto.jpg";

        //Nodes name in Configuration.xml file
        public static string testURL = "TestURL";

        //All Images Alt Property value 
        public static string addImageAlt = "Add";
        public static string saveImageAlt = "Save";
        public static string deleteImageAlt = "Delete";
        public static string editImageAlt = "Edit";
        public static string fulfillImageAlt = "Fulfill";
        public static string testVehiclePhotoAlt = "Vehicle Photo for Test_Vehicle";
        public static string testVehicle001PhotoAlt = "Vehicle Photo for Test_Vehicle001";

        //Homepage's Images
        public static string signinImageAlt = "Sign in or Register";
        public static string mileageStatsLogoAlt = "Mileage Stats Icon";
        public static string openIDImageAlt = "My OpenID";
        public static string yahooImageAlt = "Yahoo";
        public static string html5LogoAlt = "HTML5 logo and icons";

        //The specific strings in property Href of Details/Fill ups/Reminders hyperlinks
        public static string detailsHref = "layout=details";
        public static string FillupsHref = "layout=fillups";
        public static string reminderHref = "layout=reminders";

        //Validation messages
        //Add Vehicle releated 
        public static string vehiclePhotoSizeValidateMsg = "The photo uploaded must be less than 1 MB.";
        public static string vehicleRequiredValidateMsg = "Name is required.";

        //Profile releated 
        public static string USpostalcodeValidateMsg = "United States postal codes must be five digit numbers.";
        public static string ZHSpostalcodeValidateMsg = "Postal codes must be alphanumeric and ten characters or less.";
        public static string userNameRequiredValidateMsg = "Display Name is required.";

        //Reminder releated
        public static string titleRequiredValidateMsg = "Title is required.";
        public static string dueDateJunkCharValidateMsg = @"The value '&^(*' is not valid for Due Date.";
        public static string dueDistanceJunkCharValidateMsg = @"The field Due when odometer reads must be a number.";
        public static string dueDateInvalidMsg = @"The value '02/29/2011' is not valid for Due Date.";
        public static string dueDistanceInvalidMsg = @"The odometer due distance must be between 1 and 1,000,000.";     
        //public static string dueDistanceGreaterValidateMsg = "The due distance must be greater than the current odometer of 0.";

        //Fill-ups releated, Due to there is two many validation message for it, we use similar string prefix/suffix, then verify the count
        public static string fillupInvalidMsgSuffix = "must be a number";
        public static string fillupRequiredMsgSuffix = "required.";
        public static string fillupJunkCharValidateMsgPrefix = "Only alpha-numeric characters";
        public static string FillupRangeofValuesMsgMiddleStr = "must be between";
             
        //Common validate messages
        public static string charValidateMsg = "Only alpha-numeric characters and [.,_-'] are allowed.";
        public static string remarksJunkCharValidateMsg = "Only alpha-numeric characters, new lines, and [.,_-'] are allowed.";
        public static string remarksLengthValidateMsg = "Remarks must be fewer than 250 characters.";
        #endregion

        #region Help Methods
        /// <summary>
        /// Close all existed browser window
        /// </summary>
        /// <param name="title"></param>
        public static void CloseBrowser()
        {
            //Get all browser window
            UITestControlCollection coll = FindOpenIE();

            if (coll == null)
            {
                return;
            }

            foreach (UITestControl uiWindow in coll)
            {
                var browser = uiWindow as BrowserWindow;
                if (browser != null)
                {
                    browser.Close();
                }
            }
        }

        /// <summary>
        /// Get all current browser window
        /// </summary>
        /// <returns></returns>
        public static UITestControlCollection FindOpenIE()
        {
            var bWindow = new BrowserWindow();
            bWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            bWindow.SearchProperties[UITestControl.PropertyNames.ControlType] = "Window";

            UITestControlCollection coll = bWindow.FindMatchingControls();
            return coll;
        }

        /// <summary>
        /// Make sure the browser window is maximal.
        /// </summary>
        /// <param name="browser"></param>
        public static void MaximizeBrowserWindow(BrowserWindow browser)
        {
            browser.Maximized = true;
        }

        /// <summary>
        /// Get the test data which are defined in configuration.xml
        /// </summary>
        /// <returns></returns>
        public static string GetTestEnvData(string nodeName)
        {
            string testEnvData;
            XmlDocument configurationFile = new XmlDocument();
            configurationFile.Load(@"..\..\..\MileageStats.AcceptanceTest\Configuration.xml");

            //Get the innerText value of Test Data node
            XmlNode testDataNode = configurationFile.SelectSingleNode("MileageStats/TestEnv/"+ nodeName);
            testEnvData = testDataNode.InnerText;
            return testEnvData;
        }

        /// <summary>
        /// Get testUrl's AbsolutePath value which can be used for some UIControlers's search criteria.
        /// </summary>
        /// <returns></returns>
        public static string GetTestUriAbsolutePath()
        {
            Uri testUri = new Uri(GetTestEnvData(Utility.testURL));
            return testUri.AbsolutePath;
        }

        /// <summary>
        /// Accroding to photo's name to get its path in solution
        /// </summary>
        /// <returns></returns>
        public static string GetVehiclePhotoPath(string photoName)
        {
            string currentPath = System.Environment.CurrentDirectory;
            string prefixCurrentDirectory = currentPath.Remove(currentPath.IndexOf("TestResult"));
            string photoPath = prefixCurrentDirectory + @"MileageStats.AcceptanceTest\"+ photoName;
            return photoPath;
        }
        #endregion
    }
}
