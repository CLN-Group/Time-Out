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
	public partial class SelectTeams : Form
	{
		string archivo;
		Team localTeam = new Team();
		Team visitorTeam = new Team();

		public SelectTeams()
		{
			InitializeComponent();
		}

		private void Load_Teams_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir sin guardar los datos ingresados?",
				"Salir sin guardar datos",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button2);
			if (userResponce == System.Windows.Forms.DialogResult.Cancel)
				e.Cancel = true;
		}

		private void button_addTeam_Click(object sender, EventArgs e)
		{
			CreateTeam nuevo = new CreateTeam();
			nuevo.ShowDialog();
		}
	}
}
