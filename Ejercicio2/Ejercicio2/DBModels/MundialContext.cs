using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicio2.DBModels
{
    public class MundialContext : DbContext
    {
        public MundialContext(DbContextOptions<MundialContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Directort> Directort { get; set; }
        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<Judador> Judador { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Seleccion> Seleccion { get; set; }
    }
}
