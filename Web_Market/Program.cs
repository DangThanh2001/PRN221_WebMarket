using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataAccess;
using DataAccess.Repository;
using Service;
using Microsoft.Extensions.Caching.Memory;
using ObjectModel;
using Web_Market.MiddleWare;
using DataAccess.IRepositotry;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IAcountRepository, AcountRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProduct_DetailRepository, Product_DetailRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<Product_DetailService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddSingleton<ITokenService,TokenService>();

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
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
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
app.UseMiddleware<AuthenticationMiddleware>();

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

app.Run();
