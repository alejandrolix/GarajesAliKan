namespace GarajesAliKan.Forms
{
    partial class FrmClientesLavadero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientesLavadero));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnEliminarCliente = new System.Windows.Forms.Button();
            this.BtnModificarCliente = new System.Windows.Forms.Button();
            this.BtnAddCliente = new System.Windows.Forms.Button();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtNif = new System.Windows.Forms.TextBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.TxtApellidos = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LNif = new System.Windows.Forms.Label();
            this.LDireccion = new System.Windows.Forms.Label();
            this.LApellidos = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.PBuscarPor = new System.Windows.Forms.Panel();
            this.CbNifs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LBuscarPor = new System.Windows.Forms.Label();
            this.CbApellidos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).BeginInit();
            this.BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.PBuscarPor.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.BindingNavigator.Size = new System.Drawing.Size(790, 27);
            this.BindingNavigator.TabIndex = 0;
            this.BindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(48, 24);
            this.bindingNavigatorCountItem.Text = "de {0}";
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnEliminarCliente);
            this.panel1.Controls.Add(this.BtnModificarCliente);
            this.panel1.Controls.Add(this.BtnAddCliente);
            this.panel1.Controls.Add(this.TxtTelefono);
            this.panel1.Controls.Add(this.TxtNif);
            this.panel1.Controls.Add(this.TxtDireccion);
            this.panel1.Controls.Add(this.TxtApellidos);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.LTelefono);
            this.panel1.Controls.Add(this.LNif);
            this.panel1.Controls.Add(this.LDireccion);
            this.panel1.Controls.Add(this.LApellidos);
            this.panel1.Controls.Add(this.LNombre);
            this.panel1.Location = new System.Drawing.Point(6, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 211);
            this.panel1.TabIndex = 1;
            // 
            // BtnEliminarCliente
            // 
            this.BtnEliminarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnEliminarCliente.Location = new System.Drawing.Point(547, 156);
            this.BtnEliminarCliente.Name = "BtnEliminarCliente";
            this.BtnEliminarCliente.Size = new System.Drawing.Size(134, 32);
            this.BtnEliminarCliente.TabIndex = 10;
            this.BtnEliminarCliente.Text = "Eliminar Cliente";
            this.BtnEliminarCliente.UseVisualStyleBackColor = true;
            // 
            // BtnModificarCliente
            // 
            this.BtnModificarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnModificarCliente.Location = new System.Drawing.Point(547, 92);
            this.BtnModificarCliente.Name = "BtnModificarCliente";
            this.BtnModificarCliente.Size = new System.Drawing.Size(134, 32);
            this.BtnModificarCliente.TabIndex = 9;
            this.BtnModificarCliente.Text = "Modificar Cliente";
            this.BtnModificarCliente.UseVisualStyleBackColor = true;
            // 
            // BtnAddCliente
            // 
            this.BtnAddCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnAddCliente.Location = new System.Drawing.Point(547, 28);
            this.BtnAddCliente.Name = "BtnAddCliente";
            this.BtnAddCliente.Size = new System.Drawing.Size(134, 32);
            this.BtnAddCliente.TabIndex = 8;
            this.BtnAddCliente.Text = "Añadir Cliente";
            this.BtnAddCliente.UseVisualStyleBackColor = true;
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTelefono.Enabled = false;
            this.TxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtTelefono.Location = new System.Drawing.Point(107, 161);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(114, 24);
            this.TxtTelefono.TabIndex = 5;
            // 
            // TxtNif
            // 
            this.TxtNif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNif.Enabled = false;
            this.TxtNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtNif.Location = new System.Drawing.Point(107, 127);
            this.TxtNif.Name = "TxtNif";
            this.TxtNif.Size = new System.Drawing.Size(114, 24);
            this.TxtNif.TabIndex = 4;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDireccion.Enabled = false;
            this.TxtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtDireccion.Location = new System.Drawing.Point(107, 93);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(212, 24);
            this.TxtDireccion.TabIndex = 3;
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtApellidos.Enabled = false;
            this.TxtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtApellidos.Location = new System.Drawing.Point(107, 59);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(179, 24);
            this.TxtApellidos.TabIndex = 2;
            // 
            // TxtNombre
            // 
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtNombre.Location = new System.Drawing.Point(107, 25);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(164, 24);
            this.TxtNombre.TabIndex = 1;
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LTelefono.Location = new System.Drawing.Point(14, 164);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(74, 18);
            this.LTelefono.TabIndex = 4;
            this.LTelefono.Text = "Teléfono: ";
            // 
            // LNif
            // 
            this.LNif.AutoSize = true;
            this.LNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LNif.Location = new System.Drawing.Point(14, 130);
            this.LNif.Name = "LNif";
            this.LNif.Size = new System.Drawing.Size(51, 18);
            this.LNif.TabIndex = 3;
            this.LNif.Text = "N.I.F.: ";
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LDireccion.Location = new System.Drawing.Point(14, 96);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(79, 18);
            this.LDireccion.TabIndex = 2;
            this.LDireccion.Text = "Dirección: ";
            // 
            // LApellidos
            // 
            this.LApellidos.AutoSize = true;
            this.LApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LApellidos.Location = new System.Drawing.Point(14, 62);
            this.LApellidos.Name = "LApellidos";
            this.LApellidos.Size = new System.Drawing.Size(75, 18);
            this.LApellidos.TabIndex = 1;
            this.LApellidos.Text = "Apellidos: ";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LNombre.Location = new System.Drawing.Point(14, 28);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(70, 18);
            this.LNombre.TabIndex = 0;
            this.LNombre.Text = "Nombre: ";
            // 
            // PBuscarPor
            // 
            this.PBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PBuscarPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBuscarPor.Controls.Add(this.CbNifs);
            this.PBuscarPor.Controls.Add(this.label3);
            this.PBuscarPor.Controls.Add(this.panel2);
            this.PBuscarPor.Controls.Add(this.CbApellidos);
            this.PBuscarPor.Controls.Add(this.label2);
            this.PBuscarPor.Location = new System.Drawing.Point(152, 311);
            this.PBuscarPor.Name = "PBuscarPor";
            this.PBuscarPor.Size = new System.Drawing.Size(487, 100);
            this.PBuscarPor.TabIndex = 27;
            // 
            // CbNifs
            // 
            this.CbNifs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbNifs.FormattingEnabled = true;
            this.CbNifs.Location = new System.Drawing.Point(347, 58);
            this.CbNifs.Name = "CbNifs";
            this.CbNifs.Size = new System.Drawing.Size(124, 24);
            this.CbNifs.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(292, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "N.I.F.: ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.LBuscarPor);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 30);
            this.panel2.TabIndex = 0;
            // 
            // LBuscarPor
            // 
            this.LBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBuscarPor.AutoSize = true;
            this.LBuscarPor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscarPor.Location = new System.Drawing.Point(172, 4);
            this.LBuscarPor.Name = "LBuscarPor";
            this.LBuscarPor.Padding = new System.Windows.Forms.Padding(2);
            this.LBuscarPor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LBuscarPor.Size = new System.Drawing.Size(134, 24);
            this.LBuscarPor.TabIndex = 2;
            this.LBuscarPor.Text = "BUSCAR POR:";
            // 
            // CbApellidos
            // 
            this.CbApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbApellidos.FormattingEnabled = true;
            this.CbApellidos.Location = new System.Drawing.Point(92, 58);
            this.CbApellidos.Name = "CbApellidos";
            this.CbApellidos.Size = new System.Drawing.Size(175, 24);
            this.CbApellidos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apellidos: ";
            // 
            // FrmClientesLavadero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 436);
            this.Controls.Add(this.PBuscarPor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmClientesLavadero";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes Lavadero";
            this.Load += new System.EventHandler(this.FrmClientesLavadero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).EndInit();
            this.BindingNavigator.ResumeLayout(false);
            this.BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PBuscarPor.ResumeLayout(false);
            this.PBuscarPor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LNif;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.Label LApellidos;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.TextBox TxtNif;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.Panel PBuscarPor;
        private System.Windows.Forms.ComboBox CbNifs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LBuscarPor;
        private System.Windows.Forms.ComboBox CbApellidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnAddCliente;
        private System.Windows.Forms.Button BtnEliminarCliente;
        private System.Windows.Forms.Button BtnModificarCliente;
        private System.Windows.Forms.BindingSource BindingSource;
    }
}