using System;
using System.Collections.Generic;

namespace GitTPPWA2025.DAL;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Descripcion { get; set; }

    public string? ImagenProducto { get; set; }

    public double? Precio { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual ICollection<ProductoFoto> Fotos { get; set; } = new List<ProductoFoto>();


}
