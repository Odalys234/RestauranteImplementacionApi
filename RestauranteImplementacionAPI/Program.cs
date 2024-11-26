using Microsoft.AspNetCore.Authentication.Cookies;
using RestauranteImplementacionAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<HttpClient>(o =>
new HttpClient {BaseAddress = new Uri("http://localhost:5183/")
});


// Configuración para la autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login"; 
        options.LogoutPath = "/Auth/Logout";  
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
        options.SlidingExpiration = true; 
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter; 
    });

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<PlatilloService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<PuestoService>();
builder.Services.AddScoped<EmpleadoService>();


builder.Services.AddHttpClient();  

// Configuración de controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
}


app.UseStaticFiles();
app.UseRouting();
  app.UseStaticFiles(); 
// Configuramos la autenticación y autorización
app.UseAuthentication();  
app.UseAuthorization();

// Definimos las rutas de la aplicación
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
