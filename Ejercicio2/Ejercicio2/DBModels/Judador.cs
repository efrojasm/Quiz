using System;
using System.Collections.Generic;

namespace Ejercicio2.DBModels
{
    public partial class Judador
    {
        public int Id { get; set; }
        public int? Numero { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Posicion { get; set; }
        public string Club { get; set; }
        public decimal? Altura { get; set; }
        public int Idsel { get; set; }

        public Seleccion IdselNavigation { get; set; }
    }
}
