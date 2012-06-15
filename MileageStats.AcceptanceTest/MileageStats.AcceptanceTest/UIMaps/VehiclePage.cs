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
namespace MileageStats.AcceptanceTest.UIMaps.VehiclePageClasses
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
    
    
    public partial class VehiclePage
    {
        #region Help Methods
        /// <summary>
        /// AddNewVehicle - Use 'AddNewVehicleParams' to pass parameters into this method.
        /// </summary>
        public void AddNewVehicle()
        {
            #region Variable Declarations
            HtmlEdit uIVehicleNameEdit = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIVehicleNameEdit;
            HtmlComboBox uIModelYearComboBox = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIModelYearComboBox;           
            HtmlComboBox uIMakeComboBox = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIMakeComboBox;            
            HtmlComboBox uIModelComboBox = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIModelComboBox;
            HtmlFileInput uIPhoto = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIPhoto;
            HtmlImage uISaveButton = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UISaveImage;
            #endregion

            //Waiting for Vehicle Name box appears and ready for inputing name
            uIVehicleNameEdit.WaitForControlExist();
            uIVehicleNameEdit.WaitForControlReady();

            // Type 'Test_Vehicle' in 'Vehicle Name' text box
            uIVehicleNameEdit.Text = this.AddNewVehicleParams.UIVehicleNameEditText;

            //Waiting for Year Combo box is ready
            uIModelYearComboBox.WaitForControlReady();

            //Set the keyboard focus to Year bomboBox, then pass value to it using keyboard
            uIModelYearComboBox.SetFocus();
            Keyboard.SendKeys(this.AddNewVehicleParams.UIModelYearComboBoxSelectedItem);

            //Waiting for Make Combo box is ready
            uIMakeComboBox.WaitForControlReady();

            uIMakeComboBox.SetFocus();
            Keyboard.SendKeys(this.AddNewVehicleParams.UIMakeComboBoxSelectedItem);

            //Waiting for Model Combo box is ready
            uIModelComboBox.WaitForControlReady();

            uIModelComboBox.SetFocus();
            Keyboard.SendKeys(this.AddNewVehicleParams.UIModelComboBoxSelectedItem);

            //Set FileName Property of uIPhoto
            uIPhoto.FileName = Utility.GetVehiclePhotoPath(Utility.photoName);

            // Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddVehicleWithNameOnly()
        {
            #region Variable Declarations
            HtmlEdit uIVehicleNameEdit = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIVehicleNameEdit;
            //HtmlFileInput uIPhoto = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIPhoto;
            HtmlImage uISaveButton = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UISaveImage;
            #endregion

            //Waiting for Vehicle Name box appears and ready for inputing name
            uIVehicleNameEdit.WaitForControlExist();
            uIVehicleNameEdit.WaitForControlReady();

            // Type 'Test_Vehicle001' in 'Vehicle Name' text box
            uIVehicleNameEdit.Text = "Test_Vehicle001";

            //Pass vehicle Photo path included in solution to uIPhoto FileName Property
            //uIPhoto.FileName = Utility.GetVehiclePhotoPath(Utility.photoName);

            // Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddVehicleWithoutName()
        {
            #region Variable Declarations
            HtmlEdit uIVehicleNameEdit = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIVehicleNameEdit;
            HtmlImage uISaveButton = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UISaveImage;
            #endregion

            //Waiting for Vehicle Name box appears and ready for inputing name
            uIVehicleNameEdit.WaitForControlExist();
            uIVehicleNameEdit.WaitForControlReady();

            // Type '' in 'Vehicle Name' text box
            uIVehicleNameEdit.Text = "";

            //Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddVehicleWithLongName()
        {
            #region Variable Declarations
            HtmlEdit uIVehicleNameEdit = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIVehicleNameEdit;
            HtmlImage uISaveButton = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UISaveImage;
            #endregion

            //Waiting for Vehicle Name box appears and ready for inputing name
            uIVehicleNameEdit.WaitForControlExist();
            uIVehicleNameEdit.WaitForControlReady();

            // Type stirng over 20 chars 'longvehilcedisplayname' in 'Vehicle Name' text box
            uIVehicleNameEdit.Text = "longvehilcedisplayname";

            //Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddVehicleWithJunkChars()
        {
            #region Variable Declarations
            HtmlEdit uIVehicleNameEdit = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIVehicleNameEdit;
            HtmlImage uISaveButton = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UISaveImage;
            #endregion

            //Waiting for Vehicle Name box appears and ready for inputing name
            uIVehicleNameEdit.WaitForControlExist();
            uIVehicleNameEdit.WaitForControlReady();

            // Type stirng '&*^()' in 'Vehicle Name' text box
            uIVehicleNameEdit.Text = "&*^()";

            //Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        public void AddVehicleWithBigPhoto()
        {
            #region Variable Declarations
            HtmlEdit uIVehicleNameEdit = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIVehicleNameEdit;
            HtmlImage uISaveButton = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UISaveImage;
            HtmlFileInput uIPhoto = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIPhoto;
            #endregion

            //Waiting for Vehicle Name box appears and ready for inputing name
            uIVehicleNameEdit.WaitForControlExist();
            uIVehicleNameEdit.WaitForControlReady();

            // Type stirng 'volvo' in 'Vehicle Name' text box
            uIVehicleNameEdit.Text = "volvo";

            //Pass vehicle Photo path included in solution to uIPhoto FileName Property
            uIPhoto.FileName = Utility.GetVehiclePhotoPath(Utility.bigPhotoName);

            //Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        /// <summary>
        /// EditVehicle - Use 'EditVehicleParams' to pass parameters into this method.
        /// </summary>
        public void EditVehicle()
        {
            #region Variable Declarations
            HtmlImage uIEditButton = this.UIDetailsforTest_VehicWindow.UIDetailsforTest_VehicDocument.UIDetailspanePane.UIEditImage;
            HtmlEdit uIVehicleNameEdit = this.UIDetailsforTest_VehicWindow.UIEditVehicleDocument.UIVehicleNameEdit;
            HtmlComboBox uIModelYearComboBox = this.UIDetailsforTest_VehicWindow.UIEditVehicleDocument.UIModelYearComboBox;            
            HtmlComboBox uIMakeComboBox = this.UIDetailsforTest_VehicWindow.UIEditVehicleDocument.UIMakeComboBox;            
            HtmlComboBox uIModelComboBox = this.UIDetailsforTest_VehicWindow.UIEditVehicleDocument.UIModelComboBox;
            HtmlImage uISaveButton = this.UIDetailsforTest_VehicWindow.UIEditVehicleDocument.UISaveImage;
            #endregion

            // Click 'Edit' button
            Mouse.Click(uIEditButton);

            // Type 'Edited_Vehicle' in 'Vehicle Name' text box
            uIVehicleNameEdit.Text = this.EditVehicleParams.UIVehicleNameEditText;

            //Waiting for Year Combo box is ready
            uIModelYearComboBox.WaitForControlReady();

            //Set keyboard focus on Year Combobox, then send '2011' to 'Model Year' combo box
            uIModelYearComboBox.SetFocus();
            Keyboard.SendKeys(this.EditVehicleParams.UIModelYearComboBoxSelectedItem);      

            //Waiting for Make Combo box is ready
            uIMakeComboBox.WaitForControlReady();

            //Set keyboard focus on Make Combobox, then send 'Jeep' to 'Make' combo box
            uIMakeComboBox.SetFocus();
            Keyboard.SendKeys(this.EditVehicleParams.UIMakeComboBoxSelectedItem);

            //Waiting for Model Combo box is ready
            uIModelComboBox.WaitForControlReady();

            //Set keyboard focus on Model Combobox, then send 'Wrangler' to 'Model' combo box
            uIModelComboBox.SetFocus();
            Keyboard.SendKeys(this.EditVehicleParams.UIModelComboBoxSelectedItem);

            // Click 'Save' Button
            Mouse.Click(uISaveButton);
        }

        /// <summary>
        /// Delete the vehicle Test_Vehicle
        /// </summary>
        public void DeleteTestVehicle()
        {
            #region Variable Declarations
            HtmlImage uIDeleteButton = this.UIDetailsforTest_VehicWindow.UIDetailsforTest_VehicDocument.UIDetailspanePane.UIDeleteImage;
            BrowserWindow uIDetailsforTest_VehicWindow = this.UIDetailsforTest_VehicWindow;
            #endregion

            //Click Delete Button
            Mouse.Click(uIDeleteButton);

            // Click 'Ok' button in the browser dialog window
            uIDetailsforTest_VehicWindow.PerformDialogAction(BrowserDialogAction.Ok);
        }

        public void DeleteTestVehicle001()
        {
            #region Variable Declarations
            HtmlImage uIDeleteButton = this.UIDetailsforTest_VehicWindow.UIDetailsforTest_VehicDocument.UIDetailspanePane.UIDeleteImage;
            BrowserWindow uIDetailsforTest_VehicWindow = this.UIDetailsforTest_VehicWindow;
            #endregion

            //Click Delete Button
            Mouse.Click(uIDeleteButton);

            // Click 'Ok' button in the browser dialog window
            uIDetailsforTest_VehicWindow.PerformDialogAction(BrowserDialogAction.Ok);
        }

        /// <summary>
        /// Delete the vehicle Edited_Vehicle
        /// </summary>
        public void DeleteEditedVehicle()
        {
            #region Variable Declarations
            HtmlImage uIDeleteButton = this.UIDetailsforTest_VehicWindow.UIDetailsforTest_VehicDocument.UIDetailspanePane.UIDeleteImage;
            BrowserWindow uIDetailsforTest_VehicWindow = this.UIDetailsforTest_VehicWindow;
            #endregion

            //Click Delete button
            Mouse.Click(uIDeleteButton);

            // Click 'Ok' button in the browser dialog window
            uIDetailsforTest_VehicWindow.PerformDialogAction(BrowserDialogAction.Ok);
        }
        #endregion

        #region Assert Methods
        /// <summary>
        /// AssertVehicleIsUpdated - Use 'AssertVehicleIsUpdatedExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertVehicleIsUpdated()
        {
            #region Variable Declarations
            HtmlDiv uIEdited_VehiclePane = this.UIDetailsforTest_VehicWindow.UIDetailsforEdited_VehDocument.UIDetailspanePane.UIEdited_VehiclePane;
            HtmlDiv uIItem2011Pane = this.UIDetailsforTest_VehicWindow.UIDetailsforEdited_VehDocument.UIDetailspanePane.UIItem2011Pane;
            HtmlDiv uIJeepPane = this.UIDetailsforTest_VehicWindow.UIDetailsforEdited_VehDocument.UIDetailspanePane.UIJeepPane;
            HtmlDiv uIWranglerPane = this.UIDetailsforTest_VehicWindow.UIDetailsforEdited_VehDocument.UIDetailspanePane.UIWranglerPane;
            #endregion

            // Verify that 'Edited_Vehicle' pane's property 'InnerText' equals 'Edited_Vehicle '
            Assert.AreEqual(this.AssertVehicleIsUpdatedExpectedValues.UIEdited_VehiclePaneInnerText, uIEdited_VehiclePane.InnerText);

            // Verify that '2011' pane's property 'InnerText' equals '2011 '
            Assert.AreEqual(this.AssertVehicleIsUpdatedExpectedValues.UIItem2011PaneInnerText, uIItem2011Pane.InnerText);

            // Verify that 'Jeep' pane's property 'InnerText' equals 'Jeep '
            Assert.AreEqual(this.AssertVehicleIsUpdatedExpectedValues.UIJeepPaneInnerText, uIJeepPane.InnerText);

            // Verify that 'Liberty' pane's property 'InnerText' equals 'Liberty '
            Assert.AreEqual(this.AssertVehicleIsUpdatedExpectedValues.UIWranglerPaneInnerText, uIWranglerPane.InnerText);
        }

        public void AssertRequiredMsg()
        {
            #region Variable Declarations
            HtmlSpan uITheVehicleNamefieldiPane = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UITheVehicleNamefieldiPane;
            #endregion

            //Verify the validate message 'The Vehicle Name field is required.' is displayd
            Assert.IsTrue(uITheVehicleNamefieldiPane.Exists, "The validate message \'The Vehicle Name field is required.\' isn't displayed");
        }

        public void AssertCharValidateMsg()
        {
            #region Variable Declarations
            HtmlSpan uIOnlyalphanumericcharPane = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIOnlyalphanumericcharPane;
            #endregion

            // Verify that the validate message 'Only alpha-numeric characters and [.,_-'] are allowed.'is displayed
            Assert.IsTrue(uIOnlyalphanumericcharPane.Exists, "The validate message \'Only alpha-numeric characters and [.,_-'] are allowed.\' isn't displayed");
        }

        public void AssertPhotoValidateMsg()
        {
            #region Variable Declarations
            HtmlSpan uIThephotouploadedmustPane = this.UIDashboardWindowsInteWindow.UIAddVehicleDocument.UIThephotouploadedmustPane;
            #endregion

            // Verify validate msg 'The photo uploaded must be less than 1 MB.' is displayed
            Assert.IsTrue(uIThephotouploadedmustPane.Exists, "The validate message \'The photo uploaded must be less than 1 MB.\' isn't displayed");
        }

        public void AssertMaxLengthProperty()
        {
            #region Variable Declarations
            HtmlEdit uIVehicleNameEdit = this.UIDetailsforTest_VehicWindow.UIEditVehicleDocument.UIVehicleNameEdit;
            #endregion

            //Verify the MaxLength Peroperty of vehicle name box is equal 20
            Assert.IsTrue(uIVehicleNameEdit.MaxLength == 20, "The MaxLength property of vehicle name InputBox is " + uIVehicleNameEdit.MaxLength + ", it should equal 20");
        }
        #endregion

        #region Properties
        public virtual EditVehicleParams EditVehicleParams
        {
            get
            {
                if ((this.mEditVehicleParams == null))
                {
                    this.mEditVehicleParams = new EditVehicleParams();
                }
                return this.mEditVehicleParams;
            }
        }

        public virtual AssertVehicleIsUpdatedExpectedValues AssertVehicleIsUpdatedExpectedValues
        {
            get
            {
                if ((this.mAssertVehicleIsUpdatedExpectedValues == null))
                {
                    this.mAssertVehicleIsUpdatedExpectedValues = new AssertVehicleIsUpdatedExpectedValues();
                }
                return this.mAssertVehicleIsUpdatedExpectedValues;
            }
        }

        public UIDetailsforTest_VehicWindow UIDetailsforTest_VehicWindow
        {
            get
            {
                if ((this.mUIDetailsforTest_VehicWindow == null))
                {
                    this.mUIDetailsforTest_VehicWindow = new UIDetailsforTest_VehicWindow();
                }
                return this.mUIDetailsforTest_VehicWindow;
            }
        }

        public virtual AddNewVehicleParams AddNewVehicleParams
        {
            get
            {
                if ((this.mAddNewVehicleParams == null))
                {
                    this.mAddNewVehicleParams = new AddNewVehicleParams();
                }
                return this.mAddNewVehicleParams;
            }
        }

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
        private AddNewVehicleParams mAddNewVehicleParams;

        private UIDashboardWindowsInteWindow mUIDashboardWindowsInteWindow;

        private EditVehicleParams mEditVehicleParams;

        private AssertVehicleIsUpdatedExpectedValues mAssertVehicleIsUpdatedExpectedValues;

        private UIDetailsforTest_VehicWindow mUIDetailsforTest_VehicWindow;
        #endregion
    }


    //These UITestControls are generate with Coded UITest Builder, Copy them from DashboardPage.Designer.cs file.
    //then modify them if we need to 
    #region UITestControl Definition
    /// <summary>
    /// Parameters to be passed into 'AddNewVehicle'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class AddNewVehicleParams
    {
        #region Properties
        //public string UIVehicleNameEditText
        #endregion

        #region Fields
        /// <summary>
        /// Type 'Test_Vehicle' in 'Vehicle Name' text box
        /// </summary>
        public string UIVehicleNameEditText = "Test_Vehicle";

        /// <summary>
        /// Select '2010' in 'Model Year' combo box
        /// </summary>
        public string UIModelYearComboBoxSelectedItem = "2010";

        /// <summary>
        /// Select 'Honda' in 'Make' combo box
        /// </summary>
        public string UIMakeComboBoxSelectedItem = "Honda";

        /// <summary>
        /// Select 'Accord' in 'Model' combo box
        /// </summary>
        public string UIModelComboBoxSelectedItem = "Accord";
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDashboardWindowsInteWindow : BrowserWindow
    {

        public UIDashboardWindowsInteWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Dashboard";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Add Vehicle");
            #endregion
        }

        #region Properties
        public UIAddVehicleDocument UIAddVehicleDocument
        {
            get
            {
                if ((this.mUIAddVehicleDocument == null))
                {
                    this.mUIAddVehicleDocument = new UIAddVehicleDocument(this);
                }
                return this.mUIAddVehicleDocument;
            }
        }
        #endregion

        #region Fields
        private UIAddVehicleDocument mUIAddVehicleDocument;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIAddVehicleDocument : HtmlDocument
    {

        public UIAddVehicleDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Add Vehicle";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/Vehicle/Create";
            this.WindowTitles.Add("Add Vehicle");
            #endregion
        }

        #region Properties
        public HtmlEdit UIVehicleNameEdit
        {
            get
            {
                if ((this.mUIVehicleNameEdit == null))
                {
                    this.mUIVehicleNameEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIVehicleNameEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "Name";
                    this.mUIVehicleNameEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Name";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Vehicle Name";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "editor-textbox";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"Name\" class=\"editor-textbox\" name=\"N";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "1";
                    this.mUIVehicleNameEdit.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUIVehicleNameEdit;
            }
        }

        public HtmlComboBox UIModelYearComboBox
        {
            get
            {
                if ((this.mUIModelYearComboBox == null))
                {
                    this.mUIModelYearComboBox = new HtmlComboBox(this);
                    #region Search Criteria
                    this.mUIModelYearComboBox.SearchProperties[HtmlComboBox.PropertyNames.Id] = "Year";
                    this.mUIModelYearComboBox.SearchProperties[HtmlComboBox.PropertyNames.Name] = "Year";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.Size] = "0";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.LabeledBy] = "Model Year";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.Title] = null;
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.ItemCount] = "5";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.Class] = "editor-textbox";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.ControlDefinition] = "id=\"Year\" class=\"editor-textbox\" name=\"Y";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
                    this.mUIModelYearComboBox.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUIModelYearComboBox;
            }
        }

        public HtmlComboBox UIMakeComboBox
        {
            get
            {
                if ((this.mUIMakeComboBox == null))
                {
                    this.mUIMakeComboBox = new HtmlComboBox(this);
                    #region Search Criteria
                    this.mUIMakeComboBox.SearchProperties[HtmlComboBox.PropertyNames.Id] = "MakeName";
                    this.mUIMakeComboBox.SearchProperties[HtmlComboBox.PropertyNames.Name] = "MakeName";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.Size] = "0";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.LabeledBy] = "Make";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.Title] = null;
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.ItemCount] = "5";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.Class] = "editor-textbox";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.ControlDefinition] = "id=\"MakeName\" class=\"editor-textbox\" nam";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "2";
                    this.mUIMakeComboBox.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUIMakeComboBox;
            }
        }


        public HtmlComboBox UIModelComboBox
        {
            get
            {
                if ((this.mUIModelComboBox == null))
                {
                    this.mUIModelComboBox = new HtmlComboBox(this);
                    #region Search Criteria
                    this.mUIModelComboBox.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ModelName";
                    this.mUIModelComboBox.SearchProperties[HtmlComboBox.PropertyNames.Name] = "ModelName";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.Size] = "0";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.LabeledBy] = "Model";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.Title] = null;
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.ItemCount] = "3";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.Class] = "editor-textbox";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.ControlDefinition] = "id=\"ModelName\" class=\"editor-textbox\" na";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "3";
                    this.mUIModelComboBox.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUIModelComboBox;
            }
        }

        public HtmlImage UISaveImage
        {
            get
            {
                if ((this.mUISaveImage == null))
                {
                    this.mUISaveImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUISaveImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.saveImageAlt;
                    this.mUISaveImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUISaveImage.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUISaveImage;
            }
        }

        public HtmlFileInput UIPhoto
        {
            get
            {
                if ((this.mUIFileInput == null))
                {
                    this.mUIFileInput = new HtmlFileInput(this);
                    #region Search Criteria
                    this.mUIFileInput.SearchProperties[HtmlFileInput.PropertyNames.Id] = null;
                    this.mUIFileInput.SearchProperties[HtmlFileInput.PropertyNames.Name] = "photoFile";
                    this.mUIFileInput.FilterProperties[HtmlFileInput.PropertyNames.Class] = "editor-textbox";
                    this.mUIFileInput.FilterProperties[HtmlFileInput.PropertyNames.ControlDefinition] = "class=\"editor-textbox\" name=\"photoFile\" ";
                    this.mUIFileInput.WindowTitles.Add("Add Vehicle"); 
                    #endregion
                }
                return this.mUIFileInput;
            }
        }

        public HtmlSpan UITheVehicleNamefieldiPane
        {
            get
            {
                if ((this.mUITheVehicleNamefieldiPane == null))
                {
                    this.mUITheVehicleNamefieldiPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUITheVehicleNamefieldiPane.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.vehicleRequiredValidateMsg;
                    this.mUITheVehicleNamefieldiPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUITheVehicleNamefieldiPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUITheVehicleNamefieldiPane.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUITheVehicleNamefieldiPane;
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
                    this.mUIOnlyalphanumericcharPane.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUIOnlyalphanumericcharPane;
            }
        }

        public HtmlSpan UIThephotouploadedmustPane
        {
            get
            {
                if ((this.mUIThephotouploadedmustPane == null))
                {
                    this.mUIThephotouploadedmustPane = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIThephotouploadedmustPane.FilterProperties[HtmlDiv.PropertyNames.DisplayText] = Utility.vehiclePhotoSizeValidateMsg;
                    this.mUIThephotouploadedmustPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIThephotouploadedmustPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIThephotouploadedmustPane.WindowTitles.Add("Add Vehicle");
                    #endregion
                }
                return this.mUIThephotouploadedmustPane;
            }
        }
        #endregion

        #region Fields
        private HtmlEdit mUIVehicleNameEdit;

        private HtmlComboBox mUIModelYearComboBox;

        private HtmlComboBox mUIMakeComboBox;

        private HtmlComboBox mUIModelComboBox;

        private HtmlImage mUISaveImage;

        private HtmlFileInput mUIFileInput;

        private HtmlSpan mUITheVehicleNamefieldiPane;

        private HtmlSpan mUIOnlyalphanumericcharPane;

        private HtmlSpan mUIThephotouploadedmustPane;
        #endregion
    }

    /// <summary>
    /// Parameters to be passed into 'EditVehicle'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class EditVehicleParams
    {

        #region Fields
        /// <summary>
        /// Type 'Edited_Vehicle' in 'Vehicle Name' text box
        /// </summary>
        public string UIVehicleNameEditText = "Edited_Vehicle";

        /// <summary>
        /// Select '2011' in 'Model Year' combo box
        /// </summary>
        public string UIModelYearComboBoxSelectedItem = "2011";

        /// <summary>
        /// Select 'Jeep' in 'Make' combo box
        /// </summary>
        public string UIMakeComboBoxSelectedItem = "Jeep";

        /// <summary>
        /// Select 'Liberty' in 'Model' combo box
        /// </summary>
        public string UIModelComboBoxSelectedItem = "Liberty";
        #endregion
    }

    /// <summary>
    /// Parameters to be passed into 'AssertVehicleIsUpdated'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class AssertVehicleIsUpdatedExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that 'Edited_Vehicle' pane's property 'InnerText' equals 'Edited_Vehicle '
        /// </summary>
        public string UIEdited_VehiclePaneInnerText = "Edited_Vehicle ";

        /// <summary>
        /// Verify that '2011' pane's property 'InnerText' equals '2011 '
        /// </summary>
        public string UIItem2011PaneInnerText = "2011 ";

        /// <summary>
        /// Verify that 'Jeep' pane's property 'InnerText' equals 'Jeep '
        /// </summary>
        public string UIJeepPaneInnerText = "Jeep ";

        /// <summary>
        /// Verify that 'Liberty' pane's property 'InnerText' equals 'Liberty '
        /// </summary>
        public string UIWranglerPaneInnerText = "Liberty ";


        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDetailsforTest_VehicWindow : BrowserWindow
    {

        public UIDetailsforTest_VehicWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Dashboard - Windows Internet Explorer";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Dashboard");
            this.WindowTitles.Add("Edit Vehicle");
            #endregion
        }

        #region Properties
        public UIDetailsforTest_VehicDocument UIDetailsforTest_VehicDocument
        {
            get
            {
                if ((this.mUIDetailsforTest_VehicDocument == null))
                {
                    this.mUIDetailsforTest_VehicDocument = new UIDetailsforTest_VehicDocument(this);
                }
                return this.mUIDetailsforTest_VehicDocument;
            }
        }

        public UIEditVehicleDocument UIEditVehicleDocument
        {
            get
            {
                if ((this.mUIEditVehicleDocument == null))
                {
                    this.mUIEditVehicleDocument = new UIEditVehicleDocument(this);
                }
                return this.mUIEditVehicleDocument;
            }
        }

        public UIDetailsforEdited_VehDocument UIDetailsforEdited_VehDocument
        {
            get
            {
                if ((this.mUIDetailsforEdited_VehDocument == null))
                {
                    this.mUIDetailsforEdited_VehDocument = new UIDetailsforEdited_VehDocument(this);
                }
                return this.mUIDetailsforEdited_VehDocument;
            }
        }
        #endregion

        #region Fields
        private UIDetailsforTest_VehicDocument mUIDetailsforTest_VehicDocument;

        private UIEditVehicleDocument mUIEditVehicleDocument;

        private UIDetailsforEdited_VehDocument mUIDetailsforEdited_VehDocument;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDetailsforTest_VehicDocument : HtmlDocument
    {

        public UIDetailsforTest_VehicDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Details";
            this.WindowTitles.Add("Details");
            #endregion
        }

        #region Properties
        public UIDetailspanePane UIDetailspanePane
        {
            get
            {
                if ((this.mUIDetailspanePane == null))
                {
                    this.mUIDetailspanePane = new UIDetailspanePane(this);
                }
                return this.mUIDetailspanePane;
            }
        }
        #endregion

        #region Fields
        private UIDetailspanePane mUIDetailspanePane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDetailspanePane : HtmlDiv
    {

        public UIDetailspanePane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "details-pane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "DIV";
            this.WindowTitles.Add("Details"); 
            #endregion
        }

        #region Properties
        public HtmlImage UIEditImage
        {
            get
            {
                if ((this.mUIEditImage == null))
                {
                    this.mUIEditImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIEditImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.editImageAlt;
                    this.mUIEditImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIEditImage.WindowTitles.Add("Details for Test_Vehicle");
                    #endregion
                }
                return this.mUIEditImage;
            }
        }

        public HtmlImage UIDeleteImage
        {
            get
            {
                if ((this.mUIDeleteImage == null))
                {
                    this.mUIDeleteImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIDeleteImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.deleteImageAlt;
                    this.mUIDeleteImage.FilterProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIDeleteImage.WindowTitles.Add("Details");
                    #endregion
                }
                return this.mUIDeleteImage;
            }
        }
        #endregion

        #region Fields
        private HtmlImage mUIEditImage;
        private HtmlImage mUIDeleteImage;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIEditVehicleDocument : HtmlDocument
    {

        public UIEditVehicleDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Edit Vehicle";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/Vehicle/Edit/4";
            this.WindowTitles.Add("Edit Vehicle");
            #endregion
        }

        #region Properties
        public HtmlEdit UIVehicleNameEdit
        {
            get
            {
                if ((this.mUIVehicleNameEdit == null))
                {
                    this.mUIVehicleNameEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIVehicleNameEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "Name";
                    this.mUIVehicleNameEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Name";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Vehicle Name";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "editor-textbox";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"Name\" class=\"editor-textbox\" name=\"N";
                    this.mUIVehicleNameEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";
                    this.mUIVehicleNameEdit.WindowTitles.Add("Edit Vehicle");
                    #endregion
                }
                return this.mUIVehicleNameEdit;
            }
        }

        public HtmlComboBox UIModelYearComboBox
        {
            get
            {
                if ((this.mUIModelYearComboBox == null))
                {
                    this.mUIModelYearComboBox = new HtmlComboBox(this);
                    #region Search Criteria
                    this.mUIModelYearComboBox.SearchProperties[HtmlComboBox.PropertyNames.Id] = "Year";
                    this.mUIModelYearComboBox.SearchProperties[HtmlComboBox.PropertyNames.Name] = "Year";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.Size] = "0";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.LabeledBy] = "Model Year";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.Title] = null;
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.ItemCount] = "5";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.Class] = "editor-textbox";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.ControlDefinition] = "id=\"Year\" class=\"editor-textbox\" name=\"Y";
                    this.mUIModelYearComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "1";
                    this.mUIModelYearComboBox.WindowTitles.Add("Edit Vehicle");
                    #endregion
                }
                return this.mUIModelYearComboBox;
            }
        }

        public HtmlComboBox UIMakeComboBox
        {
            get
            {
                if ((this.mUIMakeComboBox == null))
                {
                    this.mUIMakeComboBox = new HtmlComboBox(this);
                    #region Search Criteria
                    this.mUIMakeComboBox.SearchProperties[HtmlComboBox.PropertyNames.Id] = "MakeName";
                    this.mUIMakeComboBox.SearchProperties[HtmlComboBox.PropertyNames.Name] = "MakeName";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.Size] = "0";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.LabeledBy] = "Make";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.Title] = null;
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.ItemCount] = "5";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.Class] = "editor-textbox";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.ControlDefinition] = "id=\"MakeName\" class=\"editor-textbox\" nam";
                    this.mUIMakeComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "2";
                    this.mUIMakeComboBox.WindowTitles.Add("Edit Vehicle");
                    #endregion
                }
                return this.mUIMakeComboBox;
            }
        }

        public HtmlComboBox UIModelComboBox
        {
            get
            {
                if ((this.mUIModelComboBox == null))
                {
                    this.mUIModelComboBox = new HtmlComboBox(this);
                    #region Search Criteria
                    this.mUIModelComboBox.SearchProperties[HtmlComboBox.PropertyNames.Id] = "ModelName";
                    this.mUIModelComboBox.SearchProperties[HtmlComboBox.PropertyNames.Name] = "ModelName";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.Size] = "0";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.LabeledBy] = "Model";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.Title] = null;
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.ItemCount] = "4";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.Class] = "editor-textbox";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.ControlDefinition] = "id=\"ModelName\" class=\"editor-textbox\" na";
                    this.mUIModelComboBox.FilterProperties[HtmlComboBox.PropertyNames.TagInstance] = "3";
                    this.mUIModelComboBox.WindowTitles.Add("Edit Vehicle");
                    #endregion
                }
                return this.mUIModelComboBox;
            }
        }

        public HtmlImage UISaveImage
        {
            get
            {
                if ((this.mUISaveImage == null))
                {
                    this.mUISaveImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUISaveImage.SearchProperties[HtmlImage.PropertyNames.Alt] = "Save";
                    this.mUISaveImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUISaveImage.WindowTitles.Add("Edit Vehicle");
                    #endregion
                }
                return this.mUISaveImage;
            }
        }
        #endregion

        #region Fields
        private HtmlEdit mUIVehicleNameEdit;

        private HtmlComboBox mUIModelYearComboBox;

        private HtmlComboBox mUIMakeComboBox;

        private HtmlComboBox mUIModelComboBox;

        private HtmlImage mUISaveImage;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDetailsforEdited_VehDocument : HtmlDocument
    {

        public UIDetailsforEdited_VehDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Details for Edited_Vehicle";
            this.WindowTitles.Add("Details for Edited_Vehicle");
            #endregion
        }

        #region Properties
        public UIDetailspanePane1 UIDetailspanePane
        {
            get
            {
                if ((this.mUIDetailspanePane == null))
                {
                    this.mUIDetailspanePane = new UIDetailspanePane1(this);
                }
                return this.mUIDetailspanePane;
            }
        }
        #endregion

        #region Fields
        private UIDetailspanePane1 mUIDetailspanePane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIDetailspanePane1 : HtmlDiv
    {

        public UIDetailspanePane1(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "details-pane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "DIV";
            this.WindowTitles.Add("Details for Edited_Vehicle");
            #endregion
        }

        #region Properties
        public HtmlDiv UIEdited_VehiclePane
        {
            get
            {
                if ((this.mUIEdited_VehiclePane == null))
                {
                    this.mUIEdited_VehiclePane = new HtmlDiv(this);
                    #region Search Criteria
                    this.mUIEdited_VehiclePane.SearchProperties[HtmlDiv.PropertyNames.Id] = null;
                    this.mUIEdited_VehiclePane.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
                    this.mUIEdited_VehiclePane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Edited_Vehicle ";
                    this.mUIEdited_VehiclePane.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
                    this.mUIEdited_VehiclePane.FilterProperties[HtmlDiv.PropertyNames.Class] = "display-field name wrap";
                    this.mUIEdited_VehiclePane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"display-field name wrap\"";
                    this.mUIEdited_VehiclePane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "11";
                    this.mUIEdited_VehiclePane.WindowTitles.Add("Details for Edited_Vehicle");
                    #endregion
                }
                return this.mUIEdited_VehiclePane;
            }
        }

        public HtmlDiv UIItem2011Pane
        {
            get
            {
                if ((this.mUIItem2011Pane == null))
                {
                    this.mUIItem2011Pane = new HtmlDiv(this);
                    #region Search Criteria
                    this.mUIItem2011Pane.SearchProperties[HtmlDiv.PropertyNames.Id] = null;
                    this.mUIItem2011Pane.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
                    this.mUIItem2011Pane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "2011 ";
                    this.mUIItem2011Pane.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
                    this.mUIItem2011Pane.FilterProperties[HtmlDiv.PropertyNames.Class] = "display-field year";
                    this.mUIItem2011Pane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"display-field year\"";
                    this.mUIItem2011Pane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "13";
                    this.mUIItem2011Pane.WindowTitles.Add("Details for Edited_Vehicle");
                    #endregion
                }
                return this.mUIItem2011Pane;
            }
        }

        public HtmlDiv UIJeepPane
        {
            get
            {
                if ((this.mUIJeepPane == null))
                {
                    this.mUIJeepPane = new HtmlDiv(this);
                    #region Search Criteria
                    this.mUIJeepPane.SearchProperties[HtmlDiv.PropertyNames.Id] = null;
                    this.mUIJeepPane.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
                    this.mUIJeepPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Jeep ";
                    this.mUIJeepPane.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
                    this.mUIJeepPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "display-field makeName";
                    this.mUIJeepPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"display-field makeName\"";
                    this.mUIJeepPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "15";
                    this.mUIJeepPane.WindowTitles.Add("Details for Edited_Vehicle");
                    #endregion
                }
                return this.mUIJeepPane;
            }
        }

        public HtmlDiv UIWranglerPane
        {
            get
            {
                if ((this.mUIWranglerPane == null))
                {
                    this.mUIWranglerPane = new HtmlDiv(this);
                    #region Search Criteria
                    this.mUIWranglerPane.SearchProperties[HtmlDiv.PropertyNames.Id] = null;
                    this.mUIWranglerPane.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
                    this.mUIWranglerPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Wrangler ";
                    this.mUIWranglerPane.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
                    this.mUIWranglerPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "display-field modelName";
                    this.mUIWranglerPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"display-field modelName\"";
                    this.mUIWranglerPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "17";
                    this.mUIWranglerPane.WindowTitles.Add("Details for Edited_Vehicle");
                    #endregion
                }
                return this.mUIWranglerPane;
            }
        }
        #endregion

        #region Fields
        private HtmlDiv mUIEdited_VehiclePane;

        private HtmlDiv mUIItem2011Pane;

        private HtmlDiv mUIJeepPane;

        private HtmlDiv mUIWranglerPane;
        #endregion
    }
    #endregion
}
