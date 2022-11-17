using JsonDataManager.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<RobotService>(client =>
{
    client.BaseAddress = new Uri("https://randomuser.me/api/");
});
builder.Services.AddHttpClient<CrimeService>();
builder.Services.AddSingleton<WageService>();
builder.Services.AddSingleton<ApiCallerService>();
builder.Services.AddSingleton<RobotService>();
builder.Services.AddSingleton<CrimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
