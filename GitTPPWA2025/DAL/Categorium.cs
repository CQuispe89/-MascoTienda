using System;
using System.Collections.Generic;

namespace GitTPPWA2025.DAL;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? CategoriaAnimal { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
