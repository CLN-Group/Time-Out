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
    public partial class partido : Form
    {
        Team local;   // Equipo local
		Team visitor; // Equipo visitante
		List<Registro> minuteToMinute = new List<Registro>();
		Counter count = new Counter();
		// Constante que guarda la cantidad limite 
		// de faltas permitidas previo a la expulsión
		const int maxFaltas = 6;
		/*
		 * Hay dos largos procesos en un partido, 
		 * suceden cuando hay Falta o cuando hay Balon Afuera.
		 */
		bool procesoFalta       = false;
		bool procesoBalonAfuera = false;
        bool localTeamShoot     = false;
		// Cantidad de tiros libres a tirar tras la falta
		int tirosLibresDisponibles = 0;
        // This will be checked in the close event,
        // avoiding unnintentional actions and lose of data.
		bool closeWindow = false;
		// Clase para guardar el registro completo del partido
		Match partidoJugado;
		// Archivo para guardar el registro del partido
		string archivoPartidos = "";

		public string ArchivoPartidos
		{
			get { return archivoPartidos; }
			set { archivoPartidos = value; }
		}

		/// <summary>
		/// El constructor de la clase.
		/// </summary>
		/// <param name="a">Equipo local</param>
		/// <param name="b">Equipo visitante</param>
        public partido(Team a, Team b)
        {
            InitializeComponent();

            local   = a;
            visitor = b;

            if (a != null && b != null) {
                actualizarListbox();
			    this.label_tituloLocal.Text     = local.Name;
			    this.label_tituloVisitante.Text = visitor.Name;
                this.label_LTO_restante.Text    = Team.TOmax.ToString();
                this.label_VTO_restante.Text    = Team.TOmax.ToString();
            }
        }

        public void actualizarListbox()
        {
            cargarTitulares();
            cargarVisitantes();
        }

        void cargarTitulares()
        {
            listBox_LocalRoster.Items.Clear();
            comboBox_LocalSubs.Items.Clear();

            foreach (Player p in this.local.Players) {
                if (p.Starter)
                    listBox_LocalRoster.Items.Add(p);
                else
                    comboBox_LocalSubs.Items.Add(p);
            }

            listBox_LocalRoster.DisplayMember = "CompleteName";
            comboBox_LocalSubs.DisplayMember  = "CompleteName";
        }

        void cargarVisitantes()
        {
            listBox_VisitorRoster.Items.Clear();
            comboBox_VisitorSubs.Items.Clear();

            foreach (Player p in this.visitor.Players) {
                if (p.Starter)
                    listBox_VisitorRoster.Items.Add(p);
                else
                    comboBox_VisitorSubs.Items.Add(p);
            }

            listBox_VisitorRoster.DisplayMember = "CompleteName";
            comboBox_VisitorSubs.DisplayMember  = "CompleteName";
        }

		/// <summary>
		/// Agrega un partido en una lista generica.
		/// </summary>
		/// <param name="equipo">Partido que sera agregado a la lista.</param>
		/// <param name="listaEquipos">Lista que tiene el resto de los partidos</param>
		/// <returns>La misma lista con el partido agregado</returns>
		List<Match> addMatchToList(Match partido, List<Match> listaPartidos)
		{
			if (listaPartidos == null)
				listaPartidos = new List<Match>();

			listaPartidos.Add(partido);

			return listaPartidos;
		}

		/// <summary>
		/// Guarda el partido y su información en el archivo
		/// </summary>
		void guardarPartidoEnArchivo()
		{
            // Load previous matchs from file
			List<Match> listaDePartidos = Main.CargarPartidos();
            // Add the new match to the list
			listaDePartidos = addMatchToList(this.partidoJugado, listaDePartidos);
            // Store the updated list to the file
			StreamWriter flujo   = new StreamWriter(this.archivoPartidos);
			XmlSerializer serial = new XmlSerializer(typeof(List<Match>));
			serial.Serialize(flujo, listaDePartidos);
			flujo.Close();
		}

		/// <summary>
		/// Guarda las estadísticas recogidas durante el partido.
		/// </summary>
		void guardarInformación()
		{
			// Crea la lista
			this.partidoJugado = new Match();

			// Add match's metadata
			partidoJugado.Fecha           = DateTime.Now;
			partidoJugado.EquipoLocal     = local.Name;
			partidoJugado.EquipoVisitante = visitor.Name;

			// Agrega los nombres de TODOS los jugadores
			// y sus respectivas estadísticas
			foreach(Player p in local.Players)
			{
				partidoJugado.JugadoresLocales.Add(p.CompleteName);
				// Agrega las estadísticas sumandolas a las actuales
				partidoJugado.EstadisticasLocal.Asistencias       += p.AsistenciasLogradas;
				partidoJugado.EstadisticasLocal.SimplesEncestados += p.TirosLibresAnotados;
				partidoJugado.EstadisticasLocal.SimplesFallidos   += p.TirosLibresFallados;
				partidoJugado.EstadisticasLocal.DoblesEncestados  += p.PuntosDoblesAnotados;
				partidoJugado.EstadisticasLocal.DoblesFallidos    += p.PuntosDoblesFallados;
				partidoJugado.EstadisticasLocal.TriplesEncestados += p.PuntosTriplesAnotados;
				partidoJugado.EstadisticasLocal.TriplesFallidos   += p.PuntosTriplesFallados;
				partidoJugado.EstadisticasLocal.RebotesDefensivos += p.RebotesDefensivos;
				partidoJugado.EstadisticasLocal.RebotesOfensivos  += p.RebotesOfensivos;
				partidoJugado.EstadisticasLocal.Faltas            += p.FaltasCometidas;
			}
			foreach(Player p in visitor.Players)
			{
				partidoJugado.JugadoresVisitantes.Add(p.CompleteName);
				// Agrega las estadísticas sumandolas a las actuales
				partidoJugado.EstadisticasVisitante.Asistencias       += p.AsistenciasLogradas;
				partidoJugado.EstadisticasVisitante.SimplesEncestados += p.TirosLibresAnotados;
				partidoJugado.EstadisticasVisitante.SimplesFallidos   += p.TirosLibresFallados;
				partidoJugado.EstadisticasVisitante.DoblesEncestados  += p.PuntosDoblesAnotados;
				partidoJugado.EstadisticasVisitante.DoblesFallidos    += p.PuntosDoblesFallados;
				partidoJugado.EstadisticasVisitante.TriplesEncestados += p.PuntosTriplesAnotados;
				partidoJugado.EstadisticasVisitante.TriplesFallidos   += p.PuntosTriplesFallados;
				partidoJugado.EstadisticasVisitante.RebotesDefensivos += p.RebotesDefensivos;
				partidoJugado.EstadisticasVisitante.RebotesOfensivos  += p.RebotesOfensivos;
				partidoJugado.EstadisticasVisitante.Faltas            += p.FaltasCometidas;
			}
			guardarPartidoEnArchivo();
		}

		/// <summary>
		/// Activa el botón de Comienzo del partido
		/// </summary>
		void activarContinuacion()
		{
			timer1.Stop();
			button1.Text           = "Comenzar";
			button1.Enabled        = true;
			this.button1.BackColor = Color.DeepSkyBlue;
		}

		/// <summary>
		/// Congela/detiene el reloj del partido y desactiva el botón de Comienzo
		/// </summary>
		void congelarContinuacion()
		{
			timer1.Stop();
			button1.Text           = "Parado";
			button1.Enabled        = false;
			this.button1.BackColor = Color.Red;
		}

		/// <summary>
		/// Pone el reloj a correr y desactiva el botón
		/// </summary>
		void correrContinuacion()
		{
			timer1.Enabled         = true;
			button1.Text           = "Pausar";
			button1.Enabled        = true;
			this.button1.BackColor = Color.Red;
		}

		/// <summary>
		/// Evento llamado cuando finaliza el encuentro.
		/// </summary>
		void finishMatch()
		{
			timer1.Stop();

			button1.Text      = "Finalizado";
			button1.Enabled   = false;
			button1.BackColor = Color.Black;

			// Almacena la información recolectada del encuentro
			guardarInformación();

			// Display a minute-to-minute chart
			ShowEvents nuevo = new ShowEvents(this.minuteToMinute);
			nuevo.ShowDialog();

            // Desactiva la pregunta al salir
            closeWindow = true;
			this.Close();
		}
		
		/// <summary>
		/// Cambia el contexto de la ventana deacuerdo al momento correspondiente
		/// </summary>
		void finalizarCuarto()
		{
			count.resetCounter();
			activarContinuacion();
			// Restablece los tiempos muertos
			this.local.restartTO();
			this.visitor.restartTO();
			// Desactiva botones no disponibles
			desactivarCambio();
			desactivarTO();
			desactivarPuntos();
			desactivarFalta();
            desactivarPerdida();
			desactivarRebotes();

			if (this.lblCuarto.Text[0] == '1')
				this.lblCuarto.Text = "2do Cuarto";
			else if (this.lblCuarto.Text[0] == '2')
				this.lblCuarto.Text = "3er Cuarto";
			else if (this.lblCuarto.Text[0] == '3')
				this.lblCuarto.Text = "4to Cuarto";
			else
				finishMatch();
		}

        private void timer1_Tick(object sender, EventArgs e)
		{
			count.decCounter();

            this.label_timer.Text = count.getCounter;

			if (count.getCounter == "00:00:00")
				finalizarCuarto();
		}

		

		#region Activar y Desactivar botones y labels

		#region Desactivar y Activar puntos
		void desactivarDoblesLocal()
		{
			btn_dobleEncestado_L.Enabled = false;
			btn_dobleErrado_L.Enabled = false;
		}
		void desactivarDoblesVisitante()
		{
			btn_dobleEncestado_V.Enabled = false;
			btn_dobleErrado_V.Enabled = false;
		}
		void desactivarTriplesLocal()
		{
			btn_tripleEncestado_L.Enabled = false;
			btn_tripleErrado_L.Enabled = false;
		}
		void desactivarTriplesVisitante()
		{
			btn_tripleEncestado_V.Enabled = false;
			btn_tripleErrado_V.Enabled = false;
		}
		void desactivarPuntos()
		{
			desactivarDoblesLocal();
			desactivarDoblesVisitante();
			desactivarTriplesLocal();
			desactivarTriplesVisitante();
		}

		void activarDoblesLocal()
		{
			btn_dobleEncestado_L.Enabled = true;
			btn_dobleErrado_L.Enabled = true;
		}
		void activarDoblesVisitante()
		{
			btn_dobleEncestado_V.Enabled = true;
			btn_dobleErrado_V.Enabled = true;
		}
		void activarTriplesLocal()
		{
			btn_tripleEncestado_L.Enabled = true;
			btn_tripleErrado_L.Enabled = true;
		}
		void activarTriplesVisitante()
		{
			btn_tripleEncestado_V.Enabled = true;
			btn_tripleErrado_V.Enabled = true;
		}
		void activarPuntos()
		{
			activarDoblesLocal();
			activarDoblesVisitante();
			activarTriplesLocal();
			activarTriplesVisitante();
		}
		#endregion

        void activarFalta()
        {
            button_faltaL.Enabled = true;
            button_faltaV.Enabled = true;
        }
        void desactivarFalta()
        {
            button_faltaL.Enabled = false;
            button_faltaV.Enabled = false;
        }
        
        void activarPerdida()
        {
            //button_perdidaL.Enabled = true;
            //button_perdidaV.Enabled = true;
        }
        void desactivarPerdida()
        {
            //button_perdidaL.Enabled = false;
            //button_perdidaV.Enabled = false;
        }
        
		void activarCambio()
		{
			this.button_changeL.Visible = true;
			this.button_changeV.Visible = true;
		}
		void desactivarCambio()
		{
			this.button_changeL.Visible = false;
			this.button_changeV.Visible = false;
		}

		
		void activarTOLocal()
		{
			if (local.TiemposMuertosRestantes > 0)
				this.LocalTO.Enabled = true;
		}
		void activarTOVisitante()
		{
			if (visitor.TiemposMuertosRestantes > 0)
				this.VisitorTO.Enabled = true;
		}
		void activarTO()
		{
			activarTOLocal();
			activarTOVisitante();
		}
		void desactivarTOLocal()
		{
			this.LocalTO.Enabled = false;
		}
		void desactivarTOVisitante()
		{
			this.VisitorTO.Enabled = false;
		}
		void desactivarTO()
		{
			desactivarTOLocal();
			desactivarTOVisitante();
		}

		void activarLibreLocal()
		{
			btn_libreEncestado_L.Enabled = true;
			btn_libreErrado_L.Enabled = true;
		}
		void desactivarLibreLocal()
		{
			btn_libreEncestado_L.Enabled = false;
			btn_libreErrado_L.Enabled = false;
		}

		void activarLibreVisitante()
		{
			btn_libreEncestado_V.Enabled = true;
			btn_libreErrado_V.Enabled = true;
		}
		void desactivarLibreVisitante()
		{
			btn_libreEncestado_V.Enabled = false;
			btn_libreErrado_V.Enabled = false;
		}

		/// <summary>
		/// Activa el rebote defensivo del equipo defensor y
		/// el rebote ofensivo del equipo atacante
		/// </summary>
		/// <param name="defensivoLocal">Si es falso, el visitante esta defendiendo el rebote</param>
		void activarRebotes(bool defensivoLocal = true)
		{
			if (defensivoLocal)
			{
				this.btn_rebote_Defensivo_L.Visible = true;
				this.btn_rebote_Ofensivo_V.Visible  = true;
			}
			else
			{
				this.btn_rebote_Ofensivo_L.Visible  = true;
				this.btn_rebote_Defensivo_V.Visible = true;
			}
		}
		/// <summary>
		/// Desactiva TODOS los rebotes de TODOS los equipos
		/// </summary>
		void desactivarRebotes()
		{
			// Locales
			this.btn_rebote_Defensivo_L.Visible = false;
			this.btn_rebote_Ofensivo_L.Visible = false;
			// y Visitantes
			this.btn_rebote_Ofensivo_V.Visible = false;
			this.btn_rebote_Defensivo_V.Visible = false;
		}
		#endregion


		#region Registros


		void registrarSimple(string nombreJugador, bool encestado = true)
		{
			string cuarto = lblCuarto.Text[0].ToString();
			string evento = (encestado) ? "Tiro Libre Anotado" : "Tiro Libre Fallado";
			Registro r    = new Registro(cuarto, this.label_timer.Text, evento, nombreJugador);
			minuteToMinute.Add(r);
		}
		void registrarDoble(string nombreJugador, bool encestado = true)
		{
			string cuarto = lblCuarto.Text[0].ToString();
			string evento = (encestado) ? "Doble Anotado" : "Doble Fallado";
            Registro r    = new Registro(cuarto, this.label_timer.Text, evento, nombreJugador);
			minuteToMinute.Add(r);
		}
		void registrarTriple(string nombreJugador, bool encestado = true)
		{
			string cuarto = lblCuarto.Text[0].ToString();
			string evento = (encestado) ? "Triple Anotado" : "Triple Fallado";
			Registro r    = new Registro(cuarto, this.label_timer.Text, evento, nombreJugador);
			minuteToMinute.Add(r);
		}
		void registrarRebote(string nombreJugador, bool ofensivo = false)
		{
			string cuarto = lblCuarto.Text[0].ToString();
			string evento = (ofensivo) ? "Rebote Ofensivo" : "Rebote Defensivo";
			Registro r    = new Registro(cuarto, this.label_timer.Text, evento, nombreJugador);
			minuteToMinute.Add(r);
		}
		void registrarFalta(string nombreJugador)
		{
			string cuarto = lblCuarto.Text[0].ToString();
			Registro r    = new Registro(cuarto, this.label_timer.Text, "Falta", nombreJugador);
			minuteToMinute.Add(r);
		}


		/// <summary>
		/// Registra una canasta simple, doble o triple Encestada. Cambia el anotador del partido
		/// </summary>
		/// <param name="valor">Puede ser 1, 2 o 3</param>
		/// <param name="jugador">Jugador al que se le asignara el punto</param>
		/// <param name="local">Si es falso, corresponde al equipo visitante</param>
		void anotacion(int valor, Player jugador, bool local = true)
		{
            switch (valor)
            {
                case 1:
                    jugador.TirosLibresAnotados++;
                    registrarSimple(jugador.CompleteName);
                    break;
                case 2:
                    jugador.PuntosDoblesAnotados++;
                    registrarDoble(jugador.CompleteName);
                    break;
                case 3:
                    jugador.PuntosTriplesAnotados++;
                    registrarTriple(jugador.CompleteName);
                    break;
            }

            Label score = null;

			if (local) 
                score = this.label_ptsLocal;
            else 
                score = this.label_ptsVsitor;

			int pts     = Convert.ToInt32(score.Text) + valor;
			score.Text = pts.ToString();
		}

		/// <summary>
		/// Registra una canasta simple, doble o triple Fallida. 
        /// Of course it does not change the scorer
		/// </summary>
		/// <param name="valor">Puede ser 1, 2 o 3</param>
		/// <param name="jugador">Jugador al que se le asignara el fallo</param>
		void fallo(int valor, Player jugador)
		{
            switch (valor)
            {
                case 1:
                    jugador.TirosLibresFallados++;
				    registrarSimple(jugador.CompleteName, false);
                    break;
                case 2:
                    jugador.PuntosDoblesFallados++;
				    registrarDoble(jugador.CompleteName, false);
                    break;
                case 3:
                    jugador.PuntosTriplesFallados++;
				    registrarTriple(jugador.CompleteName, false);
                    break;
            }
		}

        #endregion


        // ******************** //
		// * METODOS LLAMADOS * //
		// *  POR EL USUARIO  * //
		// ******************** //

		/// <summary>
		/// Sucede cuando el usuario presiona el boton de "Comienzo" del partido
		/// </summary>
		private void button1_Click(object sender, EventArgs e)
		{	
			desactivarCambio();
            desactivarRebotes();
            desactivarPuntos();
            desactivarPerdida();
            desactivarFalta();
            desactivarLibreLocal();
            desactivarLibreVisitante();

			if (procesoFalta)
			{
				MessageBox.Show("Se continua con los tiros libres..");
				congelarContinuacion();
                activarCambio();

                // Check which team received fault and enable its free shoots
                if (localTeamShoot)
				    activarLibreLocal();
                else
				    activarLibreVisitante();

                localTeamShoot = false;
			}
			else
			{
                // Check if time is running...
                if (timer1.Enabled) 
                { //... User want to stop timing
                    desactivarPerdida();
                    desactivarPuntos();
                    desactivarFalta();
                    activarContinuacion();
                    activarCambio();
                }
                else
                { //... User want to continue timing
                    activarFalta();
                    activarPerdida();
                    activarTO();
                    activarPuntos();
                    correrContinuacion();
                }
			}
		}

		/// <summary>
		/// Sucede cuando el usuario realiza un Tiempo Muerto para el LOCAL
		/// </summary>
		private void LocalTO_Click(object sender, EventArgs e)
		{
			// Cambia la interfaz del usuario
			// Parar reloj y dejarlo a disposición del usuario
			activarContinuacion();
			activarCambio();

			// Desactiva los controles no disponibles
			desactivarTO();
			desactivarPuntos();
			desactivarFalta();
            desactivarPerdida();
			desactivarLibreLocal();
            desactivarRebotes();

			// Asigna los tiempos muertos
			local.TiemposMuertosRestantes--;
            this.label_LTO_restante.Text = local.TiemposMuertosRestantes.ToString();
			if (local.TiemposMuertosRestantes == 0)
				this.LocalTO.Enabled = false;

            if (procesoFalta) {
                localTeamShoot = true;
            }
		}

		/// <summary>
		/// Sucede cuando el usuario realiza un Tiempo Muerto para el VISITANTE
		/// </summary>
		private void VisitorTO_Click(object sender, EventArgs e)
		{
			// Cambia la interfaz del usuario
			// Parar reloj y dejarlo a disposición del usuario
			activarContinuacion();
			activarCambio();

            // Desactiva los controles no disponibles
			desactivarTO();
			desactivarPuntos();
			desactivarFalta();
            desactivarPerdida();
			desactivarLibreVisitante();
            desactivarRebotes();

			// Asigna los tiempos muertos
			visitor.TiemposMuertosRestantes--;
            this.label_VTO_restante.Text = visitor.TiemposMuertosRestantes.ToString();
			if (visitor.TiemposMuertosRestantes == 0)
				this.VisitorTO.Enabled = false;
		}

		/// <summary>
		/// Sucede cuando el usuario quiere realizar un cambio del LOCAL
		/// </summary>
		private void button2_Click(object sender, EventArgs e)
		{
			if (listBox_LocalRoster.SelectedItem != null && comboBox_LocalSubs.SelectedItem != null)
			{
				Player p = (Player)listBox_LocalRoster.SelectedItem;
				p.Starter = false;
				p = (Player)comboBox_LocalSubs.SelectedItem;
				p.Starter = true;
				// Actualizar
				cargarTitulares();
			}
		}

		/// <summary>
		/// Sucede cuando el usuario quiere realizar un cambio del VISITANTE
		/// </summary>
		private void button3_Click(object sender, EventArgs e)
		{
			if (listBox_VisitorRoster.SelectedItem != null && comboBox_VisitorSubs.SelectedItem != null)
			{
				Player p = (Player)listBox_VisitorRoster.SelectedItem;
				p.Starter = false;
				p = (Player)comboBox_VisitorSubs.SelectedItem;
				p.Starter = true;
				// Actualizar
				cargarVisitantes();
			}
		}

		/// <summary>
        /// Sucede cuando el equipo LOCAL comete una falta
		/// </summary>
		private void button_faltaL_Click(object sender, EventArgs e)
		{
			congelarContinuacion();
            desactivarFalta();
            desactivarPerdida();
			desactivarTOLocal();
            activarTOVisitante();

			if (listBox_LocalRoster.SelectedItem != null)
			{				
				// Agrega la Falta al Jugador y Registra el evento
				Player p = (Player)listBox_LocalRoster.SelectedItem;
				p.FaltasCometidas++;
				registrarFalta(p.CompleteName);

				// Fire player from game if reached limit of faults committed
				if (p.FaltasCometidas == maxFaltas)
					listBox_LocalRoster.Items.Remove(p);

				// Check if player was shooting while received the fault
				DialogResult userResponce = MessageBox.Show("El jugador estaba en posicion de Tiro?",
					"Posicion de tiro",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);
				if (userResponce == DialogResult.Yes)
				{
					//desactivarTO();
					procesoFalta = true; // Activa el proceso falta
					desactivarDoblesLocal();
					desactivarTriplesLocal();
				}
				else // Saque desde el costado
				{
					desactivarPuntos();
					desactivarRebotes();
					// Activa el boton de Comienzo
					activarContinuacion();
					procesoBalonAfuera = true; // Activa el proceso Balon Afuera
				}
			}
			else // No se conoce el jugador que realizo la falta
			{
				SelectPlayer nuevo = new SelectPlayer(local.Players);
				nuevo.ShowDialog();
				this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
				button_faltaL_Click(sender, e);
			}
		}


		/// <summary>
		/// Sucede cuando el equipo VISITANTE comete una falta
		/// </summary>
		private void button_faltaV_Click(object sender, EventArgs e)
		{
			congelarContinuacion();
            desactivarFalta();
            desactivarPerdida();
			desactivarTOVisitante();
            activarTOLocal();

			if (listBox_VisitorRoster.SelectedItem != null)
			{
				// Agrega la Falta al Jugador y Registra el evento
				Player p = (Player)listBox_VisitorRoster.SelectedItem;
				p.FaltasCometidas++;
				registrarFalta(p.CompleteName);

                // Fire player from game if reached limit of faults committed
				if (p.FaltasCometidas == maxFaltas)
					listBox_VisitorRoster.Items.Remove(p);

                // Check if player was shooting while received the fault
				DialogResult userResponce = MessageBox.Show("El jugador estaba en posicion de Tiro?",
					"Posicion de tiro",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);
				if (userResponce == DialogResult.Yes)
				{
					//desactivarTO();
					procesoFalta = true; // Activa el proceso falta
					desactivarDoblesVisitante();
					desactivarTriplesVisitante();
				}
				else // Saque desde el costado
				{
					desactivarPuntos();
					desactivarRebotes();
					// Activa el boton de Comienzo
					activarContinuacion();
					procesoBalonAfuera = true; // Activa el proceso Balon Afuera
				}
			}
			else // No se conoce el jugador que realizo la falta
			{
				SelectPlayer nuevo = new SelectPlayer(visitor.Players);
				nuevo.ShowDialog();
				this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
				button_faltaV_Click(sender, e);
			}
		}


		/// <summary>
		/// Sucede cuando el equipo LOCAL encesta un DOBLE
		/// </summary>
		private void btn_DobleEns_L_Click(object sender, EventArgs e)
		{
			// Detiene el reloj
			timer1.Enabled = false;
			Player aux = (Player)listBox_LocalRoster.SelectedItem;
			if (aux != null)
			{
				anotacion(2, aux);

                desactivarPuntos();
                desactivarRebotes();
                desactivarFalta();
                desactivarPerdida();

				// Check if player has received a fault while shooting
				if (procesoFalta)
				{
					// Cambia la interfaz del usuario
					activarTOLocal();
					activarLibreLocal();
					desactivarPuntos();
					// Tira 1 tiro libre al recibir falta en zona de 2 punto
					tirosLibresDisponibles = 1;
					//TODO
					// Muestra el Estado
					//toolStripStatusLabel1.Text = ""
				}
				else
				{
					desactivarTOLocal();
					
					// Activa el boton de Comienzo
					activarContinuacion();
				}
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(local.Players);
				nuevo.ShowDialog();
				this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_DobleEns_L_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE encesta un DOBLE
		/// </summary>
		private void btn_dobleEncestado_V_Click(object sender, EventArgs e)
		{
			// Detiene el reloj
			timer1.Enabled = false;
			Player aux = (Player)listBox_VisitorRoster.SelectedItem;
			if (aux != null)
			{
				anotacion(2, aux, false);

                desactivarPuntos();
                desactivarRebotes();
                desactivarFalta();
                desactivarPerdida();

                // Check if player has received a fault while shooting
				if (procesoFalta)
				{
					// Cambia la interfaz gráfica
					activarTOVisitante();
					activarLibreVisitante();
					desactivarPuntos();
                    // Tira 1 tiro libre al recibir falta en zona de 2 punto
					// Tira 1 tiro libre
					tirosLibresDisponibles = 1;  
				}
				else
				{
					desactivarTOVisitante();

					// Activa el boton de Comienzo
					activarContinuacion();
				}
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(visitor.Players);
				nuevo.ShowDialog();
				this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_dobleEncestado_V_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo LOCAL encesta un TRIPLE
		/// </summary>
		private void btn_tripleEncestado_L_Click(object sender, EventArgs e)
		{
			// Detiene el reloj
			timer1.Enabled = false;
			Player aux = (Player)listBox_LocalRoster.SelectedItem;
			if (aux != null)
			{
				anotacion(3, aux);

                desactivarPuntos();
                desactivarRebotes();
                desactivarFalta();
                desactivarPerdida();

                // Check if player has received a fault while shooting
				if (procesoFalta)
				{
					// Cambia la interfaz del usuario
					activarTOLocal();
					activarLibreLocal();
					desactivarPuntos();
					// Jugada de 4 puntos!! oh yeah!
					tirosLibresDisponibles = 1;  // Tira 1 tiro libre
				}
				else
				{
					desactivarTOLocal();

					// Activa el boton de Comienzo
					activarContinuacion();
				}
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(local.Players);
				nuevo.ShowDialog();
				this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_DobleEns_L_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE encesta un TRIPLE
		/// </summary>
		private void btn_tripleEncestado_V_Click(object sender, EventArgs e)
		{
			// Detiene el reloj
			timer1.Enabled = false;
			Player aux = (Player)listBox_VisitorRoster.SelectedItem;
			if (aux != null)
			{
				anotacion(3, aux, false);

                desactivarPuntos();
                desactivarRebotes();
                desactivarFalta();
                desactivarPerdida();

                // Check if player has received a fault while shooting
				if (procesoFalta)
				{
					// Cambia la interfaz del usuario
					activarTOVisitante();
					activarLibreVisitante();
					desactivarPuntos();
					// Jugada de 4 puntos!! oh yeah!
					tirosLibresDisponibles = 1;  // Tira 1 tiro libre
				}
				else
				{
					desactivarTOVisitante();

					// Activa el boton de Comienzo
					activarContinuacion();
				}
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(visitor.Players);
				nuevo.ShowDialog();
				this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_tripleEncestado_V_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo LOCAL erra un DOBLE
		/// </summary>
		private void btn_DobleErrado_L_Click(object sender, EventArgs e)
		{
			desactivarPuntos();

			if (procesoFalta)
			{
				// Cambia la interfaz del usuario
				activarTOLocal();
				activarLibreLocal();
                desactivarFalta();
                desactivarPerdida();

				// Tirara 2 tiros libres
				tirosLibresDisponibles = 2; 
			}
			else
			{
				Player aux = (Player)listBox_LocalRoster.SelectedItem;
				if (aux != null)
				{
					fallo(2, aux);

					// Change UI state
					activarRebotes(false);
					desactivarTOVisitante();
				}
				else
				{
					SelectPlayer nuevo = new SelectPlayer(local.Players);
					nuevo.ShowDialog();
					this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
					btn_DobleErrado_L_Click(sender, e);
				}
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE erra un DOBLE
		/// </summary>
		private void btn_dobleErrado_V_Click(object sender, EventArgs e)
		{
			desactivarPuntos();

			if (procesoFalta)
			{
				// Cambia la interfaz del usuario
				activarTOVisitante();
				activarLibreVisitante();
                desactivarFalta();
                desactivarPerdida();

				// Tirara 2 tiros libres
				tirosLibresDisponibles = 2; 
			}
			else
			{
				Player aux = (Player)listBox_VisitorRoster.SelectedItem;
				if (aux != null)
				{
					fallo(2, aux);

                    // Change UI state
					activarRebotes();
					desactivarTOLocal();
				}
				else
				{
					SelectPlayer nuevo = new SelectPlayer(visitor.Players);
					nuevo.ShowDialog();
					this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
					btn_dobleErrado_V_Click(sender, e);
				}
			}
		}

		/// <summary>
		/// Sucede cuando el equipo LOCAL erra un TRIPLE
		/// </summary>
		private void btn_tripleErrado_L_Click(object sender, EventArgs e)
		{
			desactivarPuntos();

			if (procesoFalta)
			{
				// Cambia la interfaz del usuario
				activarTOLocal();
				activarLibreLocal();
                desactivarFalta();
                desactivarPerdida();

				// Tirara 3 tiros libres
				tirosLibresDisponibles = 3; 
			}
			else
			{
				Player aux = (Player)listBox_LocalRoster.SelectedItem;
				if (aux != null)
				{
					fallo(3, aux);

                    // Change UI state
					activarRebotes(false);
					desactivarTOVisitante();
				}
				else
				{
					SelectPlayer nuevo = new SelectPlayer(local.Players);
					nuevo.ShowDialog();
					this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
					btn_DobleErrado_L_Click(sender, e);
				}
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE erra un TRIPLE
		/// </summary>
		private void btn_tripleErrado_V_Click(object sender, EventArgs e)
		{
			desactivarPuntos();

			if (procesoFalta)
			{
				// Cambia la interfaz del usuario
				activarTOVisitante();
				activarLibreVisitante();
                desactivarFalta();
                desactivarPerdida();

				// Tirara 3 tiros libres
				tirosLibresDisponibles = 3; 
			}
			else
			{
				Player aux = (Player)listBox_VisitorRoster.SelectedItem;
				if (aux != null)
				{
					fallo(3, aux);

                    // Change UI state
					activarRebotes();
					desactivarTOLocal();
				}
				else
				{
					SelectPlayer nuevo = new SelectPlayer(visitor.Players);
					nuevo.ShowDialog();
					this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
					btn_dobleErrado_V_Click(sender, e);
				}
			}
		}

		/// <summary>
		/// Sucede cuando el equipo LOCAL logra un rebote OFENSIVO
		/// </summary>
		private void btn_rebote_L_Click(object sender, EventArgs e)
		{
			Player aux = (Player)listBox_LocalRoster.SelectedItem;
			if(aux != null)
			{
				// Registra el rebote
				aux.RebotesOfensivos++;
				registrarRebote(aux.CompleteName, true);
				// Cambial el entorno
				desactivarRebotes();
				activarFalta();
                activarPerdida();
				activarPuntos();
				// Activa TODOS los tiempos muertos
				activarTO();
				// Vuelve a correr el reloj!
				correrContinuacion();
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(local.Players);
				nuevo.ShowDialog();
				this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_rebote_L_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE logra un rebote OFENSIVO
		/// </summary>
		private void btn_rebote_Ofensivo_V_Click(object sender, EventArgs e)
		{
			Player aux = (Player)listBox_VisitorRoster.SelectedItem;
			if (aux != null)
			{
				// Registra el rebote
				aux.RebotesOfensivos++;
				registrarRebote(aux.CompleteName, true);
				// Cambial el entorno
				desactivarRebotes();
				activarFalta();
                activarPerdida();
				activarPuntos();
				// Activa TODOS los tiempos muertos
				activarTO();
				// Vuelve a correr el reloj!
				correrContinuacion();
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(visitor.Players);
				nuevo.ShowDialog();
				this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_rebote_Ofensivo_V_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo LOCAL logra un rebote DEFENSIVO
		/// </summary>
		private void btn_rebote_Defensivo_L_Click(object sender, EventArgs e)
		{
			Player aux = (Player)listBox_LocalRoster.SelectedItem;
			if (aux != null)
			{
				// Registra el rebote
				aux.RebotesDefensivos++;
				registrarRebote(aux.CompleteName);
				// Cambial el entorno
				desactivarRebotes();
				activarFalta();
                activarPerdida();
				activarPuntos();
				// Activa TODOS los tiempos muertos
				activarTO();
				// Vuelve a correr el reloj!
				correrContinuacion();
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(local.Players);
				nuevo.ShowDialog();
				this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_rebote_Defensivo_L_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE logra un rebote DEFENSIVO
		/// </summary>
		private void btn_rebote_Defensivo_V_Click(object sender, EventArgs e)
		{
			Player aux = (Player)listBox_VisitorRoster.SelectedItem;
			if (aux != null)
			{
				// Registra el rebote
				aux.RebotesDefensivos++;
				registrarRebote(aux.CompleteName);
				// Cambial el entorno
				desactivarRebotes();
				activarFalta();
                activarPerdida();
				activarPuntos();
				// Activa TODOS los tiempos muertos
				activarTO();
				// Vuelve a correr el reloj!
				correrContinuacion();
			}
			else
			{
				SelectPlayer nuevo = new SelectPlayer(visitor.Players);
				nuevo.ShowDialog();
				this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_rebote_Defensivo_V_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo LOCAL encesto un Tiro Libre
		/// </summary>
		private void btn_libreEncestado_L_Click(object sender, EventArgs e)
		{
			tirosLibresDisponibles--;
			Player aux = (Player)listBox_LocalRoster.SelectedItem;
			if (aux != null)
			{
				anotacion(1, aux);
				if (tirosLibresDisponibles == 0)
				{
					// Cambia el tiempo muerto de mando
					activarTO();
					desactivarTOLocal();
					// Desactiva los tiros libres
					desactivarLibreLocal();
					activarContinuacion();
					procesoFalta = false;
				}
			}
			else
			{
				// Selecciona el jugador LOCAL que ENCESTO el tiro
				SelectPlayer nuevo = new SelectPlayer(local.Players);
				nuevo.ShowDialog();
				this.listBox_LocalRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_libreEncestado_L_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE encesto un Tiro Libre
		/// </summary>
		private void btn_libreEncestado_V_Click(object sender, EventArgs e)
		{
			tirosLibresDisponibles--;
			Player aux = (Player)listBox_VisitorRoster.SelectedItem;
			if (aux != null)
			{
				anotacion(1, aux, false);
				if (tirosLibresDisponibles == 0)
				{
					// Cambia el tiempo muerto de mando
					activarTO();
					desactivarTOVisitante();
					desactivarLibreVisitante();
					activarContinuacion();
					procesoFalta = false;
				}
			}
			else
			{
				// Selecciona el jugador VISITANTE que ENCESTO el tiro
				SelectPlayer nuevo = new SelectPlayer(visitor.Players);
				nuevo.ShowDialog();
				this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_libreEncestado_V_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo LOCAL erra un tiro libre
		/// </summary>
		private void btn_libreErrado_L_Click(object sender, EventArgs e)
		{
			tirosLibresDisponibles--;
			Player aux = (Player)listBox_LocalRoster.SelectedItem;
			if (aux != null)
			{
				fallo(1, aux);
				if (tirosLibresDisponibles == 0)
				{
					desactivarLibreLocal();
					correrContinuacion();
					procesoFalta = false;
					// Se encienden los rebotes
					activarRebotes(false);
				}
			}
			else
			{
				// Selecciona el jugador LOCAL que FALLO el tiro
				SelectPlayer window = new SelectPlayer(local.Players);
				window.ShowDialog();
				this.listBox_LocalRoster.SelectedItem = window.JugadorSeleccionado;
				btn_libreErrado_L_Click(sender, e);
			}
		}

		/// <summary>
		/// Sucede cuando el equipo VISITANTE erra un tiro libre
		/// </summary>
		private void btn_libreErrado_V_Click(object sender, EventArgs e)
		{
			tirosLibresDisponibles--;
			Player aux = (Player)listBox_VisitorRoster.SelectedItem;
			if (aux != null)
			{
				fallo(1, aux);
				if (tirosLibresDisponibles == 0)
				{
					desactivarLibreVisitante();
					correrContinuacion();
					procesoFalta = false;
					// Se encienden los rebotes
					activarRebotes(false);
				}
			}
			else
			{
				// Selecciona el jugador LOCAL que FALLO el tiro
				SelectPlayer nuevo = new SelectPlayer(visitor.Players);
				nuevo.ShowDialog();
				this.listBox_VisitorRoster.SelectedItem = nuevo.JugadorSeleccionado;
				btn_libreErrado_V_Click(sender, e);
			}
		}

		/// <summary>
		/// Abre un dialogo pidiendo confirmación al usuario para salir del programa
		/// </summary>
		private void partido_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!closeWindow)
			{
				DialogResult userResponce = MessageBox.Show("Esta seguro que desea cerrar la ventana?\n"+
					"Los datos no seran guardados.",
					"Cerrar ventana",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2);
				if (userResponce == System.Windows.Forms.DialogResult.No)
					e.Cancel = true;
			}
		}

        private void button_perdidaL_Click(object sender, EventArgs e)
        {
            desactivarPuntos();
            desactivarRebotes();
            desactivarFalta();
            desactivarPerdida();
            // Activa el boton de Comienzo
            activarContinuacion();
            procesoBalonAfuera = true; // Activa el proceso Balon Afuera
        }

        private void button_perdidaV_Click(object sender, EventArgs e)
        {
            desactivarPuntos();
            desactivarRebotes();
            desactivarFalta();
            desactivarPerdida();
            // Activa el boton de Comienzo
            activarContinuacion();
            procesoBalonAfuera = true; // Activa el proceso Balon Afuera
        }
    }
}
