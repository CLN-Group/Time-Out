namespace TimeOut
{
	partial class SelectTeams
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTeams));
            this.panel1 = new System.Windows.Forms.Panel();
            this.interactiveLabelL = new System.Windows.Forms.Label();
            this.button_acceptSelectionL = new System.Windows.Forms.Button();
            this.pictureBox_logoLocal = new System.Windows.Forms.PictureBox();
            this.listBox_localTeams = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.interactiveLabelV = new System.Windows.Forms.Label();
            this.button_acceptSelectionV = new System.Windows.Forms.Button();
            this.pictureBox_logoVisitor = new System.Windows.Forms.PictureBox();
            this.listBox_visitorTeams = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_modifyTeam = new System.Windows.Forms.Button();
            this.button_addTeam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoLocal)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoVisitor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.interactiveLabelL);
            this.panel1.Controls.Add(this.button_acceptSelectionL);
            this.panel1.Controls.Add(this.pictureBox_logoLocal);
            this.panel1.Controls.Add(this.listBox_localTeams);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(26, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 185);
            this.panel1.TabIndex = 0;
            // 
            // interactiveLabelL
            // 
            this.interactiveLabelL.AutoSize = true;
            this.interactiveLabelL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interactiveLabelL.Location = new System.Drawing.Point(34, 142);
            this.interactiveLabelL.Name = "interactiveLabelL";
            this.interactiveLabelL.Size = new System.Drawing.Size(168, 31);
            this.interactiveLabelL.TabIndex = 5;
            this.interactiveLabelL.Text = "Ready! No?";
            this.interactiveLabelL.Visible = false;
            this.interactiveLabelL.Click += new System.EventHandler(this.interactiveLabel_Click);
            // 
            // button_acceptSelectionL
            // 
            this.button_acceptSelectionL.BackColor = System.Drawing.Color.LimeGreen;
            this.button_acceptSelectionL.Location = new System.Drawing.Point(184, 144);
            this.button_acceptSelectionL.Name = "button_acceptSelectionL";
            this.button_acceptSelectionL.Size = new System.Drawing.Size(113, 29);
            this.button_acceptSelectionL.TabIndex = 2;
            this.button_acceptSelectionL.Text = "Aceptar";
            this.button_acceptSelectionL.UseVisualStyleBackColor = false;
            this.button_acceptSelectionL.Visible = false;
            this.button_acceptSelectionL.Click += new System.EventHandler(this.button_acceptSelection_Click);
            // 
            // pictureBox_logoLocal
            // 
            this.pictureBox_logoLocal.Image = global::TimeOut.Properties.Resources.TEAM_A;
            this.pictureBox_logoLocal.Location = new System.Drawing.Point(40, 50);
            this.pictureBox_logoLocal.Name = "pictureBox_logoLocal";
            this.pictureBox_logoLocal.Size = new System.Drawing.Size(109, 80);
            this.pictureBox_logoLocal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logoLocal.TabIndex = 2;
            this.pictureBox_logoLocal.TabStop = false;
            // 
            // listBox_localTeams
            // 
            this.listBox_localTeams.FormattingEnabled = true;
            this.listBox_localTeams.Items.AddRange(new object[] {
            ""});
            this.listBox_localTeams.Location = new System.Drawing.Point(184, 4);
            this.listBox_localTeams.Name = "listBox_localTeams";
            this.listBox_localTeams.ScrollAlwaysVisible = true;
            this.listBox_localTeams.Size = new System.Drawing.Size(113, 134);
            this.listBox_localTeams.Sorted = true;
            this.listBox_localTeams.TabIndex = 1;
            this.listBox_localTeams.SelectedValueChanged += new System.EventHandler(this.listBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el equipo Local:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.interactiveLabelV);
            this.panel2.Controls.Add(this.button_acceptSelectionV);
            this.panel2.Controls.Add(this.pictureBox_logoVisitor);
            this.panel2.Controls.Add(this.listBox_visitorTeams);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(339, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 185);
            this.panel2.TabIndex = 2;
            // 
            // interactiveLabelV
            // 
            this.interactiveLabelV.AutoSize = true;
            this.interactiveLabelV.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interactiveLabelV.Location = new System.Drawing.Point(38, 141);
            this.interactiveLabelV.Name = "interactiveLabelV";
            this.interactiveLabelV.Size = new System.Drawing.Size(168, 31);
            this.interactiveLabelV.TabIndex = 6;
            this.interactiveLabelV.Text = "Ready! No?";
            this.interactiveLabelV.Visible = false;
            this.interactiveLabelV.Click += new System.EventHandler(this.interactiveLabel_Click);
            // 
            // button_acceptSelectionV
            // 
            this.button_acceptSelectionV.BackColor = System.Drawing.Color.LimeGreen;
            this.button_acceptSelectionV.Location = new System.Drawing.Point(184, 144);
            this.button_acceptSelectionV.Name = "button_acceptSelectionV";
            this.button_acceptSelectionV.Size = new System.Drawing.Size(113, 29);
            this.button_acceptSelectionV.TabIndex = 4;
            this.button_acceptSelectionV.Text = "Aceptar";
            this.button_acceptSelectionV.UseVisualStyleBackColor = false;
            this.button_acceptSelectionV.Visible = false;
            this.button_acceptSelectionV.Click += new System.EventHandler(this.button_acceptSelection_Click);
            // 
            // pictureBox_logoVisitor
            // 
            this.pictureBox_logoVisitor.Image = global::TimeOut.Properties.Resources.TEAM_B;
            this.pictureBox_logoVisitor.Location = new System.Drawing.Point(44, 50);
            this.pictureBox_logoVisitor.Name = "pictureBox_logoVisitor";
            this.pictureBox_logoVisitor.Size = new System.Drawing.Size(109, 80);
            this.pictureBox_logoVisitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logoVisitor.TabIndex = 2;
            this.pictureBox_logoVisitor.TabStop = false;
            // 
            // listBox_visitorTeams
            // 
            this.listBox_visitorTeams.FormattingEnabled = true;
            this.listBox_visitorTeams.Items.AddRange(new object[] {
            ""});
            this.listBox_visitorTeams.Location = new System.Drawing.Point(184, 4);
            this.listBox_visitorTeams.Name = "listBox_visitorTeams";
            this.listBox_visitorTeams.ScrollAlwaysVisible = true;
            this.listBox_visitorTeams.Size = new System.Drawing.Size(113, 134);
            this.listBox_visitorTeams.Sorted = true;
            this.listBox_visitorTeams.TabIndex = 3;
            this.listBox_visitorTeams.SelectedValueChanged += new System.EventHandler(this.listBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccione el equipo Visitante:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_modifyTeam);
            this.groupBox1.Controls.Add(this.button_addTeam);
            this.groupBox1.Location = new System.Drawing.Point(26, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Equipos";
            // 
            // button_modifyTeam
            // 
            this.button_modifyTeam.Enabled = false;
            this.button_modifyTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modifyTeam.Location = new System.Drawing.Point(313, 19);
            this.button_modifyTeam.Name = "button_modifyTeam";
            this.button_modifyTeam.Size = new System.Drawing.Size(298, 77);
            this.button_modifyTeam.TabIndex = 6;
            this.button_modifyTeam.Text = "Modificar un equipo";
            this.button_modifyTeam.UseVisualStyleBackColor = true;
            // 
            // button_addTeam
            // 
            this.button_addTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addTeam.Location = new System.Drawing.Point(7, 20);
            this.button_addTeam.Name = "button_addTeam";
            this.button_addTeam.Size = new System.Drawing.Size(300, 77);
            this.button_addTeam.TabIndex = 5;
            this.button_addTeam.Text = "Agregar equipo a mano";
            this.button_addTeam.UseVisualStyleBackColor = true;
            this.button_addTeam.Click += new System.EventHandler(this.button_addTeam_Click);
            // 
            // SelectTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 342);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectTeams";
            this.Text = "Cargar Equipos y Jugadores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Load_Teams_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoLocal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoVisitor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private void interactiveLabel_MouseEnter(object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException();
		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListBox listBox_visitorTeams;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox_localTeams;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button_modifyTeam;
		private System.Windows.Forms.Button button_addTeam;
		private System.Windows.Forms.Button button_acceptSelectionL;
		private System.Windows.Forms.PictureBox pictureBox_logoLocal;
		private System.Windows.Forms.Button button_acceptSelectionV;
		private System.Windows.Forms.PictureBox pictureBox_logoVisitor;
		private System.Windows.Forms.Label interactiveLabelL;
		private System.Windows.Forms.Label interactiveLabelV;
	}
}