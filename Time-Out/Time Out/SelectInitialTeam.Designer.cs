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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(45, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(341, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Diseña algo para elegir los 5 jugadores iniciales";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(46, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(458, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Solamente hay que poner en true las variables correspondientes (bool titular;) pa" +
    "ra cada jugador";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(49, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(268, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "No se pueden tener ni MAS ni MENONS que 5 titulares";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(49, 174);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(351, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Este formulario se utilizara para el equipo local y el visitante (uno a la vez)";
			// 
			// SelectInitialTeam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 219);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "SelectInitialTeam";
			this.Text = "SelectInitialTeam";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}