# Build mobile apps with Microsoft Graph

In this session, we'll build a cross-platform mobile application that uses the Microsoft Graph to upload a photo to OneDrive and send an email with both a OneDrive sharing link to that photo and the photo itself as an inline attachment.

## Prerequisites

- Windows 10 with [development mode enabled](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development)
- Visual Studio 2017 version 15.6.6 with the Xamarin workload installed
- Android SDK for Android 7.1 and Android Emulator (installed via the [Android SDK Manager in Visual Studio](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-sdk?tabs=vswin))

## Create the app

1. Open Visual Studio, then choose the **File** menu, then **New**, then **Project...**.

1. Choose the **Mobile App (Xamarin.Forms)** project template (located under **Visual C#**, **Cross-Platform**). Name the app **PhotoSender** and choose **OK**.
    ![A screenshot of the New Project dialog with the Mobile App (Xamarin.Forms) template selected](readme-images/select-template.PNG)

1. Choose the **Blank App** template. Under **Code Sharing Strategy**, select **.NET Standard**. Choose **OK**.
    ![A screenshot of the New Cross Platform App dialog](readme-images/cross-platform-options.PNG)

Visual Studio will create three projects in the solution:

- **PhotoSender** - This is the .NET Standard library that will hold all of the shared code and UI.
- **PhotoSender.Android** - This project implements the Android version of the application and contains any Android-specific code.
- **PhotoSender.iOS** - This project implements the iOS version of the application and contains any iOS-specific code.
- **PhotoSender.UWP** This project implements the Universal Windows Platform version of the application and contains any UWP-specific code.

Wait for Visual Studio to finish creating the projects before moving on to the next section.

## Install NuGet packages

Next let's install the following NuGet packages.

- [Microsoft.Identity.Client](https://www.nuget.org/packages/Microsoft.Identity.Client): The Microsoft Authentication Library (MSAL) will handle the OAuth authentication needed for the Microsoft Graph.
- [Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph/): The Microsoft Graph Client Library handles all of the Graph requests and implements types for the entities exposed by the Graph.

1. In Visual Studio, choose **Tools**, **NuGet Package Manager**, **Package Manager Console**.
1. In the **Package Manager Console**, enter the following commands.

    ```Shell
    Install-Package Microsoft.Identity.Client -Version 1.1.2-preview0008 -Project PhotoSender -Pre
    Install-Package Microsoft.Identity.Client -Version 1.1.2-preview0008 -Project PhotoSender.Android -Pre
    Install-Package Microsoft.Identity.Client -Version 1.1.2-preview0008 -Project PhotoSender.iOS -Pre
    Install-Package Microsoft.Graph -Version 1.8.1 -Project PhotoSender
    ```

## Implement sign-in

> **TIP:** To make it easier to debug in Visual Studio, change the build options on the **PhotoSender** project to generate full debug information. Right-click the **PhotoSender** project in **Solution Explorer** and choose **Properties**. Select **Build**, then **Advanced...**. Change **Debugging information** to **Full** and choose **OK**.
>
> Now is a good time to disable build of any projects that you're not actively using. If you're doing this exercise on Windows, the iOS project is disabled by default. You can also disable the Android project by selecting **Configuration Manager...** on the **Build** menu and un-checking **Build** and **Deploy**.

### Register the application

The first step is to allow the user to sign-in to the app so we can obtain an access token for calling the Microsoft Graph API. In order to do that, we need to register the application to get an application ID.

1. Open your browser and go to https://apps.dev.microsoft.com. Sign in with your Office 365 account.
1. Choose the **Add an app** button. Enter `PhotoSender` in the **Application Name** field, leave the **Let us help you get started** checkbox un-checked, and choose **Create**.
1. Choose the **Add Platform** button, then choose **Native Application**.
1. Choose **Save**.

Copy the value of **Application Id**, we'll need that value later.

### Set up the identity client

## Running on Android

MSAL requires additional configuration in the Android project to work properly. This is documented at https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Xamarin-android-specificities.

First, we need to require permissions to the internet. Open **./PhotoSender.Android/Properties/AndroidManifest.xml** and add the following permissions.

```xml
<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
```

Next, we need to specify that our app handles the `msal[APP ID HERE]` URL type. When the oAuth login process finishes, it redirects to this URL, and the app needs to receive that redirect. Add the following to the manifest, replacing `[APP ID HERE]` with your app ID from the app registration portal.

```xml
<activity android:name="microsoft.identity.client.BrowserTabActivity">
    <intent-filter>
        <action android:name="android.intent.action.VIEW" />
        <category android:name="android.intent.category.DEFAULT" />
        <category android:name="android.intent.category.BROWSABLE" />
        <data android:scheme="msal[APP ID]]" android:host="auth" />
    </intent-filter>
</activity>
```

Your manifest should look like this when you're done:

```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android" android:versionCode="1" android:versionName="1.0" package="com.companyname.PhotoSender" android:installLocation="auto">
	<uses-sdk android:minSdkVersion="15" />
	<uses-permission android:name="android.permission.INTERNET" />
	<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
	<application android:label="PhotoSender.Android">
		<activity android:name="microsoft.identity.client.BrowserTabActivity">
			<intent-filter>
				<action android:name="android.intent.action.VIEW" />
				<category android:name="android.intent.category.DEFAULT" />
				<category android:name="android.intent.category.BROWSABLE" />
				<data android:scheme="msal[APP ID HERE]" android:host="auth" />
			</intent-filter>
		</activity>
	</application>
</manifest>
```

Finally, we need to add code to the Android app's main activity to pass the auth result along to the MSAL library. Open **./PhotoSender.Android/MainActivity.cs** and add the following `using` statement at the top of the file:

```csharp
using Microsoft.Identity.Client;
```

Then add the following function to the `MainActivity` class:

```csharp
protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
{
    base.OnActivityResult(requestCode, resultCode, data);
    AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode,
        resultCode,
        data);
}
```