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
	public partial class SelectInitialTeam : Form
	{
		List<Player> jugadores;

		public List<Player> Jugadores
		{
			get { return jugadores; }
			set { jugadores = value; }
		}
		private int CantidadJugadoresIniciales
		{
			get { return listBox_initialPlayers.Items.Count; }
		}

		/// <summary>
		/// This method is the Constructor of the class.
		/// </summary>
		/// <param name="jugadores">Receives a list with all the available players</param>
		public SelectInitialTeam(List<Player> jugadores)
		{
			InitializeComponent();

			this.Jugadores = jugadores;
			loadPlayers();
		}

		private void loadPlayers()
		{
			this.listBox_availablePlayers.DataSource = this.Jugadores;
			this.listBox_availablePlayers.DisplayMember = "Nombre";
			this.listBox_initialPlayers.Items.Clear();
			this.listBox_initialPlayers.DisplayMember = "Nombre";
		}

		private void button_add_Click(object sender, EventArgs e)
		{
			this.listBox_initialPlayers.Items.Add(this.listBox_availablePlayers.SelectedItem);
			if (CantidadJugadoresIniciales == 5)
				this.button_add.Enabled = false;
		}

		private void button_finish_Click(object sender, EventArgs e)
		{
			if (CantidadJugadoresIniciales < 5)
			{
				MessageBox.Show("ERROR: debe seleccionar 5 jugadores en la plantilla inicial para continuar.",
					"Formación inicial no disponible",
					MessageBoxButtons.OK,
					MessageBoxIcon.Hand);
			}
			else
			{
				this.Close();
			}
		}
	}
}
