namespace Sistema_de_Gestion_de_Turnos_Medicos
{
    partial class FRMCambiarFechaTurno
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panelconfirmar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.uiDatetimePicker1 = new Sunny.UI.UIDatetimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelconfirmar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(20, 15);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(161, 70);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panelconfirmar
            // 
            this.panelconfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panelconfirmar.Controls.Add(this.btnConfirmar);
            this.panelconfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelconfirmar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelconfirmar.Location = new System.Drawing.Point(317, 237);
            this.panelconfirmar.Name = "panelconfirmar";
            this.panelconfirmar.Size = new System.Drawing.Size(200, 100);
            this.panelconfirmar.TabIndex = 1;
            this.panelconfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(72, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(20, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(161, 70);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // uiDatetimePicker1
            // 
            this.uiDatetimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiDatetimePicker1.DateFormat = "yyyy-MM-dd";
            this.uiDatetimePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatetimePicker1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiDatetimePicker1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiDatetimePicker1.Location = new System.Drawing.Point(22, 31);
            this.uiDatetimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatetimePicker1.MaxLength = 10;
            this.uiDatetimePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatetimePicker1.Name = "uiDatetimePicker1";
            this.uiDatetimePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatetimePicker1.Radius = 9;
            this.uiDatetimePicker1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(74)))), ((int)(((byte)(111)))));
            this.uiDatetimePicker1.Size = new System.Drawing.Size(162, 29);
            this.uiDatetimePicker1.Style = Sunny.UI.UIStyle.Custom;
            this.uiDatetimePicker1.StyleDropDown = Sunny.UI.UIStyle.Colorful;
            this.uiDatetimePicker1.SymbolDropDown = 261555;
            this.uiDatetimePicker1.SymbolNormal = 261555;
            this.uiDatetimePicker1.SymbolSize = 24;
            this.uiDatetimePicker1.TabIndex = 3;
            this.uiDatetimePicker1.Text = "2025-11-12";
            this.uiDatetimePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatetimePicker1.Value = new System.DateTime(2025, 11, 12, 13, 17, 50, 892);
            this.uiDatetimePicker1.Watermark = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(249)))));
            this.panel2.Controls.Add(this.uiDatetimePicker1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(182, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cambiar Fecha:";
            // 
            // FRMCambiarFechaTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(602, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelconfirmar);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMCambiarFechaTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FRMCambiarFechaTurno";
            this.panelconfirmar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panelconfirmar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private Sunny.UI.UIDatetimePicker uiDatetimePicker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}