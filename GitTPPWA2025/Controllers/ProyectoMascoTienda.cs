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

            var filiales = ObtenerFiliales().Take(3).ToList();
            var productos = ObtenerProductos().Take(3).ToList();
            var accesorios = ObtenerAccesorios().Take(4).ToList();

            var modelo = new PorfolioVM()
            {
                empresa = empresa,
                filials = filiales,
                productos = productos,
                accesorios = accesorios
            };


            return View(modelo);

        }

        public IActionResult ListaProductos() 
        {
            var productos = ObtenerProductos();
            return View("Productos", productos); 
        }

        public IActionResult ListaAccesorios() 
        {
            var accesorios = ObtenerAccesorios();
            return View("Productos", accesorios); 
        }
        
        public IActionResult ListadoFiliales()
        {
            var filiales = ObtenerFiliales().Take(3).ToList();
            return View(filiales);

        }
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contacto(Contacto contacto)
        {
            return RedirectToAction("Respuesta");

        }
        public IActionResult Respuesta()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Alerta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Alerta(string razonSocial)
        {
            if (string.IsNullOrWhiteSpace(razonSocial))
            {
                TempData["AlertMessage"] = "Debe ingresar la Razón Social.";
                return RedirectToAction("Index");
            }
            TempData["AlertMessage"] = $"Razón Social ingresada: {razonSocial}";
            return RedirectToAction("Index");
        }
        public IActionResult Promociones()
        {
            return View();
        }
        private List<Filial> ObtenerFiliales()
        {
            return new List<Filial> {
             new Filial
             {
                 Numero=22,
                 Ciudad="Santa Fe",
                 Imagen ="/imag/imag_SantaFe2.jpg",
                 Detalle="Nuestra sede en Santa Fe se encuentra en una ubicación estratégica para ofrecerte una atención rápida y personalizada. Contamos con un equipo capacitado para brindarte los mejores productos y asesoramiento profesional."
             },
               new Filial
             {
                 Numero=33,
                 Ciudad="Mendoza",
                 Imagen ="/imag/imag_Mendoza2.jpg",
                 Detalle="En Mendoza, te esperamos con una amplia variedad de productos para el cuidado y bienestar de tus mascotas. Además, ofrecemos servicios de peluquería y consultas veterinarias con turnos programados."
             },
               new Filial
             {
                 Numero=66,
                 Ciudad="Rio Negro",
                 Imagen ="/imag/imag_RioNegro_Ani.jpg",
                 Detalle="Nuestra sucursal en Tierra del Fuego está equipada para acompañarte durante todo el año. Ofrecemos productos especializados para climas fríos y atención dedicada a cada necesidad de tu mascota."

             },

            };
        }

        private List<Producto> ObtenerProductos()
        {
            return new List<Producto> {
             new Producto
             {
                 Código=2390,
                 Descripción="Pro Plan Adulto 20k",
                 ImagenProducto ="/imag_productos/PoplanAdulto_20k.jpg",
                 Precio=78.00f,
                 CategoriaAnimal = "Perro"
             },
               new Producto
             {
                 Código=1456,
                 Descripción="Pro Plan Puppy 3k",
                 ImagenProducto ="/imag_productos/ProplaPuppy_3k.jpg",
                 Precio=39.80f,
                 CategoriaAnimal = "Perro"
             },
                new Producto
             {
                 Código=8907,
                 Descripción="Pro Plan Reducido Calorías 3k",
                 ImagenProducto ="/imag_productos/ProplanOtros_3k.jpg",
                 Precio=48.00f,
                 CategoriaAnimal = "Perro"
             },
                new Producto
             {
                 Código=8905,
                 Descripción="Royal Canin Cachorro 1.5k",
                 ImagenProducto ="/imag_productos/RoyalCanin_Cachorro.jpg",
                 Precio=28.00f,
                 CategoriaAnimal = "Gato"
             },
                new Producto
             {
                 Código=8906,
                 Descripción="Royal Canin Fit 1.5k",
                 ImagenProducto ="/imag_productos/RoyalCanin_Fit_1.5k.jpg",
                 Precio=31.00f,
                 CategoriaAnimal = "Gato"
             },
                new Producto
             {
                 Código=8904,
                 Descripción="Balanced 3k",
                 ImagenProducto ="/imag_productos/Balanced_gato.jpg",
                 Precio=25.00f,
                 CategoriaAnimal = "Gato"
             },


            };
        }
        private List<Producto> ObtenerAccesorios()
        {
            return new List<Producto> {
             new Producto
             {
                 Código=2870,
                 Descripción="Comedero para perros",
                 ImagenProducto ="/imag_Accesorios/Comedero.jpg",
                 Precio=5000.00f,
                 CategoriaAnimal = "Perro"
             },
               new Producto
             {
                 Código=2871,
                 Descripción="Dispensador de comida para perros",
                 ImagenProducto ="/imag_Accesorios/DispenserDeComida.jpg",
                 Precio=15000.80f,
                 CategoriaAnimal = "Perro"
             },
                 new Producto
             {
                 Código=2872,
                 Descripción="Hueso plástico",
                 ImagenProducto ="/imag_Accesorios/HuesoPlastico.jpg",
                 Precio=3000.00f,
                 CategoriaAnimal = "Perro"
             },
                 new Producto
             {
                 Código=2870,
                 Descripción="Hueso plástico con soga",
                 ImagenProducto ="/imag_Accesorios/HuesoSoga.jpg",
                 Precio=5000.00f,
                 CategoriaAnimal = "Perro"
             },
                 new Producto
             {
                 Código=2870,
                 Descripción="Juguete para gatos",
                 ImagenProducto ="/imag_Accesorios/JugueteGato.jpg",
                 Precio=4000.00f,
                 CategoriaAnimal = "Gato"
             },
                 new Producto
             {
                 Código=2870,
                 Descripción="Pelota para gatos",
                 ImagenProducto ="/imag_Accesorios/PelotaGato.jpg",
                 Precio=5000.00f,
                 CategoriaAnimal = "Gato"
             },
                 new Producto
             {
                 Código=2870,
                 Descripción="Rascador para gatos",
                 ImagenProducto ="/imag_Accesorios/RascadorGato.jpg",
                 Precio=10000.00f,
                 CategoriaAnimal = "Gato"
             },
                 new Producto
             {
                 Código=2870,
                 Descripción="Transportador para gatos",
                 ImagenProducto ="/imag_Accesorios/TransportadorGato.jpg",
                 Precio=25000.00f,
                 CategoriaAnimal = "Gato"
             },

            };

        }
        public IActionResult ListarProductos(string busqueda)
        {
            var productos = ObtenerProductos();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                productos = productos
                    .Where(p =>
                        p.Descripción.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                        p.Código.ToString().Contains(busqueda))
                    .ToList();
            }

            return View(productos);
        }

        public IActionResult Accesorios(string busqueda)
        {
            var accesorios = ObtenerAccesorios();

            if (!string.IsNullOrEmpty(busqueda))
            {
                accesorios = accesorios
                    .Where(a => a.Descripción.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(accesorios);
        }
        public IActionResult Productos(string busqueda, string categoriaAnimal)
        {
            var productos = ObtenerProductos(); // o tu método real

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                productos = productos
                    .Where(p => p.Descripción.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(categoriaAnimal))
            {
                productos = productos
            .Where(p => p.CategoriaAnimal == categoriaAnimal)
            .ToList();
            }

            return View(productos);
        }

        public IActionResult BusquedaAccesorios (string busqueda, string categoriaAnimal)
        {
            var productos = ObtenerAccesorios(); // o tu método real

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                productos = productos
                    .Where(p => p.Descripción.Contains(busqueda, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(categoriaAnimal))
            {
                productos = productos
            .Where(p => p.CategoriaAnimal == categoriaAnimal)
            .ToList();
            }

            return View(productos);
        }


    }
}
