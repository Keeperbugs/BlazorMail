using BlazorEmailApp.Components;
using BlazorEmailApp.Models;
using BlazorEmailApp.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register the email service
builder.Services.AddScoped<IEmailService, EmailService>();

// Configure SMTP settings from appsettings.json
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Middleware per verificare la registrazione del servizio
app.Use(async (context, next) =>
{
    var emailService = context.RequestServices.GetService<IEmailService>();
    if (emailService == null)
    {
        Console.WriteLine("Errore: IEmailService non è stato registrato correttamente.");
    }
    else
    {
        Console.WriteLine("IEmailService è stato registrato correttamente.");
    }

    await next.Invoke();
});

app.Run();
