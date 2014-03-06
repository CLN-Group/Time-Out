using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.ComponentModel;

namespace TimeOut
{
	public class Player
	{
		#region Propiedades

		public string Id {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}
		public string Lastname {
			get;
			set;
		}
        [XmlIgnore]
		public string CompleteName {
            get { return this.Lastname + ", " + this.Name; }
		}
		public float Height {
			get;
			set;
		}
		/// <summary>
		/// Return the complete date time of the user birthdate
		/// </summary>
		[XmlIgnore]
		public DateTime Birthdate {
			get;
			set;
		}
		/// <summary>
		/// Get and set the birthdate of the user without the time (DD/MM/YYYY)
		///		<para>NOTE: this is only used to work with the XML file</para>
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[XmlElement("Birthdate")]
		public string BirthdateFormatted {
			get { return (Birthdate.ToShortDateString()); }
			// Set the birthdate converting the value from file
			set { Birthdate = DateTime.ParseExact(value, "dd/MM/yyyy", null); }
		}
		/*
		 * La posición preferida del jugador es Opcional.
		 * Los valores variaran de la siguiente forma:
		 *	N  -> ninguna posición preferida
		 *	C  -> Pivot
		 *	CF -> Ala-Pivot
		 *	F  -> Alero
		 *	FG -> Escolta
		 *	G  -> Base
		 */
		static string[] validPositions = { "N", "C", "FC", "F", "GF", "G" };
		public string Position {
			get;
			set;
		}
		/// <summary>
		/// It it used on the game to check 
        /// if player will start match playing
		/// </summary>
		[XmlIgnore]
		public bool Starter {
			get;
			set;
		}


		/// TODO:
		/// The match statistic should be moved into a proper class
		/// that will store ID_match ID_action ID_team ID_player
		

		// Propiedades estadísticas del encuentro específico,
		// estas no se guardaran en el archivo XML
		[XmlIgnore]
		public int RebotesOfensivos
		{
			get;
			set;
		}
		[XmlIgnore]
		public int RebotesDefensivos
		{
			get;
			set;
		}
		[XmlIgnore]
		public int TirosLibresAnotados
		{
			get;
			set;
		}
		[XmlIgnore]
		public int TirosLibresFallados
		{
			get;
			set;
		}
		[XmlIgnore]
		public int PuntosDoblesAnotados
		{
			get;
			set;
		}
		[XmlIgnore]
		public int PuntosDoblesFallados
		{
			get;
			set;
		}
		[XmlIgnore]
		public int PuntosTriplesAnotados
		{
			get;
			set;
		}
		[XmlIgnore]
		public int PuntosTriplesFallados
		{
			get;
			set;
		}
		[XmlIgnore]
		public int FaltasCometidas
		{
			get;
			set;
		}
		[XmlIgnore]
		public int FaltasTecnicas
		{
			get;
			set;
		}
        [XmlIgnore]
        public int AsistenciasLogradas
        {
            get;
            set;
        }
        [XmlIgnore]
        public int Perdidas
        {
            get;
            set;
        }
		[XmlIgnore]
		public float MinutosJugados
		{
			get;
			set;
		}
		#endregion


        public Player()
        {
            Id        = "";
            Birthdate = new DateTime();
            Name      = "";
            Lastname  = "";
            Height    = 1;
            Position  = "N";
        }

        public Player(string Nombre, string Apellido, DateTime Nacimiento, float Altura, string PosicionPreferida = "N", string id = "")
        {
            this.Id        = id;
            this.Birthdate = Nacimiento;
            this.Name      = Nombre;
            this.Lastname  = Apellido;
            this.Height    = Altura;
            this.Position  = PosicionPreferida;
        }
		


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
		static public bool datosValidosJugador(string nombre, string apellido, float altura, string posicion, DateTime nacimiento, string id)
		{
			bool res = true;

			if (String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(apellido))
				res = false;
			if (strConNumero(nombre) || strConNumero(apellido))
				res = false;
			if (altura < 0 || altura > 3)
				res = false;
			if (!posicionValida(getPosicion(posicion)))
				res = false;
			if (nacimiento.Year < 1940 || DateTime.Now < nacimiento)
				res = false;
            if (id.Length != 40)
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
			string posicionCorta = "N";
			string pos           = posicionCompleta.ToLower();

			if (pos == "pivot")
				posicionCorta = "C";
			if (pos == "ala-pivot")
				posicionCorta = "FC";
			if (pos == "alero")
				posicionCorta = "F";
			if (pos == "escolta")
				posicionCorta = "GF";
			if (pos == "base")
				posicionCorta = "G";

			return posicionCorta;
		}
	}
}
