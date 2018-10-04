namespace GarajesAliKan.Forms
{
    partial class FrmClientesGaraje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientesGaraje));
            this.PBuscarPor = new System.Windows.Forms.Panel();
            this.CbNifs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LBuscarPor = new System.Windows.Forms.Label();
            this.CbApellidos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbPlazas = new System.Windows.Forms.ComboBox();
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
            this.panel = new System.Windows.Forms.Panel();
            this.TxtBaseImponible = new System.Windows.Forms.TextBox();
            this.PBtnsControl = new System.Windows.Forms.Panel();
            this.BtnAddCliente = new System.Windows.Forms.Button();
            this.BtnModificarCliente = new System.Windows.Forms.Button();
            this.BtnEliminarCliente = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.LObservacionees = new System.Windows.Forms.Label();
            this.CbGarajes = new System.Windows.Forms.ComboBox();
            this.LGaraje = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.LTotal = new System.Windows.Forms.Label();
            this.TxtIva = new System.Windows.Forms.TextBox();
            this.LIva = new System.Windows.Forms.Label();
            this.LBaseImponible = new System.Windows.Forms.Label();
            this.CbConceptos = new System.Windows.Forms.ComboBox();
            this.LConcepto = new System.Windows.Forms.Label();
            this.TxtPlaza = new System.Windows.Forms.TextBox();
            this.LPlaza = new System.Windows.Forms.Label();
            this.TxtLlave = new System.Windows.Forms.TextBox();
            this.LLave = new System.Windows.Forms.Label();
            this.TxtMatricula = new System.Windows.Forms.TextBox();
            this.LMatricula = new System.Windows.Forms.Label();
            this.TxtModelo = new System.Windows.Forms.TextBox();
            this.LModelo = new System.Windows.Forms.Label();
            this.TxtMarca = new System.Windows.Forms.TextBox();
            this.LMarca = new System.Windows.Forms.Label();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.LDireccion = new System.Windows.Forms.Label();
            this.TxtNif = new System.Windows.Forms.TextBox();
            this.LNif = new System.Windows.Forms.Label();
            this.TxtApellidos = new System.Windows.Forms.TextBox();
            this.LApellidos = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LNombre = new System.Windows.Forms.Label();
            this.BtnFacturarMes = new System.Windows.Forms.Button();
            this.PBuscarPor.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).BeginInit();
            this.BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.panel.SuspendLayout();
            this.PBtnsControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // PBuscarPor
            // 
            this.PBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PBuscarPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBuscarPor.Controls.Add(this.CbNifs);
            this.PBuscarPor.Controls.Add(this.label3);
            this.PBuscarPor.Controls.Add(this.panel2);
            this.PBuscarPor.Controls.Add(this.CbApellidos);
            this.PBuscarPor.Controls.Add(this.label1);
            this.PBuscarPor.Controls.Add(this.label2);
            this.PBuscarPor.Controls.Add(this.CbPlazas);
            this.PBuscarPor.Location = new System.Drawing.Point(12, 439);
            this.PBuscarPor.Name = "PBuscarPor";
            this.PBuscarPor.Size = new System.Drawing.Size(708, 100);
            this.PBuscarPor.TabIndex = 26;
            // 
            // CbNifs
            // 
            this.CbNifs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbNifs.FormattingEnabled = true;
            this.CbNifs.Location = new System.Drawing.Point(535, 58);
            this.CbNifs.Name = "CbNifs";
            this.CbNifs.Size = new System.Drawing.Size(147, 24);
            this.CbNifs.TabIndex = 24;
            this.CbNifs.SelectionChangeCommitted += new System.EventHandler(this.CbNifs_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(480, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "N.I.F.: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.LBuscarPor);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 30);
            this.panel2.TabIndex = 0;
            // 
            // LBuscarPor
            // 
            this.LBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBuscarPor.AutoSize = true;
            this.LBuscarPor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscarPor.Location = new System.Drawing.Point(283, 4);
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
            this.CbApellidos.Location = new System.Drawing.Point(280, 58);
            this.CbApellidos.Name = "CbApellidos";
            this.CbApellidos.Size = new System.Drawing.Size(175, 24);
            this.CbApellidos.TabIndex = 23;
            this.CbApellidos.SelectionChangeCommitted += new System.EventHandler(this.CbApellidos_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Plaza: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apellidos: ";
            // 
            // CbPlazas
            // 
            this.CbPlazas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbPlazas.FormattingEnabled = true;
            this.CbPlazas.Location = new System.Drawing.Point(81, 58);
            this.CbPlazas.Name = "CbPlazas";
            this.CbPlazas.Size = new System.Drawing.Size(103, 24);
            this.CbPlazas.TabIndex = 22;
            this.CbPlazas.SelectionChangeCommitted += new System.EventHandler(this.CbPlazas_SelectionChangeCommitted);
            // 
            // BindingNavigator
            // 
            this.BindingNavigator.AddNewItem = null;
            this.BindingNavigator.BindingSource = this.BindingSource;
            this.BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.BindingNavigator.DeleteItem = null;
            this.BindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.BindingNavigator.Size = new System.Drawing.Size(1007, 27);
            this.BindingNavigator.TabIndex = 25;
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
            // panel
            // 
            this.panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.Control;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.TxtBaseImponible);
            this.panel.Controls.Add(this.PBtnsControl);
            this.panel.Controls.Add(this.BtnCancelar);
            this.panel.Controls.Add(this.TxtObservaciones);
            this.panel.Controls.Add(this.BtnGuardar);
            this.panel.Controls.Add(this.LObservacionees);
            this.panel.Controls.Add(this.CbGarajes);
            this.panel.Controls.Add(this.LGaraje);
            this.panel.Controls.Add(this.TxtTotal);
            this.panel.Controls.Add(this.LTotal);
            this.panel.Controls.Add(this.TxtIva);
            this.panel.Controls.Add(this.LIva);
            this.panel.Controls.Add(this.LBaseImponible);
            this.panel.Controls.Add(this.CbConceptos);
            this.panel.Controls.Add(this.LConcepto);
            this.panel.Controls.Add(this.TxtPlaza);
            this.panel.Controls.Add(this.LPlaza);
            this.panel.Controls.Add(this.TxtLlave);
            this.panel.Controls.Add(this.LLave);
            this.panel.Controls.Add(this.TxtMatricula);
            this.panel.Controls.Add(this.LMatricula);
            this.panel.Controls.Add(this.TxtModelo);
            this.panel.Controls.Add(this.LModelo);
            this.panel.Controls.Add(this.TxtMarca);
            this.panel.Controls.Add(this.LMarca);
            this.panel.Controls.Add(this.TxtTelefono);
            this.panel.Controls.Add(this.LTelefono);
            this.panel.Controls.Add(this.TxtDireccion);
            this.panel.Controls.Add(this.LDireccion);
            this.panel.Controls.Add(this.TxtNif);
            this.panel.Controls.Add(this.LNif);
            this.panel.Controls.Add(this.TxtApellidos);
            this.panel.Controls.Add(this.LApellidos);
            this.panel.Controls.Add(this.TxtNombre);
            this.panel.Controls.Add(this.LNombre);
            this.panel.Location = new System.Drawing.Point(12, 34);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(983, 363);
            this.panel.TabIndex = 24;
            // 
            // TxtBaseImponible
            // 
            this.TxtBaseImponible.Enabled = false;
            this.TxtBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBaseImponible.Location = new System.Drawing.Point(759, 53);
            this.TxtBaseImponible.Name = "TxtBaseImponible";
            this.TxtBaseImponible.Size = new System.Drawing.Size(95, 23);
            this.TxtBaseImponible.TabIndex = 13;
            this.TxtBaseImponible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBaseImponible_KeyPress);
            // 
            // PBtnsControl
            // 
            this.PBtnsControl.Controls.Add(this.BtnAddCliente);
            this.PBtnsControl.Controls.Add(this.BtnModificarCliente);
            this.PBtnsControl.Controls.Add(this.BtnEliminarCliente);
            this.PBtnsControl.Location = new System.Drawing.Point(92, 287);
            this.PBtnsControl.Name = "PBtnsControl";
            this.PBtnsControl.Size = new System.Drawing.Size(494, 41);
            this.PBtnsControl.TabIndex = 45;
            // 
            // BtnAddCliente
            // 
            this.BtnAddCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCliente.Location = new System.Drawing.Point(27, 9);
            this.BtnAddCliente.Name = "BtnAddCliente";
            this.BtnAddCliente.Size = new System.Drawing.Size(114, 31);
            this.BtnAddCliente.TabIndex = 17;
            this.BtnAddCliente.Text = "Añadir Cliente";
            this.BtnAddCliente.UseVisualStyleBackColor = true;
            this.BtnAddCliente.Click += new System.EventHandler(this.BtnAddCliente_Click);
            // 
            // BtnModificarCliente
            // 
            this.BtnModificarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarCliente.Location = new System.Drawing.Point(181, 9);
            this.BtnModificarCliente.Name = "BtnModificarCliente";
            this.BtnModificarCliente.Size = new System.Drawing.Size(127, 31);
            this.BtnModificarCliente.TabIndex = 18;
            this.BtnModificarCliente.Text = "Modificar Cliente";
            this.BtnModificarCliente.UseVisualStyleBackColor = true;
            this.BtnModificarCliente.Click += new System.EventHandler(this.BtnModificarCliente_Click);
            // 
            // BtnEliminarCliente
            // 
            this.BtnEliminarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarCliente.Location = new System.Drawing.Point(348, 9);
            this.BtnEliminarCliente.Name = "BtnEliminarCliente";
            this.BtnEliminarCliente.Size = new System.Drawing.Size(118, 31);
            this.BtnEliminarCliente.TabIndex = 19;
            this.BtnEliminarCliente.Text = "Eliminar Cliente";
            this.BtnEliminarCliente.UseVisualStyleBackColor = true;
            this.BtnEliminarCliente.Click += new System.EventHandler(this.BtnEliminarCliente_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(841, 297);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 31);
            this.BtnCancelar.TabIndex = 21;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtObservaciones.Enabled = false;
            this.TxtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObservaciones.Location = new System.Drawing.Point(165, 219);
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Size = new System.Drawing.Size(483, 23);
            this.TxtObservaciones.TabIndex = 6;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnGuardar.Enabled = false;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(720, 297);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(82, 31);
            this.BtnGuardar.TabIndex = 20;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // LObservacionees
            // 
            this.LObservacionees.AutoSize = true;
            this.LObservacionees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LObservacionees.Location = new System.Drawing.Point(48, 222);
            this.LObservacionees.Name = "LObservacionees";
            this.LObservacionees.Size = new System.Drawing.Size(111, 17);
            this.LObservacionees.TabIndex = 43;
            this.LObservacionees.Text = "Observaciones: ";
            // 
            // CbGarajes
            // 
            this.CbGarajes.Enabled = false;
            this.CbGarajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbGarajes.FormattingEnabled = true;
            this.CbGarajes.Location = new System.Drawing.Point(759, 170);
            this.CbGarajes.Name = "CbGarajes";
            this.CbGarajes.Size = new System.Drawing.Size(178, 24);
            this.CbGarajes.TabIndex = 16;
            this.CbGarajes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbGarajes_KeyPress);
            // 
            // LGaraje
            // 
            this.LGaraje.AutoSize = true;
            this.LGaraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGaraje.Location = new System.Drawing.Point(641, 176);
            this.LGaraje.Name = "LGaraje";
            this.LGaraje.Size = new System.Drawing.Size(59, 17);
            this.LGaraje.TabIndex = 41;
            this.LGaraje.Text = "Garaje: ";
            // 
            // TxtTotal
            // 
            this.TxtTotal.Enabled = false;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(759, 131);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(95, 23);
            this.TxtTotal.TabIndex = 15;
            this.TxtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTotal_KeyPress);
            // 
            // LTotal
            // 
            this.LTotal.AutoSize = true;
            this.LTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotal.Location = new System.Drawing.Point(641, 136);
            this.LTotal.Name = "LTotal";
            this.LTotal.Size = new System.Drawing.Size(48, 17);
            this.LTotal.TabIndex = 39;
            this.LTotal.Text = "Total: ";
            // 
            // TxtIva
            // 
            this.TxtIva.Enabled = false;
            this.TxtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIva.Location = new System.Drawing.Point(759, 92);
            this.TxtIva.Name = "TxtIva";
            this.TxtIva.Size = new System.Drawing.Size(95, 23);
            this.TxtIva.TabIndex = 14;
            this.TxtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIva_KeyPress);
            // 
            // LIva
            // 
            this.LIva.AutoSize = true;
            this.LIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIva.Location = new System.Drawing.Point(641, 96);
            this.LIva.Name = "LIva";
            this.LIva.Size = new System.Drawing.Size(37, 17);
            this.LIva.TabIndex = 37;
            this.LIva.Text = "IVA: ";
            // 
            // LBaseImponible
            // 
            this.LBaseImponible.AutoSize = true;
            this.LBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBaseImponible.Location = new System.Drawing.Point(641, 56);
            this.LBaseImponible.Name = "LBaseImponible";
            this.LBaseImponible.Size = new System.Drawing.Size(112, 17);
            this.LBaseImponible.TabIndex = 35;
            this.LBaseImponible.Text = "Base Imponible: ";
            // 
            // CbConceptos
            // 
            this.CbConceptos.Enabled = false;
            this.CbConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbConceptos.FormattingEnabled = true;
            this.CbConceptos.Location = new System.Drawing.Point(759, 13);
            this.CbConceptos.Name = "CbConceptos";
            this.CbConceptos.Size = new System.Drawing.Size(193, 24);
            this.CbConceptos.TabIndex = 12;
            this.CbConceptos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbConceptos_KeyPress);
            // 
            // LConcepto
            // 
            this.LConcepto.AutoSize = true;
            this.LConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConcepto.Location = new System.Drawing.Point(641, 16);
            this.LConcepto.Name = "LConcepto";
            this.LConcepto.Size = new System.Drawing.Size(76, 17);
            this.LConcepto.TabIndex = 33;
            this.LConcepto.Text = "Concepto: ";
            // 
            // TxtPlaza
            // 
            this.TxtPlaza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPlaza.Enabled = false;
            this.TxtPlaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPlaza.Location = new System.Drawing.Point(453, 173);
            this.TxtPlaza.Name = "TxtPlaza";
            this.TxtPlaza.Size = new System.Drawing.Size(92, 23);
            this.TxtPlaza.TabIndex = 11;
            // 
            // LPlaza
            // 
            this.LPlaza.AutoSize = true;
            this.LPlaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPlaza.Location = new System.Drawing.Point(370, 176);
            this.LPlaza.Name = "LPlaza";
            this.LPlaza.Size = new System.Drawing.Size(51, 17);
            this.LPlaza.TabIndex = 31;
            this.LPlaza.Text = "Plaza: ";
            // 
            // TxtLlave
            // 
            this.TxtLlave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtLlave.Enabled = false;
            this.TxtLlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLlave.Location = new System.Drawing.Point(453, 133);
            this.TxtLlave.Name = "TxtLlave";
            this.TxtLlave.Size = new System.Drawing.Size(66, 23);
            this.TxtLlave.TabIndex = 10;
            this.TxtLlave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLlave_KeyPress);
            // 
            // LLave
            // 
            this.LLave.AutoSize = true;
            this.LLave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLave.Location = new System.Drawing.Point(370, 136);
            this.LLave.Name = "LLave";
            this.LLave.Size = new System.Drawing.Size(50, 17);
            this.LLave.TabIndex = 29;
            this.LLave.Text = "Llave: ";
            // 
            // TxtMatricula
            // 
            this.TxtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMatricula.Enabled = false;
            this.TxtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMatricula.Location = new System.Drawing.Point(453, 93);
            this.TxtMatricula.Name = "TxtMatricula";
            this.TxtMatricula.Size = new System.Drawing.Size(104, 23);
            this.TxtMatricula.TabIndex = 9;
            // 
            // LMatricula
            // 
            this.LMatricula.AutoSize = true;
            this.LMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMatricula.Location = new System.Drawing.Point(370, 96);
            this.LMatricula.Name = "LMatricula";
            this.LMatricula.Size = new System.Drawing.Size(73, 17);
            this.LMatricula.TabIndex = 27;
            this.LMatricula.Text = "Matrícula: ";
            // 
            // TxtModelo
            // 
            this.TxtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtModelo.Enabled = false;
            this.TxtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtModelo.Location = new System.Drawing.Point(453, 53);
            this.TxtModelo.Name = "TxtModelo";
            this.TxtModelo.Size = new System.Drawing.Size(158, 23);
            this.TxtModelo.TabIndex = 8;
            // 
            // LModelo
            // 
            this.LModelo.AutoSize = true;
            this.LModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LModelo.Location = new System.Drawing.Point(370, 56);
            this.LModelo.Name = "LModelo";
            this.LModelo.Size = new System.Drawing.Size(62, 17);
            this.LModelo.TabIndex = 25;
            this.LModelo.Text = "Modelo: ";
            // 
            // TxtMarca
            // 
            this.TxtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtMarca.Enabled = false;
            this.TxtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMarca.Location = new System.Drawing.Point(453, 13);
            this.TxtMarca.Name = "TxtMarca";
            this.TxtMarca.Size = new System.Drawing.Size(133, 23);
            this.TxtMarca.TabIndex = 7;
            // 
            // LMarca
            // 
            this.LMarca.AutoSize = true;
            this.LMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMarca.Location = new System.Drawing.Point(370, 16);
            this.LMarca.Name = "LMarca";
            this.LMarca.Size = new System.Drawing.Size(55, 17);
            this.LMarca.TabIndex = 23;
            this.LMarca.Text = "Marca: ";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtTelefono.Enabled = false;
            this.TxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefono.Location = new System.Drawing.Point(132, 173);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(114, 23);
            this.TxtTelefono.TabIndex = 5;
            this.TxtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelefono_KeyPress);
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(48, 176);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(72, 17);
            this.LTelefono.TabIndex = 21;
            this.LTelefono.Text = "Teléfono: ";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDireccion.Enabled = false;
            this.TxtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDireccion.Location = new System.Drawing.Point(132, 133);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(212, 23);
            this.TxtDireccion.TabIndex = 4;
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDireccion.Location = new System.Drawing.Point(48, 136);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(75, 17);
            this.LDireccion.TabIndex = 8;
            this.LDireccion.Text = "Dirección: ";
            // 
            // TxtNif
            // 
            this.TxtNif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNif.Enabled = false;
            this.TxtNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNif.Location = new System.Drawing.Point(132, 93);
            this.TxtNif.Name = "TxtNif";
            this.TxtNif.Size = new System.Drawing.Size(114, 23);
            this.TxtNif.TabIndex = 3;
            // 
            // LNif
            // 
            this.LNif.AutoSize = true;
            this.LNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNif.Location = new System.Drawing.Point(48, 96);
            this.LNif.Name = "LNif";
            this.LNif.Size = new System.Drawing.Size(49, 17);
            this.LNif.TabIndex = 6;
            this.LNif.Text = "N.I.F.: ";
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtApellidos.Enabled = false;
            this.TxtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApellidos.Location = new System.Drawing.Point(132, 53);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(179, 23);
            this.TxtApellidos.TabIndex = 2;
            // 
            // LApellidos
            // 
            this.LApellidos.AutoSize = true;
            this.LApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellidos.Location = new System.Drawing.Point(48, 56);
            this.LApellidos.Name = "LApellidos";
            this.LApellidos.Size = new System.Drawing.Size(73, 17);
            this.LApellidos.TabIndex = 4;
            this.LApellidos.Text = "Apellidos: ";
            // 
            // TxtNombre
            // 
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(132, 13);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(164, 23);
            this.TxtNombre.TabIndex = 1;
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(48, 16);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(66, 17);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombre: ";
            // 
            // BtnFacturarMes
            // 
            this.BtnFacturarMes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFacturarMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFacturarMes.Location = new System.Drawing.Point(825, 465);
            this.BtnFacturarMes.Name = "BtnFacturarMes";
            this.BtnFacturarMes.Size = new System.Drawing.Size(108, 53);
            this.BtnFacturarMes.TabIndex = 25;
            this.BtnFacturarMes.Text = "Facturar Mes";
            this.BtnFacturarMes.UseVisualStyleBackColor = true;
            this.BtnFacturarMes.Click += new System.EventHandler(this.BtnFacturarMes_Click);
            // 
            // FrmClientesGaraje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 557);
            this.Controls.Add(this.BtnFacturarMes);
            this.Controls.Add(this.PBuscarPor);
            this.Controls.Add(this.BindingNavigator);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1023, 596);
            this.Name = "FrmClientesGaraje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes Garaje";
            this.Load += new System.EventHandler(this.FrmClientesGaraje_Load);
            this.PBuscarPor.ResumeLayout(false);
            this.PBuscarPor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).EndInit();
            this.BindingNavigator.ResumeLayout(false);
            this.BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.PBtnsControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PBuscarPor;
        private System.Windows.Forms.ComboBox CbNifs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LBuscarPor;
        private System.Windows.Forms.ComboBox CbApellidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbPlazas;
        private System.Windows.Forms.BindingNavigator BindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtObservaciones;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label LObservacionees;
        private System.Windows.Forms.ComboBox CbGarajes;
        private System.Windows.Forms.Label LGaraje;
        private System.Windows.Forms.Label LTotal;
        private System.Windows.Forms.Label LIva;
        private System.Windows.Forms.Label LBaseImponible;
        private System.Windows.Forms.ComboBox CbConceptos;
        private System.Windows.Forms.Label LConcepto;
        private System.Windows.Forms.TextBox TxtPlaza;
        private System.Windows.Forms.Label LPlaza;
        private System.Windows.Forms.TextBox TxtLlave;
        private System.Windows.Forms.Label LLave;
        private System.Windows.Forms.TextBox TxtMatricula;
        private System.Windows.Forms.Label LMatricula;
        private System.Windows.Forms.TextBox TxtModelo;
        private System.Windows.Forms.Label LModelo;
        private System.Windows.Forms.TextBox TxtMarca;
        private System.Windows.Forms.Label LMarca;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Button BtnAddCliente;
        private System.Windows.Forms.Button BtnEliminarCliente;
        private System.Windows.Forms.Button BtnModificarCliente;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.TextBox TxtNif;
        private System.Windows.Forms.Label LNif;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.Label LApellidos;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LNombre;        
        private System.Windows.Forms.Panel PBtnsControl;
        private System.Windows.Forms.TextBox TxtBaseImponible;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.TextBox TxtIva;
        private System.Windows.Forms.Button BtnFacturarMes;
        private System.Windows.Forms.BindingSource BindingSource;
    }
}