using System;
using System.Collections.Generic;

namespace Ejercicio2.DBModels
{
    public partial class Seleccion
    {
        public Seleccion()
        {
            Judador = new HashSet<Judador>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public string Confederacion { get; set; }
        public int Iddt { get; set; }

        public Directort IddtNavigation { get; set; }
        public ICollection<Judador> Judador { get; set; }
    }
}
