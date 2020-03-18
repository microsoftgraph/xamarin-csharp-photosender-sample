---
page_type: sample
products:
- office-outlook
- ms-graph
languages:
- csharp
description: "Exemple d’application Formulaires Xamarin qui utilise les extensions Microsoft Graph"
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
# Exemples Xamarin Forms Microsoft Graph

## Configurer l’exemple

### Enregistrer une application native dans le portail d’inscription des applications

1. Ouvrez un navigateur, accédez au [portail Azure - Inscriptions des applications](https://go.microsoft.com/fwlink/?linkid=2083908) et connectez-vous à l’aide d’un **compte personnel** (ou compte Microsoft) ou d’un **compte professionnel ou scolaire**.
1. Sélectionnez **Nouvelle inscription**. 

    ![Capture d’écran des inscriptions d’applications ](readme-images/aad-portal-app-registrations.PNG)

1. Lorsque la **page Inscrire une application** s’affiche, saisissez les informations d’inscription de votre application : 
    - Dans la section **Nom**, saisissez un nom d’application cohérent qui s’affichera pour les utilisateurs de l’application, par exemple `Xamarin PhotoSender`. 
    - Dans la section **Types de comptes pris en charge**, sélectionnez **Comptes dans un annuaire organisationnel**. 

    ![Capture d’écran de la page Inscrire une application](readme-images/aad-register-an-app.PNG)

1. Sélectionnez **S’inscrire** pour créer l’application. 
1. Sur la page **Vue d’ensemble** de l’application, notez la valeur **ID d’application (client)** et conservez-la pour plus tard. Vous en aurez besoin pour configurer l’application. ID de ce projet. 

    ![Une capture d’écran de l’ID d’application de la nouvelle inscription d'application](readme-images/aad-application-id.PNG)

### Ajouter l’ID de l’application au projet

Remplacez le texte `[APP_ID_HERE]` dans les fichiers suivants.

- [App.xaml.cs](./PhotoSender/PhotoSender/App.xaml.cs) : Obligatoire pour toutes les plateformes
- [AndroidManifest.xml](./PhotoSender/PhotoSender.Android/Properties/AndroidManifest.xml) : Obligatoire uniquement si vous créez la version Android de l’application
- [Info.plist](./PhotoSender/PhotoSender.iOS/Info.plist) : Obligatoire uniquement si vous créez la version iOS de l’application

## Contribution

Ce projet autorise les contributions et les suggestions.
Pour la plupart des contributions, vous devez accepter le contrat de licence de contributeur (CLA, Contributor License Agreement) stipulant que vous êtes en mesure, et que vous vous y engagez, de nous accorder les droits d’utiliser votre contribution.
Pour plus d’informations, visitez https://cla.microsoft.com.

Lorsque vous soumettez une requête de tirage, un robot CLA détermine automatiquement si vous devez fournir un CLA et si vous devez remplir la requête de tirage appropriée (par exemple, étiquette, commentaire).
Suivez simplement les instructions données par le robot.
Vous ne devrez le faire qu’une seule fois au sein de tous les référentiels à l’aide du CLA.

Ce projet a adopté le [code de conduite Open Source de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Pour en savoir plus, reportez-vous à la [FAQ relative au code de conduite](https://opensource.microsoft.com/codeofconduct/faq/)
ou contactez [opencode@microsoft.com](mailto:opencode@microsoft.com) pour toute question ou tout commentaire.

## Copyright

Copyright (c) 2019 Microsoft. Tous droits réservés.
