---
page_type: sample
products:
- office-outlook
- ms-graph
languages:
- csharp
description: "Um exemplo do aplicativo Xamarin Forms que usa o Microsoft Graph"
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
# Exemplo de Microsoft Graph do Xamarin Forms

## Configurar o exemplo

### Registre um aplicativo nativo no App Registration Portal

1. Abra um navegador e navegue até o [portal do Azure - Registros de aplicativos](https://go.microsoft.com/fwlink/?linkid=2083908) e faça login usando uma **conta pessoal** (também conhecida como: Conta Microsoft) ou **Conta Corporativa ou de Estudante**.
1. Selecione **Novo registro**. 

    ![Captura de tela dos Registros do aplicativo](readme-images/aad-portal-app-registrations.PNG)

1. Quando a **página Registrar um aplicativo** for exibida, insira as informações de registro do aplicativo: 
    - Na seção **Nome**, insira um nome de aplicativo relevante que será exibido aos usuários do aplicativo, por exemplo, `Xamarin PhotoSender`. 
    - Na seção **Tipos de conta com suporte**, selecione **Contas em qualquer diretório organizacional**. 

    ![Captura de tela da página Registrar um aplicativo](readme-images/aad-register-an-app.PNG)

1. Selecione **Registrar** para criar o aplicativo. 
1. Na página **Visão geral** do aplicativo, encontre o valor de **ID do aplicativo (cliente)** e registre-o para usar mais tarde. Será necessário para configurar o aplicativo. ID desse projeto. 

    ![Captura de tela da ID do aplicativo do novo registro do aplicativo](readme-images/aad-application-id.PNG)

### Adicione a ID do aplicativo ao projeto

Substitua o texto `[APP_ID_HERE]` nos seguintes arquivos.

- [App.xaml.cs](./PhotoSender/PhotoSender/App.xaml.cs): Necessário para todas as plataformas
- [AndroidManifest.xml](./PhotoSender/PhotoSender.Android/Properties/AndroidManifest.xml): Necessário apenas se construir a versão do aplicativo para Android
- [Info.plist](./PhotoSender/PhotoSender.iOS/Info.plist): Necessário apenas se construir a versão do aplicativo para IOS

## Colaboração

Este projeto recebe e agradece as contribuições e sugestões.
A maioria das contribuições exige que você concorde com um Contrato de Licença de Colaborador (CLA) declarando que você tem o direito, e realmente tem, de nos concede os direitos de usar sua contribuição.
Para saber mais, acesse https://cla.microsoft.com.

Ao enviar uma solicitação de pull, um CLA-bot determinará automaticamente se você precisa fornecer um CLA e decorar o PR adequadamente (por exemplo: etiqueta, comentário).
Basta seguir as instruções fornecidas pelo bot.
Você só precisa fazer isso uma vez em todos os repositórios que usam nosso CLA.

Esse projeto adotou o [Código de Conduta de Código Aberto da Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para saber mais, confira as [Perguntas frequentes sobre o Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/)
ou entre em contato pelo [opencode@microsoft.com](mailto:opencode@microsoft.com) se tiver outras dúvidas ou comentários.

## Direitos autorais

Copyright (c) 2019 Microsoft. Todos os direitos reservados.
