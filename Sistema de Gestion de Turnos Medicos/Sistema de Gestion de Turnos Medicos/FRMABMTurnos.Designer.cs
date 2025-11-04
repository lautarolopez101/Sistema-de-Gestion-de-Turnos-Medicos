namespace Sistema_de_Gestion_de_Turnos_Medicos.ABM_s
{
    partial class FRMABMTurnos
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
            this.DGVPacientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVProfesionales = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVTurnos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBLID_Turno = new System.Windows.Forms.Label();
            this.LBLID_Profesional = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LBLID_Paciente = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.RBPendiente = new System.Windows.Forms.RadioButton();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.RBConfirmado = new System.Windows.Forms.RadioButton();
            this.DTPFechaHora = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVPacientes
            // 
            this.DGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPacientes.Location = new System.Drawing.Point(1032, 76);
            this.DGVPacientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVPacientes.Name = "DGVPacientes";
            this.DGVPacientes.RowHeadersWidth = 51;
            this.DGVPacientes.RowTemplate.Height = 24;
            this.DGVPacientes.Size = new System.Drawing.Size(234, 359);
            this.DGVPacientes.TabIndex = 11;
            this.DGVPacientes.DataSourceChanged += new System.EventHandler(this.DGVPacientes_DataSourceChanged);
            this.DGVPacientes.SelectionChanged += new System.EventHandler(this.DGVPacientes_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1105, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pacientes";
            // 
            // DGVProfesionales
            // 
            this.DGVProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProfesionales.Location = new System.Drawing.Point(1032, 464);
            this.DGVProfesionales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVProfesionales.Name = "DGVProfesionales";
            this.DGVProfesionales.RowHeadersWidth = 51;
            this.DGVProfesionales.RowTemplate.Height = 24;
            this.DGVProfesionales.Size = new System.Drawing.Size(234, 313);
            this.DGVProfesionales.TabIndex = 10;
            this.DGVProfesionales.SelectionChanged += new System.EventHandler(this.DGVProfesionales_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1090, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Profesionales";
            // 
            // DGVTurnos
            // 
            this.DGVTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTurnos.Location = new System.Drawing.Point(576, 76);
            this.DGVTurnos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVTurnos.Name = "DGVTurnos";
            this.DGVTurnos.RowHeadersWidth = 51;
            this.DGVTurnos.RowTemplate.Height = 24;
            this.DGVTurnos.Size = new System.Drawing.Size(437, 701);
            this.DGVTurnos.TabIndex = 9;
            this.DGVTurnos.SelectionChanged += new System.EventHandler(this.DGVTurnos_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(763, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Turnos";
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderSize = 16;
            this.btnAgregar.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(384, 150);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 71);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Motivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.Location = new System.Drawing.Point(45, 318);
            this.txtMotivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(195, 40);
            this.txtMotivo.TabIndex = 0;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(43, 418);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(233, 109);
            this.txtObservaciones.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = "Observaciones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "ID Turno:";
            // 
            // LBLID_Turno
            // 
            this.LBLID_Turno.AutoSize = true;
            this.LBLID_Turno.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLID_Turno.Location = new System.Drawing.Point(132, 101);
            this.LBLID_Turno.Name = "LBLID_Turno";
            this.LBLID_Turno.Size = new System.Drawing.Size(108, 30);
            this.LBLID_Turno.TabIndex = 12;
            this.LBLID_Turno.Text = "MODIFICAR";
            // 
            // LBLID_Profesional
            // 
            this.LBLID_Profesional.AutoSize = true;
            this.LBLID_Profesional.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLID_Profesional.Location = new System.Drawing.Point(202, 158);
            this.LBLID_Profesional.Name = "LBLID_Profesional";
            this.LBLID_Profesional.Size = new System.Drawing.Size(108, 30);
            this.LBLID_Profesional.TabIndex = 14;
            this.LBLID_Profesional.Text = "MODIFICAR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 30);
            this.label9.TabIndex = 13;
            this.label9.Text = "ID Profesional:";
            // 
            // LBLID_Paciente
            // 
            this.LBLID_Paciente.AutoSize = true;
            this.LBLID_Paciente.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLID_Paciente.Location = new System.Drawing.Point(202, 196);
            this.LBLID_Paciente.Name = "LBLID_Paciente";
            this.LBLID_Paciente.Size = new System.Drawing.Size(108, 30);
            this.LBLID_Paciente.TabIndex = 16;
            this.LBLID_Paciente.Text = "MODIFICAR";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 30);
            this.label11.TabIndex = 15;
            this.label11.Text = "ID Paciente:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(28, 542);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 30);
            this.label13.TabIndex = 17;
            this.label13.Text = "Fecha y Hora:";
            // 
            // RBPendiente
            // 
            this.RBPendiente.AutoSize = true;
            this.RBPendiente.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBPendiente.Location = new System.Drawing.Point(89, 623);
            this.RBPendiente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RBPendiente.Name = "RBPendiente";
            this.RBPendiente.Size = new System.Drawing.Size(114, 34);
            this.RBPendiente.TabIndex = 3;
            this.RBPendiente.TabStop = true;
            this.RBPendiente.Text = "Pendiente";
            this.RBPendiente.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderSize = 16;
            this.btnModificar.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(384, 256);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(140, 71);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 16;
            this.btnEliminar.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(384, 366);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 71);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.FlatAppearance.BorderSize = 16;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(384, 473);
            this.btnLimpiarCampos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(140, 71);
            this.btnLimpiarCampos.TabIndex = 8;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // RBConfirmado
            // 
            this.RBConfirmado.AutoSize = true;
            this.RBConfirmado.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBConfirmado.Location = new System.Drawing.Point(90, 663);
            this.RBConfirmado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RBConfirmado.Name = "RBConfirmado";
            this.RBConfirmado.Size = new System.Drawing.Size(130, 34);
            this.RBConfirmado.TabIndex = 4;
            this.RBConfirmado.TabStop = true;
            this.RBConfirmado.Text = "Confirmado";
            this.RBConfirmado.UseVisualStyleBackColor = true;
            // 
            // DTPFechaHora
            // 
            this.DTPFechaHora.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaHora.Location = new System.Drawing.Point(174, 550);
            this.DTPFechaHora.MaxDate = new System.DateTime(2070, 12, 31, 0, 0, 0, 0);
            this.DTPFechaHora.MinDate = new System.DateTime(1921, 1, 1, 0, 0, 0, 0);
            this.DTPFechaHora.Name = "DTPFechaHora";
            this.DTPFechaHora.Size = new System.Drawing.Size(112, 22);
            this.DTPFechaHora.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(154, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 30);
            this.label7.TabIndex = 18;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(123, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 30);
            this.label8.TabIndex = 19;
            this.label8.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(147, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 30);
            this.label10.TabIndex = 20;
            this.label10.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(41, 591);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 30);
            this.label12.TabIndex = 21;
            this.label12.Text = "Estado:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(108, 286);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 30);
            this.label14.TabIndex = 22;
            this.label14.Text = "*";
            // 
            // FRMABMTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 788);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DTPFechaHora);
            this.Controls.Add(this.RBConfirmado);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.RBPendiente);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LBLID_Paciente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LBLID_Profesional);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LBLID_Turno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DGVTurnos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVProfesionales);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVPacientes);
            this.Controls.Add(this.label7);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FRMABMTurnos";
            this.Text = "FRMABMTurnos";
            this.Load += new System.EventHandler(this.FRMABMTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfesionales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVPacientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVProfesionales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVTurnos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBLID_Turno;
        private System.Windows.Forms.Label LBLID_Profesional;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LBLID_Paciente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton RBPendiente;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.RadioButton RBConfirmado;
        private System.Windows.Forms.DateTimePicker DTPFechaHora;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
    }
}