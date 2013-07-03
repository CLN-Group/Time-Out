using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace TimeOut
{
	public class Player
	{
		//int id;
		string nombre;
		string apellido;
		float altura;
		string nacimiento;
		DateTime fechaNacimiento;
		/*
		 * La posición preferida del jugador es Opcional.
		 * Los valores variaran de la siguiente forma:
		 *	N -> ninguna posición preferida
		 *	P -> Pivot
		 *	A -> Ala-Pivot
		 *	F -> Alero
		 *	G -> Escolta
		 *	B -> Base
		 */
		static string[] validPositions = { "none", "C", "PF", "SF", "SG", "PG" };
		string posicion;
		// Indica si el jugador es Titular o Suplente
		bool titular = false;
		// Estadísticas de un partido
		int libresAnotados = 0;
		int libresFallados = 0;
		int doblesAnotados = 0;
		int doblesFallados = 0;
		int triplesAnotados = 0;
		int triplesFallados = 0;
		int faltas = 0;
		int faltasTecnicas = 0;
		int asistencias = 0;
		float minutosJugados = 0;
		int rebotesOfensivos;
		int rebotesDefensivos;
		//TODO
        // Estadisticas globales
		//
		// Por ahora no tiene
		// Se agregarán cuando este terminada la ventana del partido
			

		/***************/
		/* PROPIEDADES */
		/***************/
		#region Propiedades
		/*
		public int ID
		{
			get { return id; }
			set { id = value; }
		}*/
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}
		public string NombreCompleto
		{
			get { return apellido+", "+nombre; }
		}
		public float Altura
		{
			get { return altura; }
			set { altura = value; }
		}
		public string Nacimiento
		{
			get { return nacimiento; }
			// This attribute is Read-Only but the set statement
			// must to be declared to save it in XML correctly
			set { }
		}
		[XmlIgnoreAttribute]
		public DateTime FechaNacimiento
		{
			get { return fechaNacimiento; }
			set  
			{ 
				fechaNacimiento = value; 
				// This also set the value of the born in string mode
				nacimiento = fechaNacimiento.ToShortDateString();
			}
		}
		public string Posicion
		{
			get { return posicion; }
			set { posicion = value; }
		}
		[XmlIgnoreAttribute]
		public bool Titular
		{
			get { return titular; }
			set { titular = value; }
		}
		// Propiedades estadísticas del encuentro específico,
		// estas no se guardaran en el archivo XML
		[XmlIgnoreAttribute]
		public int RebotesOfensivos
		{
			get { return rebotesOfensivos; }
			set { rebotesOfensivos = value; }
		}
		[XmlIgnoreAttribute]
		public int RebotesDefensivos
		{
			get { return rebotesDefensivos; }
			set { rebotesDefensivos = value; }
		}
		[XmlIgnoreAttribute]
		public int TirosLibresAnotados
		{
			get { return libresAnotados; }
			set { libresAnotados = value; }
		}
		[XmlIgnoreAttribute]
		public int TirosLibresFallados
		{
			get { return libresFallados; }
			set { libresFallados = value; }
		}
		[XmlIgnoreAttribute]
		public int PuntosDoblesAnotados
		{
			get { return doblesAnotados; }
			set { doblesAnotados = value; }
		}
		[XmlIgnoreAttribute]
		public int PuntosDoblesFallados
		{
			get { return doblesFallados; }
			set { doblesFallados = value; }
		}
		[XmlIgnoreAttribute]
		public int PuntosTriplesAnotados
		{
			get { return triplesAnotados; }
			set { triplesAnotados = value; }
		}
		[XmlIgnoreAttribute]
		public int PuntosTriplesFallados
		{
			get { return triplesFallados; }
			set { triplesFallados = value; }
		}
		[XmlIgnoreAttribute]
		public int FaltasCometidas
		{
			get { return faltas; }
			set { faltas = value; }
		}
		[XmlIgnoreAttribute]
		public int FaltasTecnicas
		{
			get { return faltasTecnicas; }
			set { faltasTecnicas = value; }
		}
		[XmlIgnoreAttribute]
		public int AsistenciasLogradas
		{
			get { return asistencias; }
			set { asistencias = value; }
		}
		[XmlIgnoreAttribute]
		public float MinutosJugados
		{
			get { return minutosJugados; }
			set { minutosJugados = value; }
		}
		#endregion
		

		/*/////////////////////*/
		/*  METODOS ESTATICOS  */
		/*/////////////////////*/
		/// <summary>
		///	Comprueba si la cadena ingresada tiene uno o más números
		/// </summary>
		/// <param name="str">La cadena a ser evaluada</param>
		/// <returns>Si la cadena no tiene números retorna False</returns>
		static public bool strConNumero(string str)
		{
			Regex rx = new Regex(@"\d");
			return rx.IsMatch(str);
		}
		/// <summary>
		/// Verifica si el valor del caracter pasado por parámetro es válido.
		/// </summary>
		/// <param name="posicion">
		/// El caracter debe tener uno de estos valores:
		/// 'N', 'P', 'A', 'F', 'G' o 'B'
		/// </param>
		/// <returns>Si tiene un valor inválido retorna False</returns>
		static public bool posicionValida(string posicion)
		{
			// Checkear 
			bool valid = (Array.IndexOf(validPositions, posicion) > -1) ? true : false;
			return valid;
		}
		/// <summary>
		/// Analísa los valores de todas las variables que pueden ser atributos del Jugador
		/// </summary>
		/// <param name="nombre">Nombre del jugador</param>
		/// <param name="apellido">Apellido del jugador</param>
		/// <param name="altura">Altura del jugador, puede ser un numero con punto para especificar los centimetros</param>
		/// <param name="posicion">Posición del jugador</param>
		/// <returns>Si todos los valores ingresados son válidos retorna True</returns>
		static public bool datosValidosJugador(string nombre, string apellido, float altura, string posicion, DateTime nacimiento)
		{
			bool res = true;
			if (nombre == "" || apellido == "")
				res = false;
			if (strConNumero(nombre) || strConNumero(apellido))
				res = false;
			if (altura < 0 || altura > 3)
				res = false;
			if (!posicionValida(getPosicion(posicion)))
				res = false;
			if (nacimiento.Year < 1940 || DateTime.Now < nacimiento)
				res = false;
			return res;
		}
		/// <summary>
		/// Procesa una cadena con el nombre correspondiente a una posición,
		/// y retorna su correspondiente abreviatura.
		/// </summary>
		/// <param name="posicionCompleta">Cadena con el título de la posición</param>
		/// <returns>La abreviatura correspondiente a la posición</returns>
		static public string getPosicion(string posicionCompleta)
		{
			string posicionCorta = "none";
			string pos = posicionCompleta.ToLower();
			if (pos == "pivot")
				posicionCorta = "C";
			if (pos == "ala-pivot")
				posicionCorta = "PF";
			if (pos == "alero")
				posicionCorta = "SF";
			if (pos == "escolta")
				posicionCorta = "SG";
			if (pos == "base")
				posicionCorta = "PG";
			return posicionCorta;
		}

		/***************/
		/* CONSTRUCTOR */
		/***************/
		public Player()
		{
			FechaNacimiento = new DateTime();
			nombre = "";
			apellido = "";
			altura = 1; // 
			posicion = "none";
		}
		public Player(string Nombre, string Apellido, DateTime Nacimiento, float Altura, string PosicionPreferida = "none")
		{
			if (datosValidosJugador(Nombre, Apellido, Altura, PosicionPreferida, Nacimiento))
			{
				FechaNacimiento = Nacimiento;
				this.nombre = Nombre;
				this.apellido = Apellido;
				this.altura = Altura;
				this.posicion = PosicionPreferida;
			}
		}
	}
}
