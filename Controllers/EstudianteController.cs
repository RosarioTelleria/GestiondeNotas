using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Authorization;


  public class EstudianteController : Controller
  {
      public IActionResult Index()
      {
        return View();
      }

  public IActionResult Estudiante()
  {
    return View();
  }

  public IActionResult _ListadoDeEstudiantes()
    {
      return View();
    }
  }


