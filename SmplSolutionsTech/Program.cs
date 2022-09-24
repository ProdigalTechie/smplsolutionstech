using Microsoft.Extensions.Options;
using SmplSolutionsTech;
using SmplSolutionsTech.Extentions;
using SmplSolutionsTech.Helpers.Classes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddHttpsRedirection(x => x.HttpsPort = 443);
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<Config>(builder.Configuration.GetSection("Config"));
builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<Config>>().Value);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IEmailHelper, EmailHelper>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
