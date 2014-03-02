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
	public partial class ShowStatistics : Form
	{
		Match partido;

		/// <summary>
		/// Constructor de la clase.
		/// <para>La ventana muestra las estadísticas de un partido determinado</para>
		/// </summary>
		/// <param name="partido">Recibe el partido y sus estadísticas</param>
		public ShowStatistics(Match partido)
		{
			InitializeComponent();

			this.partido = partido;
			displayInformation();
		}

		void displayInformation()
		{
			// Muestra la fecha corta (YYYY/MM/DD or something like that) del partido
			string fecha = this.partido.Fecha.ToShortDateString()+" "+this.partido.Fecha.ToShortTimeString();
			this.fecha.Text = fecha;
			// Muestra los titulos de los equipos
			this.titulo_local.Text = partido.EquipoLocal;
			this.titulo_visitante.Text = partido.EquipoVisitante;
			// Muestra todas las estadísticas del equipo LOCAL
			this.DOEN_L.Text = partido.EstadisticasLocal.DoblesEncestados.ToString();
			this.DOFA_L.Text = partido.EstadisticasLocal.DoblesFallidos.ToString();
			this.TREN_L.Text = partido.EstadisticasLocal.TriplesEncestados.ToString();
			this.TRFA_L.Text = partido.EstadisticasLocal.TriplesFallidos.ToString();
			this.TLEN_L.Text = partido.EstadisticasLocal.SimplesEncestados.ToString();
			this.TLFA_L.Text = partido.EstadisticasLocal.SimplesFallidos.ToString();
			this.REDE_L.Text = partido.EstadisticasLocal.RebotesDefensivos.ToString();
			this.REOF_L.Text = partido.EstadisticasLocal.RebotesOfensivos.ToString();
			this.FALTAS_L.Text = partido.EstadisticasLocal.Faltas.ToString();

            int TotalScore_Local = partido.EstadisticasLocal.SimplesEncestados;
            TotalScore_Local    += partido.EstadisticasLocal.DoblesEncestados  * 2;
            TotalScore_Local    += partido.EstadisticasLocal.TriplesEncestados * 3;

            this.label_TotalScoreL.Text = TotalScore_Local.ToString();

			// Muestra todas las estadísticas del equipo VISITANTE
			this.DOEN_V.Text = partido.EstadisticasVisitante.DoblesEncestados.ToString();
			this.DOFA_V.Text = partido.EstadisticasVisitante.DoblesFallidos.ToString();
			this.TREN_V.Text = partido.EstadisticasVisitante.TriplesEncestados.ToString();
			this.TRFA_V.Text = partido.EstadisticasVisitante.TriplesFallidos.ToString();
			this.TLEN_V.Text = partido.EstadisticasVisitante.SimplesEncestados.ToString();
			this.TLFA_V.Text = partido.EstadisticasVisitante.SimplesFallidos.ToString();
			this.REDE_V.Text = partido.EstadisticasVisitante.RebotesDefensivos.ToString();
			this.REOF_V.Text = partido.EstadisticasVisitante.RebotesOfensivos.ToString();
			this.FALTAS_V.Text = partido.EstadisticasVisitante.Faltas.ToString();

            int TotalScore_Visitor = partido.EstadisticasVisitante.SimplesEncestados;
            TotalScore_Visitor    += partido.EstadisticasVisitante.DoblesEncestados  * 2;
            TotalScore_Visitor    += partido.EstadisticasVisitante.TriplesEncestados * 3;

            this.label_TotalScoreV.Text = TotalScore_Visitor.ToString();
		}
	}
}
