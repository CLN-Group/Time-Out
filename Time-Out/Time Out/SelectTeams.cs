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
        // Esta variable se utiliza para pedir una 
		// confirmacion al usuario al cerrar la ventana
        bool confirmation = true;
		string archivo;
		Team localTeam = new Team();
		Team visitorTeam = new Team();

        public Team Local
        {
            get { return localTeam; }
            set { localTeam = value; }
        }
        public Team Visitor
        {
            get { return visitorTeam; }
            set { visitorTeam = value; }
        }
		public bool IsReady
		{
			get { return !confirmation; }
		}

		public SelectTeams()
		{
			InitializeComponent();

            archivo = Main.archivoEquipos;
            // Carga los equipos a las listas
            ActualizarListBox();
		}

        /// <summary>
        /// oculta los botones y labels de ambos lados
        /// </summary>
        void ocultarBonotes()
        {
            this.interactiveLabelL.Visible = false;
            this.interactiveLabelV.Visible = false;
            this.button_acceptSelectionL.Visible = false;
            this.button_acceptSelectionV.Visible = false;
        }

		/// <summary>
		/// Carga los equipos que esten guardados en archivos en las dos listBox.
		/// </summary>
        void ActualizarListBox()
        {
            List<Team> listaEquipos = Main.CargarEquipos();
			var listB1 = this.listBox_localTeams;
			var listB2 = this.listBox_visitorTeams;

			//List<string> titulos = Main.CargarTitulosEquipos();
			listB1.DataSource = listaEquipos;
			listB1.DisplayMember = "Titulo";

			// Se crea un nuevo administrador para que la segunda listBox
			// sea independiente a la anterior (porque tienen la misma DataSource)
			listB2.BindingContext = new BindingContext();
			listB2.DataSource = listaEquipos;
			listB2.DisplayMember = "Titulo";

			// Clear the item selected by default in both lists
			listB1.ClearSelected();
			listB2.ClearSelected();

            // Activa ambos listBox por si estan desactivados
            listB1.Enabled = true;
            listB2.Enabled = true;

            ocultarBonotes();
        }
        


		/// <summary>
		/// Sucede cuando el usuario quiere agregar un equipo a la lista
		/// </summary>
		private void button_addTeam_Click(object sender, EventArgs e)
		{
			CreateTeam nuevo = new CreateTeam();
			nuevo.ShowDialog();
            ActualizarListBox();			
		}

		/// <summary>
		/// Sucede cuando el usuario selecciona un equipo diferente
		/// o el sistema vacia el input deseleccionando todos.
		/// </summary>
		private void listBox_SelectedValueChanged(object sender, EventArgs e)
		{
			var list = (ListBox)sender;
			var button1 = this.button_acceptSelectionL;
			var button2 = this.button_acceptSelectionV;
			// Si no hay un item seleccionado actualmente
			// los botones tienen que estar ocultos
			if (list.Name.Equals("listBox_localTeams"))
				// If selectedIndex == -1 -> button.Visible = false
				button1.Visible = (list.SelectedIndex == -1) ? false : true;
			else
				button2.Visible = (list.SelectedIndex == -1) ? false : true;
		}

		/// <summary>
		/// Sucede cuando el usuario ha seleccionado un equipo específico
		/// </summary>
		private void button_acceptSelection_Click(object sender, EventArgs e)
		{
			try
			{
				int selected1 = this.listBox_localTeams.SelectedIndex;  // If NULL then catch
				int selected2 = this.listBox_visitorTeams.SelectedIndex;
				if (selected1.Equals(selected2))
				{
					MessageBox.Show("ERROR: no se pueden enfrentar los mismos equipos.\n",
						"Equipo local igual que visitante",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
						return; // Sale del metodo
				}
			} // Ataja cuando no hay item seleccionado del lado contrario
			catch (NullReferenceException) { }
			var button = (Button)sender;
			button.Visible = false;
			if (button.Name.Equals("button_acceptSelectionL"))
			{
				if (!this.interactiveLabelV.Visible)
				{
					this.interactiveLabelL.Visible = true;
					this.listBox_localTeams.Enabled = false;
				}
				else
					Ready();
			}
			else 
			{ // button_acceptSelectionV
				if (!this.interactiveLabelL.Visible)
				{
					this.interactiveLabelV.Visible = true;
					this.listBox_visitorTeams.Enabled = false;
				}
				else
					Ready();
			}
		}

		/// <summary>
		/// Sucede cuando el usuario quiere elegir un equipo diferente 
		/// al elegido actualmente
		/// </summary>
		private void interactiveLabel_Click(object sender, EventArgs e)
		{
			var labelClicked = (Label)sender;
			if (labelClicked.Name.Equals("interactiveLabelL"))
			{
				this.listBox_localTeams.Enabled = true;
				this.listBox_localTeams.ClearSelected();
			}
			else
			{
				this.listBox_visitorTeams.Enabled = true;
				this.listBox_visitorTeams.ClearSelected();
			}
			labelClicked.Visible = false;
		}


        /// <summary>
        /// Guarda los equipos seleccionados en las variables locales,
		/// <para>tanto para el local y el visitante.</para>
        /// </summary>
        void saveSelectedTeams()
        {
			// Posiciones del equipo local y visitante de los listBox
			int posLocal, posVisitor;
			posLocal = this.listBox_localTeams.SelectedIndex;
			posVisitor = this.listBox_visitorTeams.SelectedIndex;
			// Crea una lista con los equipos y la ordena
			List<Team> listaEquipos = Main.CargarEquipos();
			// Es necesario que sea ordenada, ya que la posición
			// del listBox corresponde a la lista ordenada
			listaEquipos.Sort(new Team.TeamComparer());
			// Guarda los equipos correspondientes en las variables locales
			this.localTeam = listaEquipos[posLocal];
			this.visitorTeam = listaEquipos[posVisitor];
        }

		
        /// <summary>
        /// Guarda el equipo local y visitantes en las variables locales.
        /// <para>Este metodo sera llamado cuando el usuario finalize la eleccion de ambos equipos.</para>
        /// </summary>
        void Ready()
        {
			saveSelectedTeams();
            // Desactiva la confirmacion del usuario al cerrar la ventana
            this.confirmation = false;
            this.Close();
        }

        /// <summary>
        /// Abre un dialogo pidiendo confirmación al usuario para cerrar la ventana.
        /// <para>Se ejecuta al enviar una señal para cerrar la ventana.</para>
        /// </summary>
        private void Load_Teams_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (confirmation)
            {
                DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir sin seleccionar ambos equipos?",
                    "Salir sin equipos elegidos",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (userResponce == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
	}
}
