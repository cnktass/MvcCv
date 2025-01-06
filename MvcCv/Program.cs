using Microsoft.EntityFrameworkCore;
using MvcCv.Data;
using MvcCv.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

var builder = WebApplication.CreateBuilder(args);

// Ba�lant� dizesi ile veritaban� ba�lant�s�n� yap�land�r�yoruz
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

// Session'� ve Cache'i yap�land�r�yoruz
builder.Services.AddDistributedMemoryCache(); // Cache kullanmak i�in
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);  // Oturum s�resi
	options.Cookie.HttpOnly = true;  // Sadece HTTP �zerinden eri�im
	options.Cookie.IsEssential = true;  // �erezlerin gerekli oldu�unu belirt
});

// Authentication (kimlik do�rulama) ve Authorization (yetkilendirme) middleware'lerini ekliyoruz
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Index"; // Giri� sayfas�na y�nlendirme
		options.AccessDeniedPath = "/Home/AccessDenied"; // Eri�im engellendi sayfas�
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

// Session ve kimlik do�rulama middleware'lerini s�ras�yla ekliyoruz
app.UseAuthentication(); // Kimlik do�rulama i�lemi
app.UseAuthorization();  // Yetkilendirme i�lemi
app.UseSession();  // Session y�netimi

// Default route mapping
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
