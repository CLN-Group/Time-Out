using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace TimeOut
{
	public partial class Main : Form
	{
        static string folder = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\data\");
        //static string folder = @"C:\timeout\";
		public static string archivoEquipos  = folder + "teams.xml";
		public static string archivoPartidos = folder + "matchs.xml";
        Team local   = new Team();
        Team visitor = new Team();

		public Main()
		{
			InitializeComponent();
		}
		

		/// <summary>
		/// Trata de cerrar el programa
		/// </summary>
		private void button_close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Abre un dialogo pidiendo confirmación al usuario para salir del programa
		/// </summary>
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir del programa?",
				"Salir del programa",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2);
			if (userResponce == System.Windows.Forms.DialogResult.No)
				e.Cancel = true;
		}

		/// <summary>
		/// Este metodo Muestra o Saca la información de ambos equipos.
		/// </summary>
		/// <param name="Show">Con esta variable se indica si muestra la información (True) o la quita (False).</param>
		private void teamsInformation(bool Show)
		{
			if (Show)
			{
				this.label_localTDescription.Text = this.local.Name;
				this.label_visitorTDescription.Text = this.visitor.Name;
				this.button_InitialTeamLocal.Visible = true;
				this.button_InitialTeamVisitor.Visible = true;
				this.button_startMatch.Enabled = true;
			}
			else
			{
				this.label_localTDescription.Text = "";
				this.label_visitorTDescription.Text = "";
				this.button_InitialTeamLocal.Visible = false;
				this.button_InitialTeamVisitor.Visible = false;
				this.button_startMatch.Enabled = false;
			}
		}

		/// <summary>
		/// Abre un dialogo para que el usuario seleccione los equipos para comenzar el encuentro
		/// </summary>
		private void button_loadInformation_Click(object sender, EventArgs e)
		{
			SelectTeams nuevo = new SelectTeams();
			this.Hide();
			nuevo.ShowDialog();
			if (nuevo.IsReady)
			{
				// Load teams
				this.local = nuevo.Local;
				this.visitor = nuevo.Visitor;
				// Show information available
				teamsInformation(true);
			}
			else
				teamsInformation(false); // Hide the displayed information, if any
			this.Show();
		}

		private void crearEquipoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateTeam nuevo = new CreateTeam();
			nuevo.ShowDialog();
		}

		/*TODO
		 * Este metodo esta desactivado hasta que se independizen 
		 * los archivos de jugadores con archivos de equipos
        private void crearJugadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePlayer nuevo = new CreatePlayer();
            nuevo.ShowDialog();
        }
		*/

		/*************/
		/*  Metodos  */
		/*  publicos */
		/*************/


        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }


		/// <summary>
		/// Carga todos los equipos guardados en un archivo XML en una lista generica.
		/// </summary>
		/// <returns>Una lista genérica de equipos (Teams). Si el archivo no existe retorna NULL</returns>
		public static List<Team> CargarEquipos()
		{
			List<Team> listaEquipos = null;
			if (File.Exists(archivoEquipos))
			{
				StreamReader flujo   = new StreamReader(archivoEquipos);
				XmlSerializer serial = new XmlSerializer(typeof(List<Team>));
				listaEquipos         = (List<Team>)serial.Deserialize(flujo);
				flujo.Close();
			}
			return listaEquipos;
		}

		/// <summary>
		/// Carga todos los partidos guardados en un archivo XML en una lista generica.
		/// </summary>
		/// <returns>Una lista genérica de partidos (Match). Si el archivo no existe retorna NULL</returns>
		public static List<Match> CargarPartidos()
		{
			List<Match> listaPartidos = null;
			if (File.Exists(archivoPartidos))
			{
				StreamReader flujo   = new StreamReader(archivoPartidos);
				XmlSerializer serial = new XmlSerializer(typeof(List<Match>));
				listaPartidos        = (List<Match>)serial.Deserialize(flujo);
				flujo.Close();
			}
			return listaPartidos;
		}

		/// <summary>
		/// Agrega todos los nombres de los equipos guardados en la lista generica titulos.
		/// </summary>
		public static List<string> CargarTitulosEquipos()
		{
			List<string> titulos = new List<string>();
			List<Team> equipos   = CargarEquipos();

			if (equipos != null)
			{	
				foreach (Team e in equipos)
				{
					titulos.Add(e.Name);
				}
			}

			return titulos;
		}
		
		/// <summary>
		/// Carga el último partido jugado
		/// </summary>
		/// <returns>Retorna el partido jugado, sino existe retorna NULL</returns>
		Match loadMatchFromFile()
		{
			Match ultimoPartido = null;
			List<Match> lista   = CargarPartidos();

			if (lista != null)
				ultimoPartido = lista[ lista.Count-1 ];

			return ultimoPartido;
		}


		// ********************************** //
		// * METODOS DE BOTONES PRINCIPALES * //
		// ********************************** //

		private void button_InitialTeam_Click(object sender, EventArgs e)
		{
			List<Player> listaJugadores = null;
			Button clickedButton        = (Button)sender;

			if (clickedButton.Name.Equals("button_InitialTeamLocal"))
				listaJugadores = this.local.Players;
			else
				listaJugadores = this.visitor.Players;

			SelectInitialTeam selectInitialTeamWindow = new SelectInitialTeam(listaJugadores);
			selectInitialTeamWindow.ShowDialog();

			if (selectInitialTeamWindow.Done)
				clickedButton.Visible = false;
		}

		private void button_startMatch_Click(object sender, EventArgs e)
		{
			if (this.button_InitialTeamLocal.Visible || this.button_InitialTeamVisitor.Visible)
			{
				MessageBox.Show("Debes seleccionar la formación inicial de AMBOS equipos!",
					            "Formación inicial no completada",
					            MessageBoxButtons.OK,
					            MessageBoxIcon.Error);
			}
			else
			{
				partido nuevo = new partido(local, visitor);
				nuevo.ArchivoPartidos = archivoPartidos;
				nuevo.ShowDialog();
			}
		}

		private void button_getStatistics_Click(object sender, EventArgs e)
		{
			Match match = loadMatchFromFile();

			if (match != null)
			{
				ShowStatistics window = new ShowStatistics(match);
				window.ShowDialog();
			}
			else
			{
				MessageBox.Show("ERROR: no se pudo cargar ningún partido", 
					            "Fallo al leer desde archivo",
					            MessageBoxButtons.OK,
					            MessageBoxIcon.Error);
			}
		}
	}
}
