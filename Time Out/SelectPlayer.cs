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
	public partial class SelectPlayer : Form
	{
		Player jugador;
		bool done = false;

		public Player JugadorSeleccionado
		{
			get { return jugador; }
			set { jugador = value; }
		}

		public SelectPlayer(List<Player> lista)
		{
			InitializeComponent();

			// Agrega los jugadores titulares y selecciona el primero
			foreach (Player p in lista)
			{
				if (p.Titular)
					this.listBox1.Items.Add(p);
			}
			this.listBox1.DisplayMember = "NombreCompleto";
			this.listBox1.SelectedIndex = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedItem != null)
			{
				jugador = (Player)listBox1.SelectedItem;
				done = true;
				this.Close();
			}
		}

		private void SelectPlayer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!done)
			{
				MessageBox.Show("Seleccione el jugador!!");
				e.Cancel = true;
			}
		}
	}
}
