using Microsoft.EntityFrameworkCore;
using MvcCv.Data;
using MvcCv.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DeneyimRepository>();
builder.Services.AddScoped<YetenekRepository>();
builder.Services.AddScoped<EgitimRepository>();
builder.Services.AddScoped<SertifikaRepository>();
builder.Services.AddScoped<IletisimRepository>();
builder.Services.AddScoped<HobilerimRepository>();
builder.Services.AddScoped<HakkimdaRepository>();

builder.Services.AddDistributedMemoryCache(); // Cache kullanmak için
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);  // Oturum süresi
	options.Cookie.HttpOnly = true;  // Sadece HTTP üzerinden eriþim
	options.Cookie.IsEssential = true;  // Çerezlerin gerekli olduðunu belirt
});


// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
