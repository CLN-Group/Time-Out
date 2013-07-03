using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace TimeOut
{
	public partial class CreateTeam : Form
	{
        // esta variable se utiliza para pedir una confirmacion al usuario
        bool confirmation = true;
		string rutaDelArchivo;
		Team createdTeam = new Team();
		// Las constantes se utilizan como límite inferior y superior
		// de cantidad de jugadores que debe tener el equipo
		const int cantMinJug = 5;
		const int cantMaxJug = 15;
		// Se crea una lista de strings con todos los nombres 
		// de los equipos guardados para que el nuevo equipo
		// a crear no repita su nombre, evitando duplicados
		List<string> titulos = null;


		int CantidadDeJugadoresIngresados
		{
			get { return Convert.ToInt32(this.label_cantPlayers.Text); }
		}

		/***************/
		/* CONSTRUCTOR */
		/***************/
		public CreateTeam()
		{
			InitializeComponent();

			this.rutaDelArchivo = Main.archivoEquipos;
			this.titulos = Main.CargarTitulosEquipos();
		}
		

        private void button_addPlayer_Click(object sender, EventArgs e)
        {
			if (CantidadDeJugadoresIngresados < cantMaxJug)
			{
				CreatePlayer nuevo = new CreatePlayer();
				nuevo.ShowDialog();
				if (nuevo.JugadorCreado)
				{
					this.createdTeam.Jugadores.Add(nuevo.Jugador);
					int valor = Convert.ToInt32(this.label_cantPlayers.Text) + 1;
					this.label_cantPlayers.Text =  Convert.ToString(valor);
				}
			}
			else
			{
				MessageBox.Show("ERROR: el equipo no puede tener más de " 
					+ Convert.ToString(cantMaxJug) + " jugadores!",
					"Datos ingresados inválidos!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
        }

		/// <summary>
		/// Comprueba si el titulo se encuentra en la lista generica titulos.
		/// </summary>
		/// <param name="title">El titulo a buscar en la lista.</param>
		/// <returns>Verdadero si el titulo ya se encuentra en la lista.</returns>
		bool titleIsOnList(string title)
		{
			bool result = this.titulos.Any(t => t == title);
			return result;
		}

		/// <summary>
		/// Comprueba que todos los parametros tengan valores válidos.
		/// </summary>
		/// <param name="title">Titulo del equipo (nombre).</param>
		/// <param name="nombreDT">Nombre del Director Técnico.</param>
		/// <param name="cantidadJugadores">Cantidad de jugadores ingresados hasta el momento.</param>
		/// <returns>Si todos los valores de los parametros son válidos retorna True</returns>
		public bool datosValidosEquipo(string title, string nombreDT, int cantidadJugadores)
		{
			if (title == "" || nombreDT == "")
				return false;
			if (Player.strConNumero(title) || Player.strConNumero(nombreDT))
				return false;
			if (cantidadJugadores < cantMinJug)
				return false;
			if (titleIsOnList(title))
				return false;
			return true;
		}


		/// <summary>
		/// Agrega un equipo en una lista.
		/// </summary>
		/// <param name="equipo">Equipo que sera agregado a la lista.</param>
		/// <param name="listaEquipos">Lista que tiene el resto de los equipos</param>
		/// <returns>La misma lista con el equipo agregado</returns>
		List<Team> addTeamToList(Team equipo, List<Team> listaEquipos)
		{
			if (listaEquipos == null)
				listaEquipos = new List<Team>();
			listaEquipos.Add(equipo);
			return listaEquipos;
		}

		/// <summary>
		/// Guarda el equipo creado hasta el momento en el archivo
		/// </summary>
		void GuardarEquipo()
        {
			List<Team> listaDeEquipos = Main.CargarEquipos();
			listaDeEquipos = addTeamToList(this.createdTeam, listaDeEquipos);
			StreamWriter flujo = new StreamWriter(this.rutaDelArchivo);
			XmlSerializer serial = new XmlSerializer(typeof(List<Team>));
			serial.Serialize(flujo, listaDeEquipos);
			flujo.Close();
        }

        /// <summary>
        /// comprueba que los datos ingresados sean validos, guarda la informacion y cierra la ventana
        /// </summary>
        private void button_save_Click(object sender, EventArgs e)
        {
			string titulo = this.nameTeamTextBox.Text;
			string nombreDT = this.nameCoachTextBox.Text;
			if (datosValidosEquipo(titulo, nombreDT, CantidadDeJugadoresIngresados))
			{
				this.createdTeam.Titulo = titulo;
				this.createdTeam.NombreDelTecnico = nombreDT;
				// Los jugadores ya han sidos añadidos.
				GuardarEquipo();
                // Desactiva la confirmacion del usuario al cerrar la ventana
                confirmation = false;
				this.Close();
			}
			else
			{
				MessageBox.Show("ERROR: asegurese de que los datos ingresados sean válidos e ingreselos nuevamente.\n"
					+ "NOTA: la cantidad de jugadores del equipo debe ser " 
					+ "mayor a " + Convert.ToString(cantMinJug)
					+ " y menor a " + Convert.ToString(cantMaxJug),
					"Datos ingresados inválidos!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Abre un dialogo pidiendo confirmación al usuario para cerrar la ventana.
        /// <para>Se ejecuta al enviar una señal para cerrar la ventana.</para>
        /// </summary>
        private void CreateTeam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (confirmation)
            {
                DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir sin guardar los datos ingresados?",
                    "Salir sin guardar datos",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (userResponce == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
	}
}
