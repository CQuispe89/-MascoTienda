namespace GitTPPWA2025.DAL
{
    public class ProductoFoto
    {
        public int IdFoto { get; set; }
        public string Foto { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
