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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblespecialidad = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAgregarEspecialidad = new System.Windows.Forms.Button();
            this.btnEliminarEspecialidad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProfesionales)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matricula";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.btnAgregar.Location = new System.Drawing.Point(238, 151);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(147, 63);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // DGVProfesionales
            // 
            this.DGVProfesionales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVProfesionales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProfesionales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGVProfesionales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            this.DGVProfesionales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVProfesionales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVProfesionales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVProfesionales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DGVProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProfesionales.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVProfesionales.DefaultCellStyle = dataGridViewCellStyle10;
            this.DGVProfesionales.EnableHeadersVisualStyles = false;
            this.DGVProfesionales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.DGVProfesionales.Location = new System.Drawing.Point(648, 19);
            this.DGVProfesionales.Margin = new System.Windows.Forms.Padding(4);
            this.DGVProfesionales.Name = "DGVProfesionales";
            this.DGVProfesionales.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVProfesionales.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGVProfesionales.RowHeadersVisible = false;
            this.DGVProfesionales.RowHeadersWidth = 51;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.DGVProfesionales.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVProfesionales.Size = new System.Drawing.Size(621, 727);
            this.DGVProfesionales.TabIndex = 13;
            this.DGVProfesionales.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVProfesionales_DataBindingComplete);
            this.DGVProfesionales.SelectionChanged += new System.EventHandler(this.DGVProfesionales_SelectionChanged);
            // 
            // txtMatricula
            // 
            this.txtMatricula.BackColor = System.Drawing.Color.White;
            this.txtMatricula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatricula.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.txtMatricula.Location = new System.Drawing.Point(50, 151);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(116, 20);
            this.txtMatricula.TabIndex = 0;
            // 
            // RBActivo
            // 
            this.RBActivo.AutoSize = true;
            this.RBActivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBActivo.Location = new System.Drawing.Point(18, 19);
            this.RBActivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBActivo.Name = "RBActivo";
            this.RBActivo.Size = new System.Drawing.Size(81, 25);
            this.RBActivo.TabIndex = 0;
            this.RBActivo.TabStop = true;
            this.RBActivo.Text = "Activo";
            this.RBActivo.UseVisualStyleBackColor = true;
            this.RBActivo.CheckedChanged += new System.EventHandler(this.RBActivo_CheckedChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.btnModificar.Location = new System.Drawing.Point(238, 232);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(147, 63);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.btnEliminar.Location = new System.Drawing.Point(238, 315);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(147, 63);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.btnLimpiar.Location = new System.Drawing.Point(448, 315);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(147, 63);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.txtNombre.Location = new System.Drawing.Point(50, 248);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(116, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 219);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre";
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.White;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.txtApellido.Location = new System.Drawing.Point(50, 329);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(116, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 301);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Apellido";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.txtTelefono.Location = new System.Drawing.Point(50, 433);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(141, 20);
            this.txtTelefono.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 405);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Telefono";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.txtEmail.Location = new System.Drawing.Point(50, 536);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(187, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 507);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "ID Profesionales= ";
            // 
            // lblIDProfesionales
            // 
            this.lblIDProfesionales.AutoSize = true;
            this.lblIDProfesionales.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDProfesionales.Location = new System.Drawing.Point(154, 73);
            this.lblIDProfesionales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDProfesionales.Name = "lblIDProfesionales";
            this.lblIDProfesionales.Size = new System.Drawing.Size(83, 21);
            this.lblIDProfesionales.TabIndex = 18;
            this.lblIDProfesionales.Text = "Modificar";
            // 
            // RBDesactivo
            // 
            this.RBDesactivo.AutoSize = true;
            this.RBDesactivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBDesactivo.Location = new System.Drawing.Point(107, 19);
            this.RBDesactivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBDesactivo.Name = "RBDesactivo";
            this.RBDesactivo.Size = new System.Drawing.Size(107, 25);
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
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(308, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 52);
            this.panel1.TabIndex = 14;
            // 
            // RBEstadoActivo
            // 
            this.RBEstadoActivo.AutoSize = true;
            this.RBEstadoActivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBEstadoActivo.Location = new System.Drawing.Point(59, 598);
            this.RBEstadoActivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBEstadoActivo.Name = "RBEstadoActivo";
            this.RBEstadoActivo.Size = new System.Drawing.Size(81, 25);
            this.RBEstadoActivo.TabIndex = 5;
            this.RBEstadoActivo.TabStop = true;
            this.RBEstadoActivo.Text = "Activo";
            this.RBEstadoActivo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(348, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 22;
            this.label7.Text = "Lista de:";
            // 
            // RBEstadoDesactivo
            // 
            this.RBEstadoDesactivo.AutoSize = true;
            this.RBEstadoDesactivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBEstadoDesactivo.Location = new System.Drawing.Point(59, 631);
            this.RBEstadoDesactivo.Margin = new System.Windows.Forms.Padding(4);
            this.RBEstadoDesactivo.Name = "RBEstadoDesactivo";
            this.RBEstadoDesactivo.Size = new System.Drawing.Size(107, 25);
            this.RBEstadoDesactivo.TabIndex = 6;
            this.RBEstadoDesactivo.TabStop = true;
            this.RBEstadoDesactivo.Text = "Desactivo";
            this.RBEstadoDesactivo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 570);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 21);
            this.label8.TabIndex = 24;
            this.label8.Text = "Estado";
            // 
            // DGVEspecialidades
            // 
            this.DGVEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGVEspecialidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEspecialidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DGVEspecialidades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            this.DGVEspecialidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVEspecialidades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVEspecialidades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVEspecialidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DGVEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEspecialidades.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVEspecialidades.DefaultCellStyle = dataGridViewCellStyle14;
            this.DGVEspecialidades.EnableHeadersVisualStyles = false;
            this.DGVEspecialidades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.DGVEspecialidades.Location = new System.Drawing.Point(273, 439);
            this.DGVEspecialidades.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGVEspecialidades.Name = "DGVEspecialidades";
            this.DGVEspecialidades.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVEspecialidades.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DGVEspecialidades.RowHeadersVisible = false;
            this.DGVEspecialidades.RowHeadersWidth = 51;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            this.DGVEspecialidades.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DGVEspecialidades.RowTemplate.Height = 24;
            this.DGVEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVEspecialidades.Size = new System.Drawing.Size(369, 307);
            this.DGVEspecialidades.TabIndex = 12;
            this.DGVEspecialidades.SelectionChanged += new System.EventHandler(this.DGVEspecialidades_SelectionChanged);
            // 
            // lblIDEspecialidades
            // 
            this.lblIDEspecialidades.AutoSize = true;
            this.lblIDEspecialidades.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDEspecialidades.Location = new System.Drawing.Point(170, 664);
            this.lblIDEspecialidades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDEspecialidades.Name = "lblIDEspecialidades";
            this.lblIDEspecialidades.Size = new System.Drawing.Size(83, 21);
            this.lblIDEspecialidades.TabIndex = 27;
            this.lblIDEspecialidades.Text = "Modificar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 664);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 21);
            this.label10.TabIndex = 26;
            this.label10.Text = "ID Especialidades= ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(397, 405);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 21);
            this.label9.TabIndex = 28;
            this.label9.Text = "Especialidades";
            // 
            // lblespecialidad
            // 
            this.lblespecialidad.AutoSize = true;
            this.lblespecialidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblespecialidad.Location = new System.Drawing.Point(154, 698);
            this.lblespecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblespecialidad.Name = "lblespecialidad";
            this.lblespecialidad.Size = new System.Drawing.Size(83, 21);
            this.lblespecialidad.TabIndex = 30;
            this.lblespecialidad.Text = "Modificar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 698);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 21);
            this.label12.TabIndex = 29;
            this.label12.Text = "Especialidad =";
            // 
            // btnAgregarEspecialidad
            // 
            this.btnAgregarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEspecialidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.btnAgregarEspecialidad.Location = new System.Drawing.Point(448, 151);
            this.btnAgregarEspecialidad.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad";
            this.btnAgregarEspecialidad.Size = new System.Drawing.Size(147, 63);
            this.btnAgregarEspecialidad.TabIndex = 10;
            this.btnAgregarEspecialidad.Text = "Agregar Especialidad";
            this.btnAgregarEspecialidad.UseVisualStyleBackColor = true;
            this.btnAgregarEspecialidad.Click += new System.EventHandler(this.btnAgregarEspecialidad_Click);
            // 
            // btnEliminarEspecialidad
            // 
            this.btnEliminarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEspecialidad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.btnEliminarEspecialidad.Location = new System.Drawing.Point(448, 232);
            this.btnEliminarEspecialidad.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarEspecialidad.Name = "btnEliminarEspecialidad";
            this.btnEliminarEspecialidad.Size = new System.Drawing.Size(147, 63);
            this.btnEliminarEspecialidad.TabIndex = 31;
            this.btnEliminarEspecialidad.Text = "Eliminar Especialidad";
            this.btnEliminarEspecialidad.UseVisualStyleBackColor = true;
            this.btnEliminarEspecialidad.Click += new System.EventHandler(this.btnEliminarEspecialidad_Click);
            // 
            // FRMABMProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.btnEliminarEspecialidad);
            this.Controls.Add(this.btnAgregarEspecialidad);
            this.Controls.Add(this.lblespecialidad);
            this.Controls.Add(this.label12);
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
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMABMProfesionales";
            this.Text = "Profesionales";
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
        private System.Windows.Forms.Label lblespecialidad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAgregarEspecialidad;
        private System.Windows.Forms.Button btnEliminarEspecialidad;
    }
}