using GitTPPWA2025.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace GitTPPWA2025.ModelsEF
{
    public class ProductoVM
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Debe ingresar un precio válido")]
        public double? Precio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "Debe subir una imagen del producto")]
        public IFormFile FotoPath { get; set; }

        public List<SelectListItem>? ListaCategorias { get; set; }
        public string? ImagenActual { get; set; }
    }
}
