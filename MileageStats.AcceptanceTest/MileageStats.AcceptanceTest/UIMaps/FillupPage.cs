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
namespace MileageStats.AcceptanceTest.UIMaps.FillupPageClasses
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
    
    
    public partial class FillupPage
    {
        #region Help Methods
        public void ClickAddButton()
        {
            #region Variable Declarations
            HtmlImage uIAddFillupButton = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIAddFillupImage;
            #endregion

            Mouse.Click(uIAddFillupButton);
        }

        /// <summary>
        /// AddFillup - Use 'AddFillupParams' to pass parameters into this method.
        /// </summary>
        public void AddFillupWithAllFields()
        {
            #region Variable Declarations
            HtmlImage uIAddFillupButton = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIAddFillupImage;
            HtmlEdit uIDateEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIDateEdit;
            HtmlEdit uIOdometerEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOdometerEdit;
            HtmlEdit uIPricePerGallonEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIPricePerGallonEdit;
            HtmlEdit uITotalGallonsEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITotalGallonsEdit;
            HtmlEdit uIFillupStationEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIFillupStationEdit;
            HtmlEdit uITransactionFeeEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITransactionFeeEdit;
            HtmlEdit uIRemarksEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIRemarksEdit;
            HtmlImage uISaveButton = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UISaveImage;
            #endregion

            // Click 'Add' button
            Mouse.Click(uIAddFillupButton);

            // Type '3/10/2011' in 'Date' text box
            uIDateEdit.Text = this.AddFillupWithAllFieldsParams.UIDateEditText;

            // Type '100' in 'Odometer' text box
            uIOdometerEdit.Text = this.AddFillupWithAllFieldsParams.UIOdometerEditText;

            // Type '2' in 'Price Per Gallon' text box
            uIPricePerGallonEdit.Text = this.AddFillupWithAllFieldsParams.UIPricePerGallonEditText;

            // Type '10' in 'Total Gallons' text box
            uITotalGallonsEdit.Text = this.AddFillupWithAllFieldsParams.UITotalGallonsEditText;

            // Type 'Marqie's Travel' in 'Fill-up Station' text box
            uIFillupStationEdit.Text = this.AddFillupWithAllFieldsParams.UIFillupStationEditText;

            // Type '10' in 'Transaction Fee' text box
            uITransactionFeeEdit.Text = this.AddFillupWithAllFieldsParams.UITransactionFeeEditText;

            // Type 'First fill up' in 'Remarks' text box
            uIRemarksEdit.Text = this.AddFillupWithAllFieldsParams.UIRemarksEditText;

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void AddFillupWithNullValues()
        {
            #region Variable Declarations
            HtmlImage uIAddFillupButton = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIAddFillupImage;
            HtmlEdit uIDateEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIDateEdit;
            HtmlEdit uIOdometerEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOdometerEdit;
            HtmlEdit uIPricePerGallonEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIPricePerGallonEdit;
            HtmlEdit uITotalGallonsEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITotalGallonsEdit;
            HtmlEdit uIFillupStationEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIFillupStationEdit;
            HtmlEdit uITransactionFeeEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITransactionFeeEdit;
            HtmlEdit uIRemarksEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIRemarksEdit;
            HtmlImage uISaveButton = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UISaveImage;
            #endregion

            // Click 'Add' button
            Mouse.Click(uIAddFillupButton);

            // Type '' in 'Date' text box
            uIDateEdit.Text = "";

            // Type '' in 'Odometer' text box
            uIOdometerEdit.Text = "";

            // Type '' in 'Price Per Gallon' text box
            uIPricePerGallonEdit.Text = "";

            // Type '' in 'Total Gallons' text box
            uITotalGallonsEdit.Text = "";

            // Type '' in 'Fill-up Station' text box
            uIFillupStationEdit.Text = "";

            // Type '' in 'Transaction Fee' text box
            uITransactionFeeEdit.Text = "";

            // Type '' in 'Remarks' text box
            uIRemarksEdit.Text = "";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void AddFillupWithInvalidValues()
        {
            #region Variable Declarations
            //HtmlImage uIAddFillupButton = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIAddFillupImage;
            HtmlEdit uIDateEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIDateEdit;
            HtmlEdit uIOdometerEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOdometerEdit;
            HtmlEdit uIPricePerGallonEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIPricePerGallonEdit;
            HtmlEdit uITotalGallonsEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITotalGallonsEdit;
            HtmlEdit uIFillupStationEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIFillupStationEdit;
            HtmlEdit uITransactionFeeEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITransactionFeeEdit;
            HtmlEdit uIRemarksEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIRemarksEdit;
            HtmlImage uISaveButton = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UISaveImage;
            #endregion

            // Click 'Add' button
            //Mouse.Click(uIAddFillupImage);

            // Type '*()' in 'Date' text box
            uIDateEdit.Text = "*()";

            // Type '*()' in 'Odometer' text box
            uIOdometerEdit.Text = "*()";

            // Type '*()' in 'Price Per Gallon' text box
            uIPricePerGallonEdit.Text = "*()";

            // Type '*()' in 'Total Gallons' text box
            uITotalGallonsEdit.Text = "*()";

            // Type '*()' in 'Fill-up Station' text box
            uIFillupStationEdit.Text = "*()";

            // Type '*()' in 'Transaction Fee' text box
            uITransactionFeeEdit.Text = "*()";

            // Type '*()' in 'Remarks' text box
            uIRemarksEdit.Text = "*()";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        public void AddFillupWithOutofRangeValues()
        {
            #region Variable Declarations
            //HtmlImage uIAddFillupButton = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIAddFillupImage;
            HtmlEdit uIDateEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIDateEdit;
            HtmlEdit uIOdometerEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOdometerEdit;
            HtmlEdit uIPricePerGallonEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIPricePerGallonEdit;
            HtmlEdit uITotalGallonsEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITotalGallonsEdit;
            HtmlEdit uIFillupStationEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIFillupStationEdit;
            HtmlEdit uITransactionFeeEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITransactionFeeEdit;
            HtmlEdit uIRemarksEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIRemarksEdit;
            HtmlImage uISaveButton = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UISaveImage;
            #endregion

            // Click 'Add' button
            //Mouse.Click(uIAddFillupButton);

            // Type '03/23/1011' in 'Date' text box
            uIDateEdit.Text = @"03/23/1011";

            // Type '0' in 'Odometer' text box
            uIOdometerEdit.Text = "0";

            // Type '0' in 'Price Per Gallon' text box
            uIPricePerGallonEdit.Text = "0";

            // Type '0' in 'Total Gallons' text box
            uITotalGallonsEdit.Text = "0";

            // Type '' in 'Fill-up Station' text box
            uIFillupStationEdit.Text = "";

            // Type '-10' in 'Transaction Fee' text box
            uITransactionFeeEdit.Text = "-10";

            // Type '' in 'Remarks' text box
            uIRemarksEdit.Text = "";

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        /// <summary>
        /// Add Fill up with Required Fields
        /// </summary>
        public void AddFillupWithRequiredFields()
        {
            #region Variable Declarations
            HtmlImage uIAddFillupButton = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIAddFillupImage;
            HtmlEdit uIDateEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIDateEdit;
            HtmlEdit uIOdometerEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOdometerEdit;
            HtmlEdit uIPricePerGallonEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIPricePerGallonEdit;
            HtmlEdit uITotalGallonsEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITotalGallonsEdit;
            HtmlEdit uITransactionFeeEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITransactionFeeEdit;
            HtmlImage uISaveButton = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UISaveImage;
            #endregion

            // Click 'Add' button
            Mouse.Click(uIAddFillupButton);

            // Type '3/20/2011' in 'Date' text box
            uIDateEdit.Text = this.AddFillupWithRequiredFieldsParams.UIDateEditText;

            // Type '500' in 'Odometer' text box
            uIOdometerEdit.Text = this.AddFillupWithRequiredFieldsParams.UIOdometerEditText;

            // Type '2' in 'Price Per Gallon' text box
            uIPricePerGallonEdit.Text = this.AddFillupWithRequiredFieldsParams.UIPricePerGallonEditText;

            // Type '10' in 'Total Gallons' text box
            uITotalGallonsEdit.Text = this.AddFillupWithRequiredFieldsParams.UITotalGallonsEditText;

            // Type '10' in 'Transaction Fee' text box
            uITransactionFeeEdit.Text = this.AddFillupWithRequiredFieldsParams.UITransactionFeeEditText;

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }

        /// <summary>
        /// AddSecondFillup - Use 'AddSecondFillupParams' to pass parameters into this method.
        /// </summary>
        public void AddSecondFillupWithAllFields()
        {
            #region Variable Declarations
            HtmlImage uIAddFillupButton = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIAddFillupImage;
            HtmlEdit uIDateEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIDateEdit;
            HtmlEdit uIOdometerEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOdometerEdit;
            HtmlEdit uIPricePerGallonEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIPricePerGallonEdit;
            HtmlEdit uITotalGallonsEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITotalGallonsEdit;
            HtmlEdit uIFillupStationEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIFillupStationEdit;
            HtmlEdit uITransactionFeeEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITransactionFeeEdit;
            HtmlEdit uIRemarksEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIRemarksEdit;
            HtmlImage uISaveButton = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UISaveImage;
            #endregion

            // Click 'Add' button
            Mouse.Click(uIAddFillupButton);

            // Type '3/14/2011' in 'Date' text box
            uIDateEdit.Text = this.AddSecondFillupParams.UIDateEditText;

            // Type '200' in 'Odometer' text box
            uIOdometerEdit.Text = this.AddSecondFillupParams.UIOdometerEditText;

            // Type '2' in 'Price Per Gallon' text box
            uIPricePerGallonEdit.Text = this.AddSecondFillupParams.UIPricePerGallonEditText;

            // Type '10' in 'Total Gallons' text box
            uITotalGallonsEdit.Text = this.AddSecondFillupParams.UITotalGallonsEditText;

            // Type 'Marqie's Travel' in 'Fill-up Station' text box
            uIFillupStationEdit.Text = this.AddSecondFillupParams.UIFillupStationEditText;

            // Type '10' in 'Transaction Fee' text box
            uITransactionFeeEdit.Text = this.AddSecondFillupParams.UITransactionFeeEditText;

            // Type 'Second fill-up' in 'Remarks' text box
            uIRemarksEdit.Text = this.AddSecondFillupParams.UIRemarksEditText;

            // Click 'Save' button
            Mouse.Click(uISaveButton);
        }
        #endregion 

        #region Assert Methods
        /// <summary>
        /// AssertFillupIsAdded - Use 'AssertFillupIsAddedExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertFillupIsAdded()
        {
            #region Variable Declarations
            HtmlHyperlink uIItem10Mar2011MarqiesHyperlink = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIItem10Mar2011MarqiesHyperlink;
            #endregion

            // Verify that '10 Mar 2011  Marqie's Travel  30.00' link's property 'InnerText' equals '10 Mar 2011
            //
            //Marqie's Travel
            //
            //30.00'
            Assert.AreEqual(this.AssertFillupIsAddedExpectedValues.UIItem10Mar2011MarqiesHyperlinkInnerText, uIItem10Mar2011MarqiesHyperlink.InnerText);
        }

        /// <summary>
        /// AssertFillupWithRequiredFieldsIsAdd - Use 'AssertFillupWithRequiredFieldsIsAddExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertFillupWithRequiredFieldsIsAdd()
        {
            #region Variable Declarations
            HtmlHyperlink uIItem20Mar20113000Hyperlink = this.UIFillupsforTest_VehicWindow.UIFillupsforTest_VehicDocument.UIAddFillupPane.UIItem20Mar20113000Hyperlink;
            #endregion

            // Verify that '20 Mar 2011   30.00' link's property 'InnerText' equals '20 Mar 2011
            //
            //
            //30.00'
            Assert.AreEqual(this.AssertFillupWithRequiredFieldsIsAddExpectedValues.UIItem20Mar20113000HyperlinkInnerText, uIItem20Mar20113000Hyperlink.InnerText);
        }

        public void AssertNullValuesMsg()
        {
            #region Variable Declarations
            HtmlSpan uIThevalueisRequiredCollection = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIThevalueisRequiredCollection;
            #endregion

            //Verify there are 5 validation message is displayed
            Assert.IsTrue(uIThevalueisRequiredCollection.FindMatchingControls().Count == 5);
        }

        public void AssertInvalidValuesMsg()
        {
            #region Variable Declarations
            HtmlSpan uIThevalueisnotvalidCollection = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIThevalueisnotvalidCollection;
            HtmlSpan uIOnlyalphanumericcharPaneCollection = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOnlyalphanumericcharPaneCollection;
            #endregion

            //Verify there are 4 validation message is displayed, 1 are allowed char string, 5 are not valid string
            Assert.IsTrue(uIThevalueisnotvalidCollection.FindMatchingControls().Count == 4 && uIOnlyalphanumericcharPaneCollection.FindMatchingControls().Count == 1);
        }

        public void AssertOutofRangeValuesMsg()
        {
            #region Variable Declarations
            HtmlSpan uIMustBeBetweenPaneCollection = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIMustBeBetweenPaneCollection;
            #endregion

            //Verify there are 4 validation message is displayed
            Assert.IsTrue(uIMustBeBetweenPaneCollection.FindMatchingControls().Count == 4);
        }

        public void AssertMaxLengthProperty()
        {
            #region Variable Declarations
            HtmlEdit uIDateEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIDateEdit;
            HtmlEdit uIOdometerEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIOdometerEdit;
            HtmlEdit uIPricePerGallonEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIPricePerGallonEdit;
            HtmlEdit uITotalGallonsEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITotalGallonsEdit;
            HtmlEdit uIFillupStationEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIFillupStationEdit;
            HtmlEdit uITransactionFeeEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UITransactionFeeEdit;
            HtmlEdit uIRemarksEdit = this.UIFillupsforTest_VehicWindow.UIAddFillupDocument.UIRemarksEdit;
            #endregion

            Assert.IsTrue(uIDateEdit.MaxLength == 10, "The MaxLength property of date InputBox is " + uIDateEdit.MaxLength + ", it should equal 10");
 
            Assert.IsTrue(uIOdometerEdit.MaxLength == 7, "The MaxLength property of Odometer InputBox is " + uIOdometerEdit.MaxLength + ", it should equal 7");

            Assert.IsTrue(uIPricePerGallonEdit.MaxLength == 6, "The MaxLength property of PricePerGallon InputBox is " + uIPricePerGallonEdit.MaxLength + ", it should equal 6");

            Assert.IsTrue(uITotalGallonsEdit.MaxLength == 7, "The MaxLength property of TotalGallon InputBox is " + uITotalGallonsEdit.MaxLength + ", it should equal 7");

            Assert.IsTrue(uIFillupStationEdit.MaxLength == 20, "The MaxLength property of FillupStation InputBox is " + uIFillupStationEdit.MaxLength + ", it should equal 20");

            Assert.IsTrue(uITransactionFeeEdit.MaxLength == 6, "The MaxLength property of Transaction InputBox is " + uITransactionFeeEdit.MaxLength + ", it should equal 6");

            Assert.IsTrue(uIRemarksEdit.MaxLength == 250, "The MaxLength property of Remarks InputBox is " + uITransactionFeeEdit.MaxLength + ", it should equal 250");
        }
        #endregion

        #region Properties
        public virtual AddFillupWithAllFieldsParams AddFillupWithAllFieldsParams
        {
            get
            {
                if ((this.mAddFillupWithAllFieldsParams == null))
                {
                    this.mAddFillupWithAllFieldsParams = new AddFillupWithAllFieldsParams();
                }
                return this.mAddFillupWithAllFieldsParams;
            }
        }

        public virtual AddFillupWithRequiredFieldsParams AddFillupWithRequiredFieldsParams
        {
            get
            {
                if ((this.mAddFillupWithRequiredFieldsParams == null))
                {
                    this.mAddFillupWithRequiredFieldsParams = new AddFillupWithRequiredFieldsParams();
                }
                return this.mAddFillupWithRequiredFieldsParams;
            }
        }

        public virtual AddSecondFillupParams AddSecondFillupParams
        {
            get
            {
                if ((this.mAddSecondFillupParams == null))
                {
                    this.mAddSecondFillupParams = new AddSecondFillupParams();
                }
                return this.mAddSecondFillupParams;
            }
        }

        public virtual AssertFillupIsAddedExpectedValues AssertFillupIsAddedExpectedValues
        {
            get
            {
                if ((this.mAssertFillupIsAddedExpectedValues == null))
                {
                    this.mAssertFillupIsAddedExpectedValues = new AssertFillupIsAddedExpectedValues();
                }
                return this.mAssertFillupIsAddedExpectedValues;
            }
        }

        public virtual AssertFillupWithRequiredFieldsIsAddExpectedValues AssertFillupWithRequiredFieldsIsAddExpectedValues
        {
            get
            {
                if ((this.mAssertFillupWithRequiredFieldsIsAddExpectedValues == null))
                {
                    this.mAssertFillupWithRequiredFieldsIsAddExpectedValues = new AssertFillupWithRequiredFieldsIsAddExpectedValues();
                }
                return this.mAssertFillupWithRequiredFieldsIsAddExpectedValues;
            }
        }

        public UIFillupsforTest_VehicWindow UIFillupsforTest_VehicWindow
        {
            get
            {
                if ((this.mUIFillupsforTest_VehicWindow == null))
                {
                    this.mUIFillupsforTest_VehicWindow = new UIFillupsforTest_VehicWindow();
                }
                return this.mUIFillupsforTest_VehicWindow;
            }
        }
        #endregion

        #region Fields
        private AddFillupWithAllFieldsParams mAddFillupWithAllFieldsParams;

        private AddFillupWithRequiredFieldsParams mAddFillupWithRequiredFieldsParams;

        private AssertFillupIsAddedExpectedValues mAssertFillupIsAddedExpectedValues;

        private AssertFillupWithRequiredFieldsIsAddExpectedValues mAssertFillupWithRequiredFieldsIsAddExpectedValues;

        private UIFillupsforTest_VehicWindow mUIFillupsforTest_VehicWindow;

        private AddSecondFillupParams mAddSecondFillupParams;
        #endregion
    }


    //These UITestControls are generate with Coded UITest Builder, Copy them from DashboardPage.Designer.cs file.
    //then modify them if we need to 
    #region UITestControl Definition
    /// <summary>
    /// Parameters to be passed into 'AddFillup'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class AddFillupWithAllFieldsParams
    {

        #region Fields
        /// <summary>
        /// Type '3/10/2011' in 'Date' text box
        /// </summary>
        public string UIDateEditText = "3/10/2011";

        /// <summary>
        /// Type '100' in 'Odometer' text box
        /// </summary>
        public string UIOdometerEditText = "100";

        /// <summary>
        /// Type '2' in 'Price Per Gallon' text box
        /// </summary>
        public string UIPricePerGallonEditText = "2";

        /// <summary>
        /// Type '10' in 'Total Gallons' text box
        /// </summary>
        public string UITotalGallonsEditText = "10";

        /// <summary>
        /// Type 'Marqie's Travel' in 'Fill-up Station' text box
        /// </summary>
        public string UIFillupStationEditText = "Marqie\'s Travel";

        /// <summary>
        /// Type '10' in 'Transaction Fee' text box
        /// </summary>
        public string UITransactionFeeEditText = "10";

        /// <summary>
        /// Type 'First fill-up' in 'Remarks' text box
        /// </summary>
        public string UIRemarksEditText = "First fill up";
        #endregion
    }

    /// <summary>
    /// hand-coded this AddFillupWithRequiredFieldsParams class
    /// </summary>
    public class AddFillupWithRequiredFieldsParams
    {
        #region Fields
        /// <summary>
        /// Type '3/20/2011' in 'Date' text box
        /// </summary>
        public string UIDateEditText = "3/20/2011";

        /// <summary>
        /// Type '500' in 'Odometer' text box
        /// </summary>
        public string UIOdometerEditText = "500";

        /// <summary>
        /// Type '2' in 'Price Per Gallon' text box
        /// </summary>
        public string UIPricePerGallonEditText = "2";

        /// <summary>
        /// Type '10' in 'Total Gallons' text box
        /// </summary>
        public string UITotalGallonsEditText = "10";

        /// <summary>
        /// Type '10' in 'Transaction Fee' text box
        /// </summary>
        public string UITransactionFeeEditText = "10";
        #endregion
    }

    /// <summary>
    /// Parameters to be passed into 'AddSecondFillup'
    /// </summary>
    public class AddSecondFillupParams
    {

        #region Fields
        /// <summary>
        /// Type '3/10/201' in 'Date' text box
        /// </summary>
        public string UIDateEditText = "3/14/2011";

        /// <summary>
        /// Type '200' in 'Odometer' text box
        /// </summary>
        public string UIOdometerEditText = "200";

        /// <summary>
        /// Type '2' in 'Price Per Gallon' text box
        /// </summary>
        public string UIPricePerGallonEditText = "2";

        /// <summary>
        /// Type '10' in 'Total Gallons' text box
        /// </summary>
        public string UITotalGallonsEditText = "10";

        /// <summary>
        /// Type 'Marqie's Travel' in 'Fill-up Station' text box
        /// </summary>
        public string UIFillupStationEditText = "Marqie\'s Travel";

        /// <summary>
        /// Type '10' in 'Transaction Fee' text box
        /// </summary>
        public string UITransactionFeeEditText = "10";

        /// <summary>
        /// Type 'Second fill-up' in 'Remarks' text box
        /// </summary>
        public string UIRemarksEditText = "Second fill up";
        #endregion
    }

    /// <summary>
    /// Parameters to be passed into 'AssertFillupIsAdded'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class AssertFillupIsAddedExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that '10 Mar 2011  Marqie's Travel  30.00' link's property 'InnerText' equals '10 Mar 2011
        ///
        ///Marqie's Travel
        ///
        ///30.00'
        /// </summary>
        public string UIItem10Mar2011MarqiesHyperlinkInnerText = "10 Mar 2011\r\n\r\nMarqie\'s Travel\r\n\r\n30.00";
        #endregion
    }

    public class AssertFillupWithRequiredFieldsIsAddExpectedValues
    {
        #region Fields
        /// <summary>
        /// Verify that '20 Mar 2011   30.00' link's property 'InnerText' equals '20 Mar 2011
        ///
        ///
        ///30.00'
        /// </summary>
        public string UIItem20Mar20113000HyperlinkInnerText = "20 Mar 2011\r\n\r\n\r\n30.00";
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIFillupsforTest_VehicWindow : BrowserWindow
    {

        public UIFillupsforTest_VehicWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "Dashboard";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Fill ups");
            this.WindowTitles.Add("Add Fill up");
            this.WindowTitles.Add("Fill ups for Test_Vehicle");
            #endregion
        }

        #region Properties
        public UIFillupsforTest_VehicDocument UIFillupsforTest_VehicDocument
        {
            get
            {
                if ((this.mUIFillupsforTest_VehicDocument == null))
                {
                    this.mUIFillupsforTest_VehicDocument = new UIFillupsforTest_VehicDocument(this);
                }
                return this.mUIFillupsforTest_VehicDocument;
            }
        }

        public UIAddFillupDocument UIAddFillupDocument
        {
            get
            {
                if ((this.mUIAddFillupDocument == null))
                {
                    this.mUIAddFillupDocument = new UIAddFillupDocument(this);
                }
                return this.mUIAddFillupDocument;
            }
        }
        #endregion

        #region Fields
        private UIFillupsforTest_VehicDocument mUIFillupsforTest_VehicDocument;

        private UIAddFillupDocument mUIAddFillupDocument;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIFillupsforTest_VehicDocument : HtmlDocument
    {

        public UIFillupsforTest_VehicDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            //this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Fill ups for Test_Vehicle";
            this.WindowTitles.Add("Fill ups");
            this.WindowTitles.Add("Add Fill ups");
            this.WindowTitles.Add("Fill ups for Test_Vehicle");
            #endregion
        }

        #region Properties
        public UIAddFillupPane UIAddFillupPane
        {
            get
            {
                if ((this.mUIAddFillupPane == null))
                {
                    this.mUIAddFillupPane = new UIAddFillupPane(this);
                }
                return this.mUIAddFillupPane;
            }
        }
        #endregion

        #region Fields
        private UIAddFillupPane mUIAddFillupPane;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIAddFillupPane : HtmlDiv
    {

        public UIAddFillupPane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "fillups-pane";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "DIV";
            this.WindowTitles.Add("Fill ups");
            this.WindowTitles.Add("Fill ups for Test_Vehicle"); 
            #endregion
        }

        #region Properties
        public HtmlImage UIAddFillupImage
        {
            get
            {
                if ((this.mUIAddFillupImage == null))
                {
                    this.mUIAddFillupImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIAddFillupImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.addImageAlt;
                    this.mUIAddFillupImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIAddFillupImage.WindowTitles.Add("Fill ups");
                    this.mUIAddFillupImage.WindowTitles.Add("Fill ups for Test_Vehilce");
                    #endregion
                }
                return this.mUIAddFillupImage;
            }
        }

        public HtmlHyperlink UIItem10Mar2011MarqiesHyperlink
        {
            get
            {
                if ((this.mUIItem10Mar2011MarqiesHyperlink == null))
                {
                    this.mUIItem10Mar2011MarqiesHyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUIItem10Mar2011MarqiesHyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "10 Mar 2011\r\n\r\nMarqie\'s Travel\r\n\r\n30.00";
                    this.mUIItem10Mar2011MarqiesHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Class] = "list-item selected";
                    this.mUIItem10Mar2011MarqiesHyperlink.FilterProperties[HtmlHyperlink.PropertyNames.ControlDefinition] = "class=\"list-item selected\" href=\"/Mileag";
                    this.mUIItem10Mar2011MarqiesHyperlink.WindowTitles.Add("Fill-ups for Test_Vehicle");
                    #endregion
                }
                return this.mUIItem10Mar2011MarqiesHyperlink;
            }
        }

        public HtmlHyperlink UIItem20Mar20113000Hyperlink
        {
            get
            {
                if ((this.mUIItem20Mar20113000Hyperlink == null))
                {
                    this.mUIItem20Mar20113000Hyperlink = new HtmlHyperlink(this);
                    #region Search Criteria
                    this.mUIItem20Mar20113000Hyperlink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = "20 Mar 2011\r\n\r\n\r\n30.00";
                    this.mUIItem20Mar20113000Hyperlink.FilterProperties[HtmlHyperlink.PropertyNames.Class] = "list-item selected";
                    this.mUIItem20Mar20113000Hyperlink.FilterProperties[HtmlHyperlink.PropertyNames.ControlDefinition] = "class=\"list-item selected\" href=\"/RI/IE8";
                    this.mUIItem20Mar20113000Hyperlink.WindowTitles.Add("Fill-ups for Test_Vehicle");
                    #endregion
                }
                return this.mUIItem20Mar20113000Hyperlink;
            }
        }
        #endregion

        #region Fields
        private HtmlImage mUIAddFillupImage;

        private HtmlHyperlink mUIItem10Mar2011MarqiesHyperlink;

        private HtmlHyperlink mUIItem20Mar20113000Hyperlink;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIAddFillupDocument : HtmlDocument
    {

        public UIAddFillupDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Add Fill-up";
            this.WindowTitles.Add("Add Fill-up");
            #endregion
        }

        #region Properties
        public HtmlEdit UIDateEdit
        {
            get
            {
                if ((this.mUIDateEdit == null))
                {
                    this.mUIDateEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIDateEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "Date";
                    this.mUIDateEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Date";
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Date";
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIDateEdit.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIDateEdit;
            }
        }

        public HtmlEdit UIOdometerEdit
        {
            get
            {
                if ((this.mUIOdometerEdit == null))
                {
                    this.mUIOdometerEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIOdometerEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "Odometer";
                    this.mUIOdometerEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Odometer";
                    this.mUIOdometerEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Odometer";
                    this.mUIOdometerEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIOdometerEdit.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIOdometerEdit;
            }
        }

        public HtmlEdit UIPricePerGallonEdit
        {
            get
            {
                if ((this.mUIPricePerGallonEdit == null))
                {
                    this.mUIPricePerGallonEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIPricePerGallonEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "PricePerUnit";
                    this.mUIPricePerGallonEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "PricePerUnit";
                    this.mUIPricePerGallonEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Price Per Gallon";
                    this.mUIPricePerGallonEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIPricePerGallonEdit.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIPricePerGallonEdit;
            }
        }

        public HtmlEdit UITotalGallonsEdit
        {
            get
            {
                if ((this.mUITotalGallonsEdit == null))
                {
                    this.mUITotalGallonsEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUITotalGallonsEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "TotalUnits";
                    this.mUITotalGallonsEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "TotalUnits";
                    this.mUITotalGallonsEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Total Gallons";
                    this.mUITotalGallonsEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUITotalGallonsEdit.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUITotalGallonsEdit;
            }
        }

        public HtmlEdit UIFillupStationEdit
        {
            get
            {
                if ((this.mUIFillupStationEdit == null))
                {
                    this.mUIFillupStationEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIFillupStationEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "Vendor";
                    this.mUIFillupStationEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Vendor";
                    this.mUIFillupStationEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Fill-up Station";
                    this.mUIFillupStationEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIFillupStationEdit.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIFillupStationEdit;
            }
        }

        public HtmlEdit UITransactionFeeEdit
        {
            get
            {
                if ((this.mUITransactionFeeEdit == null))
                {
                    this.mUITransactionFeeEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUITransactionFeeEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "TransactionFee";
                    this.mUITransactionFeeEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "TransactionFee";
                    this.mUITransactionFeeEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Transaction Fee";
                    this.mUITransactionFeeEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUITransactionFeeEdit.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUITransactionFeeEdit;
            }
        }

        public HtmlEdit UIRemarksEdit
        {
            get
            {
                if ((this.mUIRemarksEdit == null))
                {
                    this.mUIRemarksEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIRemarksEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "Remarks";
                    this.mUIRemarksEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "Remarks";
                    this.mUIRemarksEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Remarks";
                    this.mUIRemarksEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIRemarksEdit.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIRemarksEdit;
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
                    this.mUISaveImage.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUISaveImage;
            }
        }

        public HtmlSpan UIThevalueisnotvalidCollection
        {
            get
            {
                if ((this.mUIThevalueisnotvalidCollection == null))
                {
                    this.mUIThevalueisnotvalidCollection = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIThevalueisnotvalidCollection.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.DisplayText,
                        Utility.fillupInvalidMsgSuffix,PropertyExpressionOperator.Contains));
                    this.mUIThevalueisnotvalidCollection.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIThevalueisnotvalidCollection.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIThevalueisnotvalidCollection.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIThevalueisnotvalidCollection;
            }
        }

        public HtmlSpan UIThevalueisRequiredCollection
        {
            get
            {
                if ((this.mUIThevalueisRequiredCollection == null))
                {
                    this.mUIThevalueisRequiredCollection = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIThevalueisRequiredCollection.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.DisplayText,
                        Utility.fillupRequiredMsgSuffix, PropertyExpressionOperator.Contains));
                    this.mUIThevalueisRequiredCollection.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIThevalueisRequiredCollection.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIThevalueisRequiredCollection.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIThevalueisRequiredCollection;
            }
        }

        public HtmlSpan UIOnlyalphanumericcharPaneCollection
        {
            get
            {
                if ((this.mUIOnlyalphanumericcharPaneCollection == null))
                {
                    this.mUIOnlyalphanumericcharPaneCollection = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIOnlyalphanumericcharPaneCollection.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.DisplayText,
                        Utility.fillupJunkCharValidateMsgPrefix, PropertyExpressionOperator.Contains));
                    this.mUIOnlyalphanumericcharPaneCollection.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIOnlyalphanumericcharPaneCollection.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIOnlyalphanumericcharPaneCollection.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIOnlyalphanumericcharPaneCollection;
            }
        }

        public HtmlSpan UIMustBeBetweenPaneCollection
        {
            get
            {
                if ((this.mUIMustBeBetweenPaneCollection == null))
                {
                    this.mUIMustBeBetweenPaneCollection = new HtmlSpan(this);
                    #region Search Criteria
                    this.mUIMustBeBetweenPaneCollection.SearchProperties.Add(new PropertyExpression(HtmlDiv.PropertyNames.DisplayText,
                        Utility.FillupRangeofValuesMsgMiddleStr, PropertyExpressionOperator.Contains));
                    this.mUIMustBeBetweenPaneCollection.FilterProperties[HtmlDiv.PropertyNames.Class] = "field-validation-error";
                    this.mUIMustBeBetweenPaneCollection.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"field-validation-error\" data-valm";
                    this.mUIMustBeBetweenPaneCollection.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIMustBeBetweenPaneCollection;
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
                    this.mUIThefieldRemarksmustbPane.WindowTitles.Add("Add Fill-up");
                    #endregion
                }
                return this.mUIThefieldRemarksmustbPane;
            }
        }
        #endregion

        #region Fields
        private HtmlEdit mUIDateEdit;

        private HtmlEdit mUIOdometerEdit;

        private HtmlEdit mUIPricePerGallonEdit;

        private HtmlEdit mUITotalGallonsEdit;

        private HtmlEdit mUIFillupStationEdit;

        private HtmlEdit mUITransactionFeeEdit;

        private HtmlEdit mUIRemarksEdit;

        private HtmlImage mUISaveImage;

        private HtmlSpan mUIThevalueisnotvalidCollection;

        private HtmlSpan mUIThevalueisRequiredCollection;

        private HtmlSpan mUIOnlyalphanumericcharPaneCollection;

        private HtmlSpan mUIMustBeBetweenPaneCollection;

        private HtmlSpan mUIThefieldRemarksmustbPane;
        #endregion
    }
    #endregion


}
