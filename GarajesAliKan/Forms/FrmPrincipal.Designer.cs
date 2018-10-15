namespace GarajesAliKan
{
    partial class FrmPrincipal
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ClientesGarajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientesLavaderoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasGarajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasLavaderoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasRecibidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientesGarajeToolStripMenuItem,
            this.ClientesLavaderoToolStripMenuItem,
            this.facturasToolStripMenuItem,
            this.ProveedoresToolStripMenuItem,
            this.ListadosToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 28);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // ClientesGarajeToolStripMenuItem
            // 
            this.ClientesGarajeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ClientesGarajeToolStripMenuItem.Name = "ClientesGarajeToolStripMenuItem";
            this.ClientesGarajeToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.ClientesGarajeToolStripMenuItem.Text = "Clientes Garaje";
            this.ClientesGarajeToolStripMenuItem.Click += new System.EventHandler(this.ClientesGarajeToolStripMenuItem_Click);
            // 
            // ClientesLavaderoToolStripMenuItem
            // 
            this.ClientesLavaderoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ClientesLavaderoToolStripMenuItem.Name = "ClientesLavaderoToolStripMenuItem";
            this.ClientesLavaderoToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.ClientesLavaderoToolStripMenuItem.Text = "Clientes Lavadero";
            this.ClientesLavaderoToolStripMenuItem.Click += new System.EventHandler(this.ClientesLavaderoToolStripMenuItem_Click);
            // 
            // facturasToolStripMenuItem
            // 
            this.facturasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturasGarajeToolStripMenuItem,
            this.facturasLavaderoToolStripMenuItem,
            this.facturasRecibidasToolStripMenuItem});
            this.facturasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            this.facturasToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.facturasToolStripMenuItem.Text = "Facturas";
            // 
            // facturasGarajeToolStripMenuItem
            // 
            this.facturasGarajeToolStripMenuItem.Name = "facturasGarajeToolStripMenuItem";
            this.facturasGarajeToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.facturasGarajeToolStripMenuItem.Text = "Garaje";
            this.facturasGarajeToolStripMenuItem.Click += new System.EventHandler(this.FacturasGarajeToolStripMenuItem_Click);
            // 
            // facturasLavaderoToolStripMenuItem
            // 
            this.facturasLavaderoToolStripMenuItem.Name = "facturasLavaderoToolStripMenuItem";
            this.facturasLavaderoToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.facturasLavaderoToolStripMenuItem.Text = "Lavadero";
            this.facturasLavaderoToolStripMenuItem.Click += new System.EventHandler(this.FacturasLavaderoToolStripMenuItem_Click);
            // 
            // facturasRecibidasToolStripMenuItem
            // 
            this.facturasRecibidasToolStripMenuItem.Name = "facturasRecibidasToolStripMenuItem";
            this.facturasRecibidasToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.facturasRecibidasToolStripMenuItem.Text = "Recibidas";
            this.facturasRecibidasToolStripMenuItem.Click += new System.EventHandler(this.FacturasRecibidasToolStripMenuItem_Click);
            // 
            // ProveedoresToolStripMenuItem
            // 
            this.ProveedoresToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem";
            this.ProveedoresToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.ProveedoresToolStripMenuItem.Text = "Proveedores";
            this.ProveedoresToolStripMenuItem.Click += new System.EventHandler(this.ProveedoresToolStripMenuItem_Click);
            // 
            // ListadosToolStripMenuItem
            // 
            this.ListadosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ListadosToolStripMenuItem.Name = "ListadosToolStripMenuItem";
            this.ListadosToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.ListadosToolStripMenuItem.Text = "Listados";
            this.ListadosToolStripMenuItem.Click += new System.EventHandler(this.ListadosToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FrmPrincipal";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ClientesGarajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientesLavaderoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturasGarajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturasLavaderoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturasRecibidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListadosToolStripMenuItem;
    }
}

