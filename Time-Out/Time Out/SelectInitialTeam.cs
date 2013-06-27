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
	public partial class SelectInitialTeam : Form
	{
		Team local = new Team();
		Team visitor = new Team();

		public Team Local
		{
			get { return local; }
			set { local = value; }
		}
		public Team Visitor
		{
			get { return visitor; }
			set { visitor = value; }
		}

		public SelectInitialTeam()
		{
			InitializeComponent();
		}
	}
}
