using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AhoraSiProyecto1.Models;

public partial class PruebaFinalContext : DbContext
{
    public PruebaFinalContext()
    {
    }

    public PruebaFinalContext(DbContextOptions<PruebaFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity
                .HasKey(e => e.IdEmpleado) // ← Esto le dice a EF cuál es la clave
                .HasName("PK_Empleados");  // (opcional) puedes darle nombre a la PK

            entity.ToTable("EMPLEADOS");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");

            entity.Property(e => e.Edad).HasColumnName("edad");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.IdEmpleado)
                .HasColumnName("idEmpleado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
