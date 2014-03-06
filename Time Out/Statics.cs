using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TimeOut
{
    public class Estadisticas
    {
        public int Asistencias
        {
            get;
            set;
        }
		public int SimplesEncestados
		{
            get;
            set;
		}
		public int SimplesFallidos
		{
            get;
            set;
		}
		public int DoblesEncestados
		{
            get;
            set;
		}
		public int DoblesFallidos
		{
            get;
            set;
		}
		public int TriplesEncestados
		{
            get;
            set;
		}
		public int TriplesFallidos
		{
            get;
            set;
		}
        public int RebotesOfensivos
        {
            get;
            set;
        }
        public int RebotesDefensivos
        {
            get;
            set;
        }
        public int Robos
        {
            get;
            set;
        }
        public int Faltas
        {
            get;
            set;
        }
        /// <summary>
        /// Return the final score of the team.
        /// </summary>
        [XmlIgnore]
        public int Puntos
        {
            get { return SimplesEncestados + DoblesEncestados*2 + TriplesEncestados*3; }
        }
        [XmlIgnore]
        public int Rebotes
        {
            get { return RebotesDefensivos + RebotesOfensivos; }
        }

        public Estadisticas()
        {
            Asistencias       = 0;
			SimplesEncestados = 0;
			SimplesFallidos   = 0;
			DoblesEncestados  = 0;
			DoblesFallidos    = 0;
			TriplesEncestados = 0;
			TriplesFallidos   = 0;
            RebotesOfensivos  = 0;
            RebotesDefensivos = 0;
            Robos             = 0;
            Faltas            = 0;
        }
    }
}
