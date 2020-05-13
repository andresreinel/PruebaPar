namespace PagaTodo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.registrarBtn = new System.Windows.Forms.Button();
            this.numeroReciboText = new System.Windows.Forms.TextBox();
            this.valorPagoText = new System.Windows.Forms.TextBox();
            this.gbox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaPagoPick = new System.Windows.Forms.DateTimePicker();
            this.entidadCmb = new System.Windows.Forms.ComboBox();
            this.tablaConsignaciones = new System.Windows.Forms.DataGridView();
            this.consultarBtn = new System.Windows.Forms.Button();
            this.fechaBusquedaPick = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.entidadBuscarCmb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.totalRecaudadoText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Electricaribelbl = new System.Windows.Forms.Label();
            this.totalElectricaribeText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.totalGascaribeTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.totalEmduparText = new System.Windows.Forms.TextBox();
            this.gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsignaciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // registrarBtn
            // 
            this.registrarBtn.Location = new System.Drawing.Point(215, 193);
            this.registrarBtn.Name = "registrarBtn";
            this.registrarBtn.Size = new System.Drawing.Size(75, 32);
            this.registrarBtn.TabIndex = 0;
            this.registrarBtn.Text = "Registrar";
            this.registrarBtn.UseVisualStyleBackColor = true;
            this.registrarBtn.Click += new System.EventHandler(this.registrarBtn_Click);
            // 
            // numeroReciboText
            // 
            this.numeroReciboText.Location = new System.Drawing.Point(169, 71);
            this.numeroReciboText.Name = "numeroReciboText";
            this.numeroReciboText.Size = new System.Drawing.Size(121, 20);
            this.numeroReciboText.TabIndex = 2;
            // 
            // valorPagoText
            // 
            this.valorPagoText.Location = new System.Drawing.Point(169, 155);
            this.valorPagoText.Name = "valorPagoText";
            this.valorPagoText.Size = new System.Drawing.Size(121, 20);
            this.valorPagoText.TabIndex = 4;
            // 
            // gbox
            // 
            this.gbox.Controls.Add(this.label4);
            this.gbox.Controls.Add(this.label3);
            this.gbox.Controls.Add(this.label2);
            this.gbox.Controls.Add(this.label1);
            this.gbox.Controls.Add(this.fechaPagoPick);
            this.gbox.Controls.Add(this.entidadCmb);
            this.gbox.Controls.Add(this.valorPagoText);
            this.gbox.Controls.Add(this.numeroReciboText);
            this.gbox.Controls.Add(this.registrarBtn);
            this.gbox.Location = new System.Drawing.Point(12, 22);
            this.gbox.Name = "gbox";
            this.gbox.Size = new System.Drawing.Size(307, 237);
            this.gbox.TabIndex = 5;
            this.gbox.TabStop = false;
            this.gbox.Text = "Consignaciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Valor de pago:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Número de recibo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entidad Prestadora de servicio :";
            // 
            // fechaPagoPick
            // 
            this.fechaPagoPick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaPagoPick.Location = new System.Drawing.Point(169, 111);
            this.fechaPagoPick.Name = "fechaPagoPick";
            this.fechaPagoPick.Size = new System.Drawing.Size(121, 20);
            this.fechaPagoPick.TabIndex = 6;
            // 
            // entidadCmb
            // 
            this.entidadCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entidadCmb.FormattingEnabled = true;
            this.entidadCmb.Location = new System.Drawing.Point(169, 38);
            this.entidadCmb.Name = "entidadCmb";
            this.entidadCmb.Size = new System.Drawing.Size(121, 21);
            this.entidadCmb.TabIndex = 5;
            // 
            // tablaConsignaciones
            // 
            this.tablaConsignaciones.AllowUserToAddRows = false;
            this.tablaConsignaciones.AllowUserToDeleteRows = false;
            this.tablaConsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaConsignaciones.Location = new System.Drawing.Point(335, 59);
            this.tablaConsignaciones.Name = "tablaConsignaciones";
            this.tablaConsignaciones.ReadOnly = true;
            this.tablaConsignaciones.Size = new System.Drawing.Size(462, 349);
            this.tablaConsignaciones.TabIndex = 6;
            // 
            // consultarBtn
            // 
            this.consultarBtn.Location = new System.Drawing.Point(722, 16);
            this.consultarBtn.Name = "consultarBtn";
            this.consultarBtn.Size = new System.Drawing.Size(75, 31);
            this.consultarBtn.TabIndex = 7;
            this.consultarBtn.Text = "Consultar";
            this.consultarBtn.UseVisualStyleBackColor = true;
            this.consultarBtn.Click += new System.EventHandler(this.consultarBtn_Click);
            // 
            // fechaBusquedaPick
            // 
            this.fechaBusquedaPick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaBusquedaPick.Location = new System.Drawing.Point(387, 22);
            this.fechaBusquedaPick.Name = "fechaBusquedaPick";
            this.fechaBusquedaPick.Size = new System.Drawing.Size(99, 20);
            this.fechaBusquedaPick.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Entidad :";
            // 
            // entidadBuscarCmb
            // 
            this.entidadBuscarCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entidadBuscarCmb.FormattingEnabled = true;
            this.entidadBuscarCmb.Location = new System.Drawing.Point(563, 22);
            this.entidadBuscarCmb.Name = "entidadBuscarCmb";
            this.entidadBuscarCmb.Size = new System.Drawing.Size(121, 21);
            this.entidadBuscarCmb.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total recaudado :";
            // 
            // totalRecaudadoText
            // 
            this.totalRecaudadoText.Enabled = false;
            this.totalRecaudadoText.Location = new System.Drawing.Point(134, 117);
            this.totalRecaudadoText.Name = "totalRecaudadoText";
            this.totalRecaudadoText.Size = new System.Drawing.Size(156, 20);
            this.totalRecaudadoText.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Electricaribelbl);
            this.groupBox1.Controls.Add(this.totalElectricaribeText);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.totalGascaribeTxt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.totalEmduparText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.totalRecaudadoText);
            this.groupBox1.Location = new System.Drawing.Point(12, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 143);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Totalización";
            // 
            // Electricaribelbl
            // 
            this.Electricaribelbl.AutoSize = true;
            this.Electricaribelbl.Location = new System.Drawing.Point(50, 24);
            this.Electricaribelbl.Name = "Electricaribelbl";
            this.Electricaribelbl.Size = new System.Drawing.Size(71, 13);
            this.Electricaribelbl.TabIndex = 18;
            this.Electricaribelbl.Text = "Electricaribe :";
            // 
            // totalElectricaribeText
            // 
            this.totalElectricaribeText.Enabled = false;
            this.totalElectricaribeText.Location = new System.Drawing.Point(134, 21);
            this.totalElectricaribeText.Name = "totalElectricaribeText";
            this.totalElectricaribeText.Size = new System.Drawing.Size(156, 20);
            this.totalElectricaribeText.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Gascaribe :";
            // 
            // totalGascaribeTxt
            // 
            this.totalGascaribeTxt.Enabled = false;
            this.totalGascaribeTxt.Location = new System.Drawing.Point(134, 51);
            this.totalGascaribeTxt.Name = "totalGascaribeTxt";
            this.totalGascaribeTxt.Size = new System.Drawing.Size(156, 20);
            this.totalGascaribeTxt.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(66, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Emdupar :";
            // 
            // totalEmduparText
            // 
            this.totalEmduparText.Enabled = false;
            this.totalEmduparText.Location = new System.Drawing.Point(134, 82);
            this.totalEmduparText.Name = "totalEmduparText";
            this.totalEmduparText.Size = new System.Drawing.Size(156, 20);
            this.totalEmduparText.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 427);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.entidadBuscarCmb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fechaBusquedaPick);
            this.Controls.Add(this.consultarBtn);
            this.Controls.Add(this.tablaConsignaciones);
            this.Controls.Add(this.gbox);
            this.Name = "Form1";
            this.Text = "Consignaciones";
            this.gbox.ResumeLayout(false);
            this.gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaConsignaciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registrarBtn;
        private System.Windows.Forms.TextBox numeroReciboText;
        private System.Windows.Forms.TextBox valorPagoText;
        private System.Windows.Forms.GroupBox gbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechaPagoPick;
        private System.Windows.Forms.ComboBox entidadCmb;
        private System.Windows.Forms.DataGridView tablaConsignaciones;
        private System.Windows.Forms.Button consultarBtn;
        private System.Windows.Forms.DateTimePicker fechaBusquedaPick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox entidadBuscarCmb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox totalRecaudadoText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Electricaribelbl;
        private System.Windows.Forms.TextBox totalElectricaribeText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox totalGascaribeTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox totalEmduparText;
    }
}

