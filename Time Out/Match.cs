using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
    public class Match
    {
        public DateTime Fecha
        {
            get;
            set;
        }
        public string EquipoLocal
        {
            get;
            set;
        }
        public string EquipoVisitante
        {
            get;
            set;
        }
        public Estadisticas EstadisticasLocal
        {
            get;
            set;
        }
		public Estadisticas EstadisticasVisitante
        {
            get;
            set;
        }
        public List<string> JugadoresLocales
        {
            get;
            set;
        }
        public List<string> JugadoresVisitantes
        {
            get;
            set;
        }


        public Match()
        {
            Fecha                 = new DateTime();
            EquipoLocal           = "";
            EquipoVisitante       = "";
            EstadisticasLocal     = new Estadisticas();
            EstadisticasVisitante = new Estadisticas();
            JugadoresLocales      = new List<string>();
            JugadoresVisitantes   = new List<string>();
        }
    }
}
