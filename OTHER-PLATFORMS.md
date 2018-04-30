# Running on Android or iOS

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

Finally, we need to add code to the Android app's main activity to set the UI parent for the login flow, and to pass the auth result along to the MSAL library. Open **./PhotoSender.Android/MainActivity.cs** and add the following `using` statement at the top of the file:

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

Finally, add the following line to the end of the `OnCreate` function:

```csharp
App.AuthUiParent = new UIParent(this);
```

## Running on iOS

MSAL requires additional configuration in the iOS project to work properly. This is documented at https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Xamarin-ios-specificities.

> **NOTE:** There is currently a bug with MSAL on iOS that results in the user's tokens not persisting to the cache. The bug is reported here: https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/issues/546

First, we need to specify that our app handles the `msal[APP ID HERE]` URL type. When the oAuth login process finishes, it redirects to this URL, and the app needs to receive that redirect. Open the **./PhotoSender.iOS/Info.plist** file in Visual Studio, then select the **Advanced** tab. Locate the **URL Types** section and click **Add URL Type**, and fill in the fields as follows:

- **Identifier**: `com.yourcompany.PhotoSender`
- **URL Schemes**: `msal[APP ID HERE]` (Replace `[APP ID HERE]` with your app ID from the app registration portal.)
- **Role**: `Editor`
- **Icon**: Leave blank

Next, we need to add a handler for opening that URL type that forwards the information back to the MSAL library. Open the **./PhotoSender.iOS/AppDelegate.cs** file and add the following `using` statement at the top of the file:

```csharp
using Microsoft.Identity.Client;
```

Then add the following function to the `AppDelegate` class:

```csharp
public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
{
    AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
    return true;
}
```