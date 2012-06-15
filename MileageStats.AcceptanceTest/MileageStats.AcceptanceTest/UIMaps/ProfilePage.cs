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
namespace MileageStats.AcceptanceTest.UIMaps.ProfilePageClasses
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
    
    
    public partial class ProfilePage
    {
        #region Help Methods
        /// <summary>
        /// EditProfile - Use 'EditProfileParams' to pass parameters into this method.
        /// </summary>
        public void EditProfile()
        {
            #region Variable Declarations
            HtmlEdit uIDisplayNameEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIDisplayNameEdit;
            HtmlComboBox uICountryorRegionComboBox = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UICountryorRegionComboBox;
            HtmlEdit uIPostalCodeEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIPostalCodeEdit;
            HtmlImage uISaveButton = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIAccountPane.UISaveImage;
            #endregion

            // Type 'updateduser' in 'Display Name' text box
            uIDisplayNameEdit.Text = this.EditProfileParams.UIDisplayNameEditText;

            uICountryorRegionComboBox.SetFocus();
            Keyboard.SendKeys(this.EditProfileParams.UICountryorRegionComboBoxSelectedItem);

            // Type '98101' in 'Postal Code' text box
            uIPostalCodeEdit.Text = this.EditProfileParams.UIPostalCodeEditText;

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void EditProfilewithNullPostalCode()
        {
            #region Variable Declarations
            HtmlEdit uIDisplayNameEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIDisplayNameEdit;
            HtmlComboBox uICountryorRegionComboBox = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UICountryorRegionComboBox;
            HtmlEdit uIPostalCodeEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIPostalCodeEdit;
            HtmlImage uISaveButton = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIAccountPane.UISaveImage;
            #endregion

            // Type 'updated user name' in 'Display Name' text box
            uIDisplayNameEdit.Text = "New User2";

            uICountryorRegionComboBox.SetFocus();
            Keyboard.SendKeys(this.EditProfileParams.UICountryorRegionComboBoxSelectedItem);

            // Type '' in 'Postal Code' text box
            uIPostalCodeEdit.Text = "";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void EditProfileWithNullName()
        {
            #region Variable Declarations
            HtmlEdit uIDisplayNameEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIDisplayNameEdit;
            HtmlImage uISaveButton = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIAccountPane.UISaveImage; 
            #endregion

            // Type '' in 'Display Name' text box
            uIDisplayNameEdit.Text = "";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void EditProfileWithJunkCharsName()
        {
            #region Variable Declarations
            HtmlEdit uIDisplayNameEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIDisplayNameEdit;
            HtmlImage uISaveButton = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIAccountPane.UISaveImage;
            #endregion

            // Type *)*& in 'Display Name' text box
            uIDisplayNameEdit.Text = "*)*&";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void EditProfileWithInvalidUSPostalCode()
        {
            #region Variable Declarations
            HtmlEdit uIDisplayNameEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIDisplayNameEdit;
            HtmlComboBox uICountryorRegionComboBox = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UICountryorRegionComboBox;
            HtmlEdit uIPostalCodeEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIPostalCodeEdit;
            HtmlImage uISaveButton = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIAccountPane.UISaveImage;
            #endregion

            // Type 'updated user name' in 'Display Name' text box
            uIDisplayNameEdit.Text = @"New name',.-_";

            //Select United States
            uICountryorRegionComboBox.SetFocus();
            Keyboard.SendKeys("United States");

            // Type '989214' in 'Postal Code' text box
            uIPostalCodeEdit.Text = "989214";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void EditProfileWithInvalidZHSPostalCode()
        {
            #region Variable Declarations
            HtmlEdit uIDisplayNameEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIDisplayNameEdit;
            HtmlComboBox uICountryorRegionComboBox = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UICountryorRegionComboBox;
            HtmlEdit uIPostalCodeEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIPostalCodeEdit;
            HtmlImage uISaveButton = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIAccountPane.UISaveImage;
            #endregion

            // Type 'updated user name' in 'Display Name' text box
            uIDisplayNameEdit.Text = @"New name',.-_";

            //Select United States
            uICountryorRegionComboBox.SetFocus();
            Keyboard.SendKeys("China");

            // Type ')*^dfa' in 'Postal Code' text box
            uIPostalCodeEdit.Text = ")*^dfa";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }
        #endregion

        #region Assert Methods
        public void AssertRequiredMsg()
        {
            #region Variable Declarations
            HtmlSpan uITheDisplayNamefieldiPane = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UITheDisplayNamefieldiPane;
            #endregion

            // Verify validate message 'The Display Name field is required.' is displayed
            Assert.IsTrue(uITheDisplayNamefieldiPane.Exists, "The validate message \'The Vehicle Name field is required.\' isn't displayed");
        }

        public void AssertCharValidatedMsg()
        {
            #region Variable Declarations
            HtmlSpan uIOnlyalphanumericcharPane = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIOnlyalphanumericcharPane;
            #endregion

            // Verify the msg 'Only alpha-numeric characters and [.,_-'] are allowed.' is displayed
            Assert.IsTrue(uIOnlyalphanumericcharPane.Exists, "The validate message \'Only alpha-numeric characters and [.,_-'] are allowed.\' isn't displayed");
        }

        public void AssertInvalidUSPostalCodeMsg()
        {
            #region Variable Declarations
            HtmlSpan uIUnitedStatespostalcoPane = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIUnitedStatespostalcoPane;
            #endregion

            // Verify the msg'United States postal codes must be five digit numbers.' is displayed
            Assert.IsTrue(uIUnitedStatespostalcoPane.Exists, "The validate message \'United States postal codes must be five digit numbers.\' isn't displayed");
        }

        public void AssertInvalidZHSPostalCodeMsg()
        {
            #region Variable Declarations
            HtmlSpan uIPostalcodesmustbealpPane = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIPostalcodesmustbealpPane;
            #endregion

            // Verify the msg 'Postal codes must be alphanumeric and ten characters or less.' is displayed
            Assert.IsTrue(uIPostalcodesmustbealpPane.Exists,"The validate message \'Postal codes must be alphanumeric and ten characters or less.\' isn't displayed");
        }

        public void AssertMaxLengthProperty()
        {
            #region Variable Declarations
            HtmlEdit uIDisplayNameEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIDisplayNameEdit;
            HtmlEdit uIPostalCodeEdit = this.UIEdityourProfileWindoWindow.UIEdityourProfileDocument.UIPostalCodeEdit;
            #endregion

            //Verify the MaxLength property of display name InputBox is 15
            Assert.IsTrue(uIDisplayNameEdit.MaxLength == 15, "The MaxLength property of display name InputBox is " + uIDisplayNameEdit.MaxLength + ", It should equal 15");

            //Verify the MaxLength property of postal code InputBox is 10
            Assert.IsTrue(uIPostalCodeEdit.MaxLength == 10, "The MaxLength property of postal code InputBox is " + uIPostalCodeEdit.MaxLength + ", It should equal 10");
        }
        #endregion 

        #region Properties
        public virtual EditProfileParams EditProfileParams
        {
            get
            {
                if ((this.mEditProfileParams == null))
                {
                    this.mEditProfileParams = new EditProfileParams();
                }
                return this.mEditProfileParams;
            }
        }

        public UIEdityourProfileWindoWindow UIEdityourProfileWindoWindow
        {
            get
            {
                if ((this.mUIEdityourProfileWindoWindow == null))
                {
                    this.mUIEdityourProfileWindoWindow = new UIEdityourProfileWindoWindow();
                }
                return this.mUIEdityourProfileWindoWindow;
            }
        }
        #endregion

        #region Fields
        private EditProfileParams mEditProfileParams;

        private UIEdityourProfileWindoWindow mUIEdityourProfileWindoWindow;
        #endregion
    }

    //These UITestControls are generate with Coded UITest Builder, Copy them from DashboardPage.Designer.cs file.
    //then modify them if we need to 
    #region UITestControl Definition
    /// <summary>
    /// Parameters to be passed into 'EditProfile'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class EditProfileParams
    {

        #region Fields
        /// <summary>
        /// Type 'updateduser' in 'Display Name' text box
        /// </summary>
        public string UIDisplayNameEditText = "Updated User";

        /// <summary>
        /// Select 'United States' in 'Country or Region' combo box
        /// </summary>
        public string UICountryorRegionComboBoxSelectedItem = "United States";

        /// <summary>
        /// Type '98101' in 'Postal Code' text box
        /// </summary>
        public string UIPostalCodeEditText = "98101";
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIEdityourProfileWindoWindow : BrowserWindow
    {

        public UIEdityourProfileWindoWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Edit your Profile";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Edit your Profile");
            this.WindowTitles.Add("Dashboard");
            #endregion
        }

        #region Properties
        public UIEdityourProfileDocument UIEdityourProfileDocument
        {
            get
            {
                if ((this.mUIEdityourProfileDocument == null))
                {
                    this.mUIEdityourProfileDocument = new UIEdityourProfileDocument(this);
                }
                return this.mUIEdityourProfileDocument;
            }
        }

        public HtmlDocument UIDashboardDocument
        {
            get
            {
                if ((this.mUIDashboardDocument == null))
                {
                    this.mUIDashboardDocument = new HtmlDocument(this);
                    #region Search Criteria
                    this.mUIDashboardDocument.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
                    this.mUIDashboardDocument.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
                    this.mUIDashboardDocument.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
                    this.mUIDashboardDocument.FilterProperties[HtmlDocument.PropertyNames.Title] = "Dashboard";
                    this.mUIDashboardDocument.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/Dashboard";
                    this.mUIDashboardDocument.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "http://g1002-wctstsvr/MileageStats/Dashboard";
                    this.mUIDashboardDocument.WindowTitles.Add("Dashboard");
                    #endregion
                }
                return this.mUIDashboardDocument;
            }
        }
        #endregion

        #region Fields
        private UIEdityourProfileDocument mUIEdityourProfileDocument;

        private HtmlDocument mUIDashboardDocument;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIEdityourProfileDocument : HtmlDocument
    {

        public UIEdityourProfileDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Edit your Profile";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/Profile/Edit";
            this.WindowTitles.Add("Edit your Profile");
            #endregion
        }

        #region Properties
        public HtmlEdit UIDisplayNameEdit
        {
            get
            {
                if ((this.mUIDisplayNameEdit == null))
                {
                    this.mUIDisplayNameEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIDisplayNameEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "DisplayName";
                    this.mUIDisplayNameEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "DisplayName";
                    this.mUIDisplayNameEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Display Name";
                    this.mUIDisplayNameEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIDisplayNameEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "text-box single-line";
                    this.mUIDisplayNameEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"DisplayName\" class=\"text-box single-";
                    this.mUIDisplayNameEdit.WindowTitles.Add("Edit your Profile");
                    #endregion
                }
                return this.mUIDisplayNameEdit;
            }
        }

        public HtmlComboBox UICountryorRegionComboBox
        {
            get
            {
                if ((this.mUICountryorRegionComboBox == null))
                {
                    this.mUICountryorRegionComboBox = new HtmlComboBox(this);
                    #region Search Criteria
                    this.mUICountryorRegionComboBox.SearchProperties[HtmlComboBox.PropertyNames.Id] = "Country";
                    this.mUICountryorRegionComboBox.SearchProperties[HtmlComboBox.PropertyNames.Name] = "Country";
                    this.mUICountryorRegionComboBox.FilterProperties[HtmlComboBox.PropertyNames.Size] = "0";
                    this.mUICountryorRegionComboBox.FilterProperties[HtmlComboBox.PropertyNames.LabeledBy] = "Country or Region";
                    this.mUICountryorRegionComboBox.FilterProperties[HtmlComboBox.PropertyNames.Class] = "editor-textbox";
                    this.mUICountryorRegionComboBox.FilterProperties[HtmlComboBox.PropertyNames.ControlDefinition] = "id=\"Country\" class=\"editor-textbox\" name";
                    this.mUICountryorRegionComboBox.WindowTitles.Add("Edit your Profile");
                    #endregion
                }
                return this.mUICountryorRegionComboBox;
            }
        }

        public HtmlEdit UIPostalCodeEdit
        {
            get
            {
                if ((this.mUIPostalCodeEdit == null))
                {
                    this.mUIPostalCodeEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIPostalCodeEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "PostalCode";
                    this.mUIPostalCodeEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "PostalCode";
                    this.mUIPostalCodeEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Postal Code";
                    this.mUIPostalCodeEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIPostalCodeEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"PostalCode\" name=\"PostalCode\" maxLen";
                    this.mUIPostalCodeEdit.WindowTitles.Add("Edit your Profile");
                    #endregion
                }
                return this.mUIPostalCodeEdit;
            }
        }

        public UIAccountPane UIAccountPane
        {
            get
            {
                if ((this.mUIAccountPane == null))
                {
                    this.mUIAccountPane = new UIAccountPane(this);
                }
                return this.mUIAccountPane;
            }
        }

        public HtmlSpan UITheDisplayNamefieldiPane
        {
            get
            {
                if ((this.mUITheDisplayNamefieldiPane == null))
                {
                    this.mUITheDisplayNamefieldiPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUITheDisplayNamefieldiPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.userNameRequiredValidateMsg;
                    this.mUITheDisplayNamefieldiPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUITheDisplayNamefieldiPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUITheDisplayNamefieldiPane.WindowTitles.Add("Edit your Profile");
                    #endregion
                }
                return this.mUITheDisplayNamefieldiPane;
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
                    this.mUIOnlyalphanumericcharPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.charValidateMsg;
                    this.mUIOnlyalphanumericcharPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIOnlyalphanumericcharPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIOnlyalphanumericcharPane.WindowTitles.Add("Edit your Profile");
                    #endregion
                }
                return this.mUIOnlyalphanumericcharPane;
            }
        }

        public HtmlSpan UIUnitedStatespostalcoPane
        {
            get
            {
                if ((this.mUIUnitedStatespostalcoPane == null))
                {
                    this.mUIUnitedStatespostalcoPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIUnitedStatespostalcoPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.USpostalcodeValidateMsg;
                    this.mUIUnitedStatespostalcoPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIUnitedStatespostalcoPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIUnitedStatespostalcoPane.WindowTitles.Add("Edit your Profile");
                    #endregion
                }
                return this.mUIUnitedStatespostalcoPane;
            }
        }

        public HtmlSpan UIPostalcodesmustbealpPane
        {
            get
            {
                if ((this.mUIPostalcodesmustbealpPane == null))
                {
                    this.mUIPostalcodesmustbealpPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIPostalcodesmustbealpPane.FilterProperties[HtmlDiv.PropertyNames.DisplayText] = 
                    this.mUIPostalcodesmustbealpPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIPostalcodesmustbealpPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIPostalcodesmustbealpPane.WindowTitles.Add("Edit your Profile");
                    #endregion
                }
                return this.mUIPostalcodesmustbealpPane;
            }
        }
        #endregion

        #region Fields
        private HtmlEdit mUIDisplayNameEdit;

        private HtmlComboBox mUICountryorRegionComboBox;

        private HtmlEdit mUIPostalCodeEdit;

        private UIAccountPane mUIAccountPane;

        private HtmlSpan mUITheDisplayNamefieldiPane;

        private HtmlSpan mUIOnlyalphanumericcharPane;

        private HtmlSpan mUIUnitedStatespostalcoPane;

        private HtmlSpan mUIPostalcodesmustbealpPane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIAccountPane : HtmlDiv
    {

        public UIAccountPane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = "account";
            this.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "\r\nYour Profile\r\n\r\n \r\n\r\nDisplay Name \r\n\r\n";
            this.FilterProperties[HtmlDiv.PropertyNames.Class] = "framed article";
            this.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"account\" class=\"framed article\"";
            this.WindowTitles.Add("Edit your Profile");
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
                    this.mUISaveImage.WindowTitles.Add("Edit your Profile");
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
    #endregion
}
