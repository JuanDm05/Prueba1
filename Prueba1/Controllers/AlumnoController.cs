using Prueba1.Models;
using Prueba1.Datos;
using Microsoft.AspNetCore.Mvc;

namespace Prueba1.Controllers
{
    public class AlumnoController1 : Controller
    {
        AlumnoDatos _alumnoDatos= new AlumnoDatos();
        public IActionResult Listar()
        {
            var lista =  _alumnoDatos.Listar();
            return View();
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult Guardar(AlumnoModel mdoel) 
        {
            var respuesta = _alumnoDatos.GuardarAlumno(mdoel);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
