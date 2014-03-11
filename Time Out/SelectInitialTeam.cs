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
		bool done = false;

		public List<Player> Jugadores
		{
			get { return jugadores; }
			set { jugadores = value; }
		}
		private int CantidadJugadoresIniciales
		{
			get { return listBox_initialPlayers.Items.Count; }
		}
		public bool Done
		{
			get { return done; }
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

		/// <summary>
		/// Carga los jugadores desde la lista genérica a listBox
		/// </summary>
		private void loadPlayers()
		{
			this.listBox_availablePlayers.DataSource = this.Jugadores;
			// Se limpia el input del listBox vacío
			this.listBox_initialPlayers.Items.Clear();
			// Ambos listBox mostrarán las mismas propiedades
			this.listBox_availablePlayers.DisplayMember = "CompleteName";
			this.listBox_initialPlayers.DisplayMember = "CompleteName";
		}

		/// <summary>
		/// Se llama cuando el usuario quiere agregar un jugador a la lista de titulares
		/// </summary>
		private void button_add_Click(object sender, EventArgs e)
		{
			Player aux = (Player)this.listBox_availablePlayers.SelectedItem;
			if (aux != null)
			{
				if (!aux.Starter)
				{
					this.listBox_initialPlayers.Items.Add(aux);
					aux.Starter = true;
					if (CantidadJugadoresIniciales == 5)
						this.button_add.Enabled = false;
					if (CantidadJugadoresIniciales == 1)
						this.button_remove.Enabled = true;
				}
				else
					MessageBox.Show("El jugador ya es titular!");
			}
		}

		/// <summary>
		/// Se llama cuando el usuario quiere sacar un jugador de la lista de titulares
		/// </summary>
        private void button_remove_Click(object sender, EventArgs e)
        {
			Player aux = (Player)this.listBox_initialPlayers.SelectedItem;
			if (aux != null)
			{
				Player real = jugadores.FirstOrDefault(x => x == aux);
				real.Starter = false;
				this.listBox_initialPlayers.Items.RemoveAt(this.listBox_initialPlayers.SelectedIndex);
				// Si el botón de agregar jugador estaba desactivado, lo activa
				if (!this.button_add.Enabled)
					this.button_add.Enabled = true;
			}
        }

		/// <summary>
		/// Se llama cuando el usuario termino de realizar los cambios
		/// </summary>
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
				this.done = true;
				this.Close();
			}
		}

		/// <summary>
		/// Revierte todos los cambios realizados en esta clase/ventana
		/// </summary>
		void anularCambios()
		{
			foreach (Player p in this.jugadores)
				p.Starter = false;
		}

		private void SelectInitialTeam_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.done)
			{
				DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir sin guardar los cambios?",
					"Cambios no guardados",
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Warning,
					MessageBoxDefaultButton.Button2);
				if (userResponce == System.Windows.Forms.DialogResult.Cancel)
					e.Cancel = true;
				else
					anularCambios();
			}
		}
	}
}
