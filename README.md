# totalvoice-csharp
Client C# para a API da TotalVoice

> ### Funcionalidades

- [X] Gerenciamento das chamadas
- [X] Consulta e envio de SMS
- [X] Consulta e envio de TTS
- [X] Consulta e envio de Audio
- [X] Gerenciamento da Conta
- [X] Gerenciamento de Ramais
- [X] URL do Webphone
- [X] Gerenciamento de DID

> ### Pré requisitos

- .NET 4.5
- Nuget

> ### Utilização

Para utilizar esta biblioteca, primeiramente você deverá realizar um cadastro no site da [Total Voice](http://www.totalvoice.com.br).
Após a criação do cadastro será disponibilizado um AccessToken para acesso a API.

Com o AccessToken em mãos será possível realizar as consultas/cadastros conforme documentação da [API](https://api.totalvoice.com.br/doc/#/)

> #### Instalando com o gerenciador de pacotes [Nuget](https://www.nuget.org/packages/TotalVoice/) 

```
PM> Install-Package TotalVoice -Version 1.0.1
```
ou .NET CLI

```
dotnet add package TotalVoice --version 1.0.1
```


> ### Licença

Esta biblioteca segue os termos de uso da [MIT](https://github.com/totalvoice/totalvoice-csharp/blob/master/LICENSE)
