using System;
using System.Collections.Generic;

namespace Ejercicio2.DBModels
{
    public partial class Directort
    {
        public Directort()
        {
            Seleccion = new HashSet<Seleccion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        public ICollection<Seleccion> Seleccion { get; set; }
    }
}
