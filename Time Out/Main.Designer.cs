namespace TimeOut
{
	partial class Main
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.title = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button_close = new System.Windows.Forms.Button();
			this.panel_actions = new System.Windows.Forms.Panel();
			this.button_getStatistics = new System.Windows.Forms.Button();
			this.button_startMatch = new System.Windows.Forms.Button();
			this.button_loadInformation = new System.Windows.Forms.Button();
			this.splitContainer_teamsDescriptions = new System.Windows.Forms.SplitContainer();
			this.button_InitialTeamLocal = new System.Windows.Forms.Button();
			this.label_localTDescription = new System.Windows.Forms.Label();
			this.pictureBox_localT = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button_InitialTeamVisitor = new System.Windows.Forms.Button();
			this.label_visitorTDescription = new System.Windows.Forms.Label();
			this.pictureBox_visitorT = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.equiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.crearEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eliminarEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jugadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eliminarJugadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel_actions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_teamsDescriptions)).BeginInit();
			this.splitContainer_teamsDescriptions.Panel1.SuspendLayout();
			this.splitContainer_teamsDescriptions.Panel2.SuspendLayout();
			this.splitContainer_teamsDescriptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_localT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_visitorT)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// title
			// 
			this.title.AutoSize = true;
			this.title.Cursor = System.Windows.Forms.Cursors.Default;
			this.title.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Millimeter);
			this.title.ForeColor = System.Drawing.Color.Blue;
			this.title.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.title.Location = new System.Drawing.Point(121, 24);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(380, 45);
			this.title.TabIndex = 0;
			this.title.Text = "Bienvenido al menú";
			this.title.UseMnemonic = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(279, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Seleccione una de las siguientes acciones:";
			// 
			// button_close
			// 
			this.button_close.Location = new System.Drawing.Point(566, 395);
			this.button_close.Name = "button_close";
			this.button_close.Size = new System.Drawing.Size(75, 23);
			this.button_close.TabIndex = 6;
			this.button_close.Text = "Salir";
			this.button_close.UseVisualStyleBackColor = true;
			this.button_close.Click += new System.EventHandler(this.button_close_Click);
			// 
			// panel_actions
			// 
			this.panel_actions.Controls.Add(this.button_getStatistics);
			this.panel_actions.Controls.Add(this.button_startMatch);
			this.panel_actions.Controls.Add(this.button_loadInformation);
			this.panel_actions.Location = new System.Drawing.Point(15, 119);
			this.panel_actions.Name = "panel_actions";
			this.panel_actions.Size = new System.Drawing.Size(276, 264);
			this.panel_actions.TabIndex = 3;
			// 
			// button_getStatistics
			// 
			this.button_getStatistics.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button_getStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_getStatistics.ForeColor = System.Drawing.Color.Red;
			this.button_getStatistics.Location = new System.Drawing.Point(4, 178);
			this.button_getStatistics.Name = "button_getStatistics";
			this.button_getStatistics.Size = new System.Drawing.Size(269, 81);
			this.button_getStatistics.TabIndex = 5;
			this.button_getStatistics.Text = "Obtener estadísticas del último encuentro";
			this.button_getStatistics.UseVisualStyleBackColor = false;
			this.button_getStatistics.Click += new System.EventHandler(this.button_getStatistics_Click);
			// 
			// button_startMatch
			// 
			this.button_startMatch.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button_startMatch.Enabled = false;
			this.button_startMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_startMatch.ForeColor = System.Drawing.Color.Red;
			this.button_startMatch.Location = new System.Drawing.Point(4, 91);
			this.button_startMatch.Name = "button_startMatch";
			this.button_startMatch.Size = new System.Drawing.Size(269, 81);
			this.button_startMatch.TabIndex = 4;
			this.button_startMatch.Text = "Comenzar partido";
			this.button_startMatch.UseVisualStyleBackColor = false;
			this.button_startMatch.Click += new System.EventHandler(this.button_startMatch_Click);
			// 
			// button_loadInformation
			// 
			this.button_loadInformation.BackColor = System.Drawing.Color.LightSteelBlue;
			this.button_loadInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_loadInformation.ForeColor = System.Drawing.Color.Red;
			this.button_loadInformation.Location = new System.Drawing.Point(4, 4);
			this.button_loadInformation.Name = "button_loadInformation";
			this.button_loadInformation.Size = new System.Drawing.Size(269, 81);
			this.button_loadInformation.TabIndex = 1;
			this.button_loadInformation.Text = "Cargar Equipos y Jugadores";
			this.button_loadInformation.UseVisualStyleBackColor = false;
			this.button_loadInformation.Click += new System.EventHandler(this.button_loadInformation_Click);
			// 
			// splitContainer_teamsDescriptions
			// 
			this.splitContainer_teamsDescriptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer_teamsDescriptions.Location = new System.Drawing.Point(297, 119);
			this.splitContainer_teamsDescriptions.Name = "splitContainer_teamsDescriptions";
			this.splitContainer_teamsDescriptions.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer_teamsDescriptions.Panel1
			// 
			this.splitContainer_teamsDescriptions.Panel1.Controls.Add(this.button_InitialTeamLocal);
			this.splitContainer_teamsDescriptions.Panel1.Controls.Add(this.label_localTDescription);
			this.splitContainer_teamsDescriptions.Panel1.Controls.Add(this.pictureBox_localT);
			this.splitContainer_teamsDescriptions.Panel1.Controls.Add(this.label2);
			// 
			// splitContainer_teamsDescriptions.Panel2
			// 
			this.splitContainer_teamsDescriptions.Panel2.Controls.Add(this.button_InitialTeamVisitor);
			this.splitContainer_teamsDescriptions.Panel2.Controls.Add(this.label_visitorTDescription);
			this.splitContainer_teamsDescriptions.Panel2.Controls.Add(this.pictureBox_visitorT);
			this.splitContainer_teamsDescriptions.Panel2.Controls.Add(this.label3);
			this.splitContainer_teamsDescriptions.Size = new System.Drawing.Size(344, 264);
			this.splitContainer_teamsDescriptions.SplitterDistance = 129;
			this.splitContainer_teamsDescriptions.TabIndex = 4;
			this.splitContainer_teamsDescriptions.TabStop = false;
			// 
			// button_InitialTeamLocal
			// 
			this.button_InitialTeamLocal.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.button_InitialTeamLocal.Location = new System.Drawing.Point(137, 56);
			this.button_InitialTeamLocal.Name = "button_InitialTeamLocal";
			this.button_InitialTeamLocal.Size = new System.Drawing.Size(111, 42);
			this.button_InitialTeamLocal.TabIndex = 2;
			this.button_InitialTeamLocal.Text = "Preparar formación Inicial";
			this.button_InitialTeamLocal.UseVisualStyleBackColor = false;
			this.button_InitialTeamLocal.Visible = false;
			this.button_InitialTeamLocal.Click += new System.EventHandler(this.button_InitialTeam_Click);
			// 
			// label_localTDescription
			// 
			this.label_localTDescription.AutoSize = true;
			this.label_localTDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_localTDescription.Location = new System.Drawing.Point(134, 15);
			this.label_localTDescription.Name = "label_localTDescription";
			this.label_localTDescription.Size = new System.Drawing.Size(66, 17);
			this.label_localTDescription.TabIndex = 2;
			this.label_localTDescription.Text = "ninguno";
			// 
			// pictureBox_localT
			// 
			this.pictureBox_localT.Image = global::TimeOut.Properties.Resources.no_team;
			this.pictureBox_localT.Location = new System.Drawing.Point(19, 35);
			this.pictureBox_localT.Name = "pictureBox_localT";
			this.pictureBox_localT.Size = new System.Drawing.Size(80, 80);
			this.pictureBox_localT.TabIndex = 1;
			this.pictureBox_localT.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Equipo local:";
			// 
			// button_InitialTeamVisitor
			// 
			this.button_InitialTeamVisitor.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.button_InitialTeamVisitor.Location = new System.Drawing.Point(137, 63);
			this.button_InitialTeamVisitor.Name = "button_InitialTeamVisitor";
			this.button_InitialTeamVisitor.Size = new System.Drawing.Size(111, 42);
			this.button_InitialTeamVisitor.TabIndex = 3;
			this.button_InitialTeamVisitor.Text = "Preparar formación Inicial";
			this.button_InitialTeamVisitor.UseVisualStyleBackColor = false;
			this.button_InitialTeamVisitor.Visible = false;
			this.button_InitialTeamVisitor.Click += new System.EventHandler(this.button_InitialTeam_Click);
			// 
			// label_visitorTDescription
			// 
			this.label_visitorTDescription.AutoSize = true;
			this.label_visitorTDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_visitorTDescription.Location = new System.Drawing.Point(134, 17);
			this.label_visitorTDescription.Name = "label_visitorTDescription";
			this.label_visitorTDescription.Size = new System.Drawing.Size(66, 17);
			this.label_visitorTDescription.TabIndex = 2;
			this.label_visitorTDescription.Text = "ninguno";
			// 
			// pictureBox_visitorT
			// 
			this.pictureBox_visitorT.Image = global::TimeOut.Properties.Resources.no_team;
			this.pictureBox_visitorT.Location = new System.Drawing.Point(19, 40);
			this.pictureBox_visitorT.Name = "pictureBox_visitorT";
			this.pictureBox_visitorT.Size = new System.Drawing.Size(80, 80);
			this.pictureBox_visitorT.TabIndex = 1;
			this.pictureBox_visitorT.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Equipo visitante:";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(653, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivosToolStripMenuItem
			// 
			this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equiposToolStripMenuItem,
            this.jugadoresToolStripMenuItem});
			this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
			this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.archivosToolStripMenuItem.Text = "Archivos";
			// 
			// equiposToolStripMenuItem
			// 
			this.equiposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearEquipoToolStripMenuItem,
            this.eliminarEquipoToolStripMenuItem});
			this.equiposToolStripMenuItem.Name = "equiposToolStripMenuItem";
			this.equiposToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.equiposToolStripMenuItem.Text = "Equipos";
			// 
			// crearEquipoToolStripMenuItem
			// 
			this.crearEquipoToolStripMenuItem.Name = "crearEquipoToolStripMenuItem";
			this.crearEquipoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.crearEquipoToolStripMenuItem.Text = "Crear Equipo";
			this.crearEquipoToolStripMenuItem.Click += new System.EventHandler(this.crearEquipoToolStripMenuItem_Click);
			// 
			// eliminarEquipoToolStripMenuItem
			// 
			this.eliminarEquipoToolStripMenuItem.Name = "eliminarEquipoToolStripMenuItem";
			this.eliminarEquipoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.eliminarEquipoToolStripMenuItem.Text = "Eliminar Equipo";
			// 
			// jugadoresToolStripMenuItem
			// 
			this.jugadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarJugadorToolStripMenuItem});
			this.jugadoresToolStripMenuItem.Name = "jugadoresToolStripMenuItem";
			this.jugadoresToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.jugadoresToolStripMenuItem.Text = "Jugadores";
			// 
			// eliminarJugadorToolStripMenuItem
			// 
			this.eliminarJugadorToolStripMenuItem.Name = "eliminarJugadorToolStripMenuItem";
			this.eliminarJugadorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.eliminarJugadorToolStripMenuItem.Text = "Eliminar Jugador";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(653, 430);
			this.Controls.Add(this.splitContainer_teamsDescriptions);
			this.Controls.Add(this.panel_actions);
			this.Controls.Add(this.button_close);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.title);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.Text = "Menu";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.panel_actions.ResumeLayout(false);
			this.splitContainer_teamsDescriptions.Panel1.ResumeLayout(false);
			this.splitContainer_teamsDescriptions.Panel1.PerformLayout();
			this.splitContainer_teamsDescriptions.Panel2.ResumeLayout(false);
			this.splitContainer_teamsDescriptions.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_teamsDescriptions)).EndInit();
			this.splitContainer_teamsDescriptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_localT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_visitorT)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label title;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_close;
		private System.Windows.Forms.Panel panel_actions;
		private System.Windows.Forms.Button button_getStatistics;
		private System.Windows.Forms.Button button_startMatch;
		private System.Windows.Forms.Button button_loadInformation;
		private System.Windows.Forms.SplitContainer splitContainer_teamsDescriptions;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox_localT;
		private System.Windows.Forms.PictureBox pictureBox_visitorT;
		private System.Windows.Forms.Label label_localTDescription;
		private System.Windows.Forms.Label label_visitorTDescription;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem equiposToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem crearEquipoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eliminarEquipoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jugadoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eliminarJugadorToolStripMenuItem;
		private System.Windows.Forms.Button button_InitialTeamLocal;
		private System.Windows.Forms.Button button_InitialTeamVisitor;

	}
}

