using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
		int tiemposMuertosRestantes = 0;
		// Constante que define la cantidad de tiempos muertos maximos
		const int TOmax = 6;

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
		[XmlIgnoreAttribute]
		public int TiemposMuertosRestantes
		{
			get { return tiemposMuertosRestantes; }
			set { tiemposMuertosRestantes = value; }
		}
        public List<Player> Jugadores
        {
            get { return jugadores; }
            set { jugadores = value; }
        }
		#endregion
		

		/*****************/
		/* CONSTRUCTORES */
		/*****************/
		public Team()
		{
			titulo = "";
			nombreDT = "";
			partidosGanados = 0;
			partidosPerdidos = 0;
			jugadores = new List<Player>();
			tiemposMuertosRestantes = 5;
		}
		public Team(string Titulo, string NombreDelTecnico = "")
		{
			this.titulo = Titulo;
			this.nombreDT = NombreDelTecnico;
			partidosGanados = 0;
			partidosPerdidos = 0;
			tiemposMuertosRestantes = TOmax;
		}

		/// <summary>
		/// Reestablece los tiempos muertos a su valor inicial
		/// </summary>
		public void restartTO()
		{
			this.tiemposMuertosRestantes = TOmax;
		}

		public class TeamComparer : IComparer<Team>
		{
			public int Compare(Team x, Team y)
			{
				if (x == null)
				{
					if (y == null)
					{
						// If x is null and y is null, they're 
						// equal.  
						return 0;
					}
					else
					{
						// If x is null and y is not null, y 
						// is greater.  
						return -1;
					}
				}
				else
				{
					// If x is not null... 
					// 
					if (y == null)
					// ...and y is null, x is greater.
					{
						return 1;
					}
					else
					{
						// ...and y is not null, compare the  
						// lengths of the two strings. 
						// 
						int retval = x.Titulo.CompareTo(y.Titulo);

						if (retval != 0)
						{
							// If the strings are not of equal length, 
							// the longer string is greater. 
							// 
							return retval;
						}
						else
						{
							// If the strings are of equal length, 
							// sort them with ordinary string comparison. 
							// 
							return x.Titulo.CompareTo(y.Titulo);
						}
					}
				}
			}
		}
	}
}
