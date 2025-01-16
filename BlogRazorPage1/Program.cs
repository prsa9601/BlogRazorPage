using BlogRazorPage.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



    //builder.Services.AddAuthentication(options =>
    //{
    //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //})
    //.AddJwtBearer(options =>
    //{
    //    options.TokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuer = true,
    //        ValidateAudience = true,
    //        ValidateLifetime = true,
    //        ValidateIssuerSigningKey = true,
    //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
    //        ValidAudience = builder.Configuration["Jwt:Audience"],
    //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
    //    };
    //});

    //builder.Services.AddRazorPages();


// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.RegisterApiServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization(option =>
{
    //option.AddPolicy("Account", builder =>
    //{
    //    builder.RequireAuthenticatedUser();
    //});
    option.AddPolicy("SellerPanel", builder =>
    {
        builder.RequireAuthenticatedUser();
        builder.RequireAssertion(f => f.User.Claims
            .Any(c => c.Type == ClaimTypes.Role && c.Value.Contains("Seller")));
    });
});

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation()
    .AddRazorPagesOptions(options =>
    {
       // options.Conventions.AuthorizeFolder("/Profile", "Account");
        options.Conventions.AuthorizeFolder("/SellerPanel", "SellerPanel");
    });

//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//});
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SignInKey"])),
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["token"]?.ToString();
    if (string.IsNullOrWhiteSpace(token) == false)
    {
        context.Request.Headers.Append("Authorization", $"Bearer {token}");
    }
    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.Use(async (context, next) =>
{
    await next();
    var status = context.Response.StatusCode;
    if (status == 401)
    {
        var path = context.Request.Path;
        context.Response.Redirect($"../../../../Auth/Login?redirectTo={path}");
    }
    //else if (status == 404)
    //{
    //    var path = context.Request.Path;
    //    context.Response.Redirect($"../../../../auth/login?redirectTo={path}");
    //}
});
app.UseAuthentication();


//app.UseAuthorization();
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Default", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapAreaControllerRoute(name: "AdminPanel",areaName:"Admin1", pattern: "CodeYad{controller-Home}/{action-Index}/{id?}");
});
app.MapRazorPages();

app.Run();
