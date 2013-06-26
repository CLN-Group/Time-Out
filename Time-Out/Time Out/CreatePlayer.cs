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
	public partial class CreatePlayer : Form
	{
		//string rutaDelArchivo;
		Player jugador = new Player();
		bool status = false;

		#region Propiedades
        public Player Jugador
        {
            get { return jugador; }
        }
		public bool JugadorCreado
		{
			get { return status; }
		}
		/*
		public string RutaDelArchivo
		{
			get { return rutaDelArchivo; }
			set { rutaDelArchivo = value; }
		}*/
		#endregion

		public CreatePlayer()
		{
			InitializeComponent();

			// Inicializa el valor por defecto de la altura del jugador
			// y el nivel del incremento (cada 1 centímetro)
			numericUpDown_altura.Value = 1.90M;
			numericUpDown_altura.Increment = 0.01M;
		}

		/// <summary>
		/// Abre un dialogo pidiendo confirmación al usuario para cerrar la ventana.
		/// <para>Se ejecuta al enviar una señal para cerrar la ventana.</para>
		/// </summary>
		// TODO
		// This method is disabled until solve the bug that opens the AskDialog while closing the form.
		private void CreatePlayer_FormClosing(object sender, FormClosingEventArgs e)
		{
			/*
			if (e.CloseReason == CloseReason.UserClosing)
			{
				DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir sin guardar los datos?",
					"Cerrar ventana",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2);
				if (userResponce == System.Windows.Forms.DialogResult.No)
					e.Cancel = true;
				}
			else
			{ // Llamada de cierre por el sistema o por el programador luego de el guardado de datos
				MessageBox.Show("closing me by me");
				// TODO
				//e.Cancel = true; --> it doesn't work
				return;
			}
			*/
		}
		private void button_cancel_Click(object sender, EventArgs e)
		{
			this.Close(); // Trata de cerrar la ventana
		}

		/// <summary>
		/// Carga todos los jugadores guardados en un archivo XML en una lista de jugadores.
		/// </summary>
		/// <returns>Una lista genérica de jugadores (Players). Si el archivo no existe retorna NULL</returns>
		/*public List<Player> getPlayers()
		{
			List<Player> lista = null;
			if (File.Exists(this.rutaDelArchivo))
			{
				StreamReader flujo = new StreamReader(this.rutaDelArchivo);
				XmlSerializer serial = new XmlSerializer(typeof(List<Player>));
				lista = (List<Player>)serial.Deserialize(flujo);
				flujo.Close();
			}
			return lista;
		}*/

		/// <summary>
		/// Agrega el jugador a la lista. 
		///  <para>La lista puede estar vacía (null).</para>
		/// </summary>
		/// <param name="jugador">Jugador que se guardara en la lista</param>
		/// <param name="listaJugadores">Lista con los otros jugadores, si no existe debe ser null</param>
		/// <returns>Una nueva lista con el jugador agregado.</returns>
		/*List<Player> addPlayerToList(Player jugador, List<Player> listaJugadores)
		{
			if (listaJugadores != null)
			{
				// Obtiene el index más grande de la lista,
				// el mismo lo tendra el último jugador de la lista
				int indexMax = listaJugadores[listaJugadores.Count - 1].ID;
				// El ID del jugador sera único (el último más 1)
				jugador.ID = indexMax + 1;
			} 
			else
			{ // Crea una nueva lista
				// El ID del único jugador (el primer jugador) será 1
				jugador.ID = 1;
				listaJugadores = new List<Player>();
			}
			// Agrega el jugador a la lista
			listaJugadores.Add(jugador);
			return listaJugadores;
		}*/

		/// <summary>
		/// Guarda el jugador agregandolo al archivo XML.
		/// <para>Si el archivo no existe sera creado.</para>
		/// </summary>
		/*void GuardarJugador()
		{
			List<Player> listaDeJugadores = getPlayers();
			listaDeJugadores = addPlayerToList(jugador, listaDeJugadores);
			StreamWriter flujo = new StreamWriter(rutaDelArchivo);
			XmlSerializer serial = new XmlSerializer(typeof(List<Player>));
			serial.Serialize(flujo, listaDeJugadores);
			flujo.Close();
		}*/


		private void button_save_Click(object sender, EventArgs e)
		{
			string n = this.textBox_name.Text;
			string l = this.textBox_lastname.Text;
			float a = (float)this.numericUpDown_altura.Value;
			DateTime b = this.monthCalendar1.SelectionStart;
			string p = Player.getPosicion(this.posicionPreferida.Text);
			bool result = Player.datosValidosJugador(n, l, a, p, b);
			if (result)
			{
				jugador.Nombre = n;
				jugador.Apellido = l;
				jugador.Altura = a;
				jugador.FechaNacimiento = b;
				jugador.Posicion = p;
				//GuardarJugador();
				MessageBox.Show("El jugador ha sido creado correctamente");
				this.status = true;
				//this.CreatePlayer_FormClosing(this, new FormClosingEventArgs(CloseReason.None, false));
				this.Close();
			}
			else
			{
				MessageBox.Show("ERROR: asegurese de que los datos ingresados sean válidos e ingreselos nuevamente.",
					"Datos ingresados inválidos!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
		}
	}
}
