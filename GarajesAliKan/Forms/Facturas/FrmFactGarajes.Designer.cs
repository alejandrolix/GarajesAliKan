﻿namespace GarajesAliKan.Forms.FacturasEInformes
{
    partial class FrmFactGarajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFactGarajes));
            this.ReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewer
            // 
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.LocalReport.ReportEmbeddedResource = "GarajesAliKan.Informes.FacturasGarajes.rdlc";
            this.ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.ServerReport.BearerToken = null;
            this.ReportViewer.Size = new System.Drawing.Size(800, 450);
            this.ReportViewer.TabIndex = 1;
            // 
            // FrmFactGarajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmFactGarajes";
            this.ShowInTaskbar = false;
            this.Text = "Factura de Garajes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFactGarajes_Load);
            this.ResumeLayout(false);

        }

        #endregion
        
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer;
    }
}