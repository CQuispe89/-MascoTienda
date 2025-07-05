using GitTPPWA2025.DAL;
using GitTPPWA2025.Data;
using GitTPPWA2025.Models;
using GitTPPWA2025.ModelsEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                      .Include(p => p.IdCategoriaNavigation)
                      .ToList();

            return View("ProductoFoto", list); // Asegurate que el modelo en la vista es List<Producto>
        }
        [HttpGet]
        public IActionResult Crear()
        {
            var modelo = new ProductoVM
            {
                ListaCategorias = context.Categoria.Select(c => new SelectListItem
                {
                    Value = c.IdCategoria.ToString(),
                    Text = c.CategoriaAnimal
                }).ToList()
            };

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Crear(ProductoVM modeloProducto)
        {
            if (!ModelState.IsValid)
                return View(modeloProducto);

            // 1. Guardar la imagen
            string nombreArchivo = UploadFile(modeloProducto);

            // 2. Crear el producto
            Producto producto = new Producto
            {
                Descripcion = modeloProducto.Descripcion,
                Precio = modeloProducto.Precio,
                ImagenProducto = nombreArchivo, // opcional, si querés guardar imagen principal
                IdCategoria = modeloProducto.IdCategoria
            };

            context.Productos.Add(producto);
            context.SaveChanges(); // necesario para generar IdProducto

            // 3. Crear la foto asociada al producto
            ProductoFoto foto = new ProductoFoto
            {
                Foto = nombreArchivo,
                IdProducto = producto.IdProducto
            };

            context.ProductoFotos.Add(foto);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        private Producto EncontrarProducto(int id)
        {
            return context.Productos
        .Include(p => p.Fotos)          // Incluye fotos asociadas
        .Include(p => p.IdCategoriaNavigation) // Incluye la relación con Categorium
        .FirstOrDefault(p => p.IdProducto == id);
        }

        [HttpGet]
        public IActionResult Actualizar(int id)
        {
         var producto = EncontrarProducto(id);
         if (producto == null)
         return NotFound();

        ProductoVM vm = new ProductoVM
        {
        IdProducto = producto.IdProducto,
        Descripcion = producto.Descripcion,
        Precio = producto.Precio,
        IdCategoria = producto.IdCategoria,
        
        ImagenActual = producto.ImagenProducto,
        ListaCategorias = ObtenerCategorias()
        };

        return View(vm); // busca Actualizar.cshtml
        }
        
        private List<SelectListItem> ObtenerCategorias()
        {
            return context.Categoria
                          .Select(c => new SelectListItem
                          {
                              Value = c.IdCategoria.ToString(),
                              Text = c.CategoriaAnimal
                          })
                          .ToList();
        }



        [HttpPost]
        public IActionResult Actualizar(ProductoVM modeloProducto)
        {
            if (!ModelState.IsValid)
            {
                // Volver a cargar las categorías por si hubo errores de validación
                modeloProducto.ListaCategorias = context.Categoria
                    .Select(c => new SelectListItem { Value = c.IdCategoria.ToString(), Text = c.CategoriaAnimal })
                    .ToList();

                return View(modeloProducto);
            }

            var producto = context.Productos.Include(p => p.Fotos)
                .FirstOrDefault(p => p.IdProducto == modeloProducto.IdCategoria);

            if (producto == null)
                return NotFound();

            producto.Descripcion = modeloProducto.Descripcion;
            producto.Precio = modeloProducto.Precio;
            producto.IdCategoria = modeloProducto.IdCategoria;

            if (modeloProducto.FotoPath != null && modeloProducto.FotoPath.Length > 0)
            {
                string nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(modeloProducto.FotoPath.FileName);
                string rutaGuardar = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagenes", nombreArchivo);

                using (var stream = new FileStream(rutaGuardar, FileMode.Create))
                {
                    modeloProducto.FotoPath.CopyTo(stream);
                }

                producto.ImagenProducto = nombreArchivo;
            }

            context.SaveChanges();

            return RedirectToAction("Index");



        }

        [HttpGet]
        public IActionResult Eliminar(int IdProducto)
        {
            Producto producto = EncontrarProducto(IdProducto);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto modeloProducto)
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == modeloProducto.IdProducto);
            if (producto == null)
                return NotFound();

            context.Productos.Remove(producto);
            context.SaveChanges();

            return RedirectToAction("Index", "Producto");
        }

    }
}
