# Xamarin Forms Microsoft Graph Sample

## Configure the sample

### Register a native application in the App Registration Portal

1. Open a browser and navigate to the [Application Registration Portal](https://apps.dev.microsoft.com) and login using a **personal account** (aka: Microsoft Account) or **Work or School Account**.

1. Select **Add an app** at the top of the page.

    > **Note:** If you see more than one **Add an app** button on the page, select the one that corresponds to the **Converged apps** list.

1. On the **Register your application** page, set the **Application Name** to **Xamarin PhotoSender** and select **Create**.

1. On the **Xamarin PhotoSender Registration** page, under the **Properties** section, copy the **Application Id** as you will need it later.

1. Scroll down to the **Platforms** section.

    1. Select **Add Platform**.
    1. In the **Add Platform** dialog, select **Native Application**.

1. Scroll to the bottom of the page and select **Save**.

### Add the application ID to the project

Replace the text `[APP_ID_HERE]` in the following files.

- [App.xaml.cs](./PhotoSender/PhotoSender/App.xaml.cs): Required for all platforms
- [AndroidManifest.xml](./PhotoSender/PhotoSender.Android/Properties/AndroidManifest.xml): Only required if building the Android version of the app
- [Info.plist](./PhotoSender/PhotoSender.iOS/Info.plist): Only required if building the iOS version of the app

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
