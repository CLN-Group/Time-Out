using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
    public class Match
    {
        DateTime fecha;
        string equipoLocal;
        string equipoVisitante;
        Estadisticas stLocal;
        Estadisticas stVisitante;
        List<string> jugadoresLocales;
        List<string> jugadoresVisitantes;

        #region Propiedades
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string EquipoLocal
        {
            get { return equipoLocal; }
            set { equipoLocal = value; }
        }
        public string EquipoVisitante
        {
            get { return equipoVisitante; }
            set { equipoVisitante = value; }
        }
        public Estadisticas EstadisticasLocal
        {
            get { return stLocal; }
            set { stLocal = value; }
        }
		public Estadisticas EstadisticasVisitante
        {
            get { return stVisitante; }
            set { stVisitante = value; }
        }
        public List<string> JugadoresLocales
        {
            get { return jugadoresLocales; }
            set { jugadoresLocales = value; }
        }
        public List<string> JugadoresVisitantes
        {
            get { return jugadoresVisitantes; }
            set { jugadoresVisitantes = value; }
        }
        #endregion

        public Match()
        {
            fecha = new DateTime();
            equipoLocal = "";
            equipoVisitante = "";
            stLocal = new Estadisticas();
            stVisitante = new Estadisticas();
            jugadoresLocales = new List<string>();
            jugadoresVisitantes = new List<string>();
        }
    }
}
