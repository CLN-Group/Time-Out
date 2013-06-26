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
	public partial class SelectTeams : Form
	{
		string archivo;
        List<Team> listaEquipos = new List<Team>();
		Team localTeam = new Team();
		Team visitorTeam = new Team();

		public SelectTeams()
		{
			InitializeComponent();

            archivo = Main.archivoEquipos;
            CargarEquipos();
            ActualizarListBox();
		}
        void ActualizarListBox()
        {
            this.listBox_localTeams.DataSource = null;
            this.listBox_localTeams.DataSource = listaEquipos;
            this.listBox_localTeams.DisplayMember = "Titulo";

            this.listBox_visitorTeams.DataSource = null;
            this.listBox_visitorTeams.DataSource = listaEquipos;
            this.listBox_visitorTeams.DisplayMember = "Titulo";
        }
        void CargarEquipos()
        {
            if (File.Exists(archivo))
            {
                StreamReader flujo = new StreamReader(archivo);
                XmlSerializer serial = new XmlSerializer(typeof(Team));
                listaEquipos = (List<Team>)serial.Deserialize(flujo);
                flujo.Close();
            }
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
