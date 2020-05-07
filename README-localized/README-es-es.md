---
page_type: sample
products:
- office-outlook
- ms-graph
languages:
- csharp
description: "Aplicación de ejemplo de Xamarin Forms que usa Microsoft Graph"
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
# Ejemplo de Xamarin Forms con Microsoft Graph

## Configuración del ejemplo

### Registrar una aplicación nativa en el Portal de registro de aplicaciones

1. Abra un explorador y vaya al [Portal de Azure: registros de aplicación](https://go.microsoft.com/fwlink/?linkid=2083908) e inicie sesión con una **cuenta personal** (es decir: una cuenta de Microsoft) o una **cuenta profesional o educativa**.
1. Seleccione **Nuevo registro**. 

    ![Una captura de pantalla de los registros de la aplicación ](readme-images/aad-portal-app-registrations.PNG)

1. Cuando aparezca la **página Registrar una aplicación**, escriba la información de registro de la aplicación: 
    - En la sección **Nombre**, escriba un nombre significativo para la aplicación, que se mostrará a los usuarios de la aplicación, por ejemplo, `Xamarin PhotoSender`. 
    - En la sección **Tipos de cuentas compatibles**, seleccione **Cuentas de cualquier directorio de la organización**. 

    ![Una captura de pantalla de la página Registrar una aplicación](readme-images/aad-register-an-app.PNG)

1. Seleccione **Registrar** para crear la aplicación. 
1. En la página **Información general** de la aplicación, busque el valor **Id. de la aplicación (cliente)** y guárdelo para más tarde. Lo necesitará para configurar la aplicación. Identificador para este proyecto. 

    ![Captura de pantalla del ID. de aplicación del nuevo registro de la aplicación](readme-images/aad-application-id.PNG)

### Agregar el ID. de aplicación al proyecto

Reemplace el texto `[APP_ID_HERE]` en los archivos siguientes.

- [App.xaml.cs](./PhotoSender/PhotoSender/App.xaml.cs): Necesario para todas las plataformas
- [AndroidManifest.xml](./PhotoSender/PhotoSender.Android/Properties/AndroidManifest.xml): Solo es necesario si se compila la versión de Android de la aplicación
- [Info.plist](./PhotoSender/PhotoSender.iOS/Info.plist): Solo es necesario si se compila la versión de iOS de la aplicación

## Colaboradores

Este proyecto recibe las contribuciones y las sugerencias.
La mayoría de las contribuciones necesitan un contrato de licencia de colaboración (CLA) que declare que tiene el derecho, y realmente lo tiene, de otorgarnos los derechos para usar su contribución.
Para obtener más información, visite https://cla.microsoft.com.

Cuando envíe una solicitud de incorporación de cambios, un bot de CLA determinará automáticamente si necesita proporcionar un CLA y decorar PR correctamente (por ejemplo, etiqueta, comentario).
Siga las instrucciones proporcionadas por el bot.
Solo debe hacerlo una vez en todos los repos que usen nuestro CLA.

Este proyecto ha adoptado el [Código de conducta de código abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para obtener más información, vea [Preguntas frecuentes sobre el código de conducta](https://opensource.microsoft.com/codeofconduct/faq/)
o póngase en contacto con [opencode@microsoft.com](mailto:opencode@microsoft.com) si tiene otras preguntas o comentarios.

## Copyright

Copyright (c) 2019 Microsoft. Todos los derechos reservados.
