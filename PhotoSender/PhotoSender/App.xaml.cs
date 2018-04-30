using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using System.Net.Http.Headers;

using Xamarin.Forms;

namespace PhotoSender
{
    public partial class App : Application
    {
        public static PublicClientApplication PCA;
        public static string AppId = "[APP ID HERE]";
        public static string[] AppScopes = { "User.Read", "Mail.Read", "Mail.Send", "Files.ReadWrite", "People.Read" };
        public static UIParent AuthUiParent = null;
        public static bool PendingAuth = false;

        public static GraphServiceClient GraphClient;

        public App ()
        {
            InitializeComponent();
            PCA = new PublicClientApplication(AppId);

            GraphClient = new GraphServiceClient(new DelegateAuthenticationProvider(
                async (request) =>
                {
                    // Get token silently from MSAL
                    var authResult = await PCA.AcquireTokenSilentAsync(AppScopes, PCA.Users.FirstOrDefault());

                    // Add the access token to the "Authorization" header
                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                }
            ));

            MainPage = new SignInPage();
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
