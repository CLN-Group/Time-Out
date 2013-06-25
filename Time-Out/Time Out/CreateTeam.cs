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
	public partial class CreateTeam : Form
	{
		Team createdTeam = new Team();

		public CreateTeam()
		{
			InitializeComponent();
		}

		private void CreateTeam_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir sin guardar los datos ingresados?",
				"Salir sin guardar datos",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button2);
			if (userResponce == System.Windows.Forms.DialogResult.Cancel)
				e.Cancel = true;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
