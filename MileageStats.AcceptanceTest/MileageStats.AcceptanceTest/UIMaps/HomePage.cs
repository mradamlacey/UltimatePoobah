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
namespace MileageStats.AcceptanceTest.UIMaps.HomePageClasses
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
    
    
    public partial class HomePage
    {
        #region Help Methods
        /// <summary>
        /// Sign in to Dashboard page
        /// </summary>
        public void SignIn()
        {
            #region Variable Declarations
            HtmlImage uISignInorRegisterButton = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UISignInorRegisterImage;
            HtmlEdit uIProviderUrlEdit = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UIProviderUrlEdit;
            HtmlInputButton uISignInButton1 = this.UIHomePageWindowsInteWindow.UIMockAuthenticationDocument.UIAuthentication_respoCustom.UISignInButton;
            BrowserWindow currentBrowserWindow = this.UIHomePageWindowsInteWindow;
            #endregion
           
            // Go to web page 'Mileage Stats' using new browser window
            this.UIHomePageWindowsInteWindow.LaunchUrl(new System.Uri(Utility.GetTestEnvData(Utility.testURL)));

            //Maxmized browserWindow
            Utility.MaximizeBrowserWindow(currentBrowserWindow);

            //Input a fake OpenId account into ProviderUrl box, If no anything in the box, user will redirect to Auth Sign in page
            uIProviderUrlEdit.Text = "test@yahoo.com";

            //Click 'Sign In or Register' button
            Mouse.Click(uISignInorRegisterButton);
          
            //Click 'Sign in' button on Mock page
            Mouse.Click(uISignInButton1);                     
        }

        /// <summary>
        /// Open Home page
        /// </summary>
        public void OpenHomePage()
        {
            #region Variable Declarations
            BrowserWindow currentBrowserWindow = this.UIHomePageWindowsInteWindow;
            #endregion

            // Go to web page 'Mileage Stats' using new browser instance
            this.UIHomePageWindowsInteWindow.LaunchUrl(new System.Uri(Utility.GetTestEnvData(Utility.testURL)));

            //Maxmized browserWindow
            Utility.MaximizeBrowserWindow(currentBrowserWindow);
        }

        ///// <summary>
        ///// Click Sign in button navigate to Mock page
        ///// </summary>
        public void ClickSignInButtonOnHomepage()
        {
            #region Variable Declarations
            HtmlImage uISignInButton = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UISignInorRegisterImage;
            HtmlEdit uIProviderUrlEdit = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UIProviderUrlEdit;
            #endregion

            //Input a fake OpenId account into ProviderUrl box, If no anything in the box, user will redirect to Auth Sign in page
            uIProviderUrlEdit.Text = "test@yahoo.com";

            // Click 'Sign In' button
            Mouse.Click(uISignInButton);
        }

        public void ClickSigninButtonOnMockPage()
        {
            #region Variable Declarations
            HtmlInputButton uISignInButton1 = this.UIHomePageWindowsInteWindow.UIMockAuthenticationDocument.UIAuthentication_respoCustom.UISignInButton;
            #endregion

            // Click 'Sign In' button
            Mouse.Click(uISignInButton1);
        }

        public void SignInWithNewUser()
        {
            #region Variable Declarations
            HtmlImage uISignInorRegisterImage = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UISignInorRegisterImage;
            HtmlEdit uIProviderUrlEdit = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UIProviderUrlEdit;
            HtmlEdit uIClaimedIdentifierEdit = this.UIHomePageWindowsInteWindow.UIMockAuthenticationDocument.UIAuthentication_respoCustom.UIClaimedIdentifierEdit;
            HtmlInputButton uISignInButton1 = this.UIHomePageWindowsInteWindow.UIMockAuthenticationDocument.UIAuthentication_respoCustom.UISignInButton;
            BrowserWindow currentBrowserWindow = this.UIHomePageWindowsInteWindow;
            #endregion

            // Go to web page 'Mileage Stats' using new browser instance
            this.UIHomePageWindowsInteWindow.LaunchUrl(new System.Uri(Utility.GetTestEnvData(Utility.testURL)));

            //Maxmized browserWindow
            Utility.MaximizeBrowserWindow(currentBrowserWindow);

            //Input a fake OpenId account into ProviderUrl box, If no anything in the box, user will redirect to Auth Sign in page
            uIProviderUrlEdit.Text = "http://ritest.myidprovider.org";

            // Click 'Sign In or Gegistrer' button
            Mouse.Click(uISignInorRegisterImage);

            // Type 'http://ritest.myidprovider.org/' in 'Claimed Identifier' text box
            uIClaimedIdentifierEdit.Text = @"http://ritest.myidprovider.org/";

            // Click 'Sign In' button
            Mouse.Click(uISignInButton1);
        }
        #endregion

        #region Assert Methods
        public void AssertSignIn()
        {
            UIDashboardWindowsInteWindow dashboardpage = new UIDashboardWindowsInteWindow();

            // Verify that Dashboard page is displayed
            Assert.IsTrue(dashboardpage.Name.Contains("Dashboard - Windows Internet Explorer"));
        }

        public void AssertSignOut()
        {
            UIMileageStatsDocument mileageStatsDoc = new UIMileageStatsDocument(this.UIHomePageWindowsInteWindow);

            //Verify Navigate to homepage
            Assert.AreEqual("Mileage Stats | Know where your gas takes you", mileageStatsDoc.Title);
        }

        public void AssertMaxLengthProperty()
        {
            #region Variable Declarations
            HtmlEdit uIProviderUrlEdit = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UIProviderUrlEdit;
            #endregion

            Assert.IsTrue(uIProviderUrlEdit.MaxLength == 200, "The MaxLength property of display name InputBox is " + uIProviderUrlEdit.MaxLength + ", It should equal 200");
        }

        public void AssertMaxLengthProperty1()
        {
            #region Variable Declarations
            HtmlEdit uIClaimedIdentifierEdit = this.UIHomePageWindowsInteWindow.UIMockAuthenticationDocument.UIAuthentication_respoCustom.UIClaimedIdentifierEdit;
            #endregion

            Assert.IsTrue(uIClaimedIdentifierEdit.MaxLength == 200, "The MaxLength property of Claimed Identifier InputBox is " + uIClaimedIdentifierEdit.MaxLength + ", It should equal 200");

        }

        public void AssertImageAltProperty()
        {
            #region Variable Declarations
            HtmlImage uIMileageStatsIconImage = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UIMileageStatsIconImage;
            HtmlImage uIMyOpenIDImage = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UIMyOpenIDImage;
            HtmlImage uIYahooImage = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UILoginPane.UIYahooImage;
            HtmlImage uIHTML5logoandiconsImage = this.UIHomePageWindowsInteWindow.UIMileageStatsDocument.UIHtml5Pane.UIHTML5logoandiconsImage;
            #endregion

            // Verify that 'Mileage Stats Icon' image's property 'Alt' exist
            Assert.IsTrue(uIMileageStatsIconImage.Exists);

            // Verify that 'My OpenID' image's property 'Alt'exist
            Assert.IsTrue(uIMyOpenIDImage.Exists);

            // Verify that 'Yahoo' image's property 'Alt' exist
            Assert.IsTrue(uIYahooImage.Exists);

            // Verify that 'HTML5 logo and icons' image's property 'Alt' exist
            Assert.IsTrue(uIHTML5logoandiconsImage.Exists);
        }
        #endregion

        #region Properties
        public UIHomePageWindowsInteWindow UIHomePageWindowsInteWindow
        {
            get
            {
                if ((this.mUIHomePageWindowsInteWindow == null))
                {
                    this.mUIHomePageWindowsInteWindow = new UIHomePageWindowsInteWindow();
                }
                return this.mUIHomePageWindowsInteWindow;
            }
        }
        #endregion

        #region Fields
        private UIHomePageWindowsInteWindow mUIHomePageWindowsInteWindow;
        #endregion
    }

    //These UITestControls are generate with Coded UITest Builder, Copy them from DashboardPage.Designer.cs file.
    //then modify them if we need to 
    #region UITestControl Definition 
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
    }

    public class UIHomePageWindowsInteWindow : BrowserWindow
    {

        public UIHomePageWindowsInteWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("Blank Page");
            this.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
            this.WindowTitles.Add("Mock Authentication");
            #endregion
        }

        public void LaunchUrl(System.Uri url)
        {
            this.CopyFrom(BrowserWindow.Launch(url));
        }

        #region Properties
        public UIMileageStatsDocument UIMileageStatsDocument
        {
            get
            {
                if ((this.mUIMileageStatsDocument == null))
                {
                    this.mUIMileageStatsDocument = new UIMileageStatsDocument(this);
                }
                return this.mUIMileageStatsDocument;
            }
        }

        public UIMockAuthenticationDocument UIMockAuthenticationDocument
        {
            get
            {
                if ((this.mUIMockAuthenticationDocument == null))
                {
                    this.mUIMockAuthenticationDocument = new UIMockAuthenticationDocument(this);
                }
                return this.mUIMockAuthenticationDocument;
            }
        }

        public UISignintoYahooDocument UISignintoYahooDocument
        {
            get
            {
                if ((this.mUISignintoYahooDocument == null))
                {
                    this.mUISignintoYahooDocument = new UISignintoYahooDocument(this);
                }
                return this.mUISignintoYahooDocument;
            }
        }
        #endregion

        #region Fields
        private UIMileageStatsDocument mUIMileageStatsDocument;

        private UIMockAuthenticationDocument mUIMockAuthenticationDocument;

        private UISignintoYahooDocument mUISignintoYahooDocument;
        #endregion
    }

    public class UIMileageStatsDocument : HtmlDocument
    {

        public UIMileageStatsDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.Title] = "Mileage Stats | Know where your gas takes you";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath();
            this.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
            #endregion
        }

        #region Properties
        public UILoginPane UILoginPane
        {
            get
            {
                if ((this.mUILoginPane == null))
                {
                    this.mUILoginPane = new UILoginPane(this);
                }
                return this.mUILoginPane;
            }
        }

        public HtmlImage UIMileageStatsIconImage
        {
            get
            {
                if ((this.mUIMileageStatsIconImage == null))
                {
                    this.mUIMileageStatsIconImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIMileageStatsIconImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.mileageStatsLogoAlt;
                    this.mUIMileageStatsIconImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIMileageStatsIconImage.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
                    #endregion
                }
                return this.mUIMileageStatsIconImage;
            }
        }

        public UIHtml5Pane UIHtml5Pane
        {
            get
            {
                if ((this.mUIHtml5Pane == null))
                {
                    this.mUIHtml5Pane = new UIHtml5Pane(this);
                }
                return this.mUIHtml5Pane;
            }
        }
        #endregion

        #region Fields
        private UILoginPane mUILoginPane;

        private HtmlImage mUIMileageStatsIconImage;

        private UIHtml5Pane mUIHtml5Pane;
        #endregion
    }

    public class UIMockAuthenticationDocument : HtmlDocument
    {

        public UIMockAuthenticationDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Mock Authentication";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = Utility.GetTestUriAbsolutePath() + "/MockAuthenticator";
            this.WindowTitles.Add("Mock Authentication");
            #endregion
        }

        #region Properties
        public UIAuthentication_respoCustom UIAuthentication_respoCustom
        {
            get
            {
                if ((this.mUIAuthentication_respoCustom == null))
                {
                    this.mUIAuthentication_respoCustom = new UIAuthentication_respoCustom(this);
                }
                return this.mUIAuthentication_respoCustom;
            }
        }
        #endregion

        #region Fields
        private UIAuthentication_respoCustom mUIAuthentication_respoCustom;
        #endregion
    }

    public class UIAuthentication_respoCustom : HtmlCustom
    {

        public UIAuthentication_respoCustom(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "authentication_response";
            this.SearchProperties[UITestControl.PropertyNames.Name] = null;
            this.SearchProperties["TagName"] = "FORM";
            this.FilterProperties["Class"] = null;
            this.FilterProperties["ControlDefinition"] = "id=\"authentication_response\" encType=\"mu";
            this.WindowTitles.Add("Mock Authentication");
            #endregion
        }

        #region Properties
        //To get the signin button on Mock page
        public HtmlInputButton UISignInButton
        {
            get
            {
                if ((this.mUISignInButton == null))
                {
                    this.mUISignInButton = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mUISignInButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Sign In";
                    this.mUISignInButton.FilterProperties[HtmlButton.PropertyNames.Type] = "submit";
                    this.mUISignInButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "value=\"Sign In\" type=\"submit\"";
                    this.mUISignInButton.WindowTitles.Add("Mock Authentication");
                    #endregion
                }
                return this.mUISignInButton;
            }
        }

        public HtmlEdit UIClaimedIdentifierEdit
        {
            get
            {
                if ((this.mUIClaimedIdentifierEdit == null))
                {
                    this.mUIClaimedIdentifierEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIClaimedIdentifierEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "claimed_identifier";
                    this.mUIClaimedIdentifierEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "claimed_identifier";
                    this.mUIClaimedIdentifierEdit.WindowTitles.Add("Mock Authentication");
                    #endregion
                }
                return this.mUIClaimedIdentifierEdit;
            }
        }

        #endregion

        #region Fields
        private HtmlInputButton mUISignInButton;

        private HtmlEdit mUIClaimedIdentifierEdit;

        #endregion
    }

    public class UILoginPane : HtmlDiv
    {

        public UILoginPane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties["Id"] = "login";
            this.SearchProperties["TagName"] = "Div";
            this.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
            #endregion
        }

        #region Properties
        //To get the Sign In or Register Image on Home Page
        public HtmlImage UISignInorRegisterImage
        {
            get
            {
                if ((this.mUISignInorRegisterImage == null))
                {
                    this.mUISignInorRegisterImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUISignInorRegisterImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.signinImageAlt;
                    this.mUISignInorRegisterImage.SearchProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUISignInorRegisterImage.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
                    #endregion
                }
                return this.mUISignInorRegisterImage;
            }
        }

        public HtmlEdit UIProviderUrlEdit
        {
            get 
            {
                if (this.mUIProviderUrlEdit == null)
                {
                    this.mUIProviderUrlEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIProviderUrlEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "providerUrl";
                    this.mUIProviderUrlEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "providerUrl";
                    this.mUIProviderUrlEdit.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
                    #endregion
                }
                return mUIProviderUrlEdit;
            }
        }

        public HtmlImage UIMyOpenIDImage
        {
            get
            {
                if ((this.mUIMyOpenIDImage == null))
                {
                    this.mUIMyOpenIDImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIMyOpenIDImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.openIDImageAlt;
                    this.mUIMyOpenIDImage.FilterProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIMyOpenIDImage.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
                    #endregion
                }
                return this.mUIMyOpenIDImage;
            }
        }

        public HtmlImage UIYahooImage
        {
            get
            {
                if ((this.mUIYahooImage == null))
                {
                    this.mUIYahooImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIYahooImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.yahooImageAlt;
                    this.mUIYahooImage.FilterProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIYahooImage.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
                    #endregion
                }
                return this.mUIYahooImage;
            }
        }
        #endregion

        #region Fields
        private HtmlImage mUISignInorRegisterImage;

        private HtmlEdit mUIProviderUrlEdit;

        private HtmlImage mUIMyOpenIDImage;

        private HtmlImage mUIYahooImage;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.30319.1")]
    public class UIHtml5Pane : HtmlDiv
    {

        public UIHtml5Pane(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = "html5";
            this.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"html5\"";
            this.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
            #endregion
        }

        #region Properties
        public HtmlImage UIHTML5logoandiconsImage
        {
            get
            {
                if ((this.mUIHTML5logoandiconsImage == null))
                {
                    this.mUIHTML5logoandiconsImage = new HtmlImage(this);
                    #region Search Criteria
                    this.mUIHTML5logoandiconsImage.SearchProperties[HtmlImage.PropertyNames.Alt] = Utility.html5LogoAlt;
                    this.mUIHTML5logoandiconsImage.FilterProperties[HtmlImage.PropertyNames.TagName] = "IMG";
                    this.mUIHTML5logoandiconsImage.WindowTitles.Add("Mileage Stats | Know where your gas takes you");
                    #endregion
                }
                return this.mUIHTML5logoandiconsImage;
            }
        }
        #endregion

        #region Fields
        private HtmlImage mUIHTML5logoandiconsImage;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "10.0.40219.1")]
    public class UISignintoYahooDocument : HtmlDocument
    {

        public UISignintoYahooDocument(UITestControl searchLimitContainer) :
            base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = "yregtgen";
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "Sign in to Yahoo!";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/config/login";
            this.WindowTitles.Add("Sign in to Yahoo!");
            #endregion
        }

        #region Properties
        public HtmlEdit UIYahooIDEdit
        {
            get
            {
                if ((this.mUIYahooIDEdit == null))
                {
                    this.mUIYahooIDEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIYahooIDEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "username";
                    this.mUIYahooIDEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "login";
                    this.mUIYahooIDEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Yahoo! ID";
                    this.mUIYahooIDEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIYahooIDEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIYahooIDEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "yreg_ipt";
                    this.mUIYahooIDEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"username\" class=\"yreg_ipt\" name=\"log";
                    this.mUIYahooIDEdit.WindowTitles.Add("Sign in to Yahoo!");
                    #endregion
                }
                return this.mUIYahooIDEdit;
            }
        }

        public HtmlEdit UIPasswordEdit
        {
            get
            {
                if ((this.mUIPasswordEdit == null))
                {
                    this.mUIPasswordEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIPasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "passwd";
                    this.mUIPasswordEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "passwd";
                    this.mUIPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = "Password:";
                    this.mUIPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
                    this.mUIPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "yreg_ipt";
                    this.mUIPasswordEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "id=\"passwd\" class=\"yreg_ipt\" name=\"passw";
                    this.mUIPasswordEdit.WindowTitles.Add("Sign in to Yahoo!");
                    #endregion
                }
                return this.mUIPasswordEdit;
            }
        }

        public HtmlCheckBox UIKeepmesignedinCheckBox
        {
            get
            {
                if ((this.mUIKeepmesignedinCheckBox == null))
                {
                    this.mUIKeepmesignedinCheckBox = new HtmlCheckBox(this);
                    #region Search Criteria
                    this.mUIKeepmesignedinCheckBox.SearchProperties[HtmlCheckBox.PropertyNames.Id] = "persistent";
                    this.mUIKeepmesignedinCheckBox.SearchProperties[HtmlCheckBox.PropertyNames.Name] = ".persistent";
                    this.mUIKeepmesignedinCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Value] = "on";
                    this.mUIKeepmesignedinCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.LabeledBy] = "Keep me signed in";
                    this.mUIKeepmesignedinCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Title] = null;
                    this.mUIKeepmesignedinCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.Class] = null;
                    this.mUIKeepmesignedinCheckBox.FilterProperties[HtmlCheckBox.PropertyNames.ControlDefinition] = "style=\"margin: 0px; padding: 0px; float:";
                    this.mUIKeepmesignedinCheckBox.WindowTitles.Add("Sign in to Yahoo!");
                    #endregion
                }
                return this.mUIKeepmesignedinCheckBox;
            }
        }

        public HtmlInputButton UISignInButton
        {
            get
            {
                if ((this.mUISignInButton == null))
                {
                    this.mUISignInButton = new HtmlInputButton(this);
                    #region Search Criteria
                    this.mUISignInButton.SearchProperties[HtmlButton.PropertyNames.Id] = ".save";
                    this.mUISignInButton.SearchProperties[HtmlButton.PropertyNames.Name] = ".save";
                    this.mUISignInButton.FilterProperties[HtmlButton.PropertyNames.DisplayText] = "Sign In";
                    this.mUISignInButton.FilterProperties[HtmlButton.PropertyNames.Type] = "submit";
                    this.mUISignInButton.FilterProperties[HtmlButton.PropertyNames.Title] = null;
                    this.mUISignInButton.FilterProperties[HtmlButton.PropertyNames.Class] = null;
                    this.mUISignInButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "id=\".save\" name=\".save\" value=\"Sign In\" ";
                    this.mUISignInButton.WindowTitles.Add("Sign in to Yahoo!");
                    #endregion
                }
                return this.mUISignInButton;
            }
        }
        #endregion

        #region Fields
        private HtmlEdit mUIYahooIDEdit;

        private HtmlEdit mUIPasswordEdit;

        private HtmlCheckBox mUIKeepmesignedinCheckBox;

        private HtmlInputButton mUISignInButton;
        #endregion
    }
    #endregion
}
