using Blazored.Modal;
using EmployeeInfo.Data;
using EmployeeInfo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazorBootstrap();

builder.Services.AddDbContext<EmployeeInfoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyDbConnection"),
        b => b.MigrationsAssembly("EmployeeInfo")), ServiceLifetime.Scoped);


//builder.Services.AddScoped<NpgsqlConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("MyDbConnection")));

builder.Services.AddTransient<IEmployeeService, EmployeeService>();


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
