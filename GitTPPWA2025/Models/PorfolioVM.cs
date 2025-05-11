namespace GitTPPWA2025.Models
{
    public class PorfolioVM
    {
        public Empresa empresa { get; set; }
        public IEnumerable<Filial> filials { get; set; }

        public List<Producto> productos { get; set; }
        public List<Producto> accesorios { get; set; }
    }
}
