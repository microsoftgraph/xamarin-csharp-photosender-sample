---
page_type: sample
products:
- office-outlook
- ms-graph
languages:
- csharp
description: "Microsoft Graph を使用した Xamarin Forms アプリのサンプル"
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
# Xamarin Forms Microsoft Graph のサンプル

## サンプルを構成する

### ネイティブ アプリケーションをアプリ登録ポータルに登録する

1. ブラウザーを開き、[Azure ポータル - アプリ登録](https://go.microsoft.com/fwlink/?linkid=2083908)に移動し、**個人用アカウント** (別名:Microsoft アカウント) か**職場または学校のアカウント**を使用してログインします。
1. [**新規登録**] を選択します。 

    ![アプリの登録のスクリーンショット ](readme-images/aad-portal-app-registrations.PNG)

1. [**アプリケーションの登録ページ**] が表示されたら、以下のアプリケーションの登録情報を入力します。 
    - [**名前**] セクションに、アプリのユーザーに表示されるわかりやすいアプリケーション名を入力します (例: `Xamarin PhotoSender`)。 
    - [**サポート対象のアカウントの種類**] セクションで、[**任意の組織ディレクトリのアカウント**] を選択します。 

    ![[アプリケーションの登録] ページのスクリーンショット](readme-images/aad-register-an-app.PNG)

1. [**登録**] を選択して、アプリケーションを作成します。 
1. アプリの [**概要**] ページで、[**Application (client) ID**] (アプリケーション (クライアント) ID) の値を確認し、後で使用するために記録します。この値はアプリの構成に必要になります。このプロジェクトの ID になります。 

    ![新しいアプリ登録のアプリケーション ID のスクリーンショット](readme-images/aad-application-id.PNG)

### アプリケーション ID をプロジェクトに追加する

次のファイルのテキスト `[APP_ID_HERE]` を置き換えます。

- [App.xaml.cs](./PhotoSender/PhotoSender/App.xaml.cs):すべてのプラットフォームで必須
- [AndroidManifest.xml](./PhotoSender/PhotoSender.Android/Properties/AndroidManifest.xml):Android 版アプリを構築する場合にのみ必須
- [Info.plist](./PhotoSender/PhotoSender.iOS/Info.plist):iOS 版アプリを構築する場合にのみ必須

## 投稿

このプロジェクトは投稿や提案を歓迎します。
たいていの投稿には、投稿者のライセンス契約 (CLA) に同意することにより、投稿内容を使用する権利を Microsoft に付与する権利が自分にあり、実際に付与する旨を宣言していただく必要があります。
詳細については、https://cla.microsoft.com をご覧ください。

プル要求を送信すると、CLA を提供して PR を適切に修飾する (ラベル、コメントなど) 必要があるかどうかを CLA ボットが自動的に判断します。
ボットの指示に従ってください。
すべてのリポジトリに対して 1 度のみ、CLA を使用してこれを行う必要があります。

このプロジェクトでは、[Microsoft Open Source Code of Conduct (Microsoft オープン ソース倫理規定)](https://opensource.microsoft.com/codeofconduct/) が採用されています。
詳細については、「[倫理規定の FAQ](https://opensource.microsoft.com/codeofconduct/faq/)」を参照してください。
また、その他の質問やコメントがあれば、[opencode@microsoft.com](mailto:opencode@microsoft.com) までお問い合わせください。

## 著作権

Copyright (c) 2019 Microsoft.All rights reserved.
