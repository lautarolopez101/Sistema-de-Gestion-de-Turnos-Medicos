namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    partial class TurnosAsignados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvturnos = new System.Windows.Forms.DataGridView();
            this.panelbtn = new System.Windows.Forms.Panel();
            this.btnAtender = new System.Windows.Forms.Button();
            this.paneldgv = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvturnos)).BeginInit();
            this.panelbtn.SuspendLayout();
            this.paneldgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvturnos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvturnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvturnos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.dgvturnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvturnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvturnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvturnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvturnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvturnos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(141)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvturnos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvturnos.EnableHeadersVisualStyles = false;
            this.dgvturnos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.dgvturnos.Location = new System.Drawing.Point(23, 22);
            this.dgvturnos.Name = "dgvturnos";
            this.dgvturnos.RowHeadersVisible = false;
            this.dgvturnos.RowHeadersWidth = 51;
            this.dgvturnos.RowTemplate.Height = 24;
            this.dgvturnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvturnos.Size = new System.Drawing.Size(668, 300);
            this.dgvturnos.TabIndex = 0;
            this.dgvturnos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvturnos_CellFormatting);
            this.dgvturnos.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panelbtn
            // 
            this.panelbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panelbtn.Controls.Add(this.btnAtender);
            this.panelbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelbtn.Location = new System.Drawing.Point(245, 375);
            this.panelbtn.Name = "panelbtn";
            this.panelbtn.Size = new System.Drawing.Size(282, 100);
            this.panelbtn.TabIndex = 1;
            this.panelbtn.Click += new System.EventHandler(this.panelbtn_Click);
            // 
            // btnAtender
            // 
            this.btnAtender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtender.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.btnAtender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtender.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.btnAtender.Location = new System.Drawing.Point(26, 20);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(237, 60);
            this.btnAtender.TabIndex = 0;
            this.btnAtender.Text = "Atender";
            this.btnAtender.UseVisualStyleBackColor = true;
            this.btnAtender.Click += new System.EventHandler(this.panelbtn_Click);
            // 
            // paneldgv
            // 
            this.paneldgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.paneldgv.Controls.Add(this.dgvturnos);
            this.paneldgv.Location = new System.Drawing.Point(31, 12);
            this.paneldgv.Name = "paneldgv";
            this.paneldgv.Size = new System.Drawing.Size(711, 345);
            this.paneldgv.TabIndex = 2;
            // 
            // TurnosAsignados
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(754, 487);
            this.Controls.Add(this.paneldgv);
            this.Controls.Add(this.panelbtn);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(48)))));
            this.Name = "TurnosAsignados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TurnosAsignados";
            this.Load += new System.EventHandler(this.TurnosAsignados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvturnos)).EndInit();
            this.panelbtn.ResumeLayout(false);
            this.paneldgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvturnos;
        private System.Windows.Forms.Panel panelbtn;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.Panel paneldgv;
    }
}