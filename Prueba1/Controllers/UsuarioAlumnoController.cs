using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Prueba1.Datos;
using Prueba1.Models;

namespace Prueba1.Controllers
{
    public class UsuarioAlumnoController : Controller
    {
        UsuarioAlumnoDatos _usuarioAlumnoDatos = new UsuarioAlumnoDatos();
        public IActionResult Listar()
        {
            var lista = _usuarioAlumnoDatos.Listar();

            return View();
        }

        [HttpGet]

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(UsuarioAlumnoModel model)
        {
            var respuesta = _usuarioAlumnoDatos.CrearUsuarioAlm(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");

            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int IdUsuario)
        {
            UsuarioAlumnoModel _usuario = _usuarioAlumnoDatos.ObtenerUsuario(IdUsuario);
            return View();
        }
        [HttpPost]
        public IActionResult Editar(UsuarioAlumnoModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _usuarioAlumnoDatos.EditarAlm(model);
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
