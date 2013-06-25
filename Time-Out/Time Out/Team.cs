using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
	public class Team
	{
		string titulo;
		string nombreDT;
		int partidosGanados;
		int partidosPerdidos;
		List<Player> jugadores;
		// Estadísticas de un partido
		int faltas = 0;

		/***************/
		/* PROPIEDADES */
		/***************/
		#region Propiedades
		public string Titulo
		{
			get { return titulo; }
			set { titulo = value; }
		}
		public string NombreDelTecnico
		{
			get { return nombreDT; }
			set { nombreDT = value; }
		}
		public int PartidosJugados
		{
			get { return partidosGanados + partidosPerdidos; }
		}
		public int PartidosGanados
		{
			get { return partidosGanados; }
			set { partidosGanados = value; }
		}
		public int PartidosPerdidos
		{
			get { return partidosPerdidos; }
			set { partidosPerdidos = value; }
		}
		public int Faltas
		{
			get { return faltas; }
			set { faltas = value; }
		}
		#endregion
		

		/***************/
		/* CONSTRUCTOR */
		/***************/
		public Team()
		{
			titulo = "";
			nombreDT = "";
			partidosGanados = 0;
			partidosPerdidos = 0;
			jugadores = new List<Player>();
		}
		public Team(string Titulo, string NombreDelTecnico = "")
		{
			this.titulo = Titulo;
			this.nombreDT = NombreDelTecnico;
		}
	}
}
