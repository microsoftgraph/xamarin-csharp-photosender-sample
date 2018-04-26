using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Identity.Client;

using Xamarin.Forms;

namespace PhotoSender
{
    public partial class App : Application
    {
        public static PublicClientApplication PCA;
        public static string AppId = "[APP ID HERE]";
        public static string[] AppScopes = { "User.Read", "Mail.Read", "Mail.Send", "Files.ReadWrite" };
        public static UIParent AuthUiParent = null;

        public App ()
        {
            InitializeComponent();
            PCA = new PublicClientApplication(AppId);
            MainPage = new NavigationPage(new SignInPage());
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
