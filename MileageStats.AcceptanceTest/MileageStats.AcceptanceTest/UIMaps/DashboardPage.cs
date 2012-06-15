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
namespace MileageStats.AcceptanceTest.UIMaps.DashboardPageClasses
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Input;
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    public partial class DashboardPage
    {
        #region Help Methods
        /// <summary>
        /// Sign out from Dashboard page
        /// </summary>
        public void SignOut()
        {
            #region Variable Declarations
            HtmlHyperlink uISignOutHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UISignOutHyperlink;
            #endregion

            // Click 'Sign Out' link
            Mouse.Click(uISignOutHyperlink);
        }

        /// <summary>
        /// Refresh Dashboard page
        /// </summary>
        public void RefreshDashboardPage()
        {
            #region Variable Declarations
            HtmlDocument uIDashboardDocument = this.UIDashboardWindowsInteWindow.UIDashboardDocument;
            #endregion

            // Type '{F5}' in 'Dashboard' document
            Keyboard.SendKeys(uIDashboardDocument, "{f5}", ModifierKeys.None);
        }

        /// <summary>
        /// Click Dashboard link to go to Dashboard page
        /// </summary>
        public void NavigateToDashboardpage()
        {
            #region Variable Declarations
            HtmlHyperlink mUIDashboardHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UIDashboardHyperlink;
            #endregion

            Mouse.Click(mUIDashboardHyperlink);
        }

        #region Click Methods
        /// <summary>
        /// Navigate to profile page by clicking profile link
        /// </summary>
        public void ClickProfileHyperlink()
        {
            #region Variable Declarations
            HtmlHyperlink uIProfileHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UIProfileHyperlink;
            #endregion

            // Click 'Sign Out' link
            Mouse.Click(uIProfileHyperlink);
        }

        /// <summary>
        /// Click "+ Add Vehicle" link
        /// </summary>
        public void ClickAddVehicleHyperlink()
        {
            #region Variable Declarations
            HtmlHyperlink uIAddVehicleHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UIAddVehicleHyperlink;
            #endregion

            //Waiting for '+ Add Vehicle' is enabled for clicking.
            uIAddVehicleHyperlink.WaitForControlEnabled();

            // Click 'Add Vehicle' link
            Mouse.Click(uIAddVehicleHyperlink);
        }

        public void ClickTestVehicle001DetailsHyperlink()
        {
            #region Variable Declarations
            HtmlHyperlink uITestVehicle001DetailsHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UITestVehicle001Pane.UITest_Vehicle001DetailsHyperlink;
            #endregion

            //Waiting for Vehicle Details is clickable
            uITestVehicle001DetailsHyperlink.WaitForControlEnabled();

            //Click the Vehicle Detaisl link
            Mouse.Click(uITestVehicle001DetailsHyperlink);
        }

        /// <summary>
        ///  Click Details link of "Test_Vehicle"
        /// </summary>
        public void ClickTestVehicleDetailsHyperlink()
        {
            #region Variable Declarations
            HtmlHyperlink uITestVehicleDetailsHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UINewVehiclePane.UITest_VehicleDetailsHyperlink;
            #endregion
            
            //Waiting for control is ready for mouse clicking
            uITestVehicleDetailsHyperlink.WaitForControlReady();

            //Click the Vehicle Details link
            Mouse.Click(uITestVehicleDetailsHyperlink);
        }

        /// <summary>
        ///  Click Details link of "Edited_Vehicle"
        /// </summary>
        public void ClickEditedVehicleDetailsHyperlink()
        {
            #region Variable Declarations
            HtmlHyperlink uIEditedVehicleDetailsHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UIEditedVehiclePane.UIEdited_VehicleDetailsHyperlink;
            #endregion

            //Waiting for control is ready for mouse clicking
            uIEditedVehicleDetailsHyperlink.WaitForControlReady();

            //Click the Vehicle Details link
            Mouse.Click(uIEditedVehicleDetailsHyperlink);
        }

        /// <summary>
        /// Click Fill ups link of "Test_Vehilce" 
        /// </summary>
        public void ClickTestVehicleFillupHyperlink()
        {
            #region Variable Declarations
            HtmlHyperlink mUITest_VehicleFillupsHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UINewVehiclePane.UITest_VehicleFillupsHyperlink;
            #endregion

            //Waiting for Fill-ups link is clickable
            mUITest_VehicleFillupsHyperlink.WaitForControlEnabled();

            //Click the Fill-ups link of Test_Vehilce
            Mouse.Click(mUITest_VehicleFillupsHyperlink);
        }

        /// <summary>
        /// Click Reminsers link of "Test_Vehilce" 
        /// </summary>
        public void ClickTestVehicleRemindersHyperlink()
        {
            #region Variable Declarations
            HtmlHyperlink mUITest_VehicleRemindersHyperlink = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UINewVehiclePane.UITest_VehicleRemindersHyperlink;
            #endregion

            //Waiting for Reminders link is clickable
            mUITest_VehicleRemindersHyperlink.WaitForControlEnabled();

            //Click the Reminders link of Test_Vehilce
            Mouse.Click(mUITest_VehicleRemindersHyperlink);
        }
        #endregion

        #region Bool Methonds
        /// <summary>
        /// Verify if the vehicle "Test_Vehicle"  with vehicle photo is existed on dashboard page
        /// </summary>
        /// <returns></returns>
        public bool TestVehicleIsExisted()
        {
            #region Variable Declarations
            HtmlDiv uITestVehiclePane = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UINewVehiclePane;
            HtmlImage uIVehiclePhotoImage = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UINewVehiclePane.UIVehiclePhotoImage;
            #endregion

            return (uITestVehiclePane.Exists && uIVehiclePhotoImage.Exists);

        }

        public bool TestVehicle001IsExisted()
        {
            #region Variable Declarations
            HtmlDiv uITestVehicle001Pane = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UITestVehicle001Pane;
            #endregion

            return (uITestVehicle001Pane.Exists);
        }

        /// <summary>
        /// Verify if the vehicle "Edited_Vehicle"  is existed on dashboard page
        /// </summary>
        /// <returns></returns>
        public bool EditedVehicleIsExisted()
        {
            #region Variable Declarations
            HtmlDiv uIEdited_VehiclePane = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UIEditedVehiclePane;
            #endregion

            return uIEdited_VehiclePane.Exists;
        }

        /// <summary>
        /// Verify the welcome new user  message is existed.
        /// </summary>
        /// <returns></returns>
        public bool WelcomeNewUserIsExisted()
        {
            #region Variable Declarations
            HtmlDiv uIWelcomeupdatedusernaPane = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UIWelcomeupdatedusernaPane;
            #endregion

            return uIWelcomeupdatedusernaPane.Exists;
        }

        public bool WelcomeNewUser2IsExisted()
        {
            #region Variable Declarations
            HtmlDiv uIWelcomeNewUser2Pane = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UIWelcomeNewUser2Pane;
            #endregion

            return uIWelcomeNewUser2Pane.Exists;
        }

        /// <summary>
        /// Verify the Test vehicle mpg value is existed, To get the Mpg Value Pane 
        /// </summary>
        /// <returns></returns>
        public bool TestVehicleMPGValuePaneIsExisted()
        {
            #region Variable Declarations
            HtmlDiv uITestVehicleMPGValuePane = this.UIDashboardWindowsInteWindow.UIDashboardDocument.UINewVehiclePane.UIVehicleMPGValuePane;
            #endregion

            return uITestVehicleMPGValuePane.Exists;
        }
        #endregion

        #endregion

        #region Properties
        public UIDashboardWindowsInteWindow UIDashboardWindowsInteWindow
        {
            get
            {
                if ((this.mUIDashboardWindowsInteWindow == null))
                {
                    this.mUIDashboardWindowsInteWindow = new UIDashboardWindowsInteWindow();
                }
                return this.mUIDashboardWindowsInteWindow;
            }
        }
        #endregion
        
        #region Fields  
        private UIDashboardWindowsInteWindow mUIDashboardWindowsInteWindow;
        #endregion
    }

    //These UITestControls are generate with Coded UITest Builder, Copy them from DashboardPage.Designer.cs file.
    //then modify them if we need to 
    #region UITestControl Definition
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDashboardWindowsInteWindow : BrowserWindow
    {

        public UIDashboardWindowsInteWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Dashboard";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Dashboard");
            #endregion
        }

        #region Properties
        public UIDashboardDocument UIDashboardDocument
        {
            get
            {
                if ((this.mUIDashboardDocument == null))
                {
                    this.mUIDashboardDocument = new UIDashboardDocument(this);
                }
                return this.mUIDashboardDocument;
            }
        }
        #endregion

        #region Fields
        private UIDashboardDocument mUIDashboardDocument;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDashboardDocument : HtmlDocument
    {

        public UIDashboardDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Dashboard";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/Home/Dashboard";
            this.WindowTitles.Add("Dashboard");
            #endregion
        }

        #region Properties
        public HtmlHyperlink UISignOutHyperlink
        {
            get
            {
                if ((this.mUISignOutHyperlink == null))
                {
                    this.mUISignOutHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUISignOutHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "login-link";
                    this.mUISignOutHyperlink.WindowTitles.Add("Dashboard");
                    this.mUISignOutHyperlink.WindowTitles.Add("Add Reminder");
                    this.mUISignOutHyperlink.WindowTitles.Add("Add Fill-upo");
                    #endregion
                }
                return this.mUISignOutHyperlink;
            }
        }    

        public HtmlHyperlink UIAddVehicleHyperlink
        {
            get
            {
                if ((this.mUIAddVehicleHyperlink == null))
                {
                    this.mUIAddVehicleHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUIAddVehicleHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "+ Add Vehicle";
                    this.mUIAddVehicleHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/Vehicle/Create";
                    this.mUIAddVehicleHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.ControlDefinition] = "href=\"/MileageStats/Vehicle/Create\"";
                    this.mUIAddVehicleHyperlink.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUIAddVehicleHyperlink;
            }
        }

        public HtmlHyperlink UIDashboardHyperlink
        {
            get
            {
                if ((this.mUIDashboardHyperlink == null))
                {
                    this.mUIDashboardHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUIDashboardHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "dashboard-link";
                    this.mUIDashboardHyperlink.WindowTitles.Add("Dashboard");
                    this.mUIDashboardHyperlink.WindowTitles.Add("Add Vehicle");
                    this.mUIDashboardHyperlink.WindowTitles.Add("Fill-ups for Test_Vehicle");
                    this.mUIDashboardHyperlink.WindowTitles.Add("Add Reminder");
                    this.mUIDashboardHyperlink.WindowTitles.Add("Details for Test_Vehicle");
                    #endregion
                }
                return this.mUIDashboardHyperlink;
            }
        }

        public HtmlHyperlink UIProfileHyperlink
        {
            get
            {
                if (this.mUIProfileHyperlink == null)
                {
                    this.mUIProfileHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUIProfileHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Id] = "profile-link";
                    this.mUIProfileHyperlink.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUIProfileHyperlink;
            }
        }

        public UINewVehiclePane UINewVehiclePane
        {
            get
            {
                if ((this.mUINewVehiclePane == null))
                {
                    this.mUINewVehiclePane = new UINewVehiclePane(this);
                }
                return this.mUINewVehiclePane;
            }
        }

        public UITestVehicle001Pane UITestVehicle001Pane
        {
            get
            {
                if ((this.mUITestVehicle001Pane == null))
                {
                    this.mUITestVehicle001Pane = new UITestVehicle001Pane(this);
                }
                return this.mUITestVehicle001Pane;
            }
        }

        public UIEditedVehiclePane UIEditedVehiclePane
        {
            get
            {
                if ((this.mUIEditedVehiclePane == null))
                {
                    this.mUIEditedVehiclePane = new UIEditedVehiclePane(this);
                }
                return this.mUIEditedVehiclePane;
            }
        }

        public UIWelcomeupdatedusernaPane UIWelcomeupdatedusernaPane
        {
            get 
            {
                if (this.mUIWelcomeupdatedusernaPane == null)
                {
                    this.mUIWelcomeupdatedusernaPane = new UIWelcomeupdatedusernaPane(this);
                }
                return this.mUIWelcomeupdatedusernaPane;
            }
        }

        public UIWelcomeNewUser2Pane UIWelcomeNewUser2Pane
        {
            get
            {
                if (this.mUIWelcomeNewUser2Pane == null)
                {
                    this.mUIWelcomeNewUser2Pane = new UIWelcomeNewUser2Pane(this);
                }
                return this.mUIWelcomeNewUser2Pane;
            }
        }
        #endregion

        #region Fields
        private HtmlHyperlink mUISignOutHyperlink;
           
        private HtmlHyperlink mUIAddVehicleHyperlink;

        private HtmlHyperlink mUIDashboardHyperlink;

        private HtmlHyperlink mUIProfileHyperlink;

        private UINewVehiclePane mUINewVehiclePane;

        private UITestVehicle001Pane mUITestVehicle001Pane;

        private UIEditedVehiclePane mUIEditedVehiclePane;

        private UIWelcomeupdatedusernaPane mUIWelcomeupdatedusernaPane;

        private UIWelcomeNewUser2Pane mUIWelcomeNewUser2Pane;
        #endregion
    }
        
    /// <summary>
    /// This is created by hand-code, To define the "Test_Vehicle" Pane
    /// </summary>
    public class UINewVehiclePane : HtmlDiv
    {
        public UINewVehiclePane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.ControlType] = ControlType.Pane.Name;
            this.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.FriendlyName, 
                "2010HondaAccord  Test_Vehicle", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Dashboard");
            #endregion
        }

        #region Properties
        public HtmlHyperlink UITest_VehicleDetailsHyperlink
        {
            get
            {
                if ((this.mUITest_VehicleDetailsHyperlink == null))
                {
                    this.mUITest_VehicleDetailsHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUITest_VehicleDetailsHyperlink.SearchProperties.Add(new PropertyExpression(HtmlHyperlink.PropertyNames.Href,
                    Utility.detailsHref, PropertyExpressionOperator.Contains));
                    this.mUITest_VehicleDetailsHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.FriendlyName] = "Details";
                    this.mUITest_VehicleDetailsHyperlink.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUITest_VehicleDetailsHyperlink;
            }
        }

        public HtmlHyperlink UITest_VehicleFillupsHyperlink
        {
            get
            {
                if ((this.mUITest_VehicleFillupsHyperlink == null))
                {
                    this.mUITest_VehicleFillupsHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUITest_VehicleFillupsHyperlink.SearchProperties.Add(new PropertyExpression(HtmlHyperlink.PropertyNames.Href,
                    Utility.FillupsHref, PropertyExpressionOperator.Contains));
                    this.mUITest_VehicleFillupsHyperlink.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUITest_VehicleFillupsHyperlink;
            }
        }

        public HtmlHyperlink UITest_VehicleRemindersHyperlink
        {
            get
            {
                if ((this.mUITest_VehicleRemindersHyperlink == null))
                {
                    this.mUITest_VehicleRemindersHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUITest_VehicleRemindersHyperlink.SearchProperties.Add(new PropertyExpression(HtmlHyperlink.PropertyNames.Href,
                    Utility.reminderHref, PropertyExpressionOperator.Contains));
                    this.mUITest_VehicleRemindersHyperlink.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUITest_VehicleRemindersHyperlink;
            }
        }

        public UIVehicleMPGValuePane UIVehicleMPGValuePane
        {
            get 
            {
                if (this.mUIVehicleMPGValuePane == null)
                {
                    this.mUIVehicleMPGValuePane = new UIVehicleMPGValuePane(this);
                }
                return mUIVehicleMPGValuePane;
            }
        }

        public HtmlImage UIVehiclePhotoImage
        {
            get
            {
                if ((this.mUIVehiclePhotoImage == null))
                {
                    this.mUIVehiclePhotoImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIVehiclePhotoImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.testVehiclePhotoAlt;
                    this.mUIVehiclePhotoImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIVehiclePhotoImage.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUIVehiclePhotoImage;
            }
        }
        #endregion

        #region Fields
        private HtmlHyperlink mUITest_VehicleDetailsHyperlink;
        private HtmlHyperlink mUITest_VehicleFillupsHyperlink;
        private HtmlHyperlink mUITest_VehicleRemindersHyperlink;
        private UIVehicleMPGValuePane mUIVehicleMPGValuePane;
        private HtmlImage mUIVehiclePhotoImage;
        #endregion
    }

    /// <summary>
    /// This is created by hand-code, To define the "Test_Vehicle001" Pane  "Test_Vehicle001             "
    /// </summary>
    public class UITestVehicle001Pane : HtmlDiv
    {
        public UITestVehicle001Pane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.ControlType] = ControlType.Pane.Name;
            this.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.FriendlyName,
                "Test_Vehicle001", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Dashboard");
            #endregion
        }

        #region Properties
        public HtmlHyperlink UITest_Vehicle001DetailsHyperlink
        {
            get
            {
                if ((this.mUITest_Vehicle001DetailsHyperlink == null))
                {
                    this.mUITest_Vehicle001DetailsHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUITest_Vehicle001DetailsHyperlink.SearchProperties.Add(new PropertyExpression(HtmlHyperlink.PropertyNames.Href,
                       Utility.detailsHref, PropertyExpressionOperator.Contains));
                    this.mUITest_Vehicle001DetailsHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Target] = null;
                    this.mUITest_Vehicle001DetailsHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = null;
                    this.mUITest_Vehicle001DetailsHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.FriendlyName] = "Details";
                    this.mUITest_Vehicle001DetailsHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Title] = null;
                    this.mUITest_Vehicle001DetailsHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Class] = null;
                    this.mUITest_Vehicle001DetailsHyperlink.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUITest_Vehicle001DetailsHyperlink;
            }
        }

        public HtmlImage UIVehicle001PhotoImage
        {
            get
            {
                if ((this.mUIVehicle001PhotoImage == null))
                {
                    this.mUIVehicle001PhotoImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIVehicle001PhotoImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.testVehicle001PhotoAlt;
                    this.mUIVehicle001PhotoImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIVehicle001PhotoImage.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUIVehicle001PhotoImage;
            }
        }
        #endregion 

        #region Fields
        private HtmlHyperlink mUITest_Vehicle001DetailsHyperlink;

        private HtmlImage mUIVehicle001PhotoImage;
        #endregion

    }

    /// <summary>
    /// This is created by hand-code, To define the "Edited_Vehicle" Pane
    /// </summary>
    public class UIEditedVehiclePane : HtmlDiv
    {
        public UIEditedVehiclePane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.ControlType] = ControlType.Pane.Name;
            this.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.FriendlyName,
              "2011JeepLiberty  Edited_Vehicle", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Dashboard");
            #endregion
        }

        #region Properties
        public HtmlHyperlink UIEdited_VehicleDetailsHyperlink
        {
            get
            {
                if ((this.mUIEdited_VehicleDetailsHyperlink == null))
                {
                    this.mUIEdited_VehicleDetailsHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUIEdited_VehicleDetailsHyperlink.SearchProperties.Add(new PropertyExpression(HtmlHyperlink.PropertyNames.Href,
                    Utility.detailsHref, PropertyExpressionOperator.Contains));
                    this.mUIEdited_VehicleDetailsHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.Target] = null;
                    this.mUIEdited_VehicleDetailsHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = null;
                    this.mUIEdited_VehicleDetailsHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.FriendlyName] = "Details";
                    this.mUIEdited_VehicleDetailsHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Title] = null;
                    this.mUIEdited_VehicleDetailsHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Class] = null;
                    this.mUIEdited_VehicleDetailsHyperlink.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUIEdited_VehicleDetailsHyperlink;
            }
        }
        #endregion 

        #region Fields
        private HtmlHyperlink mUIEdited_VehicleDetailsHyperlink;
        #endregion 
    }

    /// <summary>
    /// This is created by hand-code, the get the mpg value of Test_Vehicle
    /// </summary>
    public class UIVehicleMPGValuePane : HtmlDiv
    {
        public UIVehicleMPGValuePane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"quantity\"";
            this.SearchProperties[HtmlDiv.PropertyNames.FriendlyName] = "10";
            this.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "10";
            this.WindowTitles.Add("Dashboard");
            #endregion
        }
    }

    /// <summary>
    /// This is created by hand-code, the get the new user name pane.
    /// </summary>
    public class UIWelcomeupdatedusernaPane : HtmlDiv
    {
        public UIWelcomeupdatedusernaPane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = "welcome";
            this.SearchProperties[HtmlDiv.PropertyNames.TagName] = "SPAN";
            this.SearchProperties[HtmlDiv.PropertyNames.ClassName] = "HtmlPane";
            this.SearchProperties[HtmlDiv.PropertyNames.InnerText] = "Welcome Updated User";
            this.WindowTitles.Add("Dashboard");
            #endregion
        }
    }

    public class UIWelcomeNewUser2Pane : HtmlDiv
    {
        public UIWelcomeNewUser2Pane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = "welcome";
            this.SearchProperties[HtmlDiv.PropertyNames.TagName] = "SPAN";
            this.SearchProperties[HtmlDiv.PropertyNames.ClassName] = "HtmlPane";
            this.SearchProperties[HtmlDiv.PropertyNames.InnerText] = "Welcome New User2";
            this.WindowTitles.Add("Dashboard");
            #endregion
        }
    }

    #endregion
}
    