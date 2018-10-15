namespace GarajesAliKan.Forms.Informes
{
    partial class FrmInfClientesGarajes
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
            this.CrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrystalReportViewer
            // 
            this.CrystalReportViewer.ActiveViewIndex = -1;
            this.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.CrystalReportViewer.Name = "CrystalReportViewer";
            this.CrystalReportViewer.ShowGroupTreeButton = false;
            this.CrystalReportViewer.ShowLogo = false;
            this.CrystalReportViewer.ShowParameterPanelButton = false;
            this.CrystalReportViewer.ShowRefreshButton = false;
            this.CrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.CrystalReportViewer.TabIndex = 0;
            this.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmInfClientesGarajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmInfClientesGarajes";
            this.ShowInTaskbar = false;
            this.Text = "Informe Clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInfClientesGarajes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer;
    }
}