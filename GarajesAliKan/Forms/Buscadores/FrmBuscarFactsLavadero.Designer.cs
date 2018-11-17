namespace GarajesAliKan.Forms.Buscadores
{
    partial class FrmBuscarFactsRecibidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarFactsRecibidas));
            this.DgvFactsLavadero = new System.Windows.Forms.DataGridView();
            this.numFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estaPagada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseImponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.DtFecha = new System.Windows.Forms.DateTimePicker();
            this.CkBoxPagada = new System.Windows.Forms.CheckBox();
            this.TxtTotalFactura = new System.Windows.Forms.TextBox();
            this.LTotalFactura = new System.Windows.Forms.Label();
            this.TxtIva = new System.Windows.Forms.TextBox();
            this.TxtBaseImponible = new System.Windows.Forms.TextBox();
            this.LIva = new System.Windows.Forms.Label();
            this.LBaseImponible = new System.Windows.Forms.Label();
            this.LFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtConcepto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFactsLavadero)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvFactsLavadero
            // 
            this.DgvFactsLavadero.AllowUserToAddRows = false;
            this.DgvFactsLavadero.AllowUserToDeleteRows = false;
            this.DgvFactsLavadero.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvFactsLavadero.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFactsLavadero.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvFactsLavadero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFactsLavadero.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numFactura,
            this.fecha,
            this.cliente,
            this.estaPagada,
            this.concepto,
            this.baseImponible,
            this.iva,
            this.totalFactura});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFactsLavadero.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvFactsLavadero.Location = new System.Drawing.Point(12, 12);
            this.DgvFactsLavadero.Name = "DgvFactsLavadero";
            this.DgvFactsLavadero.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFactsLavadero.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvFactsLavadero.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvFactsLavadero.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvFactsLavadero.RowTemplate.Height = 26;
            this.DgvFactsLavadero.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFactsLavadero.Size = new System.Drawing.Size(873, 268);
            this.DgvFactsLavadero.TabIndex = 1;
            // 
            // numFactura
            // 
            this.numFactura.HeaderText = "Nº Factura";
            this.numFactura.Name = "numFactura";
            this.numFactura.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 120;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 180;
            // 
            // estaPagada
            // 
            this.estaPagada.HeaderText = "¿Está Pagada?";
            this.estaPagada.Name = "estaPagada";
            this.estaPagada.ReadOnly = true;
            // 
            // concepto
            // 
            this.concepto.HeaderText = "Concepto";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Width = 140;
            // 
            // baseImponible
            // 
            this.baseImponible.HeaderText = "Base Imponible";
            this.baseImponible.Name = "baseImponible";
            this.baseImponible.ReadOnly = true;
            // 
            // iva
            // 
            this.iva.HeaderText = "IVA";
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            // 
            // totalFactura
            // 
            this.totalFactura.HeaderText = "Total Factura";
            this.totalFactura.Name = "totalFactura";
            this.totalFactura.ReadOnly = true;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(400, 527);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(96, 33);
            this.BtnGuardar.TabIndex = 40;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // DtFecha
            // 
            this.DtFecha.CustomFormat = "dd/MM/yyyy";
            this.DtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha.Location = new System.Drawing.Point(200, 311);
            this.DtFecha.Name = "DtFecha";
            this.DtFecha.Size = new System.Drawing.Size(122, 24);
            this.DtFecha.TabIndex = 35;
            this.DtFecha.Value = new System.DateTime(2018, 10, 5, 0, 0, 0, 0);
            this.DtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtFecha_KeyPress);
            // 
            // CkBoxPagada
            // 
            this.CkBoxPagada.AutoSize = true;
            this.CkBoxPagada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CkBoxPagada.Location = new System.Drawing.Point(200, 359);
            this.CkBoxPagada.Name = "CkBoxPagada";
            this.CkBoxPagada.Size = new System.Drawing.Size(83, 24);
            this.CkBoxPagada.TabIndex = 36;
            this.CkBoxPagada.Text = "Pagada";
            this.CkBoxPagada.UseVisualStyleBackColor = true;
            // 
            // TxtTotalFactura
            // 
            this.TxtTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtTotalFactura.Location = new System.Drawing.Point(689, 431);
            this.TxtTotalFactura.Name = "TxtTotalFactura";
            this.TxtTotalFactura.Size = new System.Drawing.Size(95, 24);
            this.TxtTotalFactura.TabIndex = 39;
            this.TxtTotalFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTotalFactura_KeyPress);
            // 
            // LTotalFactura
            // 
            this.LTotalFactura.AutoSize = true;
            this.LTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LTotalFactura.Location = new System.Drawing.Point(556, 434);
            this.LTotalFactura.Name = "LTotalFactura";
            this.LTotalFactura.Size = new System.Drawing.Size(103, 18);
            this.LTotalFactura.TabIndex = 44;
            this.LTotalFactura.Text = "Total Factura: ";
            // 
            // TxtIva
            // 
            this.TxtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtIva.Location = new System.Drawing.Point(689, 388);
            this.TxtIva.Name = "TxtIva";
            this.TxtIva.Size = new System.Drawing.Size(95, 24);
            this.TxtIva.TabIndex = 38;
            this.TxtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIva_KeyPress);
            // 
            // TxtBaseImponible
            // 
            this.TxtBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtBaseImponible.Location = new System.Drawing.Point(689, 345);
            this.TxtBaseImponible.Name = "TxtBaseImponible";
            this.TxtBaseImponible.Size = new System.Drawing.Size(95, 24);
            this.TxtBaseImponible.TabIndex = 37;
            this.TxtBaseImponible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBaseImponible_KeyPress);
            // 
            // LIva
            // 
            this.LIva.AutoSize = true;
            this.LIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LIva.Location = new System.Drawing.Point(556, 391);
            this.LIva.Name = "LIva";
            this.LIva.Size = new System.Drawing.Size(49, 18);
            this.LIva.TabIndex = 43;
            this.LIva.Text = "I.V.A.: ";
            // 
            // LBaseImponible
            // 
            this.LBaseImponible.AutoSize = true;
            this.LBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LBaseImponible.Location = new System.Drawing.Point(556, 348);
            this.LBaseImponible.Name = "LBaseImponible";
            this.LBaseImponible.Size = new System.Drawing.Size(117, 18);
            this.LBaseImponible.TabIndex = 42;
            this.LBaseImponible.Text = "Base Imponible: ";
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LFecha.Location = new System.Drawing.Point(112, 317);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(57, 18);
            this.LFecha.TabIndex = 41;
            this.LFecha.Text = "Fecha: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(112, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "Concepto: ";
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtConcepto.Location = new System.Drawing.Point(199, 406);
            this.TxtConcepto.MaxLength = 100;
            this.TxtConcepto.Multiline = true;
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(290, 76);
            this.TxtConcepto.TabIndex = 46;
            // 
            // FrmBuscarFactsLavadero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 572);
            this.Controls.Add(this.TxtConcepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.DtFecha);
            this.Controls.Add(this.CkBoxPagada);
            this.Controls.Add(this.TxtTotalFactura);
            this.Controls.Add(this.LTotalFactura);
            this.Controls.Add(this.TxtIva);
            this.Controls.Add(this.TxtBaseImponible);
            this.Controls.Add(this.LIva);
            this.Controls.Add(this.LBaseImponible);
            this.Controls.Add(this.LFecha);
            this.Controls.Add(this.DgvFactsLavadero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBuscarFactsLavadero";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Facturas Lavadero";
            this.Load += new System.EventHandler(this.FrmBuscarFactsLavadero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFactsLavadero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFactsLavadero;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn estaPagada;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseImponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFactura;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.DateTimePicker DtFecha;
        private System.Windows.Forms.CheckBox CkBoxPagada;
        private System.Windows.Forms.TextBox TxtTotalFactura;
        private System.Windows.Forms.Label LTotalFactura;
        private System.Windows.Forms.TextBox TxtIva;
        private System.Windows.Forms.TextBox TxtBaseImponible;
        private System.Windows.Forms.Label LIva;
        private System.Windows.Forms.Label LBaseImponible;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtConcepto;
    }
}