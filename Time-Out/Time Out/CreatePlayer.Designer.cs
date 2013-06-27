namespace TimeOut
{
	partial class CreatePlayer
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_cancel = new System.Windows.Forms.Button();
			this.button_save = new System.Windows.Forms.Button();
			this.posicionPreferida = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown_altura = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.textBox_lastname = new System.Windows.Forms.TextBox();
			this.textBox_name = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_altura)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Millimeter);
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(376, 35);
			this.label1.TabIndex = 2;
			this.label1.Text = "Ingresar un nuevo Jugador";
			this.label1.UseMnemonic = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button_cancel);
			this.panel1.Controls.Add(this.button_save);
			this.panel1.Controls.Add(this.posicionPreferida);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.numericUpDown_altura);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.monthCalendar1);
			this.panel1.Controls.Add(this.textBox_lastname);
			this.panel1.Controls.Add(this.textBox_name);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.shapeContainer1);
			this.panel1.Location = new System.Drawing.Point(19, 59);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(499, 314);
			this.panel1.TabIndex = 5;
			// 
			// button_cancel
			// 
			this.button_cancel.Location = new System.Drawing.Point(257, 225);
			this.button_cancel.Name = "button_cancel";
			this.button_cancel.Size = new System.Drawing.Size(214, 49);
			this.button_cancel.TabIndex = 13;
			this.button_cancel.Text = "Cancelar";
			this.button_cancel.UseVisualStyleBackColor = true;
			this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
			// 
			// button_save
			// 
			this.button_save.Location = new System.Drawing.Point(257, 170);
			this.button_save.Name = "button_save";
			this.button_save.Size = new System.Drawing.Size(214, 49);
			this.button_save.TabIndex = 12;
			this.button_save.Text = "Guardar";
			this.button_save.UseVisualStyleBackColor = true;
			this.button_save.Click += new System.EventHandler(this.button_save_Click);
			// 
			// posicionPreferida
			// 
			this.posicionPreferida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.posicionPreferida.FormattingEnabled = true;
			this.posicionPreferida.Items.AddRange(new object[] {
            "Pivot",
            "Ala-Pivot",
            "Alero",
            "Escolta",
            "Base"});
			this.posicionPreferida.Location = new System.Drawing.Point(365, 57);
			this.posicionPreferida.Name = "posicionPreferida";
			this.posicionPreferida.Size = new System.Drawing.Size(121, 21);
			this.posicionPreferida.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(232, 57);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(126, 17);
			this.label6.TabIndex = 9;
			this.label6.Text = "Posicion preferida:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(115, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "(metros)";
			// 
			// numericUpDown_altura
			// 
			this.numericUpDown_altura.DecimalPlaces = 2;
			this.numericUpDown_altura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown_altura.Location = new System.Drawing.Point(58, 57);
			this.numericUpDown_altura.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numericUpDown_altura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown_altura.Name = "numericUpDown_altura";
			this.numericUpDown_altura.Size = new System.Drawing.Size(51, 23);
			this.numericUpDown_altura.TabIndex = 3;
			this.numericUpDown_altura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown_altura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 59);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Altura:";
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(6, 139);
			this.monthCalendar1.MaxDate = new System.DateTime(2013, 6, 24, 0, 0, 0, 0);
			this.monthCalendar1.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.ShowToday = false;
			this.monthCalendar1.TabIndex = 5;
			// 
			// textBox_lastname
			// 
			this.textBox_lastname.Location = new System.Drawing.Point(356, 16);
			this.textBox_lastname.Name = "textBox_lastname";
			this.textBox_lastname.Size = new System.Drawing.Size(115, 20);
			this.textBox_lastname.TabIndex = 2;
			this.textBox_lastname.Text = "apellido";
			// 
			// textBox_name
			// 
			this.textBox_name.Location = new System.Drawing.Point(235, 16);
			this.textBox_name.Name = "textBox_name";
			this.textBox_name.Size = new System.Drawing.Size(115, 20);
			this.textBox_name.TabIndex = 1;
			this.textBox_name.Text = "nombre";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(206, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nombre y Apellido del Jugador:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(143, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Fecha de nacimiento:";
			// 
			// shapeContainer1
			// 
			this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.shapeContainer1.Name = "shapeContainer1";
			this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
			this.shapeContainer1.Size = new System.Drawing.Size(499, 314);
			this.shapeContainer1.TabIndex = 11;
			this.shapeContainer1.TabStop = false;
			// 
			// lineShape1
			// 
			this.lineShape1.Name = "lineShape1";
			this.lineShape1.X1 = 276;
			this.lineShape1.X2 = 456;
			this.lineShape1.Y1 = 148;
			this.lineShape1.Y2 = 148;
			// 
			// CreatePlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 379);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "CreatePlayer";
			this.Text = "Crear Jugador";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreatePlayer_FormClosing);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_altura)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox_lastname;
		private System.Windows.Forms.TextBox textBox_name;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.NumericUpDown numericUpDown_altura;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox posicionPreferida;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button_save;
		private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
		private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
		private System.Windows.Forms.Button button_cancel;
	}
}