using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
	public class Registro
	{
		string tiempo;
		string evento;
		string jugador;

		public string Tiempo
		{
			get{return tiempo;}
			set {tiempo=value;}
		}
		public string Evento
		{
			get { return evento; }
			set { evento = value; }
		}
		public string Jugador
		{
			get { return jugador; }
			set { jugador = value; }
		}

		public string renglon
		{
			get{return tiempo+", "+evento+", "+jugador;}
		}

		public Registro(string nroCuarto, string minutos, string evento, string jugador)
		{
			this.tiempo=nroCuarto+"-"+minutos;
			this.evento=evento;
			this.jugador=jugador;
		}

		
	}
}
