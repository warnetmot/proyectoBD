using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace proyectoBD.Models;

public partial class ProyectoBdContext : DbContext
{
    public ProyectoBdContext()
    {
    }

    public ProyectoBdContext(DbContextOptions<ProyectoBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<FormaDePago> FormaDePagos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
 //       => optionsBuilder.UseSqlServer("server=DESKTOP-OL866KF\\SQLEXPRESS; database=proyectoBD; integrated security=true; Encrypt=False; TrustServerCertificate=True;");

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FBD0F0535");

            entity.ToTable("categorias");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clientes__3213E83FE28D2EDD");

            entity.ToTable("clientes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApellidoPrimero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_primero");
            entity.Property(e => e.ApellidoSegundo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_segundo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__empleado__3213E83F1CAE17E2");

            entity.ToTable("empleados");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApellidoPrimero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_primero");
            entity.Property(e => e.ApellidoSegundo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_segundo");
            entity.Property(e => e.Cargo)
                .HasMaxLength(255)
                .HasColumnName("cargo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario");
        });

        modelBuilder.Entity<FormaDePago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__forma_de__3213E83FF27D4FEC");

            entity.ToTable("forma_de_pago");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .HasColumnName("tipo_pago");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__producto__3213E83F8A1877BE");

            entity.ToTable("productos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdVentas).HasColumnName("id_ventas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__productos__id_ca__6383C8BA");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__productos__id_pr__628FA481");

            entity.HasOne(d => d.IdVentasNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdVentas)
                .HasConstraintName("FK__productos__id_ve__6477ECF3");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__proveedo__3213E83FF19DA28B");

            entity.ToTable("proveedores");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ApellidoPrimero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_primero");
            entity.Property(e => e.ApellidoSegundo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_segundo");
            entity.Property(e => e.CantidadPan).HasColumnName("cantidad_pan");
            entity.Property(e => e.Contacto)
                .HasMaxLength(255)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ventas__3213E83F7A585FC8");

            entity.ToTable("ventas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdFormaDePago).HasColumnName("id_forma_de_pago");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ventas__id_clien__5DCAEF64");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ventas__id_emple__5EBF139D");

            entity.HasOne(d => d.IdFormaDePagoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdFormaDePago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ventas__id_forma__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
