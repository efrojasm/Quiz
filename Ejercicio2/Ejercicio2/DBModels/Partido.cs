using System;
using System.Collections.Generic;

namespace Ejercicio2.DBModels
{
    public partial class Partido
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Local { get; set; }
        public string Visita { get; set; }
        public string Marcador { get; set; }
        public int Idest { get; set; }

        public Estadio IdestNavigation { get; set; }
    }
}
