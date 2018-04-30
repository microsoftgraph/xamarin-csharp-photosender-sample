using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using System.Reflection;

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

                // Get the user's name from the Graph
                var user = await App.GraphClient.Me.Request()
                    .Select("displayName,mail")
                    .GetAsync();

                lblUserName.Text = user.DisplayName;
                lblUserEmail.Text = user.Mail;

                // Get the user's profile photo
                var photo = await App.GraphClient.Me.Photo.Content.Request().GetAsync();

                if (photo != null)
                {
                    imgProfilePhoto.Source = ImageSource.FromStream(() => photo);
                }
                else
                {
                    // Fallback on a placeholder image
                    imgProfilePhoto.Source = ImageSource.FromResource("PhotoSender.no-profile-pic.png", Assembly.GetExecutingAssembly());
                }
            }
            catch (MsalException)
            {
                // Show the signin UI
                await Navigation.PushModalAsync(new SignInPage(), true);
            }
            catch (ServiceException ex)
            {
                await DisplayAlert("A Graph error occurred", ex.Message, "Dismiss");
            }
        }

        async void OnUserTapped(object sender, EventArgs e)
        {
            var signout = await DisplayAlert("Sign out?", "Do you want to sign out?", "Yes", "No");
            if (signout)
            {
                SignOut();
            }

            var action = await DisplayActionSheet("What would you like to do?", "Cancel", null, "Change profile picture", "Sign out");
        }

        async void OnPhotoTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Photo tapped", "YAY", "Got it");
        }

        async void SignOut()
        {
            App.PCA.Remove(App.PCA.Users.FirstOrDefault());
            // Show the sigin UI
            await Navigation.PushModalAsync(new SignInPage(), true);
        }
    }
}
