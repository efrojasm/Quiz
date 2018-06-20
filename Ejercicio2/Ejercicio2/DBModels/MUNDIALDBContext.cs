using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ejercicio2.DBModels
{
    public partial class MUNDIALDBContext : DbContext
    {
        
        public virtual DbSet<Directort> Directort { get; set; }
        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<Judador> Judador { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Seleccion> Seleccion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MUNDIALDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Directort>(entity =>
            {
                entity.ToTable("DIRECTORT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nacionalidad)
                    .HasColumnName("NACIONALIDAD")
                    .HasColumnType("nchar(40)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.ToTable("ESTADIO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Capacidad)
                    .HasColumnName("CAPACIDAD")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("CIUDAD")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Judador>(entity =>
            {
                entity.ToTable("JUDADOR");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Altura)
                    .HasColumnName("ALTURA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Club)
                    .HasColumnName("CLUB")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FECHA_NACIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idsel).HasColumnName("IDSEL");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Posicion)
                    .HasColumnName("POSICION")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.IdselNavigation)
                    .WithMany(p => p.Judador)
                    .HasForeignKey(d => d.Idsel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JUDADOR__IDSEL__286302EC");
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.ToTable("PARTIDO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idest).HasColumnName("IDEST");

                entity.Property(e => e.Local)
                    .HasColumnName("LOCAL")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Marcador)
                    .HasColumnName("MARCADOR")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Visita)
                    .HasColumnName("VISITA")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.IdestNavigation)
                    .WithMany(p => p.Partido)
                    .HasForeignKey(d => d.Idest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PARTIDO__IDEST__2F10007B");
            });

            modelBuilder.Entity<Seleccion>(entity =>
            {
                entity.ToTable("SELECCION");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Confederacion)
                    .HasColumnName("CONFEDERACION")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Grupo)
                    .HasColumnName("GRUPO")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Iddt).HasColumnName("IDDT");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.IddtNavigation)
                    .WithMany(p => p.Seleccion)
                    .HasForeignKey(d => d.Iddt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SELECCION__IDDT__300424B4");
            });
        }
    }
}
