
using Nika1337.Library.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Nika1337.Library.Infrastructure.Mapping;
using Nika1337.Library.Presentation.Mapping;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureServices(builder.Configuration);


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/EmployeeAccount/SignIn";
    options.LogoutPath = "/EmployeeAccount/SignOut";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build());

var presentationAssembly = typeof(Nika1337.Library.Presentation.AssemblyReference).Assembly;

builder.Services.AddControllersWithViews()
    .AddApplicationPart(presentationAssembly);

builder.Services.AddAutoMapper(
    typeof(EmployeeMappingProfile),
    typeof(EmailTemplateMappingProfile),
    typeof(EmployeeViewModelMappingProfile),
    typeof(EmailTemplateViewModelMappingProfile));


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/SomethingWentWrong");
    app.UseStatusCodePagesWithReExecute("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "..", "Presentation", "wwwroot"))
});

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
