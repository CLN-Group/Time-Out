using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
	public class Registro
	{
		public string Tiempo
		{
			get;
			set;
		}
		public string Evento
		{
			get;
            set;
		}
		public string Jugador
		{
            get;
            set;
		}

		public string renglon
		{
			get { return Tiempo + ", " + Evento + ", " + Jugador; }
		}

		public Registro(string nroCuarto, string minutos, string evento, string jugador)
		{
            this.Tiempo  = nroCuarto + "-" + minutos;
            this.Evento  = evento;
            this.Jugador = jugador;
		}
	}
}
