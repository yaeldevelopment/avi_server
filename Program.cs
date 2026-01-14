using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policyBuilder =>
    {
        policyBuilder.WithOrigins("https://avinoam.netlify.app") // בלי '/' בסוף
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
});

// Register EmailService and bind SMTP settings
builder.Services.Configure<WebApplication14.Services.SmtpSettings>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddSingleton<WebApplication14.Services.IEmailService, WebApplication14.Services.EmailService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Swagger תמיד זמין (אם תרצה רק ב־Development אפשר להחזיר את ה־if)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");
    c.RoutePrefix = "swagger";
});

app.UseRouting();

// Enable CORS (לאחר Routing)
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0:8080");
