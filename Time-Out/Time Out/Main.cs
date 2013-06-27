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

namespace TimeOut
{
	public partial class Main : Form
	{
		static string folder = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\data\");
		public static string archivoEquipos = folder + "equipos.xml";
		//string archivoJugadores = folder + "players.xml";
        Team local = new Team();
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
				// Show information
				this.label_localTDescription.Text = this.local.Titulo;
				this.label_visitorTDescription.Text = this.visitor.Titulo;
				this.button_InitialTeamLocal.Visible = true;
				this.button_InitialTeamVisitor.Visible = true;
			}
			this.Show();
		}

		private void crearEquipoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateTeam nuevo = new CreateTeam();
			nuevo.ShowDialog();
		}
		/*
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
		/// <summary>
		/// Carga todos los equipos guardados en un archivo XML en una lista generica.
		/// </summary>
		/// <returns>Una lista genérica de equipos (Teams). Si el archivo no existe retorna NULL</returns>
		public static List<Team> CargarEquipos()
		{
			List<Team> listaEquipos = null;
			if (File.Exists(archivoEquipos))
			{
				StreamReader flujo = new StreamReader(archivoEquipos);
				XmlSerializer serial = new XmlSerializer(typeof(List<Team>));
				listaEquipos = (List<Team>)serial.Deserialize(flujo);
				flujo.Close();
			}
			return listaEquipos;
		}
		/// <summary>
		/// Agrega todos los nombres de los equipos guardados en la lista generica titulos.
		/// </summary>
		public static List<string> CargarTitulosEquipos()
		{
			List<string> titulos = new List<string>();
			List<Team> equipos = CargarEquipos();
			if (equipos != null)
			{	
				foreach (Team e in equipos)
				{
					titulos.Add(e.Titulo);
				}
			}
			return titulos;
		}
	}
}
