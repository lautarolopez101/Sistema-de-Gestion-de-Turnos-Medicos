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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LBLID_Turno = new System.Windows.Forms.Label();
            this.LBLID_Profesional = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LBLID_Paciente = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LBLFechaHora = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.RBPendiente = new System.Windows.Forms.RadioButton();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.RBConfirmado = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVPacientes
            // 
            this.DGVPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPacientes.Location = new System.Drawing.Point(774, 62);
            this.DGVPacientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGVPacientes.Name = "DGVPacientes";
            this.DGVPacientes.RowHeadersWidth = 51;
            this.DGVPacientes.RowTemplate.Height = 24;
            this.DGVPacientes.Size = new System.Drawing.Size(328, 292);
            this.DGVPacientes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(910, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pacientes";
            // 
            // DGVProfesionales
            // 
            this.DGVProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProfesionales.Location = new System.Drawing.Point(774, 430);
            this.DGVProfesionales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGVProfesionales.Name = "DGVProfesionales";
            this.DGVProfesionales.RowHeadersWidth = 51;
            this.DGVProfesionales.RowTemplate.Height = 24;
            this.DGVProfesionales.Size = new System.Drawing.Size(328, 254);
            this.DGVProfesionales.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(886, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Profesionales";
            // 
            // DGVTurnos
            // 
            this.DGVTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTurnos.Location = new System.Drawing.Point(432, 62);
            this.DGVTurnos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DGVTurnos.Name = "DGVTurnos";
            this.DGVTurnos.RowHeadersWidth = 51;
            this.DGVTurnos.RowTemplate.Height = 24;
            this.DGVTurnos.Size = new System.Drawing.Size(328, 622);
            this.DGVTurnos.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(556, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Turnos";
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderSize = 16;
            this.btnAgregar.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(288, 122);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 58);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Motivo";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(34, 258);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 33);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(32, 340);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 33);
            this.textBox2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 313);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Observaciones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "ID Turno:";
            // 
            // LBLID_Turno
            // 
            this.LBLID_Turno.AutoSize = true;
            this.LBLID_Turno.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLID_Turno.Location = new System.Drawing.Point(99, 82);
            this.LBLID_Turno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBLID_Turno.Name = "LBLID_Turno";
            this.LBLID_Turno.Size = new System.Drawing.Size(89, 25);
            this.LBLID_Turno.TabIndex = 12;
            this.LBLID_Turno.Text = "MODIFICAR";
            // 
            // LBLID_Profesional
            // 
            this.LBLID_Profesional.AutoSize = true;
            this.LBLID_Profesional.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLID_Profesional.Location = new System.Drawing.Point(133, 128);
            this.LBLID_Profesional.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBLID_Profesional.Name = "LBLID_Profesional";
            this.LBLID_Profesional.Size = new System.Drawing.Size(89, 25);
            this.LBLID_Profesional.TabIndex = 14;
            this.LBLID_Profesional.Text = "MODIFICAR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 128);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "ID Profesional:";
            // 
            // LBLID_Paciente
            // 
            this.LBLID_Paciente.AutoSize = true;
            this.LBLID_Paciente.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLID_Paciente.Location = new System.Drawing.Point(116, 159);
            this.LBLID_Paciente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBLID_Paciente.Name = "LBLID_Paciente";
            this.LBLID_Paciente.Size = new System.Drawing.Size(89, 25);
            this.LBLID_Paciente.TabIndex = 16;
            this.LBLID_Paciente.Text = "MODIFICAR";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(31, 159);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 25);
            this.label11.TabIndex = 15;
            this.label11.Text = "ID Paciente:";
            // 
            // LBLFechaHora
            // 
            this.LBLFechaHora.AutoSize = true;
            this.LBLFechaHora.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLFechaHora.Location = new System.Drawing.Point(126, 430);
            this.LBLFechaHora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBLFechaHora.Name = "LBLFechaHora";
            this.LBLFechaHora.Size = new System.Drawing.Size(89, 25);
            this.LBLFechaHora.TabIndex = 18;
            this.LBLFechaHora.Text = "MODIFICAR";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(31, 430);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 25);
            this.label13.TabIndex = 17;
            this.label13.Text = "Fecha y Hora:";
            // 
            // RBPendiente
            // 
            this.RBPendiente.AutoSize = true;
            this.RBPendiente.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBPendiente.Location = new System.Drawing.Point(33, 486);
            this.RBPendiente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RBPendiente.Name = "RBPendiente";
            this.RBPendiente.Size = new System.Drawing.Size(97, 29);
            this.RBPendiente.TabIndex = 19;
            this.RBPendiente.TabStop = true;
            this.RBPendiente.Text = "Pendiente";
            this.RBPendiente.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.FlatAppearance.BorderSize = 16;
            this.btnModificar.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(288, 208);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(105, 58);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 16;
            this.btnEliminar.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(288, 297);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 58);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.FlatAppearance.BorderSize = 16;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.Location = new System.Drawing.Point(288, 384);
            this.btnLimpiarCampos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(105, 58);
            this.btnLimpiarCampos.TabIndex = 22;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            // 
            // RBConfirmado
            // 
            this.RBConfirmado.AutoSize = true;
            this.RBConfirmado.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBConfirmado.Location = new System.Drawing.Point(34, 518);
            this.RBConfirmado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RBConfirmado.Name = "RBConfirmado";
            this.RBConfirmado.Size = new System.Drawing.Size(110, 29);
            this.RBConfirmado.TabIndex = 23;
            this.RBConfirmado.TabStop = true;
            this.RBConfirmado.Text = "Confirmado";
            this.RBConfirmado.UseVisualStyleBackColor = true;
            // 
            // FRMABMTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 693);
            this.Controls.Add(this.RBConfirmado);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.RBPendiente);
            this.Controls.Add(this.LBLFechaHora);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LBLID_Paciente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LBLID_Profesional);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LBLID_Turno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DGVTurnos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVProfesionales);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVPacientes);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBLID_Turno;
        private System.Windows.Forms.Label LBLID_Profesional;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LBLID_Paciente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LBLFechaHora;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton RBPendiente;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.RadioButton RBConfirmado;
    }
}