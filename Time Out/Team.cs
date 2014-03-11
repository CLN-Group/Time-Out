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
		// Constante que define la cantidad de tiempos muertos maximos
		public const int TOmax = 6;

		public string Name
		{
			get;
			set;
		}
		public string Coach
		{
			get;
			set;
		}
		public int PartidosJugados
		{
            get { return PartidosGanados + PartidosPerdidos; }
		}
		public int PartidosGanados
		{
			get;
			set;
		}
		public int PartidosPerdidos
		{
			get;
			set;
		}
        public List<Player> Players
        {
            get;
            set;
        }
        // Estadísticas de un partido
		public int Faltas
		{
			get;
            set;
		}
		[XmlIgnoreAttribute]
		public int TiemposMuertosRestantes
		{
            get;
            set;
		}



		public Team()
		{
			Name                    = "";
			Coach                   = "";
			PartidosGanados         = 0;
			PartidosPerdidos        = 0;
			Players                 = new List<Player>();
            TiemposMuertosRestantes = TOmax;
		}

		public Team(string Name, string NombreDelTecnico = "")
		{
            this.Name               = Name;
            this.Coach              = NombreDelTecnico;
            PartidosGanados         = 0;
            PartidosPerdidos        = 0;
            TiemposMuertosRestantes = TOmax;
		}

		/// <summary>
		/// Reestablece los tiempos muertos a su valor inicial
		/// </summary>
		public void restartTO()
		{
            this.TiemposMuertosRestantes = TOmax;
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
						int retval = x.Name.CompareTo(y.Name);

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
							return x.Name.CompareTo(y.Name);
						}
					}
				}
			}
		}
	}
}
