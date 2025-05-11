using GitTPPWA2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitTPPWA2025.Controllers
{
    public class ProyectoMascoTienda : Controller
    {
        public IActionResult Index()
        {
            Empresa empresa = new Empresa()
            {
                RazonSocial = "Mascotienda",
                cuit = 237891231
            };


            return View(empresa);
        }
    }
}
