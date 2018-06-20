using System;
using System.Collections.Generic;

namespace Ejercicio2.DBModels
{
    public partial class Estadio
    {
        public Estadio()
        {
            Partido = new HashSet<Partido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Capacidad { get; set; }

        public ICollection<Partido> Partido { get; set; }
    }
}
