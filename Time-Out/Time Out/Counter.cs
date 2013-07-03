using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOut
{
	public class Counter
	{
		int minutos;
		int segundos;
		int milisegundos;
		// Se define una constante con los minutos limites
		const int minutoInicial = 1;

		public int Minutos
		{
			get { return minutos; }
			set { minutos = value; }
		}
		public int Segundos
		{
			get { return segundos; }
			set { segundos = value; }
		}
		public int Milisegundos
		{
			get { return milisegundos; }
			set { milisegundos = value; }
		}
		// STRINGS
		public string strMinutos
		{
			get
			{
				var aux = minutos.ToString();
				if (aux.Length == 1)
					return "0" + aux;
				return aux;
			}
		}
		public string strSegundos
		{
			get
			{
				var aux = segundos.ToString();
				if (aux.Length == 1)
					return "0" + aux;
				return aux;
			}
		}
		public string strMilisegundos
		{
			get
			{
				var aux = milisegundos.ToString();
				if (aux.Length == 1)
					return "0" + aux;
				return aux;
			}
		}

		/// <summary>
		/// Retorna el contador con el formato "MM:SS:FF"
		/// </summary>
		public string getCounter
		{
			get 
			{
				return strMinutos + ":" +
					strSegundos + ":" + 
					strMilisegundos;
			}
		}

		/// <summary>
		/// Setea el contador en su minuto inicial
		/// </summary>
		public Counter()
		{
			minutos = minutoInicial;
			segundos = 0;
			milisegundos = 0;
		}

		/// <summary>
		/// Reinicial el contador a su minuto inicial
		/// </summary>
		public void resetCounter()
		{
			this.minutos = minutoInicial;
			this.segundos = 0;
			this.milisegundos = 0;
		}

		/// <summary>
		/// Disminuye en una unidad el contador.
		/// <para>Si llego al limite, no realiza nada.</para>
		/// </summary>
		public void decCounter()
		{
			if (minutos == 0)
			{
				if (segundos == 0)
				{
					if (milisegundos == 0)
						return;
					milisegundos--;
				}
				else
				{
					if (milisegundos == 0)
					{
						segundos--;
						milisegundos = 59;
					}
					else
						milisegundos--;
				}
			}
			else
			{
				if (segundos == 0)
				{
					if (milisegundos == 0)
					{
						minutos--;
						segundos = 59;
						milisegundos = 59;
					}
					else
						milisegundos--;
				}
				else
				{
					if (milisegundos == 0)
					{
						segundos--;
						milisegundos = 59;
					}
					else
						milisegundos--;
				}
			}
		}
	}
}
