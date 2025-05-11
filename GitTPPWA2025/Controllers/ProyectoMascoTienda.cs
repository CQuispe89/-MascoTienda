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

        public IActionResult Productos()
        {
            var productos = ObtenerProductos(); // esto NO puede ser null
            return View(productos);
        }

        public IActionResult Accesorios()
        {
            var accesorios = ObtenerAccesorios(); // esto NO puede ser null
            return View(accesorios);
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
                 Precio=78.00f
             },
               new Producto
             {
                 Código=1456,
                 Descripción="Pro Plan Puppy 3k",
                 ImagenProducto ="/imag_productos/ProplaPuppy_3k.jpg",
                 Precio=39.80f
             },
                 new Producto
             {
                 Código=8907,
                 Descripción="Pro Plan Reducido Calorías 3k",
                 ImagenProducto ="/imag_productos/ProplanOtros_3k.jpg",
                 Precio=48.00f
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
                 Precio=5000.00f
             },
               new Producto
             {
                 Código=2871,
                 Descripción="Dispensador de comida para perros",
                 ImagenProducto ="/imag_Accesorios/DispenserDeComida.jpg",
                 Precio=15000.80f
             },
                 new Producto
             {
                 Código=2872,
                 Descripción="Hueso plástico",
                 ImagenProducto ="/imag_Accesorios/HuesoPlastico.jpg",
                 Precio=3000.00f
             },
                 new Producto
             {
                 Código=2870,
                 Descripción="Hueso plástico con soga",
                 ImagenProducto ="/imag_Accesorios/HuesoSoga.jpg",
                 Precio=5000.00f
             },

            };

        }
    }
}
