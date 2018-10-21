namespace GarajesAliKan.Forms
{
    partial class FrmProveedores
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProveedores));
            this.BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.PBotonesControl = new System.Windows.Forms.Panel();
            this.BtnEliminarProveedor = new System.Windows.Forms.Button();
            this.BtnModificarProveedor = new System.Windows.Forms.Button();
            this.BtnAddProveedor = new System.Windows.Forms.Button();
            this.LEmpresa = new System.Windows.Forms.Label();
            this.lCif = new System.Windows.Forms.Label();
            this.LConcepto = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtConcepto = new System.Windows.Forms.TextBox();
            this.TxtCif = new System.Windows.Forms.TextBox();
            this.TxtEmpresa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).BeginInit();
            this.BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.PBotonesControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BindingNavigator
            // 
            this.BindingNavigator.AddNewItem = null;
            this.BindingNavigator.BindingSource = this.BindingSource;
            this.BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.BindingNavigator.DeleteItem = null;
            this.BindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BindingNavigator.Name = "BindingNavigator";
            this.BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.BindingNavigator.Size = new System.Drawing.Size(913, 27);
            this.BindingNavigator.TabIndex = 3;
            this.BindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.BindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.BindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.BindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 24);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.BindingNavigatorMoveLastItem_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnCancelar.Location = new System.Drawing.Point(779, 255);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(93, 35);
            this.BtnCancelar.TabIndex = 8;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Enabled = false;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnGuardar.Location = new System.Drawing.Point(655, 255);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(86, 35);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // PBotonesControl
            // 
            this.PBotonesControl.Controls.Add(this.BtnEliminarProveedor);
            this.PBotonesControl.Controls.Add(this.BtnModificarProveedor);
            this.PBotonesControl.Controls.Add(this.BtnAddProveedor);
            this.PBotonesControl.Location = new System.Drawing.Point(9, 236);
            this.PBotonesControl.Name = "PBotonesControl";
            this.PBotonesControl.Size = new System.Drawing.Size(585, 61);
            this.PBotonesControl.TabIndex = 36;
            // 
            // BtnEliminarProveedor
            // 
            this.BtnEliminarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnEliminarProveedor.Location = new System.Drawing.Point(426, 19);
            this.BtnEliminarProveedor.Name = "BtnEliminarProveedor";
            this.BtnEliminarProveedor.Size = new System.Drawing.Size(143, 35);
            this.BtnEliminarProveedor.TabIndex = 6;
            this.BtnEliminarProveedor.Text = "Eliminar Proveedor";
            this.BtnEliminarProveedor.UseVisualStyleBackColor = true;
            this.BtnEliminarProveedor.Click += new System.EventHandler(this.BtnEliminarProveedor_Click);
            // 
            // BtnModificarProveedor
            // 
            this.BtnModificarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnModificarProveedor.Location = new System.Drawing.Point(212, 19);
            this.BtnModificarProveedor.Name = "BtnModificarProveedor";
            this.BtnModificarProveedor.Size = new System.Drawing.Size(159, 35);
            this.BtnModificarProveedor.TabIndex = 5;
            this.BtnModificarProveedor.Text = "Modificar Proveedor";
            this.BtnModificarProveedor.UseVisualStyleBackColor = true;
            this.BtnModificarProveedor.Click += new System.EventHandler(this.BtnModificarProveedor_Click);
            // 
            // BtnAddProveedor
            // 
            this.BtnAddProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnAddProveedor.Location = new System.Drawing.Point(16, 19);
            this.BtnAddProveedor.Name = "BtnAddProveedor";
            this.BtnAddProveedor.Size = new System.Drawing.Size(138, 35);
            this.BtnAddProveedor.TabIndex = 4;
            this.BtnAddProveedor.Text = "Añadir Proveedor";
            this.BtnAddProveedor.UseVisualStyleBackColor = true;
            this.BtnAddProveedor.Click += new System.EventHandler(this.BtnAddProveedor_Click);
            // 
            // LEmpresa
            // 
            this.LEmpresa.AutoSize = true;
            this.LEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LEmpresa.Location = new System.Drawing.Point(294, 45);
            this.LEmpresa.Name = "LEmpresa";
            this.LEmpresa.Size = new System.Drawing.Size(76, 18);
            this.LEmpresa.TabIndex = 37;
            this.LEmpresa.Text = "Empresa: ";
            // 
            // lCif
            // 
            this.lCif.AutoSize = true;
            this.lCif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lCif.Location = new System.Drawing.Point(294, 96);
            this.lCif.Name = "lCif";
            this.lCif.Size = new System.Drawing.Size(51, 18);
            this.lCif.TabIndex = 38;
            this.lCif.Text = "C.I.F.: ";
            // 
            // LConcepto
            // 
            this.LConcepto.AutoSize = true;
            this.LConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LConcepto.Location = new System.Drawing.Point(294, 147);
            this.LConcepto.Name = "LConcepto";
            this.LConcepto.Size = new System.Drawing.Size(81, 18);
            this.LConcepto.TabIndex = 39;
            this.LConcepto.Text = "Concepto: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TxtConcepto);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.TxtCif);
            this.panel1.Controls.Add(this.BtnGuardar);
            this.panel1.Controls.Add(this.TxtEmpresa);
            this.panel1.Controls.Add(this.PBotonesControl);
            this.panel1.Controls.Add(this.LEmpresa);
            this.panel1.Controls.Add(this.LConcepto);
            this.panel1.Controls.Add(this.lCif);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 316);
            this.panel1.TabIndex = 40;
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConcepto.Enabled = false;
            this.TxtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtConcepto.Location = new System.Drawing.Point(403, 146);
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(189, 24);
            this.TxtConcepto.TabIndex = 3;
            // 
            // TxtCif
            // 
            this.TxtCif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCif.Enabled = false;
            this.TxtCif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtCif.Location = new System.Drawing.Point(403, 94);
            this.TxtCif.Name = "TxtCif";
            this.TxtCif.Size = new System.Drawing.Size(121, 24);
            this.TxtCif.TabIndex = 2;
            this.TxtCif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCif_KeyPress);
            // 
            // TxtEmpresa
            // 
            this.TxtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtEmpresa.Enabled = false;
            this.TxtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtEmpresa.Location = new System.Drawing.Point(403, 42);
            this.TxtEmpresa.Name = "TxtEmpresa";
            this.TxtEmpresa.Size = new System.Drawing.Size(189, 24);
            this.TxtEmpresa.TabIndex = 1;
            // 
            // FrmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 380);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmProveedores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).EndInit();
            this.BindingNavigator.ResumeLayout(false);
            this.BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.PBotonesControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator BindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Panel PBotonesControl;
        private System.Windows.Forms.Button BtnEliminarProveedor;
        private System.Windows.Forms.Button BtnModificarProveedor;
        private System.Windows.Forms.Button BtnAddProveedor;
        private System.Windows.Forms.Label LEmpresa;
        private System.Windows.Forms.Label lCif;
        private System.Windows.Forms.Label LConcepto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtConcepto;
        private System.Windows.Forms.TextBox TxtCif;
        private System.Windows.Forms.TextBox TxtEmpresa;
        private System.Windows.Forms.BindingSource BindingSource;
    }
}