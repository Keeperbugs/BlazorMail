# Blazor Email App

Questa è un'applicazione Blazor per l'invio di email. Utilizza Blazor Server per fornire un'interfaccia interattiva e ASP.NET Core per la logica lato server.

## Requisiti

- .NET 9.0 o versione successiva
- Un editor di testo come Visual Studio Code o Visual Studio
- Un server SMTP configurato per l'invio di email

## Configurazione

1. Clona il repository:
   ```bash
   git clone <URL_DEL_REPOSITORY>
   cd BlazorEmailApp
   ```

2. Configura i file `appsettings.json` e `appsettings.Development.json` con le impostazioni SMTP. Esempio:
   ```json
   {
       "SmtpSettings": {
           "Host": "smtp.example.com",
           "Port": 587,
           "Username": "tuo_username",
           "Password": "tua_password"
       }
   }
   ```

## Avvio dell'applicazione

1. Ripristina i pacchetti NuGet:
   ```bash
   dotnet restore
   ```

2. Avvia l'applicazione:
   ```bash
   dotnet run --project BlazorEmailApp
   ```

3. Apri il browser e vai a `https://localhost:5001`.

## Struttura del progetto

- `Components/`: Contiene i componenti Razor per l'interfaccia utente.
- `Models/`: Contiene i modelli di dati come `EmailMessage` e `SmtpSettings`.
- `Services/`: Contiene i servizi come `EmailService` per l'invio di email.
- `wwwroot/`: Contiene file statici come CSS e immagini.

## Contributi

I contributi sono benvenuti! Sentiti libero di aprire una pull request o segnalare un problema.

## Licenza

Questo progetto è distribuito sotto la licenza MIT. Consulta il file LICENSE per ulteriori dettagli.
