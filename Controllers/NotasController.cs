using AspnetCoreMvcFull.DB;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  public class NotasController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult Evaluaciones()
    {
      var estudiantes = new List<Estudiantes>
      {
            new Estudiantes { IdEstudiante = 8, Nombre = "Alejandro Flores", Email = "alejandro.flores@ejemplo.edu"},
            new Estudiantes { IdEstudiante = 1, Nombre = "Ana García", Email = "ana.garcia@ejemplo.edu"},
            new Estudiantes { IdEstudiante = 2, Nombre = "Carlos Rodríguez", Email = "carlos.rodriguez@ejemplo.edu"},
            new Estudiantes { IdEstudiante = 6, Nombre = "Diego Sánchez", Email = "diego.sanchez@ejemplo.edu"},
            new Estudiantes { IdEstudiante = 4, Nombre = "Juan Martínez", Email = "juan.martinez@ejemplo.edu"},
            new Estudiantes { IdEstudiante = 3, Nombre = "María López", Email = "maria.lopez@ejemplo.edu"}
        };

      return View(estudiantes);
    }
    public IActionResult Conducta()
    {
      return View();
    }
    public IActionResult SabanaDeCalificaciones()
    {
      return View();
    }
    public IActionResult PromedioGlobal()
    {
      return View();
    }
  }
}
