using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")
    
    ));
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//        .AddJwtBearer(options =>
//        {
//            options.RequireHttpsMetadata = false;
//            options.SaveToken = true;
//            options.TokenValidationParameters = new TokenValidationParameters
//            {
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
//                ValidateIssuer = true,
//                ValidIssuer = builder.Configuration["Jwt:Issuer"],
//                ValidateAudience = true,
//                ValidAudience = builder.Configuration["Jwt:Audience"],
//                ClockSkew = TimeSpan.Zero
//            };
//        });
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseAuthentication();
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();
//});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//app.Use(async (context, next) =>
//{
//    var token = context.Session.GetString("Token");
//    if (!string.IsNullOrEmpty(token))
//    {
//        context.Request.Headers.Add("Authorization", "Bearer " + token);
//    }
//    await next();
//});

app.Run();
