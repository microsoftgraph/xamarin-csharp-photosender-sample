using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoSender
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage ()
        {
            InitializeComponent ();
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

                // Since we're already logged in, proceed to main page
                await Navigation.PushAsync(new NavigationPage(new MainPage()));
            }
            catch (MsalUiRequiredException) {}
        }

        async void SignIn(object sender, EventArgs e)
        {
            try
            {
                var result = await App.PCA.AcquireTokenAsync(App.AppScopes, App.AuthUiParent);

                await Navigation.PushAsync(new NavigationPage(new MainPage()));
            }
            catch (MsalException ex)
            {
                await DisplayAlert("Signin Error", ex.Message, "Dismiss");
            }
        }
    }
}