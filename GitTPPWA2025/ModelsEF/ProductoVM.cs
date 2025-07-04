using GitTPPWA2025.DAL;

namespace GitTPPWA2025.ModelsEF
{
    public class ProductoVM
    {
        public int IdProducto { get; set; }
        public string? Descripcion { get; set; }
        public double? Precio { get; set; }
        public IFormFile? FotoPath { get; set; }
    }
}
