using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccess;
using DataAccess.Repository;
using Service;
using Microsoft.Extensions.Caching.Memory;
using ObjectModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAcountRepository, AcountRepository>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ITokenService,TokenService>();

builder.Services.AddDbContext<DbContextBase>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")

    ).EnableSensitiveDataLogging(true)
           .EnableDetailedErrors(true)
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
           .LogTo(Console.WriteLine, LogLevel.Information));
builder.Services.AddMemoryCache();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ClockSkew = TimeSpan.Zero
            };
        });

builder.Services.AddRazorPages();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<DbContextBase>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthentication();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Use(async (context, next) =>
{
    // Check if token exists in cache
    if (context.Request.Path != "/login" && context.Request.Path != "/register")
    {
        var cache = context.RequestServices.GetService<IMemoryCache>();
        var token = cache.Get<string>("Token");
        if (!string.IsNullOrEmpty(token))
        {
            context.Request.Headers.Add("Authorization", "Bearer " + token);
        }
    }

    await next();
});

app.Run();
