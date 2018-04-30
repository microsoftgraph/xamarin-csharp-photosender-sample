using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using System.Reflection;
using System.IO;

namespace PhotoSender
{
    public partial class MainPage : ContentPage
    {
        private List<Person> recipientList;

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

                var photoStream = await GetUserPhoto();
                imgProfilePhoto.Source = ImageSource.FromStream(() => photoStream);

                // Get user's relevant people
                var recipients = await App.GraphClient.Me.People.Request().GetAsync();
                recipientList = recipients.ToList();
                pickerRecipient.ItemsSource = recipientList;
                pickerRecipient.ItemDisplayBinding = new Binding("DisplayName");
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
        }

        async void OnPhotoTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Photo tapped", "TODO: Implement this!", "Got it");
        }

        void OnRecipientSelected(object sender, EventArgs e)
        {
            // Enable the send button
            btnSend.IsEnabled = true;
        }

        async Task<Stream> GetUserPhoto()
        {
            // Get the user's profile photo
            var photo = await App.GraphClient.Me.Photo.Content.Request().GetAsync();
            if (photo == null)
            {
                // Fallback on a placeholder image
                photo = Assembly.GetExecutingAssembly().GetManifestResourceStream("PhotoSender.no-profile-pic.png");
            }

            return photo;
        }

        async void SendMail(object sender, EventArgs e)
        {
            ShowProgress("Getting profile photo");

            try
            {
                // Upload the profile pic to OneDrive
                var photoStream = await GetUserPhoto();

                // Copy to memory stream
                MemoryStream memStream = new MemoryStream();
                photoStream.CopyTo(memStream);

                // Get the bytes
                var photoBytes = memStream.ToArray();

                UpdateProgress("Uploading photo to OneDrive");
                var uploadedPhoto = await App.GraphClient.Me.Drive.Root.ItemWithPath("ProfilePhoto.png")
                    .Content.Request().PutAsync<DriveItem>(new MemoryStream(photoBytes));

                // Generate a sharing link

                UpdateProgress("Generating sharing link");
                var sharingLink = await App.GraphClient.Me.Drive.Items[uploadedPhoto.Id]
                    .CreateLink("view", "organization").Request().PostAsync();

                // Create the email message
                var selectedRecipient = pickerRecipient.SelectedItem as Person;

                var recipient = new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Name = selectedRecipient.DisplayName,
                        Address = selectedRecipient.ScoredEmailAddresses.FirstOrDefault().Address
                    }
                };

                var message = new Message()
                {
                    Subject = "Check out my profile photo",
                    ToRecipients = new List<Recipient>()
                {
                    recipient
                },
                    Body = new ItemBody()
                    {
                        ContentType = BodyType.Html
                    },
                    Attachments = new MessageAttachmentsCollectionPage()
                };

                // Attach profile pic and add as inline
                message.Attachments.Add(new FileAttachment()
                {
                    ODataType = "#microsoft.graph.fileAttachment",
                    ContentBytes = photoBytes,
                    ContentType = "image/png",
                    Name = "ProfilePhoto.png",
                    IsInline = true
                });

                message.Body.Content = $@"<html><head>
<meta http-equiv='Content-Type' content='text/html; charset=us-ascii'>
</head>
<body style='font-family:calibri'>
  <h2>Hello, {selectedRecipient.GivenName}!</h2>
  <p>This is a message from the PhotoSender app.What do you think of my profile picture?</p>
  <img src=""cid:ProfilePhoto.png""></img>
  <p>You can also <a href=""{sharingLink.Link.WebUrl}"" >view it on my OneDrive</a>.</p>
</body></html>";

                UpdateProgress("Sending message");
                // Send the message
                await App.GraphClient.Me.SendMail(message, true).Request().PostAsync();

                await DisplayAlert("Success", "Message sent", "OK");
            }
            catch(ServiceException ex)
            {
                await DisplayAlert("A Graph error occurred", ex.Message, "Dismiss");
            }
            finally
            {
                HideProgress();
            }
        }

        void ShowProgress(string message)
        {
            progressIndicator.IsVisible = true;
            mainView.IsVisible = false;
            spinner.IsRunning = true;
            progressMessage.Text = message;
        }

        void UpdateProgress(string message)
        {
            progressMessage.Text = message;
        }

        void HideProgress()
        {
            progressMessage.Text = "Busy";
            spinner.IsRunning = false;
            progressIndicator.IsVisible = false;
            mainView.IsVisible = true;
        }

        async void SignOut()
        {
            foreach(var user in App.PCA.Users)
            {
                App.PCA.Remove(user);
            }

            // Show the sigin UI
            await Navigation.PushModalAsync(new SignInPage(), true);
        }
    }
}
