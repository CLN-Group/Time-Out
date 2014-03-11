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
		bool confirmation = true;

		#region Propiedades
        public Player Jugador
        {
            get { return jugador; }
        }
		public bool JugadorCreado
		{
			get { return !confirmation; }
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

		
		#region Codigo anulado por cambios de diseños
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
		#endregion


		private void button_save_Click(object sender, EventArgs e)
		{
            string date      = DateTime.Now.ToLongDateString() + DateTime.Now.ToString();
            string id_player = Main.GetHashString(date);

			string n = this.textBox_name.Text;
			string l = this.textBox_lastname.Text;
			float a = (float)this.numericUpDown_altura.Value;
			DateTime b = this.monthCalendar1.SelectionStart;
			string p = Player.getPosicion(this.posicionPreferida.Text);

            if (Player.datosValidosJugador(n, l, a, p, b, id_player))
			{
				jugador.Name      = n;
				jugador.Lastname  = l;
				jugador.Height    = a;
				jugador.Birthdate = b;
				jugador.Position  = p;
                jugador.Id        = id_player;

				// No se guarda el jugador en ningun archivo por cambios de diseño
				//GuardarJugador();

				MessageBox.Show("El jugador ha sido creado correctamente!");
				this.confirmation = false; // Desactiva el mensaje de confirmación
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

		private void button_cancel_Click(object sender, EventArgs e)
		{
			this.Close(); // Trata de cerrar la ventana
		}

		/// <summary>
		/// Abre un dialogo pidiendo confirmación al usuario para cerrar la ventana.
		/// <para>Se ejecuta al enviar una señal para cerrar la ventana.</para>
		/// </summary>
		private void CreatePlayer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (confirmation)
			{
				DialogResult userResponce = MessageBox.Show("Esta seguro que desea salir sin guardar los datos?",
					"Cerrar ventana",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2);
				if (userResponce == System.Windows.Forms.DialogResult.No)
					e.Cancel = true;
			}
		}
	}
}
