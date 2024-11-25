using Microsoft.AspNetCore.Mvc;
using RestauranteImplementacionAPI.Models;
using RestauranteImplementacionAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestauranteImplementacionAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public AuthController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                // Autenticar al usuario
                var result = await _usuarioService.LoginAsync(login);

                if (result)
                {
                    // Si la autenticación fue exitosa
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, login.Username),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true 
                    };

                    // Emitir la cookie de autenticación
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Si la autenticación falla, agregar el mensaje de error
                    TempData["ErrorMessage"] = "Usuario o contraseña incorrectos.";
                }

                // Si el login falla, muestra un error
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
            }

            return View(login);  // Si hay un error, vuelve a la vista de login
        }  
       
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Eliminar la cookie de autenticación
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirigir al login después de cerrar sesión
            return RedirectToAction("Login", "Auth");
        }
        
    }
}
