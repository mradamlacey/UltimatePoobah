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
namespace MileageStats.AcceptanceTest.UIMaps.ReminderPageClasses
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
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    public partial class ReminderPage
    {
        #region Help Methods
        public void ClickReminderButton()
        {
            #region Variable Declarations
            HtmlImage uIAddReminderButton = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument.UIAddReminderPane.UIAddReminderImage;
            #endregion

            // Click 'Add' Button
            Mouse.Click(uIAddReminderButton);
        }     

        /// <summary>
        /// AddReminder - Use 'AddReminderParams' to pass parameters into this method.
        /// </summary>
        public void AddReminder()
        {
            #region Variable Declarations
            HtmlImage uIAddReminderButton = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument.UIAddReminderPane.UIAddReminderImage;
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlTextArea uIRemarksEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIRemarksEdit;
            HtmlEdit uIDueDateEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDueDateEdit;
            HtmlEdit uIDuewhenodometerreadsEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDuewhenodometerreadsEdit;
            HtmlImage uISaveButton = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIReminderspanePane.UISaveImage;
            #endregion

            // Click 'Add' button
            Mouse.Click(uIAddReminderButton);

            // Type 'Check Wiper Fluid' in 'Title' text box
            uITitleEdit.Text = this.AddReminderParams.UITitleEditText;

            // Type 'Check condition of the wipe' in 'Remarks' text box
            uIRemarksEdit.Text = this.AddReminderParams.UIRemarksEditText;

            // Type '6/20/2012' in 'Due Date' text box
            uIDueDateEdit.Text = this.AddReminderParams.UIDueDateEditText;

            // Type '1000' in 'Due when odometer reads' text box
            uIDuewhenodometerreadsEdit.Text = this.AddReminderParams.UIDuewhenodometerreadsEditText;

            // Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddReminderWithTitleDueDate()
        {
            #region Variable Declarations
            HtmlImage uIAddReminderButton = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument.UIAddReminderPane.UIAddReminderImage;
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlEdit uIDueDateEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDueDateEdit;
            HtmlImage uISaveButton = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIReminderspanePane.UISaveImage;
            #endregion

            // Click 'Add' button
            Mouse.Click(uIAddReminderButton);

            // Type 'Check Wiper Fluid' in 'Title' text box
            uITitleEdit.Text = "Check Wiper Fluid";

            // Type '6/20/2012' in 'Due Date' text box
            uIDueDateEdit.Text = @"6/20/2012";

            // Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddReminderWithTitleDueOdometerReads()
        {
            #region Variable Declarations
            HtmlImage uIAddReminderButton = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument.UIAddReminderPane.UIAddReminderImage;
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlEdit uIDuewhenodometerreadsEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDuewhenodometerreadsEdit;
            HtmlImage uISaveButton = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIReminderspanePane.UISaveImage;
            #endregion

            // Click 'Add' Button
            Mouse.Click(uIAddReminderButton);

            // Type 'Check Wiper Fluid' in 'Title' text box
            uITitleEdit.Text = "Check Wiper Fluid";

            // Type '3000' in 'Due when odometer reads' text box
            uIDuewhenodometerreadsEdit.Text = "3000";

            // Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddReminderWithJunkChar()
        {
            #region Variable Declarations
            HtmlImage uIAddReminderButton = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument.UIAddReminderPane.UIAddReminderImage;
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlTextArea uIRemarksEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIRemarksEdit;
            HtmlEdit uIDueDateEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDueDateEdit;
            HtmlEdit uIDuewhenodometerreadsEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDuewhenodometerreadsEdit;
            HtmlImage uISaveButton = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIReminderspanePane.UISaveImage;
            #endregion

            // Click 'Add' button
            Mouse.Click(uIAddReminderButton);

            // Type '&*(^&' in 'Title' text box
            uITitleEdit.Text = "&*(^&";

            // Type '&^(*' in 'Remarks' text box
            uIRemarksEdit.Text = @"&^(*";

            // Type '&^(*' in 'Due Date' text box
            uIDueDateEdit.Text = @"&^(*";

            // Type "&^(* in 'Due when odometer reads' text box
            uIDuewhenodometerreadsEdit.Text = @"&^(*";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void AddReminderWithInvalidDueDate()
        {
            #region Variable Declarations
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlTextArea uIRemarksEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIRemarksEdit;
            HtmlEdit uIDueDateEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDueDateEdit;
            HtmlEdit uIDuewhenodometerreadsEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDuewhenodometerreadsEdit;
            HtmlImage uISaveButton = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIReminderspanePane.UISaveImage;
            #endregion

            // Type 'test' in 'Title' text box
            uITitleEdit.Text = "test";

            // Type '' in 'Remarks' text box
            uIRemarksEdit.Text = "";

            // Type '02/29/2011' in 'Due Date' text box
            uIDueDateEdit.Text = @"02/29/2011";

            // Type '' in 'Due when odometer reads' text box
            uIDuewhenodometerreadsEdit.Text = "";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void AddReminderWithNullTitle()
        {
            #region Variable Declarations
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlTextArea uIRemarksEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIRemarksEdit;
            HtmlEdit uIDueDateEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDueDateEdit;
            HtmlEdit uIDuewhenodometerreadsEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDuewhenodometerreadsEdit;
            HtmlImage uISaveButton = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIReminderspanePane.UISaveImage;
            #endregion

            // Type '' in 'Title' text box
            uITitleEdit.Text = "";

            // Type '' in 'Remarks' text box
            uIRemarksEdit.Text = "";

            // Type '' in 'Due Date' text box
            uIDueDateEdit.Text = "";

            // Type '' in 'Due when odometer reads' text box
            uIDuewhenodometerreadsEdit.Text = "";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void addReminderWithInvalidDueOdometerReads()
        {
            #region Variable Declarations
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlTextArea uIRemarksEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIRemarksEdit;
            HtmlEdit uIDueDateEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDueDateEdit;
            HtmlEdit uIDuewhenodometerreadsEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDuewhenodometerreadsEdit;
            HtmlImage uISaveButton = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIReminderspanePane.UISaveImage;
            #endregion

            // Type 'test' in 'Title' text box
            uITitleEdit.Text = "test";

            // Type '' in 'Remarks' text box
            uIRemarksEdit.Text = "";

            // Type '' in 'Due Date' text box
            uIDueDateEdit.Text = "";

            // Type '-100' in 'Due when odometer reads' text box
            uIDuewhenodometerreadsEdit.Text = "-100";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        /// <summary>
        /// Verify if thre already has test reminder
        /// </summary>
        /// <returns></returns>
        public bool ReminderIsExisted()
        {
            #region Variable Declarations
            HtmlHyperlink uICheckWiperFluidDueonHyperlink = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument1.UIReminderspanePane.UICheckWiperFluidDueonHyperlink;
            #endregion

            //Verify if three already has test reminder
            return uICheckWiperFluidDueonHyperlink.Exists;
        }

        /// <summary>
        /// FulfillReminder
        /// </summary>
        public void FulfillReminder()
        {
            #region Variable Declarations
            HtmlImage uIFulfillButton = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument2.UIReminderspanePane.UIFulfillImage;
            BrowserWindow uIRemindersforTest_VehWindow = this.UIRemindersforTest_VehWindow;
            #endregion

            // Click 'Fulfill' Button
            Mouse.Click(uIFulfillButton);

            // Click 'Ok' button in the browser dialog window
            uIRemindersforTest_VehWindow.PerformDialogAction(BrowserDialogAction.Ok);
        }
        #endregion

        #region Assert Methonds
        /// <summary>
        /// AssertReminderIsAdded - Use 'AssertReminderIsAddedExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertReminderIsAdded()
        {
            #region Variable Declarations
            HtmlHyperlink uICheckWiperFluidDueonHyperlink = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument1.UIReminderspanePane.UICheckWiperFluidDueonHyperlink;
            #endregion

            // Verify that 'Check Wiper Fluid  Due on 20 Jun 2012 or at 1000 m...' link's property 'InnerText' equals 'Check Wiper Fluid
            //
            //Due on 20 Jun 2012 or at 1000 miles 
            //
            //Accord '
            Assert.AreEqual(this.AssertReminderIsAddedExpectedValues.UICheckWiperFluidDueonHyperlinkInnerText, uICheckWiperFluidDueonHyperlink.InnerText);
        }

        public void AssertOnlyTitleDateReminderIsAdded()
        {
            #region Variable Declarations
            HtmlHyperlink uICheckWiperFluidDueonHyperlink1 = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument1.UIReminderspanePane.UICheckWiperFluidDueonHyperlink1;
            #endregion

            // Verify that reminder 'Check Wiper Fluid  Due on 20 Jun 2012' is added
            Assert.IsTrue(uICheckWiperFluidDueonHyperlink1.Exists);
        }

        public void AssertOnlyTitleOdometerReadsReminderIsAdded()
        {
            #region Variable Declarations
            HtmlHyperlink uICheckWiperFluidDueatHyperlink = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument1.UIReminderspanePane.UICheckWiperFluidDueatHyperlink;
            #endregion

            // Verify that reminder 'Check Wiper Fluid  Due at 3000 miles' is added
            Assert.IsTrue(uICheckWiperFluidDueatHyperlink.Exists);
        }

        public void AssertMaxLengthProperty()
        {
            #region Variable Declarations
            HtmlEdit uITitleEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITitleEdit;
            HtmlEdit uIDueDateEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDueDateEdit;
            HtmlEdit uIDuewhenodometerreadsEdit = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIDuewhenodometerreadsEdit;
            #endregion

            //Verify the MaxLength Property of Title box equal 50
            Assert.IsTrue(uITitleEdit.MaxLength == 50, "The MaxLength property of Title InputBox is " + uITitleEdit.MaxLength + ", it should equal 50");

            //Verify the MaxLength Property of DueDate box equal 10
            Assert.IsTrue(uIDueDateEdit.MaxLength == 10, "The MaxLength property of DueDate InputBox is " + uIDueDateEdit.MaxLength + ", it should equal 10");

            //Verify the MaxLength Property of Due Odometer reads box equal 7
            Assert.IsTrue(uIDuewhenodometerreadsEdit.MaxLength == 7, "The MaxLength property of Due Odometer reads InputBox is " + uIDuewhenodometerreadsEdit.MaxLength + ", it should equal 7");
        }

        /// <summary>
        /// AssertReminderIsNotExist - Verify the reminder just created doesn't not exist anymore.
        /// </summary>
        public void AssertReminderIsNotExisted()
        {
            #region Variable Declarations
            HtmlDiv uIItemPane = this.UIRemindersforTest_VehWindow.UIRemindersforTest_VehDocument1.UIReminderspanePane.UIItemPane;
            #endregion

            //Verify the null reminder pane exist
            Assert.IsTrue(uIItemPane.Exists);
        }

        public void AssertJunkCharValidateMsg()
        {
            #region Variable Declarations
            HtmlSpan uIOnlyalphanumericcharPane1 = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIOnlyalphanumericcharPane1;
            HtmlSpan uIThevalueisnotvalidfoPane1 = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIThevalueisnotvalidfoPane1;
            #endregion

            // Verify that 'Only alpha-numeric characters and [.,_-'] are allowed.' is displayed
            Assert.IsTrue(uIOnlyalphanumericcharPane1.Exists, @"The validate message 'Only alpha-numeric characters and [.,_-'] are allowed.' isn't displayed");

            // Verify that 'The value '&^(*' is not valid for Due when odometer reads.' is displayed
            Assert.IsTrue(uIThevalueisnotvalidfoPane1.Exists, @"The validate message '&^(*' is not valid forDue when odometer reads.' isn't displayed");
        }

        public void AssertInvalidDueDateValidatedMsg()
        {
            #region Variable Declarations
            HtmlSpan uIThevalue02292011isnoPane = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UIThevalue02292011isnoPane;
            #endregion

            // Verify that 'The value '02/29/2011' is not valid for Due Date.' is displayed
            Assert.IsTrue(uIThevalue02292011isnoPane.Exists, @"The validate message 'The value '02/29/2011' is not valid for Due Date.' isn't displayed");          
        }

        public void AssertNullTitleValidateMsg()
        {
            #region Variable Declarations
            HtmlSpan uITheTitlefieldisrequiPane = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITheTitlefieldisrequiPane;
            #endregion

            // Verify that 'The Title field is required.' is displayed
            Assert.IsTrue(uITheTitlefieldisrequiPane.Exists, "The validate message \'The Title field is required.\' isn't displayed");
        }

        public void AssertInvalidDueOdometerReadsValidatedMsg()
        {
            #region Variable Declarations
            HtmlSpan uITheodometerduedistanPane = this.UIRemindersforTest_VehWindow.UIAddReminderDocument.UITheodometerduedistanPane;
            #endregion

            // Verify that 'The odometer due distance must be between 1 and 1,000,000.'is displayed
            Assert.IsTrue(uITheodometerduedistanPane.Exists, "The validate message \'The odometer due distance must be between 1 and 1,000,000.\' isn't displayed");
        }
        #endregion 

        #region Properties
        public virtual AddReminderParams AddReminderParams
        {
            get
            {
                if ((this.mAddReminderParams == null))
                {
                    this.mAddReminderParams = new AddReminderParams();
                }
                return this.mAddReminderParams;
            }
        }

        public virtual AssertReminderIsAddedExpectedValues AssertReminderIsAddedExpectedValues
        {
            get
            {
                if ((this.mAssertReminderIsAddedExpectedValues == null))
                {
                    this.mAssertReminderIsAddedExpectedValues = new AssertReminderIsAddedExpectedValues();
                }
                return this.mAssertReminderIsAddedExpectedValues;
            }
        }

        public UIRemindersforTest_VehWindow UIRemindersforTest_VehWindow
        {
            get
            {
                if ((this.mUIRemindersforTest_VehWindow == null))
                {
                    this.mUIRemindersforTest_VehWindow = new UIRemindersforTest_VehWindow();
                }
                return this.mUIRemindersforTest_VehWindow;
            }
        }
        #endregion

        #region Fields
        private AddReminderParams mAddReminderParams;

        private AssertReminderIsAddedExpectedValues mAssertReminderIsAddedExpectedValues;

        private UIRemindersforTest_VehWindow mUIRemindersforTest_VehWindow;
        #endregion
    }

    //These UITestControls are generate with Coded UITest Builder, Copy them from DashboardPage.Designer.cs file.
    //then modify them if we need to 
    #region UITestControl Definition
    /// <summary>
    /// Parameters to be passed into 'AddReminder'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class AddReminderParams
    {

        #region Fields
        /// <summary>
        /// Type 'Check Wiper Fluid' in 'Title' text box
        /// </summary>
        public string UITitleEditText = "Check Wiper Fluid";

        /// <summary>
        /// Type 'Check condition of the wipe' in 'Remarks' text box
        /// </summary>
        public string UIRemarksEditText = "Check condition of the wipe";

        /// <summary>
        /// Type '6/20/2012' in 'Due Date' text box
        /// </summary>
        public string UIDueDateEditText = "6/20/2012";

        /// <summary>
        /// Type '1000' in 'Due when odometer reads' text box
        /// </summary>
        public string UIDuewhenodometerreadsEditText = "1000";
        #endregion
    }

    /// <summary>
    /// Parameters to be passed into 'AssertReminderIsAdded'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class AssertReminderIsAddedExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Check Wiper Fluid  Due on 20 Jun 2012 or at 1000 m...' link's property 'InnerText' equals 'Check Wiper Fluid
        ///
        ///Due on 20 Jun 2012 or at 1000 miles '
        /// </summary>
        //public string UICheckWiperFluidDueonHyperlinkInnerText = "Check Wiper Fluid\r\n\r\nDue on 20 Jun 2012 or at 1000 miles \r\n\r\nAccord ";
        public string UICheckWiperFluidDueonHyperlinkInnerText = "Check Wiper Fluid\r\n\r\nDue on 20 Jun 2012 or at 1000 miles. ";
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRemindersforTest_VehWindow : BrowserWindow
    {

        public UIRemindersforTest_VehWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Dashboard";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Reminders");
            this.WindowTitles.Add("Reminders for Test_Vehicle");
            this.WindowTitles.Add("Add Reminder");
            #endregion
        }

        public void LaunchUrl(System.Uri url)
        {
            this.CopyFrom(BrowserWindow.Launch(url));
        }

        #region Properties
        public UIRemindersforTest_VehDocument UIRemindersforTest_VehDocument
        {
            get
            {
                if ((this.mUIRemindersforTest_VehDocument == null))
                {
                    this.mUIRemindersforTest_VehDocument = new UIRemindersforTest_VehDocument(this);
                }
                return this.mUIRemindersforTest_VehDocument;
            }
        }

        public UIAddReminderDocument UIAddReminderDocument
        {
            get
            {
                if ((this.mUIAddReminderDocument == null))
                {
                    this.mUIAddReminderDocument = new UIAddReminderDocument(this);
                }
                return this.mUIAddReminderDocument;
            }
        }

        public UIRemindersforTest_VehDocument1 UIRemindersforTest_VehDocument1
        {
            get
            {
                if ((this.mUIRemindersforTest_VehDocument1 == null))
                {
                    this.mUIRemindersforTest_VehDocument1 = new UIRemindersforTest_VehDocument1(this);
                }
                return this.mUIRemindersforTest_VehDocument1;
            }
        }

        public UIRemindersforTest_VehDocument2 UIRemindersforTest_VehDocument2
        {
            get
            {
                if ((this.mUIRemindersforTest_VehDocument2 == null))
                {
                    this.mUIRemindersforTest_VehDocument2 = new UIRemindersforTest_VehDocument2(this);
                }
                return this.mUIRemindersforTest_VehDocument2;
            }
        }
        #endregion

        #region Fields
        private UIRemindersforTest_VehDocument mUIRemindersforTest_VehDocument;

        private UIAddReminderDocument mUIAddReminderDocument;

        private UIRemindersforTest_VehDocument1 mUIRemindersforTest_VehDocument1;

        private UIRemindersforTest_VehDocument2 mUIRemindersforTest_VehDocument2;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRemindersforTest_VehDocument : HtmlDocument
    {

        public UIRemindersforTest_VehDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Reminders";
            this.WindowTitles.Add("Reminders");
            //this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Reminders for Test_Vehicle";
            this.WindowTitles.Add("Reminders for Test_Vehicle");
            #endregion
        }

        #region Properties
        public UIAddReminderPane UIAddReminderPane
        {
            get
            {
                if ((this.mUIAddReminderPane == null))
                {
                    this.mUIAddReminderPane = new UIAddReminderPane(this);
                }
                return this.mUIAddReminderPane;
            }
        }
        #endregion

        #region Fields
        private UIAddReminderPane mUIAddReminderPane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIAddReminderPane : HtmlDiv
    {

        public UIAddReminderPane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "reminders-pane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "DIV";
            this.WindowTitles.Add("Reminders for Test_Vehicle");
            #endregion
        }

        #region Properties
        public HtmlImage UIAddReminderImage
        {
            get
            {
                if ((this.mUIAddReminderImage == null))
                {
                    this.mUIAddReminderImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIAddReminderImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.addImageAlt;
                    this.mUIAddReminderImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIAddReminderImage.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIAddReminderImage;
            }
        }
        #endregion

        #region Fields
        private HtmlImage mUIAddReminderImage;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIAddReminderDocument : HtmlDocument
    {

        public UIAddReminderDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Add Reminder";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/Reminder/Create/7";
            this.WindowTitles.Add("Add Reminder");
            #endregion
        }

        #region Properties
        public HtmlEdit UITitleEdit
        {
            get
            {
                if ((this.mUITitleEdit == null))
                {
                    this.mUITitleEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUITitleEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "ReminderTitle";
                    this.mUITitleEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Title";
                    this.mUITitleEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mUITitleEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUITitleEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUITitleEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = null;
                    this.mUITitleEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"ReminderTitle\" name=\"Title\" value=\"\"";
                    this.mUITitleEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "1";
                    this.mUITitleEdit.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUITitleEdit;
            }
        }

        public HtmlTextArea UIRemarksEdit
        {
            get
            {
                if ((this.mUIRemarksEdit == null))
                {
                    this.mUIRemarksEdit = new HtmlTextArea(this);
                    #region Search Criteria
                    this.mUIRemarksEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "Remarks";
                    this.mUIRemarksEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Remarks";
                    this.mUIRemarksEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Remarks";
                    this.mUIRemarksEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"Remarks\" cols=\"20\" rows=\"2\" name=\"Re";
                    this.mUIRemarksEdit.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIRemarksEdit;
            }
        }

        public HtmlEdit UIDueDateEdit
        {
            get
            {
                if ((this.mUIDueDateEdit == null))
                {
                    this.mUIDueDateEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIDueDateEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "DueDate";
                    this.mUIDueDateEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "DueDate";
                    this.mUIDueDateEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Due Date";
                    this.mUIDueDateEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIDueDateEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "text-box single-line";
                    this.mUIDueDateEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"DueDate\" class=\"text-box single-line";
                    this.mUIDueDateEdit.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIDueDateEdit;
            }
        }

        public HtmlEdit UIDuewhenodometerreadsEdit
        {
            get
            {
                if ((this.mUIDuewhenodometerreadsEdit == null))
                {
                    this.mUIDuewhenodometerreadsEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIDuewhenodometerreadsEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "DueDistance";
                    this.mUIDuewhenodometerreadsEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "DueDistance";
                    this.mUIDuewhenodometerreadsEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Due when odometer reads";
                    this.mUIDuewhenodometerreadsEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIDuewhenodometerreadsEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIDuewhenodometerreadsEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "text-box single-line";
                    this.mUIDuewhenodometerreadsEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"DueDistance\" class=\"text-box single-";
                    this.mUIDuewhenodometerreadsEdit.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIDuewhenodometerreadsEdit;
            }
        }

        public UIReminderspanePane1 UIReminderspanePane
        {
            get
            {
                if ((this.mUIReminderspanePane == null))
                {
                    this.mUIReminderspanePane = new UIReminderspanePane1(this);
                }
                return this.mUIReminderspanePane;
            }
        }

        public HtmlSpan UITheTitlefieldisrequiPane
        {
            get
            {
                if ((this.mUITheTitlefieldisrequiPane == null))
                {
                    this.mUITheTitlefieldisrequiPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUITheTitlefieldisrequiPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.titleRequiredValidateMsg;
                    this.mUITheTitlefieldisrequiPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUITheTitlefieldisrequiPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUITheTitlefieldisrequiPane.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUITheTitlefieldisrequiPane;
            }
        }

        public HtmlSpan UIOnlyalphanumericcharPane
        {
            get
            {
                if ((this.mUIOnlyalphanumericcharPane == null))
                {
                    this.mUIOnlyalphanumericcharPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIOnlyalphanumericcharPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.remarksJunkCharValidateMsg;
                    this.mUIOnlyalphanumericcharPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIOnlyalphanumericcharPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIOnlyalphanumericcharPane.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIOnlyalphanumericcharPane;
            }
        }

        public HtmlSpan UIThevalueisnotvalidfoPane
        {
            get
            {
                if ((this.mUIThevalueisnotvalidfoPane == null))
                {
                    this.mUIThevalueisnotvalidfoPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIThevalueisnotvalidfoPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.dueDateJunkCharValidateMsg;
                    this.mUIThevalueisnotvalidfoPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIThevalueisnotvalidfoPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIThevalueisnotvalidfoPane.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIThevalueisnotvalidfoPane;
            }
        }

        public HtmlSpan UIThevalueisnotvalidfoPane1
        {
            get
            {
                if ((this.mUIThevalueisnotvalidfoPane1 == null))
                {
                    this.mUIThevalueisnotvalidfoPane1 = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIThevalueisnotvalidfoPane1.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.dueDistanceJunkCharValidateMsg;
                    this.mUIThevalueisnotvalidfoPane1.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIThevalueisnotvalidfoPane1.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIThevalueisnotvalidfoPane1.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIThevalueisnotvalidfoPane1;
            }
        }

        public HtmlSpan UIOnlyalphanumericcharPane1
        {
            get
            {
                if ((this.mUIOnlyalphanumericcharPane1 == null))
                {
                    this.mUIOnlyalphanumericcharPane1 = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIOnlyalphanumericcharPane1.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.charValidateMsg;
                    this.mUIOnlyalphanumericcharPane1.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIOnlyalphanumericcharPane1.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIOnlyalphanumericcharPane1.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIOnlyalphanumericcharPane1;
            }
        }

        public HtmlSpan UIThevalue02292011isnoPane
        {
            get
            {
                if ((this.mUIThevalue02292011isnoPane == null))
                {
                    this.mUIThevalue02292011isnoPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIThevalue02292011isnoPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.dueDateInvalidMsg;
                    this.mUIThevalue02292011isnoPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIThevalue02292011isnoPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIThevalue02292011isnoPane.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIThevalue02292011isnoPane;
            }
        }

        public HtmlSpan UITheodometerduedistanPane
        {
            get
            {
                if ((this.mUITheodometerduedistanPane == null))
                {
                    this.mUITheodometerduedistanPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUITheodometerduedistanPane.FilterProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.dueDistanceInvalidMsg;
                    this.mUITheodometerduedistanPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUITheodometerduedistanPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUITheodometerduedistanPane.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUITheodometerduedistanPane;
            }
        }

        public HtmlSpan UIThefieldRemarksmustbPane
        {
            get
            {
                if ((this.mUIThefieldRemarksmustbPane == null))
                {
                    this.mUIThefieldRemarksmustbPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIThefieldRemarksmustbPane.FilterProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.remarksLengthValidateMsg;
                    this.mUIThefieldRemarksmustbPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIThefieldRemarksmustbPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIThefieldRemarksmustbPane.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIThefieldRemarksmustbPane;
            }
        }
        #endregion

        #region Fields
        private HtmlEdit mUITitleEdit;

        private HtmlTextArea mUIRemarksEdit;

        private HtmlEdit mUIDueDateEdit;

        private HtmlEdit mUIDuewhenodometerreadsEdit;

        private UIReminderspanePane1 mUIReminderspanePane;

        private HtmlSpan mUITheTitlefieldisrequiPane;

        private HtmlSpan mUIOnlyalphanumericcharPane;

        private HtmlSpan mUIThevalueisnotvalidfoPane;

        private HtmlSpan mUIThevalueisnotvalidfoPane1;

        private HtmlSpan mUIOnlyalphanumericcharPane1;

        private HtmlSpan mUIThevalue02292011isnoPane;

        private HtmlSpan mUITheodometerduedistanPane;

        private HtmlSpan mUIThefieldRemarksmustbPane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIReminderspanePane1 : HtmlDiv
    {

        public UIReminderspanePane1(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "reminders-pane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "DIV";
            this.WindowTitles.Add("Add Reminder");
            #endregion
        }

        #region Properties
        public HtmlImage UISaveImage
        {
            get
            {
                if ((this.mUISaveImage == null))
                {
                    this.mUISaveImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUISaveImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.saveImageAlt;
                    this.mUISaveImage.FilterProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUISaveImage.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUISaveImage;
            }
        }
        #endregion

        #region Fields
        private HtmlImage mUISaveImage;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRemindersforTest_VehDocument1 : HtmlDocument
    {

        public UIRemindersforTest_VehDocument1(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Reminders";
            this.WindowTitles.Add("Reminders");
            this.WindowTitles.Add("Add Reminder");
            #endregion
        }

        #region Properties
        public UIReminderspanePane2 UIReminderspanePane
        {
            get
            {
                if ((this.mUIReminderspanePane == null))
                {
                    this.mUIReminderspanePane = new UIReminderspanePane2(this);
                }
                return this.mUIReminderspanePane;
            }
        }
        #endregion

        #region Fields
        private UIReminderspanePane2 mUIReminderspanePane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIReminderspanePane2 : HtmlDiv
    {

        public UIReminderspanePane2(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "reminders-pane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "DIV";
            this.FilterProperties["Class"] = "tab opened";
            this.WindowTitles.Add("Reminders");
            this.WindowTitles.Add("Add Reminder");
            #endregion
        }

        #region Properties
        public HtmlHyperlink UICheckWiperFluidDueonHyperlink
        {
            get
            {
                if ((this.mUICheckWiperFluidDueonHyperlink == null))
                {
                    this.mUICheckWiperFluidDueonHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUICheckWiperFluidDueonHyperlink.SearchProperties.Add(new PropertyExpression(HtmlHyperlink.PropertyNames.InnerText,"Check Wiper Fluid\r\n\r\nDue on 20 Jun 2012 or at 1000 miles", PropertyExpressionOperator.Contains));
                    this.mUICheckWiperFluidDueonHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Class] = "list-item selected ";
                    this.mUICheckWiperFluidDueonHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.ControlDefinition] = "class=\"list-item selected \" href=\"/Milea";
                    this.mUICheckWiperFluidDueonHyperlink.WindowTitles.Add("Reminders");
                    this.mUICheckWiperFluidDueonHyperlink.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUICheckWiperFluidDueonHyperlink;
            }
        }

        public HtmlHyperlink UICheckWiperFluidDueonHyperlink1
        {
            get
            {
                if ((this.mUICheckWiperFluidDueonHyperlink1 == null))
                {
                    this.mUICheckWiperFluidDueonHyperlink1 = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUICheckWiperFluidDueonHyperlink1.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Check Wiper Fluid\r\n\r\nDue on 20 Jun 2012. ";
                    this.mUICheckWiperFluidDueonHyperlink1.FilterProperties[HtmlHyperlink.PropertyNames.Title] = null;
                    this.mUICheckWiperFluidDueonHyperlink1.FilterProperties[HtmlHyperlink.PropertyNames.Class] = "list-item selected ";
                    this.mUICheckWiperFluidDueonHyperlink1.FilterProperties[HtmlHyperlink.PropertyNames.ControlDefinition] = "class=\"list-item selected \" href=\"/Milea";
                    this.mUICheckWiperFluidDueonHyperlink1.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUICheckWiperFluidDueonHyperlink1;
            }
        }

        public HtmlHyperlink UICheckWiperFluidDueatHyperlink
        {
            get
            {
                if ((this.mUICheckWiperFluidDueatHyperlink == null))
                {
                    this.mUICheckWiperFluidDueatHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUICheckWiperFluidDueatHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "Check Wiper Fluid\r\n\r\nDue at 3000 miles. ";
                    this.mUICheckWiperFluidDueatHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Class] = "list-item selected ";
                    this.mUICheckWiperFluidDueatHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.ControlDefinition] = "class=\"list-item selected \" href=\"/Milea";
                    this.mUICheckWiperFluidDueatHyperlink.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUICheckWiperFluidDueatHyperlink;
            }
        }

        public HtmlDiv UIItemPane
        {
            get
            {
                if (this.mUIItemPane == null)
                {
                    this.mUIItemPane = new HtmlDiv(this);
                    #region Search Criteria
                    this.mUIItemPane.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "";
                    this.mUIItemPane.SearchProperties[HtmlHyperlink.PropertyNames.Class] = "aside";
                    this.mUIItemPane.WindowTitles.Add("Reminders");
                    #endregion
                }

                return this.mUIItemPane;
            }
        }
        #endregion

        #region Fields
        private HtmlHyperlink mUICheckWiperFluidDueonHyperlink;

        private HtmlHyperlink mUICheckWiperFluidDueonHyperlink1;

        private HtmlHyperlink mUICheckWiperFluidDueatHyperlink;

        private HtmlDiv mUIItemPane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIRemindersforTest_VehDocument2 : HtmlDocument
    {

        public UIRemindersforTest_VehDocument2(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Reminders for Test_Vehicle";
            this.WindowTitles.Add("Reminders for Test_Vehicle");
            this.WindowTitles.Add("Add Reminder");
            #endregion
        }

        #region Properties
        public UIReminderspanePane3 UIReminderspanePane
        {
            get
            {
                if ((this.mUIReminderspanePane == null))
                {
                    this.mUIReminderspanePane = new UIReminderspanePane3(this);
                }
                return this.mUIReminderspanePane;
            }
        }
        #endregion

        #region Fields
        private UIReminderspanePane3 mUIReminderspanePane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIReminderspanePane3 : HtmlDiv
    {

        public UIReminderspanePane3(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "reminders-pane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "DIV";
            this.WindowTitles.Add("Add Reminder");
            #endregion
        }

        #region Properties
        public HtmlImage UIFulfillImage
        {
            get
            {
                if ((this.mUIFulfillImage == null))
                {
                    this.mUIFulfillImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIFulfillImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.fulfillImageAlt;
                    this.mUIFulfillImage.FilterProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIFulfillImage.WindowTitles.Add("Add Reminder");
                    #endregion
                }
                return this.mUIFulfillImage;
            }
        }
        #endregion

        #region Fields
        private HtmlImage mUIFulfillImage;
        #endregion
    }
    #endregion
}
