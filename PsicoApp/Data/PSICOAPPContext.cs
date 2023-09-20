using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PsicoApp.Data
{
    public partial class PSICOAPPContext : DbContext
    {
        public PSICOAPPContext()
        {
        }

        public PSICOAPPContext(DbContextOptions<PSICOAPPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Foto> Fotos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-H4ICEER\\SQLEXPRESS;Initial Catalog=PSICOAPP;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foto>(entity =>
            {
                entity.ToTable("FOTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dni)
                    .HasMaxLength(50)
                    .HasColumnName("DNI");

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("PACIENTES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Departamento).HasMaxLength(50);

                entity.Property(e => e.Dni)
                    .HasMaxLength(50)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Estatus).HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.Tipo).HasMaxLength(10);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ROLES");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .HasColumnName("ROL");

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dni)
                    .HasMaxLength(50)
                    .HasColumnName("DNI");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
