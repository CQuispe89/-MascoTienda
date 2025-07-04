using System;
using System.Collections.Generic;
using GitTPPWA2025.DAL;
using Microsoft.EntityFrameworkCore;

namespace GitTPPWA2025.Data;

public partial class MascoTiendaContext : DbContext
{
    public MascoTiendaContext()
    {
    }

    public MascoTiendaContext(DbContextOptions<MascoTiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoFoto> ProductoFotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK_Categoria1");

            entity.Property(e => e.CategoriaAnimal)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ImagenProducto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_Producto_Categoria");
        });

        // ✅ CORRECTO MAPEADO DE LA TABLA
        modelBuilder.Entity<ProductoFoto>(entity =>
        {
            entity.ToTable("ProductoFoto"); // <---- AGREGAR ESTO

            entity.HasKey(e => e.IdFoto).HasName("PK_ProductoFoto");

            entity.Property(e => e.Foto)
                .IsRequired()
                .HasColumnType("varchar(max)");

            entity.HasOne(e => e.Producto)
                .WithMany(p => p.Fotos)
                .HasForeignKey(e => e.IdProducto)
                .HasConstraintName("FK_ProductoFoto_Producto");
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
