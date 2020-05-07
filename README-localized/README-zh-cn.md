---
page_type: sample
products:
- office-outlook
- ms-graph
languages:
- csharp
description: "使用 Microsoft Graph 的示例 Xamarin Forms 应用程序"
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  services:
  - Outlook 
  - Users
  platforms:
  - Xamarin
  createdDate: 4/26/2018 1:35:59 PM
---
# Xamarin Forms Microsoft Graph 示例

## 配置示例

### 在 App Registration 门户中注册本机应用程序

1. 打开浏览器，并导航到 [Azure 门户 – 应用程序注册](https://go.microsoft.com/fwlink/?linkid=2083908)，然后使用**个人帐户**（亦称为：“Microsoft 帐户”）或**工作/学校帐户**登录。
1. 选择“**新注册**”。 

    ![“应用注册”的屏幕截图](readme-images/aad-portal-app-registrations.PNG)

1. 出现“**注册应用程序页**”后，输入应用程序的注册信息： 
    - 在“**名称**”部分输入一个会显示给应用用户的有意义的应用程序名称，例如 `Xamarin PhotoSender`。 
    - 在“**受支持的帐户类型**”部分，选择“**任何组织目录中的帐户**”。 

    ![注册应用程序”页的屏幕截图](readme-images/aad-register-an-app.PNG)

1. 选择“**注册**”以创建应用程序。 
1. 在应用的“**概述**”页上，查找“**应用程序(客户端) ID**”值，并稍后记录下来。你将需要它来配置应用。此项目的 Id。 

    ![新应用注册的应用程序 ID 的屏幕截图](readme-images/aad-application-id.PNG)

### 添加应用程序 ID 至项目

在下列文件中替换文本 `[APP_ID_HERE]`。

- [App.xaml.cs](./PhotoSender/PhotoSender/App.xaml.cs):所有平台必填项
- [AndroidManifest.xml](./PhotoSender/PhotoSender.Android/Properties/AndroidManifest.xml)：仅限在生成 Android 版本应用程序时需要
- [Info.plist](./PhotoSender/PhotoSender.iOS/Info.plist):仅限在生成 iOS 版本应用程序时需要

## 参与

本项目欢迎供稿和建议。
大多数的供稿都要求你同意“参与者许可协议 (CLA)”，声明你有权并确定授予我们使用你所供内容的权利。
有关详细信息，请访问 https://cla.microsoft.com。

在提交拉取请求时，CLA 机器人会自动确定你是否需要提供 CLA 并适当地修饰 PR（例如标记、批注）。
只需按照机器人提供的说明操作即可。
只需在所有存储库上使用我们的 CLA 执行此操作一次。

此项目已采用 [Microsoft 开放源代码行为准则](https://opensource.microsoft.com/codeofconduct/)。
有关详细信息，请参阅[行为准则常见问题解答](https://opensource.microsoft.com/codeofconduct/faq/)。
如有其他任何问题或意见，也可联系 [opencode@microsoft.com](mailto:opencode@microsoft.com)。

## 版权信息

版权所有 (c) 2019 Microsoft。保留所有权利。
