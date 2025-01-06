using Microsoft.EntityFrameworkCore;
using MvcCv.Data;
using MvcCv.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

var builder = WebApplication.CreateBuilder(args);

// Baðlantý dizesi ile veritabaný baðlantýsýný yapýlandýrýyoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository'leri ekliyoruz
builder.Services.AddScoped<DeneyimRepository>();
builder.Services.AddScoped<YetenekRepository>();
builder.Services.AddScoped<EgitimRepository>();
builder.Services.AddScoped<SertifikaRepository>();
builder.Services.AddScoped<IletisimRepository>();
builder.Services.AddScoped<HobilerimRepository>();
builder.Services.AddScoped<HakkimdaRepository>();

// Session'ý ve Cache'i yapýlandýrýyoruz
builder.Services.AddDistributedMemoryCache(); // Cache kullanmak için
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);  // Oturum süresi
	options.Cookie.HttpOnly = true;  // Sadece HTTP üzerinden eriþim
	options.Cookie.IsEssential = true;  // Çerezlerin gerekli olduðunu belirt
});

// Authentication (kimlik doðrulama) ve Authorization (yetkilendirme) middleware'lerini ekliyoruz
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Index"; // Giriþ sayfasýna yönlendirme
		options.AccessDeniedPath = "/Home/AccessDenied"; // Eriþim engellendi sayfasý
	});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session ve kimlik doðrulama middleware'lerini sýrasýyla ekliyoruz
app.UseAuthentication(); // Kimlik doðrulama iþlemi
app.UseAuthorization();  // Yetkilendirme iþlemi
app.UseSession();  // Session yönetimi

// Default route mapping
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
