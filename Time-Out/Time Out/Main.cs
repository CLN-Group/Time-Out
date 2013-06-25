using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeOut
{
	public partial class Main : Form
	{
		static string folder = @"C:\Users\GAMES\Documents\Visual Studio 2012\Projects\Time Out\Time Out\data";
		string archivoEquipos = folder + "teams.xml";
		string archivoJugadores = folder + "players.xml";

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
			this.Show();
		}

		private void crearEquipoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateTeam nuevo = new CreateTeam();
			nuevo.ShowDialog();
		}
	}
}
