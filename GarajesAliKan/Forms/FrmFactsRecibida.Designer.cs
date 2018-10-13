namespace GarajesAliKan.Forms
{
    partial class FrmFactsRecibida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFactsRecibida));
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
            this.DtFecha = new System.Windows.Forms.DateTimePicker();
            this.TxtNumFactura = new System.Windows.Forms.TextBox();
            this.LFecha = new System.Windows.Forms.Label();
            this.LNumFactura = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.PBotonesControl = new System.Windows.Forms.Panel();
            this.BtnEliminarFactura = new System.Windows.Forms.Button();
            this.BtnModificarFactura = new System.Windows.Forms.Button();
            this.BtnAddFactura = new System.Windows.Forms.Button();
            this.TxtEmpresa = new System.Windows.Forms.TextBox();
            this.LEmpresa = new System.Windows.Forms.Label();
            this.TxtTotalFactura = new System.Windows.Forms.TextBox();
            this.LTotalFactura = new System.Windows.Forms.Label();
            this.TxtIva = new System.Windows.Forms.TextBox();
            this.TxtBaseImponible = new System.Windows.Forms.TextBox();
            this.LIva = new System.Windows.Forms.Label();
            this.LBaseImponible = new System.Windows.Forms.Label();
            this.CbGarajes = new System.Windows.Forms.ComboBox();
            this.LGaraje = new System.Windows.Forms.Label();
            this.PBuscarPor = new System.Windows.Forms.Panel();
            this.CbGjBuscar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LBuscarPor = new System.Windows.Forms.Label();
            this.CbEmpresas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CbFechas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).BeginInit();
            this.BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.PBotonesControl.SuspendLayout();
            this.PBuscarPor.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.BindingNavigator.Size = new System.Drawing.Size(885, 27);
            this.BindingNavigator.TabIndex = 2;
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
            // DtFecha
            // 
            this.DtFecha.CustomFormat = "dd/MM/yyyy";
            this.DtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtFecha.Enabled = false;
            this.DtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha.Location = new System.Drawing.Point(197, 53);
            this.DtFecha.Name = "DtFecha";
            this.DtFecha.Size = new System.Drawing.Size(122, 24);
            this.DtFecha.TabIndex = 2;
            this.DtFecha.Value = new System.DateTime(2018, 10, 5, 0, 0, 0, 0);
            this.DtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtFecha_KeyPress);
            // 
            // TxtNumFactura
            // 
            this.TxtNumFactura.Enabled = false;
            this.TxtNumFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtNumFactura.Location = new System.Drawing.Point(197, 12);
            this.TxtNumFactura.Name = "TxtNumFactura";
            this.TxtNumFactura.Size = new System.Drawing.Size(51, 24);
            this.TxtNumFactura.TabIndex = 1;
            this.TxtNumFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumFactura_KeyPress);
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LFecha.Location = new System.Drawing.Point(83, 57);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(57, 18);
            this.LFecha.TabIndex = 5;
            this.LFecha.Text = "Fecha: ";
            // 
            // LNumFactura
            // 
            this.LNumFactura.AutoSize = true;
            this.LNumFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LNumFactura.Location = new System.Drawing.Point(83, 15);
            this.LNumFactura.Name = "LNumFactura";
            this.LNumFactura.Size = new System.Drawing.Size(86, 18);
            this.LNumFactura.TabIndex = 3;
            this.LNumFactura.Text = "Nº Factura: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnGuardar);
            this.panel1.Controls.Add(this.PBotonesControl);
            this.panel1.Controls.Add(this.TxtEmpresa);
            this.panel1.Controls.Add(this.LEmpresa);
            this.panel1.Controls.Add(this.TxtTotalFactura);
            this.panel1.Controls.Add(this.LTotalFactura);
            this.panel1.Controls.Add(this.TxtIva);
            this.panel1.Controls.Add(this.TxtBaseImponible);
            this.panel1.Controls.Add(this.LIva);
            this.panel1.Controls.Add(this.LBaseImponible);
            this.panel1.Controls.Add(this.CbGarajes);
            this.panel1.Controls.Add(this.LGaraje);
            this.panel1.Controls.Add(this.LNumFactura);
            this.panel1.Controls.Add(this.DtFecha);
            this.panel1.Controls.Add(this.LFecha);
            this.panel1.Controls.Add(this.TxtNumFactura);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 304);
            this.panel1.TabIndex = 7;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnCancelar.Location = new System.Drawing.Point(752, 245);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(93, 35);
            this.BtnCancelar.TabIndex = 12;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Enabled = false;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnGuardar.Location = new System.Drawing.Point(614, 245);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(86, 35);
            this.BtnGuardar.TabIndex = 11;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // PBotonesControl
            // 
            this.PBotonesControl.Controls.Add(this.BtnEliminarFactura);
            this.PBotonesControl.Controls.Add(this.BtnModificarFactura);
            this.PBotonesControl.Controls.Add(this.BtnAddFactura);
            this.PBotonesControl.Location = new System.Drawing.Point(13, 226);
            this.PBotonesControl.Name = "PBotonesControl";
            this.PBotonesControl.Size = new System.Drawing.Size(517, 61);
            this.PBotonesControl.TabIndex = 33;
            // 
            // BtnEliminarFactura
            // 
            this.BtnEliminarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnEliminarFactura.Location = new System.Drawing.Point(376, 19);
            this.BtnEliminarFactura.Name = "BtnEliminarFactura";
            this.BtnEliminarFactura.Size = new System.Drawing.Size(129, 35);
            this.BtnEliminarFactura.TabIndex = 10;
            this.BtnEliminarFactura.Text = "Eliminar Factura";
            this.BtnEliminarFactura.UseVisualStyleBackColor = true;
            this.BtnEliminarFactura.Click += new System.EventHandler(this.BtnEliminarFactura_Click);
            // 
            // BtnModificarFactura
            // 
            this.BtnModificarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnModificarFactura.Location = new System.Drawing.Point(187, 19);
            this.BtnModificarFactura.Name = "BtnModificarFactura";
            this.BtnModificarFactura.Size = new System.Drawing.Size(136, 35);
            this.BtnModificarFactura.TabIndex = 9;
            this.BtnModificarFactura.Text = "Modificar Factura";
            this.BtnModificarFactura.UseVisualStyleBackColor = true;
            this.BtnModificarFactura.Click += new System.EventHandler(this.BtnModificarFactura_Click);
            // 
            // BtnAddFactura
            // 
            this.BtnAddFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnAddFactura.Location = new System.Drawing.Point(15, 19);
            this.BtnAddFactura.Name = "BtnAddFactura";
            this.BtnAddFactura.Size = new System.Drawing.Size(119, 35);
            this.BtnAddFactura.TabIndex = 8;
            this.BtnAddFactura.Text = "Añadir Factura";
            this.BtnAddFactura.UseVisualStyleBackColor = true;
            this.BtnAddFactura.Click += new System.EventHandler(this.BtnAddFactura_Click);
            // 
            // TxtEmpresa
            // 
            this.TxtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtEmpresa.Enabled = false;
            this.TxtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtEmpresa.Location = new System.Drawing.Point(197, 137);
            this.TxtEmpresa.Name = "TxtEmpresa";
            this.TxtEmpresa.Size = new System.Drawing.Size(174, 24);
            this.TxtEmpresa.TabIndex = 4;
            // 
            // LEmpresa
            // 
            this.LEmpresa.AutoSize = true;
            this.LEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LEmpresa.Location = new System.Drawing.Point(83, 141);
            this.LEmpresa.Name = "LEmpresa";
            this.LEmpresa.Size = new System.Drawing.Size(76, 18);
            this.LEmpresa.TabIndex = 30;
            this.LEmpresa.Text = "Empresa: ";
            // 
            // TxtTotalFactura
            // 
            this.TxtTotalFactura.Enabled = false;
            this.TxtTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtTotalFactura.Location = new System.Drawing.Point(680, 121);
            this.TxtTotalFactura.Name = "TxtTotalFactura";
            this.TxtTotalFactura.Size = new System.Drawing.Size(95, 24);
            this.TxtTotalFactura.TabIndex = 7;
            this.TxtTotalFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTotalFactura_KeyPress);
            // 
            // LTotalFactura
            // 
            this.LTotalFactura.AutoSize = true;
            this.LTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LTotalFactura.Location = new System.Drawing.Point(535, 123);
            this.LTotalFactura.Name = "LTotalFactura";
            this.LTotalFactura.Size = new System.Drawing.Size(103, 18);
            this.LTotalFactura.TabIndex = 28;
            this.LTotalFactura.Text = "Total Factura: ";
            // 
            // TxtIva
            // 
            this.TxtIva.Enabled = false;
            this.TxtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtIva.Location = new System.Drawing.Point(680, 80);
            this.TxtIva.Name = "TxtIva";
            this.TxtIva.Size = new System.Drawing.Size(95, 24);
            this.TxtIva.TabIndex = 6;
            this.TxtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIva_KeyPress);
            // 
            // TxtBaseImponible
            // 
            this.TxtBaseImponible.Enabled = false;
            this.TxtBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtBaseImponible.Location = new System.Drawing.Point(680, 39);
            this.TxtBaseImponible.Name = "TxtBaseImponible";
            this.TxtBaseImponible.Size = new System.Drawing.Size(95, 24);
            this.TxtBaseImponible.TabIndex = 5;
            this.TxtBaseImponible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBaseImponible_KeyPress);
            // 
            // LIva
            // 
            this.LIva.AutoSize = true;
            this.LIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LIva.Location = new System.Drawing.Point(535, 82);
            this.LIva.Name = "LIva";
            this.LIva.Size = new System.Drawing.Size(49, 18);
            this.LIva.TabIndex = 27;
            this.LIva.Text = "I.V.A.: ";
            // 
            // LBaseImponible
            // 
            this.LBaseImponible.AutoSize = true;
            this.LBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LBaseImponible.Location = new System.Drawing.Point(535, 41);
            this.LBaseImponible.Name = "LBaseImponible";
            this.LBaseImponible.Size = new System.Drawing.Size(117, 18);
            this.LBaseImponible.TabIndex = 26;
            this.LBaseImponible.Text = "Base Imponible: ";
            // 
            // CbGarajes
            // 
            this.CbGarajes.Enabled = false;
            this.CbGarajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbGarajes.FormattingEnabled = true;
            this.CbGarajes.Location = new System.Drawing.Point(197, 94);
            this.CbGarajes.Name = "CbGarajes";
            this.CbGarajes.Size = new System.Drawing.Size(174, 26);
            this.CbGarajes.TabIndex = 3;
            this.CbGarajes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbGarajes_KeyPress);
            // 
            // LGaraje
            // 
            this.LGaraje.AutoSize = true;
            this.LGaraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LGaraje.Location = new System.Drawing.Point(83, 99);
            this.LGaraje.Name = "LGaraje";
            this.LGaraje.Size = new System.Drawing.Size(60, 18);
            this.LGaraje.TabIndex = 7;
            this.LGaraje.Text = "Garaje: ";
            // 
            // PBuscarPor
            // 
            this.PBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PBuscarPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBuscarPor.Controls.Add(this.CbGjBuscar);
            this.PBuscarPor.Controls.Add(this.label3);
            this.PBuscarPor.Controls.Add(this.panel3);
            this.PBuscarPor.Controls.Add(this.CbEmpresas);
            this.PBuscarPor.Controls.Add(this.label4);
            this.PBuscarPor.Controls.Add(this.CbFechas);
            this.PBuscarPor.Controls.Add(this.label5);
            this.PBuscarPor.Location = new System.Drawing.Point(50, 399);
            this.PBuscarPor.Name = "PBuscarPor";
            this.PBuscarPor.Size = new System.Drawing.Size(784, 100);
            this.PBuscarPor.TabIndex = 31;
            // 
            // CbGjBuscar
            // 
            this.CbGjBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbGjBuscar.FormattingEnabled = true;
            this.CbGjBuscar.Location = new System.Drawing.Point(606, 58);
            this.CbGjBuscar.Name = "CbGjBuscar";
            this.CbGjBuscar.Size = new System.Drawing.Size(157, 26);
            this.CbGjBuscar.TabIndex = 15;
            this.CbGjBuscar.SelectionChangeCommitted += new System.EventHandler(this.CbGjBuscar_SelectionChangeCommitted);
            this.CbGjBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbGjBuscar_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(539, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Garaje: ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.LBuscarPor);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 30);
            this.panel3.TabIndex = 0;
            // 
            // LBuscarPor
            // 
            this.LBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBuscarPor.AutoSize = true;
            this.LBuscarPor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscarPor.Location = new System.Drawing.Point(321, 4);
            this.LBuscarPor.Name = "LBuscarPor";
            this.LBuscarPor.Padding = new System.Windows.Forms.Padding(2);
            this.LBuscarPor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LBuscarPor.Size = new System.Drawing.Size(134, 24);
            this.LBuscarPor.TabIndex = 2;
            this.LBuscarPor.Text = "BUSCAR POR:";
            // 
            // CbEmpresas
            // 
            this.CbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbEmpresas.FormattingEnabled = true;
            this.CbEmpresas.Location = new System.Drawing.Point(339, 58);
            this.CbEmpresas.Name = "CbEmpresas";
            this.CbEmpresas.Size = new System.Drawing.Size(169, 26);
            this.CbEmpresas.TabIndex = 14;
            this.CbEmpresas.SelectionChangeCommitted += new System.EventHandler(this.CbEmpresas_SelectionChangeCommitted);
            this.CbEmpresas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbEmpresas_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(257, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "Empresa: ";
            // 
            // CbFechas
            // 
            this.CbFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbFechas.FormattingEnabled = true;
            this.CbFechas.Location = new System.Drawing.Point(84, 58);
            this.CbFechas.Name = "CbFechas";
            this.CbFechas.Size = new System.Drawing.Size(144, 26);
            this.CbFechas.TabIndex = 13;
            this.CbFechas.SelectionChangeCommitted += new System.EventHandler(this.CbFechas_SelectionChangeCommitted);
            this.CbFechas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbFechas_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(19, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fecha: ";
            // 
            // FrmFactsRecibida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 511);
            this.Controls.Add(this.PBuscarPor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFactsRecibida";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas Recibidas";
            this.Load += new System.EventHandler(this.FrmFactsRecibida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).EndInit();
            this.BindingNavigator.ResumeLayout(false);
            this.BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PBotonesControl.ResumeLayout(false);
            this.PBuscarPor.ResumeLayout(false);
            this.PBuscarPor.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.DateTimePicker DtFecha;
        private System.Windows.Forms.TextBox TxtNumFactura;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LNumFactura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CbGarajes;
        private System.Windows.Forms.Label LGaraje;
        private System.Windows.Forms.TextBox TxtTotalFactura;
        private System.Windows.Forms.Label LTotalFactura;
        private System.Windows.Forms.TextBox TxtIva;
        private System.Windows.Forms.TextBox TxtBaseImponible;
        private System.Windows.Forms.Label LIva;
        private System.Windows.Forms.Label LBaseImponible;
        private System.Windows.Forms.TextBox TxtEmpresa;
        private System.Windows.Forms.Label LEmpresa;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Panel PBotonesControl;
        private System.Windows.Forms.Button BtnEliminarFactura;
        private System.Windows.Forms.Button BtnModificarFactura;
        private System.Windows.Forms.Button BtnAddFactura;
        private System.Windows.Forms.Panel PBuscarPor;
        private System.Windows.Forms.ComboBox CbGjBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LBuscarPor;
        private System.Windows.Forms.ComboBox CbFechas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbEmpresas;
    }
}