using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
    public class Estadisticas
    {
        int asistencias;
		int simplesEncestados;
		int simplesFallidos;
        int doblesEncestados;
		int doblesFallidos;
		int triplesEncestados;
		int triplesFallidos;
        int rebotesOfensivos;
        int rebotesDefensivos;
        int robos;
        int faltas;

        #region Propiedades
        public int Asistencias
        {
            get { return asistencias; }
            set { asistencias = value; }
        }
		public int SimplesEncestados
		{
			get { return simplesEncestados; }
			set { simplesEncestados = value; }
		}
		public int SimplesFallidos
		{
			get { return simplesFallidos; }
			set { simplesFallidos = value; }
		}
		public int DoblesEncestados
		{
			get { return doblesEncestados; }
			set { doblesEncestados = value; }
		}
		public int DoblesFallidos
		{
			get { return doblesFallidos; }
			set { doblesFallidos = value; }
		}
		public int TriplesEncestados
		{
			get { return triplesEncestados; }
			set { triplesEncestados = value; }
		}
		public int TriplesFallidos
		{
			get { return triplesFallidos; }
			set { triplesFallidos = value; }
		}
        public int Puntos
        {
            get { return doblesEncestados+triplesEncestados; }
			set { } // Necesario para guardar al archivo
        }
        public int RebotesOfensivos
        {
            get { return rebotesOfensivos; }
            set { rebotesOfensivos = value; }
        }
        public int RebotesDefensivos
        {
            get { return rebotesDefensivos; }
            set { rebotesDefensivos = value; }
        }
        public int Rebotes
        {
            get { return rebotesDefensivos + rebotesOfensivos; }
        }
        public int Robos
        {
            get { return robos; }
            set { robos = value; }
        }
        public int Faltas
        {
            get { return faltas; }
            set { faltas = value; }
        }
        #endregion

        public Estadisticas()
        {
            asistencias = 0;
			simplesEncestados = 0;
			simplesFallidos = 0;
			doblesEncestados = 0;
			doblesFallidos = 0;
			triplesEncestados = 0;
			triplesFallidos = 0;
            rebotesOfensivos = 0;
            rebotesDefensivos = 0;
            robos = 0;
            faltas = 0;
        }
    }
}
