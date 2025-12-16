namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    partial class FRMAtenderTurno
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
            this.panelInformacion = new System.Windows.Forms.Panel();
            this.lblmotivo = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lbldni = new System.Windows.Forms.Label();
            this.lblapellido = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCancelar = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelAtendido = new System.Windows.Forms.Panel();
            this.btnAtendido = new System.Windows.Forms.Button();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelObservacion = new System.Windows.Forms.Panel();
            this.panelInformacion.SuspendLayout();
            this.panelCancelar.SuspendLayout();
            this.panelAtendido.SuspendLayout();
            this.panelObservacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInformacion
            // 
            this.panelInformacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panelInformacion.Controls.Add(this.lblmotivo);
            this.panelInformacion.Controls.Add(this.lblemail);
            this.panelInformacion.Controls.Add(this.lbldni);
            this.panelInformacion.Controls.Add(this.lblapellido);
            this.panelInformacion.Controls.Add(this.lblnombre);
            this.panelInformacion.Controls.Add(this.label1);
            this.panelInformacion.Location = new System.Drawing.Point(345, 72);
            this.panelInformacion.Name = "panelInformacion";
            this.panelInformacion.Size = new System.Drawing.Size(446, 343);
            this.panelInformacion.TabIndex = 0;
            // 
            // lblmotivo
            // 
            this.lblmotivo.AutoSize = true;
            this.lblmotivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmotivo.Location = new System.Drawing.Point(34, 287);
            this.lblmotivo.Name = "lblmotivo";
            this.lblmotivo.Size = new System.Drawing.Size(72, 23);
            this.lblmotivo.TabIndex = 5;
            this.lblmotivo.Text = "label6";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.Location = new System.Drawing.Point(34, 238);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(72, 23);
            this.lblemail.TabIndex = 4;
            this.lblemail.Text = "label5";
            // 
            // lbldni
            // 
            this.lbldni.AutoSize = true;
            this.lbldni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldni.Location = new System.Drawing.Point(34, 182);
            this.lbldni.Name = "lbldni";
            this.lbldni.Size = new System.Drawing.Size(72, 23);
            this.lbldni.TabIndex = 3;
            this.lbldni.Text = "label4";
            // 
            // lblapellido
            // 
            this.lblapellido.AutoSize = true;
            this.lblapellido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapellido.Location = new System.Drawing.Point(34, 124);
            this.lblapellido.Name = "lblapellido";
            this.lblapellido.Size = new System.Drawing.Size(72, 23);
            this.lblapellido.TabIndex = 2;
            this.lblapellido.Text = "label3";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(34, 67);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(72, 23);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informacion del Paciente:";
            // 
            // panelCancelar
            // 
            this.panelCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panelCancelar.Controls.Add(this.btnCancelar);
            this.panelCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelCancelar.Location = new System.Drawing.Point(53, 428);
            this.panelCancelar.Name = "panelCancelar";
            this.panelCancelar.Size = new System.Drawing.Size(200, 100);
            this.panelCancelar.TabIndex = 1;
            this.panelCancelar.Click += new System.EventHandler(this.panelCancelar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(18, 16);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(164, 61);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.panelCancelar_Click);
            // 
            // panelAtendido
            // 
            this.panelAtendido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panelAtendido.Controls.Add(this.btnAtendido);
            this.panelAtendido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelAtendido.Location = new System.Drawing.Point(463, 428);
            this.panelAtendido.Name = "panelAtendido";
            this.panelAtendido.Size = new System.Drawing.Size(200, 100);
            this.panelAtendido.TabIndex = 2;
            this.panelAtendido.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAtendido
            // 
            this.btnAtendido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtendido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.btnAtendido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtendido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtendido.Location = new System.Drawing.Point(18, 20);
            this.btnAtendido.Name = "btnAtendido";
            this.btnAtendido.Size = new System.Drawing.Size(164, 61);
            this.btnAtendido.TabIndex = 1;
            this.btnAtendido.Text = "Atendido";
            this.btnAtendido.UseVisualStyleBackColor = true;
            this.btnAtendido.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservacion.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(19, 19);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(287, 182);
            this.txtObservacion.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 27);
            this.label7.TabIndex = 4;
            this.label7.Text = "Observacion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 40);
            this.label8.TabIndex = 5;
            this.label8.Text = "Atendiendo.............";
            // 
            // panelObservacion
            // 
            this.panelObservacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panelObservacion.Controls.Add(this.txtObservacion);
            this.panelObservacion.Location = new System.Drawing.Point(12, 168);
            this.panelObservacion.Name = "panelObservacion";
            this.panelObservacion.Size = new System.Drawing.Size(321, 223);
            this.panelObservacion.TabIndex = 6;
            // 
            // FRMAtenderTurno
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(847, 557);
            this.Controls.Add(this.panelObservacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panelAtendido);
            this.Controls.Add(this.panelCancelar);
            this.Controls.Add(this.panelInformacion);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMAtenderTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMAtenderTurno";
            this.Load += new System.EventHandler(this.FRMAtenderTurno_Load);
            this.panelInformacion.ResumeLayout(false);
            this.panelInformacion.PerformLayout();
            this.panelCancelar.ResumeLayout(false);
            this.panelAtendido.ResumeLayout(false);
            this.panelObservacion.ResumeLayout(false);
            this.panelObservacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInformacion;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lbldni;
        private System.Windows.Forms.Label lblapellido;
        private System.Windows.Forms.Label lblmotivo;
        private System.Windows.Forms.Panel panelCancelar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelAtendido;
        private System.Windows.Forms.Button btnAtendido;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelObservacion;
    }
}