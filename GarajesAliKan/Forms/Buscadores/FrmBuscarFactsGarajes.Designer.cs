namespace GarajesAliKan.Forms
{
    partial class FrmBuscarFactsGarajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarFactsGarajes));
            this.DgvFactsGarajes = new System.Windows.Forms.DataGridView();
            this.numFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estaPagada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.garaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseImponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtFecha = new System.Windows.Forms.DateTimePicker();
            this.CkBoxPagada = new System.Windows.Forms.CheckBox();
            this.TxtTotalFactura = new System.Windows.Forms.TextBox();
            this.LTotalFactura = new System.Windows.Forms.Label();
            this.TxtIva = new System.Windows.Forms.TextBox();
            this.TxtBaseImponible = new System.Windows.Forms.TextBox();
            this.LIva = new System.Windows.Forms.Label();
            this.LBaseImponible = new System.Windows.Forms.Label();
            this.LFecha = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFactsGarajes)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvFactsGarajes
            // 
            this.DgvFactsGarajes.AllowUserToAddRows = false;
            this.DgvFactsGarajes.AllowUserToDeleteRows = false;
            this.DgvFactsGarajes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvFactsGarajes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFactsGarajes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvFactsGarajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFactsGarajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numFactura,
            this.fecha,
            this.cliente,
            this.estaPagada,
            this.concepto,
            this.garaje,
            this.plaza,
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
            this.DgvFactsGarajes.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvFactsGarajes.Location = new System.Drawing.Point(12, 12);
            this.DgvFactsGarajes.Name = "DgvFactsGarajes";
            this.DgvFactsGarajes.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFactsGarajes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvFactsGarajes.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvFactsGarajes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvFactsGarajes.RowTemplate.Height = 26;
            this.DgvFactsGarajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFactsGarajes.Size = new System.Drawing.Size(873, 268);
            this.DgvFactsGarajes.TabIndex = 0;
            this.DgvFactsGarajes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFactsGarajes_CellClick);
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
            // garaje
            // 
            this.garaje.HeaderText = "Garaje";
            this.garaje.Name = "garaje";
            this.garaje.ReadOnly = true;
            this.garaje.Width = 140;
            // 
            // plaza
            // 
            this.plaza.HeaderText = "Plaza";
            this.plaza.Name = "plaza";
            this.plaza.ReadOnly = true;
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
            // DtFecha
            // 
            this.DtFecha.CustomFormat = "dd/MM/yyyy";
            this.DtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha.Location = new System.Drawing.Point(236, 316);
            this.DtFecha.Name = "DtFecha";
            this.DtFecha.Size = new System.Drawing.Size(122, 24);
            this.DtFecha.TabIndex = 1;
            this.DtFecha.Value = new System.DateTime(2018, 10, 5, 0, 0, 0, 0);
            this.DtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtFecha_KeyPress);
            // 
            // CkBoxPagada
            // 
            this.CkBoxPagada.AutoSize = true;
            this.CkBoxPagada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CkBoxPagada.Location = new System.Drawing.Point(236, 364);
            this.CkBoxPagada.Name = "CkBoxPagada";
            this.CkBoxPagada.Size = new System.Drawing.Size(83, 24);
            this.CkBoxPagada.TabIndex = 2;
            this.CkBoxPagada.Text = "Pagada";
            this.CkBoxPagada.UseVisualStyleBackColor = true;
            // 
            // TxtTotalFactura
            // 
            this.TxtTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtTotalFactura.Location = new System.Drawing.Point(640, 404);
            this.TxtTotalFactura.Name = "TxtTotalFactura";
            this.TxtTotalFactura.Size = new System.Drawing.Size(95, 24);
            this.TxtTotalFactura.TabIndex = 5;
            this.TxtTotalFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTotalFactura_KeyPress);
            // 
            // LTotalFactura
            // 
            this.LTotalFactura.AutoSize = true;
            this.LTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LTotalFactura.Location = new System.Drawing.Point(507, 407);
            this.LTotalFactura.Name = "LTotalFactura";
            this.LTotalFactura.Size = new System.Drawing.Size(103, 18);
            this.LTotalFactura.TabIndex = 34;
            this.LTotalFactura.Text = "Total Factura: ";
            // 
            // TxtIva
            // 
            this.TxtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtIva.Location = new System.Drawing.Point(640, 361);
            this.TxtIva.Name = "TxtIva";
            this.TxtIva.Size = new System.Drawing.Size(95, 24);
            this.TxtIva.TabIndex = 4;
            this.TxtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIva_KeyPress);
            // 
            // TxtBaseImponible
            // 
            this.TxtBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtBaseImponible.Location = new System.Drawing.Point(640, 318);
            this.TxtBaseImponible.Name = "TxtBaseImponible";
            this.TxtBaseImponible.Size = new System.Drawing.Size(95, 24);
            this.TxtBaseImponible.TabIndex = 3;
            this.TxtBaseImponible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBaseImponible_KeyPress);
            // 
            // LIva
            // 
            this.LIva.AutoSize = true;
            this.LIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LIva.Location = new System.Drawing.Point(507, 364);
            this.LIva.Name = "LIva";
            this.LIva.Size = new System.Drawing.Size(49, 18);
            this.LIva.TabIndex = 33;
            this.LIva.Text = "I.V.A.: ";
            // 
            // LBaseImponible
            // 
            this.LBaseImponible.AutoSize = true;
            this.LBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LBaseImponible.Location = new System.Drawing.Point(507, 321);
            this.LBaseImponible.Name = "LBaseImponible";
            this.LBaseImponible.Size = new System.Drawing.Size(117, 18);
            this.LBaseImponible.TabIndex = 32;
            this.LBaseImponible.Text = "Base Imponible: ";
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LFecha.Location = new System.Drawing.Point(161, 321);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(57, 18);
            this.LFecha.TabIndex = 27;
            this.LFecha.Text = "Fecha: ";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(400, 473);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(96, 33);
            this.BtnGuardar.TabIndex = 6;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmBuscarFactsGarajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 518);
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
            this.Controls.Add(this.DgvFactsGarajes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBuscarFactsGarajes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Facturas Garajes";
            this.Load += new System.EventHandler(this.FrmBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFactsGarajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFactsGarajes;
        private System.Windows.Forms.DateTimePicker DtFecha;
        private System.Windows.Forms.CheckBox CkBoxPagada;
        private System.Windows.Forms.TextBox TxtTotalFactura;
        private System.Windows.Forms.Label LTotalFactura;
        private System.Windows.Forms.TextBox TxtIva;
        private System.Windows.Forms.TextBox TxtBaseImponible;
        private System.Windows.Forms.Label LIva;
        private System.Windows.Forms.Label LBaseImponible;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn numFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn estaPagada;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn garaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn plaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseImponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFactura;
    }
}