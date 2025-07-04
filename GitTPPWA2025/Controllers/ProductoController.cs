using GitTPPWA2025.DAL;
using GitTPPWA2025.Data;
using GitTPPWA2025.Models;
using GitTPPWA2025.ModelsEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GitTPPWA2025.Controllers
{
    public class ProductoController : Controller
    {
        private readonly MascoTiendaContext context;
        private readonly IWebHostEnvironment webHostEnvironment;


        public ProductoController(MascoTiendaContext _context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = _context;
            this.webHostEnvironment = webHostEnvironment;
        }
        

        public string UploadFile(ProductoVM modeloProducto)
        {
            string nombreArchivo = null;
            if (modeloProducto.FotoPath != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "imag_productos");
                nombreArchivo = Guid.NewGuid().ToString() + "-" + modeloProducto.FotoPath.FileName;
                string rutaArchivo = Path.Combine(uploadDir, nombreArchivo);

                using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    modeloProducto.FotoPath.CopyTo(fileStream);
                }
            }

            return nombreArchivo;


        }
        public IActionResult Index()
        {
            var list = context.Productos
                      .Include(p => p.Fotos)
                      .ToList();

            return View("ProductoFoto",list); // Asegurate que el modelo en la vista es List<Producto>
        }

    }
}
