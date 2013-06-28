namespace TimeOut
{
	partial class SelectInitialTeam
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
			this.title = new System.Windows.Forms.Label();
			this.groupBox_available = new System.Windows.Forms.GroupBox();
			this.groupBox_initial = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button_add = new System.Windows.Forms.Button();
			this.button_remove = new System.Windows.Forms.Button();
			this.button_finish = new System.Windows.Forms.Button();
			this.listBox_availablePlayers = new System.Windows.Forms.ListBox();
			this.listBox_initialPlayers = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox_available.SuspendLayout();
			this.groupBox_initial.SuspendLayout();
			this.SuspendLayout();
			// 
			// title
			// 
			this.title.AutoSize = true;
			this.title.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.title.ForeColor = System.Drawing.Color.Blue;
			this.title.Location = new System.Drawing.Point(26, 9);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(381, 18);
			this.title.TabIndex = 0;
			this.title.Text = "Seleccione los 5 jugadores iniciales para el encuentro";
			// 
			// groupBox_available
			// 
			this.groupBox_available.Controls.Add(this.listBox_availablePlayers);
			this.groupBox_available.Controls.Add(this.label1);
			this.groupBox_available.Location = new System.Drawing.Point(16, 54);
			this.groupBox_available.Name = "groupBox_available";
			this.groupBox_available.Size = new System.Drawing.Size(199, 200);
			this.groupBox_available.TabIndex = 1;
			this.groupBox_available.TabStop = false;
			this.groupBox_available.Text = "Jugadores disponibles";
			// 
			// groupBox_initial
			// 
			this.groupBox_initial.Controls.Add(this.label2);
			this.groupBox_initial.Controls.Add(this.listBox_initialPlayers);
			this.groupBox_initial.Location = new System.Drawing.Point(269, 54);
			this.groupBox_initial.Name = "groupBox_initial";
			this.groupBox_initial.Size = new System.Drawing.Size(163, 200);
			this.groupBox_initial.TabIndex = 2;
			this.groupBox_initial.TabStop = false;
			this.groupBox_initial.Text = "Jugadores iniciales";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(170, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Seleccione los jugadores:";
			// 
			// button_add
			// 
			this.button_add.Location = new System.Drawing.Point(222, 120);
			this.button_add.Name = "button_add";
			this.button_add.Size = new System.Drawing.Size(41, 23);
			this.button_add.TabIndex = 2;
			this.button_add.Text = ">>";
			this.button_add.UseVisualStyleBackColor = true;
			this.button_add.Click += new System.EventHandler(this.button_add_Click);
			// 
			// button_remove
			// 
			this.button_remove.Enabled = false;
			this.button_remove.Location = new System.Drawing.Point(221, 149);
			this.button_remove.Name = "button_remove";
			this.button_remove.Size = new System.Drawing.Size(42, 23);
			this.button_remove.TabIndex = 4;
			this.button_remove.Text = "<<";
			this.button_remove.UseVisualStyleBackColor = true;
			// 
			// button_finish
			// 
			this.button_finish.Location = new System.Drawing.Point(222, 189);
			this.button_finish.Name = "button_finish";
			this.button_finish.Size = new System.Drawing.Size(40, 65);
			this.button_finish.TabIndex = 5;
			this.button_finish.Text = "OK!";
			this.button_finish.UseVisualStyleBackColor = true;
			this.button_finish.Click += new System.EventHandler(this.button_finish_Click);
			// 
			// listBox_availablePlayers
			// 
			this.listBox_availablePlayers.FormattingEnabled = true;
			this.listBox_availablePlayers.Items.AddRange(new object[] {
            ""});
			this.listBox_availablePlayers.Location = new System.Drawing.Point(9, 66);
			this.listBox_availablePlayers.Name = "listBox_availablePlayers";
			this.listBox_availablePlayers.Size = new System.Drawing.Size(167, 121);
			this.listBox_availablePlayers.TabIndex = 1;
			// 
			// listBox_initialPlayers
			// 
			this.listBox_initialPlayers.DisplayMember = "\"Nombre\"";
			this.listBox_initialPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox_initialPlayers.FormattingEnabled = true;
			this.listBox_initialPlayers.ItemHeight = 16;
			this.listBox_initialPlayers.Items.AddRange(new object[] {
            ""});
			this.listBox_initialPlayers.Location = new System.Drawing.Point(19, 66);
			this.listBox_initialPlayers.Name = "listBox_initialPlayers";
			this.listBox_initialPlayers.Size = new System.Drawing.Size(120, 84);
			this.listBox_initialPlayers.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(133, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Jugadores iniciales:";
			// 
			// SelectInitialTeam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 266);
			this.Controls.Add(this.button_finish);
			this.Controls.Add(this.button_remove);
			this.Controls.Add(this.button_add);
			this.Controls.Add(this.groupBox_initial);
			this.Controls.Add(this.groupBox_available);
			this.Controls.Add(this.title);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SelectInitialTeam";
			this.Text = "SelectInitialTeam";
			this.groupBox_available.ResumeLayout(false);
			this.groupBox_available.PerformLayout();
			this.groupBox_initial.ResumeLayout(false);
			this.groupBox_initial.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label title;
		private System.Windows.Forms.GroupBox groupBox_available;
		private System.Windows.Forms.ListBox listBox_availablePlayers;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox_initial;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox_initialPlayers;
		private System.Windows.Forms.Button button_add;
		private System.Windows.Forms.Button button_remove;
		private System.Windows.Forms.Button button_finish;

	}
}