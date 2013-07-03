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
	public partial class ShowEvents : Form
	{
		List<Registro> eventos;
		public ShowEvents(List<Registro> sucesos)
		{
			InitializeComponent();

			eventos = sucesos;
			mostrarEventos();
		}

		void mostrarEventos()
		{
			listBox1.DataSource = eventos;
			listBox1.DisplayMember = "renglon";
		}
	}
}
