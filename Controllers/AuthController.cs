using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Identity;

namespace AspnetCoreMvcFull.Controllers;

public class AuthController : Controller
{
  private readonly UserManager<IdentityUser> _userManager;
  private readonly SignInManager<IdentityUser> _signInManager;
  private readonly ILogger<AuthController> _logger;

  public AuthController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,ILogger<AuthController> logger)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _logger = logger;
  }
  public IActionResult ForgotPasswordBasic() => View();
  public IActionResult LoginBasic() => View();

  [HttpPost]
  public async Task<IActionResult> Login(string username, string password, bool rememberMe)
  {
    var user = await _userManager.FindByNameAsync(username);
    if (user != null && await _userManager.CheckPasswordAsync(user, password))
    {
      await _signInManager.SignInAsync(user, isPersistent: rememberMe);
      return Json(new { success = true, message = "Inicio de sesión exitoso" });
    }

    return Json(new { success = false, message = "Intento de inicio de sesión fallido" });
  }
  public IActionResult RegisterBasic() => View();

  // Acción para registrar un nuevo usuario
  [HttpPost]
  public async Task<IActionResult> Register(string username, string password)
  {
    var user = new IdentityUser { UserName = username };
    var result = await _userManager.CreateAsync(user, password);

    if (result.Succeeded)
    {
      await _signInManager.SignInAsync(user, isPersistent: false);
      return Json(new { success = true, message = "Usuario registrado correctamente" });
    }
    foreach (var error in result.Errors)
    {
      ModelState.AddModelError(string.Empty, error.Description);
    }
    return Json(new { success = false, message = "error al crear al usuario" });
  }
}
