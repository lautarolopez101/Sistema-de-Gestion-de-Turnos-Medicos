namespace Sistema_de_Gestion_de_Turnos_Medicos.ABM_s
{
    partial class FRMABMProfesionales
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.DGVProfesionales = new System.Windows.Forms.DataGridView();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.RBActivo = new System.Windows.Forms.RadioButton();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIDProfesionales = new System.Windows.Forms.Label();
            this.RBDesactivo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RBEstadoActivo = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.RBEstadoDesactivo = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.DGVEspecialidades = new System.Windows.Forms.DataGridView();
            this.lblIDEspecialidades = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfesionales)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matricula";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(450, 159);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(168, 63);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // DGVProfesionales
            // 
            this.DGVProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProfesionales.Location = new System.Drawing.Point(661, 16);
            this.DGVProfesionales.Margin = new System.Windows.Forms.Padding(4);
            this.DGVProfesionales.Name = "DGVProfesionales";
            this.DGVProfesionales.RowHeadersWidth = 51;
            this.DGVProfesionales.Size = new System.Drawing.Size(693, 726);
            this.DGVProfesionales.TabIndex = 11;
            this.DGVProfesionales.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVProfesionales_DataBindingComplete);
            this.DGVProfesionales.SelectionChanged += new System.EventHandler(this.DGVProfesionales_SelectionChanged);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(89, 150);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(132, 34);
            this.txtMatricula.TabIndex = 0;
            // 
            // RBActivo
            // 
            this.RBActivo.AutoSize = true;
            this.RBActivo.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBActivo.Location = new System.Drawing.Point(16, 18);
            this.RBActivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBActivo.Name = "RBActivo";
            this.RBActivo.Size = new System.Drawing.Size(76, 29);
            this.RBActivo.TabIndex = 0;
            this.RBActivo.TabStop = true;
            this.RBActivo.Text = "Activo";
            this.RBActivo.UseVisualStyleBackColor = true;
            this.RBActivo.CheckedChanged += new System.EventHandler(this.RBActivo_CheckedChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(450, 247);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(168, 63);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(450, 330);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(168, 63);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(450, 424);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(168, 63);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(89, 247);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 34);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 219);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(89, 330);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(132, 34);
            this.txtApellido.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 302);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Apellido";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(89, 433);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(132, 34);
            this.txtTelefono.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 405);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Telefono";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(89, 535);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(132, 34);
            this.txtEmail.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(84, 507);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "ID Profesionales= ";
            // 
            // lblIDProfesionales
            // 
            this.lblIDProfesionales.AutoSize = true;
            this.lblIDProfesionales.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDProfesionales.Location = new System.Drawing.Point(176, 74);
            this.lblIDProfesionales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDProfesionales.Name = "lblIDProfesionales";
            this.lblIDProfesionales.Size = new System.Drawing.Size(77, 25);
            this.lblIDProfesionales.TabIndex = 18;
            this.lblIDProfesionales.Text = "Modificar";
            // 
            // RBDesactivo
            // 
            this.RBDesactivo.AutoSize = true;
            this.RBDesactivo.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBDesactivo.Location = new System.Drawing.Point(100, 18);
            this.RBDesactivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBDesactivo.Name = "RBDesactivo";
            this.RBDesactivo.Size = new System.Drawing.Size(98, 29);
            this.RBDesactivo.TabIndex = 1;
            this.RBDesactivo.TabStop = true;
            this.RBDesactivo.Text = "Desactivo";
            this.RBDesactivo.UseVisualStyleBackColor = true;
            this.RBDesactivo.CheckedChanged += new System.EventHandler(this.RBDesactivo_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.RBActivo);
            this.panel1.Controls.Add(this.RBDesactivo);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(279, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 20;
            // 
            // RBEstadoActivo
            // 
            this.RBEstadoActivo.AutoSize = true;
            this.RBEstadoActivo.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBEstadoActivo.Location = new System.Drawing.Point(97, 607);
            this.RBEstadoActivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBEstadoActivo.Name = "RBEstadoActivo";
            this.RBEstadoActivo.Size = new System.Drawing.Size(76, 29);
            this.RBEstadoActivo.TabIndex = 5;
            this.RBEstadoActivo.TabStop = true;
            this.RBEstadoActivo.Text = "Activo";
            this.RBEstadoActivo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(305, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 32);
            this.label7.TabIndex = 22;
            this.label7.Text = "Lista de:";
            // 
            // RBEstadoDesactivo
            // 
            this.RBEstadoDesactivo.AutoSize = true;
            this.RBEstadoDesactivo.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBEstadoDesactivo.Location = new System.Drawing.Point(97, 632);
            this.RBEstadoDesactivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBEstadoDesactivo.Name = "RBEstadoDesactivo";
            this.RBEstadoDesactivo.Size = new System.Drawing.Size(98, 29);
            this.RBEstadoDesactivo.TabIndex = 6;
            this.RBEstadoDesactivo.TabStop = true;
            this.RBEstadoDesactivo.Text = "Desactivo";
            this.RBEstadoDesactivo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(92, 578);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 25);
            this.label8.TabIndex = 24;
            this.label8.Text = "Estado";
            // 
            // DGVEspecialidades
            // 
            this.DGVEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEspecialidades.Location = new System.Drawing.Point(252, 595);
            this.DGVEspecialidades.Name = "DGVEspecialidades";
            this.DGVEspecialidades.RowHeadersWidth = 51;
            this.DGVEspecialidades.RowTemplate.Height = 24;
            this.DGVEspecialidades.Size = new System.Drawing.Size(402, 150);
            this.DGVEspecialidades.TabIndex = 25;
            this.DGVEspecialidades.SelectionChanged += new System.EventHandler(this.DGVEspecialidades_SelectionChanged);
            // 
            // lblIDEspecialidades
            // 
            this.lblIDEspecialidades.AutoSize = true;
            this.lblIDEspecialidades.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDEspecialidades.Location = new System.Drawing.Point(168, 665);
            this.lblIDEspecialidades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDEspecialidades.Name = "lblIDEspecialidades";
            this.lblIDEspecialidades.Size = new System.Drawing.Size(77, 25);
            this.lblIDEspecialidades.TabIndex = 27;
            this.lblIDEspecialidades.Text = "Modificar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 665);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "ID Especialidades= ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(395, 544);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 30);
            this.label9.TabIndex = 28;
            this.label9.Text = "Especialidades";
            // 
            // FRMABMProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 757);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblIDEspecialidades);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DGVEspecialidades);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RBEstadoDesactivo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RBEstadoActivo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblIDProfesionales);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.DGVProfesionales);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMABMProfesionales";
            this.Load += new System.EventHandler(this.FRMABMProfesionales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfesionales)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView DGVProfesionales;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.RadioButton RBActivo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIDProfesionales;
        private System.Windows.Forms.RadioButton RBDesactivo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RBEstadoActivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton RBEstadoDesactivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DGVEspecialidades;
        private System.Windows.Forms.Label lblIDEspecialidades;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}