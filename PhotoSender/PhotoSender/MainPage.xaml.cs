using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Identity.Client;

namespace PhotoSender
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                // Try to *silently* get a token
                // Silent here means without prompting the user to login.
                // This will only work if we have a previously cached token
                var result = await App.PCA.AcquireTokenSilentAsync(App.AppScopes,
                    App.PCA.Users.FirstOrDefault());

                tokenView.Text = result.AccessToken;
            }
            catch
            {
                // Show the signin UI
                await Navigation.PushModalAsync(new SignInPage(), true);
            }
        }

        async void SignOut(object sender, EventArgs e)
        {
            App.PCA.Remove(App.PCA.Users.FirstOrDefault());
            // Show the sigin UI
            await Navigation.PushModalAsync(new SignInPage(), true);
        }
    }
}
