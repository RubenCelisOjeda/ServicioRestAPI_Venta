using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Servicio.Core.Entity;

namespace Servicio.Core.Data.BDTablas
{
    public partial class BD_SistemaVentaContext : DbContext
    {
        private string _ConnectionString = string.Empty;

        public BD_SistemaVentaContext()
        {

        }

        public BD_SistemaVentaContext(DbContextOptions<BD_SistemaVentaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ConceptoVenta> ConceptoVenta { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ConnectionString = "Server=localhost;Database=BD_SistemaVenta;User ID=sa;Password=codigolinux89;";

            if (!optionsBuilder.IsConfigured)
            {
                if (string.IsNullOrEmpty(ConnectionString.Connection))
                {
                    ConnectionString.Connection = _ConnectionString;
                }

                optionsBuilder.UseSqlServer(ConnectionString.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ApellidoMaterno).HasMaxLength(50);
                entity.Property(e => e.ApellidoPaterno).HasMaxLength(50);
                entity.Property(e => e.Nombres).HasMaxLength(50);
                entity.Property(e => e.Dni).HasMaxLength(10);
                entity.Property(e => e.Status);
                entity.Property(e => e.Celular).HasMaxLength(20);
                entity.Property(e => e.NombreFacebook).HasMaxLength(100);
                entity.Property(e => e.DireccionLugarEntrega).HasMaxLength(500);
            });

            modelBuilder.Entity<ConceptoVenta>(entity =>
            {
                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Cantidad);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Status);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.ConceptoVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_tbl_ConceptoVenta_tbl_Producto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ConceptoVenta)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_tbl_Usuario_tbl_Usuario");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.ConceptoVenta)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK_tbl_ConceptoVenta_tbl_Venta");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.ApellidoMaterno).HasMaxLength(50);

                entity.Property(e => e.ApellidoPaterno).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.EstadoCivil);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Status);
            });

            modelBuilder.Entity<Parametros>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Valor1).HasMaxLength(50);

                entity.Property(e => e.Valor2).HasMaxLength(50);

                entity.Property(e => e.Valor3).HasMaxLength(50);

                entity.Property(e => e.Estado);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Stock);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.RoId);

                entity.Property(e => e.Estado);

                entity.Property(e => e.UsuarioName).HasMaxLength(50);

                entity.Property(e => e.Status);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_tbl_Usuario_tbl_Empleado");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_tbl_Venta_tbl_Cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
