namespace GarajesAliKan.Forms
{
    partial class FrmFactsGaraje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFactsGaraje));
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
            this.CbClientes = new System.Windows.Forms.ComboBox();
            this.LCliente = new System.Windows.Forms.Label();
            this.DtFecha = new System.Windows.Forms.DateTimePicker();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.PBotonesControl = new System.Windows.Forms.Panel();
            this.BtnEliminarFactura = new System.Windows.Forms.Button();
            this.BtnModificarFactura = new System.Windows.Forms.Button();
            this.BtnAddFactura = new System.Windows.Forms.Button();
            this.CkBoxPagada = new System.Windows.Forms.CheckBox();
            this.TxtTotalFactura = new System.Windows.Forms.TextBox();
            this.LTotalFactura = new System.Windows.Forms.Label();
            this.CbGarajes = new System.Windows.Forms.ComboBox();
            this.CbConceptos = new System.Windows.Forms.ComboBox();
            this.TxtIva = new System.Windows.Forms.TextBox();
            this.TxtBaseImponible = new System.Windows.Forms.TextBox();
            this.TxtPlaza = new System.Windows.Forms.TextBox();
            this.LIva = new System.Windows.Forms.Label();
            this.LBaseImponible = new System.Windows.Forms.Label();
            this.LPlaza = new System.Windows.Forms.Label();
            this.LGaraje = new System.Windows.Forms.Label();
            this.LConcepto = new System.Windows.Forms.Label();
            this.TxtNumFactura = new System.Windows.Forms.TextBox();
            this.LFecha = new System.Windows.Forms.Label();
            this.LNumFactura = new System.Windows.Forms.Label();
            this.PBuscarPor = new System.Windows.Forms.Panel();
            this.CbFechas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LBuscarPor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbNumsFacturas = new System.Windows.Forms.ComboBox();
            this.BtnImprimirFactura = new System.Windows.Forms.Button();
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
            this.BindingNavigator.Size = new System.Drawing.Size(908, 27);
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
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CbClientes);
            this.panel1.Controls.Add(this.LCliente);
            this.panel1.Controls.Add(this.DtFecha);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnGuardar);
            this.panel1.Controls.Add(this.PBotonesControl);
            this.panel1.Controls.Add(this.CkBoxPagada);
            this.panel1.Controls.Add(this.TxtTotalFactura);
            this.panel1.Controls.Add(this.LTotalFactura);
            this.panel1.Controls.Add(this.CbGarajes);
            this.panel1.Controls.Add(this.CbConceptos);
            this.panel1.Controls.Add(this.TxtIva);
            this.panel1.Controls.Add(this.TxtBaseImponible);
            this.panel1.Controls.Add(this.TxtPlaza);
            this.panel1.Controls.Add(this.LIva);
            this.panel1.Controls.Add(this.LBaseImponible);
            this.panel1.Controls.Add(this.LPlaza);
            this.panel1.Controls.Add(this.LGaraje);
            this.panel1.Controls.Add(this.LConcepto);
            this.panel1.Controls.Add(this.TxtNumFactura);
            this.panel1.Controls.Add(this.LFecha);
            this.panel1.Controls.Add(this.LNumFactura);
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 351);
            this.panel1.TabIndex = 1;
            // 
            // CbClientes
            // 
            this.CbClientes.Enabled = false;
            this.CbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbClientes.FormattingEnabled = true;
            this.CbClientes.Location = new System.Drawing.Point(183, 90);
            this.CbClientes.Name = "CbClientes";
            this.CbClientes.Size = new System.Drawing.Size(240, 26);
            this.CbClientes.TabIndex = 28;
            this.CbClientes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbClientes_KeyPress);
            // 
            // LCliente
            // 
            this.LCliente.AutoSize = true;
            this.LCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LCliente.Location = new System.Drawing.Point(69, 93);
            this.LCliente.Name = "LCliente";
            this.LCliente.Size = new System.Drawing.Size(61, 18);
            this.LCliente.TabIndex = 27;
            this.LCliente.Text = "Cliente: ";
            // 
            // DtFecha
            // 
            this.DtFecha.CustomFormat = "dd/MM/yyyy";
            this.DtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtFecha.Enabled = false;
            this.DtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecha.Location = new System.Drawing.Point(183, 52);
            this.DtFecha.Name = "DtFecha";
            this.DtFecha.Size = new System.Drawing.Size(122, 24);
            this.DtFecha.TabIndex = 26;
            this.DtFecha.Value = new System.DateTime(2018, 10, 5, 0, 0, 0, 0);
            this.DtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DtFecha_KeyPress);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnCancelar.Location = new System.Drawing.Point(764, 295);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(93, 35);
            this.BtnCancelar.TabIndex = 17;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Enabled = false;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnGuardar.Location = new System.Drawing.Point(626, 295);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(86, 35);
            this.BtnGuardar.TabIndex = 16;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // PBotonesControl
            // 
            this.PBotonesControl.Controls.Add(this.BtnEliminarFactura);
            this.PBotonesControl.Controls.Add(this.BtnModificarFactura);
            this.PBotonesControl.Controls.Add(this.BtnAddFactura);
            this.PBotonesControl.Location = new System.Drawing.Point(25, 276);
            this.PBotonesControl.Name = "PBotonesControl";
            this.PBotonesControl.Size = new System.Drawing.Size(517, 61);
            this.PBotonesControl.TabIndex = 25;
            // 
            // BtnEliminarFactura
            // 
            this.BtnEliminarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnEliminarFactura.Location = new System.Drawing.Point(376, 19);
            this.BtnEliminarFactura.Name = "BtnEliminarFactura";
            this.BtnEliminarFactura.Size = new System.Drawing.Size(129, 35);
            this.BtnEliminarFactura.TabIndex = 15;
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
            this.BtnModificarFactura.TabIndex = 14;
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
            this.BtnAddFactura.TabIndex = 13;
            this.BtnAddFactura.Text = "Añadir Factura";
            this.BtnAddFactura.UseVisualStyleBackColor = true;
            this.BtnAddFactura.Click += new System.EventHandler(this.BtnAddFactura_Click);
            // 
            // CkBoxPagada
            // 
            this.CkBoxPagada.AutoSize = true;
            this.CkBoxPagada.Enabled = false;
            this.CkBoxPagada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CkBoxPagada.Location = new System.Drawing.Point(183, 165);
            this.CkBoxPagada.Name = "CkBoxPagada";
            this.CkBoxPagada.Size = new System.Drawing.Size(83, 24);
            this.CkBoxPagada.TabIndex = 6;
            this.CkBoxPagada.Text = "Pagada";
            this.CkBoxPagada.UseVisualStyleBackColor = true;
            // 
            // TxtTotalFactura
            // 
            this.TxtTotalFactura.Enabled = false;
            this.TxtTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtTotalFactura.Location = new System.Drawing.Point(641, 205);
            this.TxtTotalFactura.Name = "TxtTotalFactura";
            this.TxtTotalFactura.Size = new System.Drawing.Size(95, 24);
            this.TxtTotalFactura.TabIndex = 12;
            this.TxtTotalFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTotalFactura_KeyPress);
            // 
            // LTotalFactura
            // 
            this.LTotalFactura.AutoSize = true;
            this.LTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LTotalFactura.Location = new System.Drawing.Point(496, 208);
            this.LTotalFactura.Name = "LTotalFactura";
            this.LTotalFactura.Size = new System.Drawing.Size(103, 18);
            this.LTotalFactura.TabIndex = 22;
            this.LTotalFactura.Text = "Total Factura: ";
            // 
            // CbGarajes
            // 
            this.CbGarajes.Enabled = false;
            this.CbGarajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbGarajes.FormattingEnabled = true;
            this.CbGarajes.Location = new System.Drawing.Point(641, 53);
            this.CbGarajes.Name = "CbGarajes";
            this.CbGarajes.Size = new System.Drawing.Size(193, 26);
            this.CbGarajes.TabIndex = 8;
            this.CbGarajes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbGarajes_KeyPress);
            // 
            // CbConceptos
            // 
            this.CbConceptos.Enabled = false;
            this.CbConceptos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbConceptos.FormattingEnabled = true;
            this.CbConceptos.Location = new System.Drawing.Point(641, 16);
            this.CbConceptos.Name = "CbConceptos";
            this.CbConceptos.Size = new System.Drawing.Size(193, 26);
            this.CbConceptos.TabIndex = 7;
            this.CbConceptos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbConceptos_KeyPress);
            // 
            // TxtIva
            // 
            this.TxtIva.Enabled = false;
            this.TxtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtIva.Location = new System.Drawing.Point(641, 164);
            this.TxtIva.Name = "TxtIva";
            this.TxtIva.Size = new System.Drawing.Size(95, 24);
            this.TxtIva.TabIndex = 11;
            this.TxtIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIva_KeyPress);
            // 
            // TxtBaseImponible
            // 
            this.TxtBaseImponible.Enabled = false;
            this.TxtBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtBaseImponible.Location = new System.Drawing.Point(641, 127);
            this.TxtBaseImponible.Name = "TxtBaseImponible";
            this.TxtBaseImponible.Size = new System.Drawing.Size(95, 24);
            this.TxtBaseImponible.TabIndex = 10;
            this.TxtBaseImponible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBaseImponible_KeyPress);
            // 
            // TxtPlaza
            // 
            this.TxtPlaza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPlaza.Enabled = false;
            this.TxtPlaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtPlaza.Location = new System.Drawing.Point(641, 90);
            this.TxtPlaza.Name = "TxtPlaza";
            this.TxtPlaza.Size = new System.Drawing.Size(92, 24);
            this.TxtPlaza.TabIndex = 9;
            // 
            // LIva
            // 
            this.LIva.AutoSize = true;
            this.LIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LIva.Location = new System.Drawing.Point(496, 167);
            this.LIva.Name = "LIva";
            this.LIva.Size = new System.Drawing.Size(49, 18);
            this.LIva.TabIndex = 15;
            this.LIva.Text = "I.V.A.: ";
            // 
            // LBaseImponible
            // 
            this.LBaseImponible.AutoSize = true;
            this.LBaseImponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LBaseImponible.Location = new System.Drawing.Point(496, 130);
            this.LBaseImponible.Name = "LBaseImponible";
            this.LBaseImponible.Size = new System.Drawing.Size(117, 18);
            this.LBaseImponible.TabIndex = 14;
            this.LBaseImponible.Text = "Base Imponible: ";
            // 
            // LPlaza
            // 
            this.LPlaza.AutoSize = true;
            this.LPlaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LPlaza.Location = new System.Drawing.Point(496, 93);
            this.LPlaza.Name = "LPlaza";
            this.LPlaza.Size = new System.Drawing.Size(53, 18);
            this.LPlaza.TabIndex = 13;
            this.LPlaza.Text = "Plaza: ";
            // 
            // LGaraje
            // 
            this.LGaraje.AutoSize = true;
            this.LGaraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LGaraje.Location = new System.Drawing.Point(496, 56);
            this.LGaraje.Name = "LGaraje";
            this.LGaraje.Size = new System.Drawing.Size(60, 18);
            this.LGaraje.TabIndex = 12;
            this.LGaraje.Text = "Garaje: ";
            // 
            // LConcepto
            // 
            this.LConcepto.AutoSize = true;
            this.LConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LConcepto.Location = new System.Drawing.Point(496, 19);
            this.LConcepto.Name = "LConcepto";
            this.LConcepto.Size = new System.Drawing.Size(81, 18);
            this.LConcepto.TabIndex = 11;
            this.LConcepto.Text = "Concepto: ";
            // 
            // TxtNumFactura
            // 
            this.TxtNumFactura.Enabled = false;
            this.TxtNumFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TxtNumFactura.Location = new System.Drawing.Point(183, 16);
            this.TxtNumFactura.Name = "TxtNumFactura";
            this.TxtNumFactura.Size = new System.Drawing.Size(51, 24);
            this.TxtNumFactura.TabIndex = 1;
            this.TxtNumFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumFactura_KeyPress);
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LFecha.Location = new System.Drawing.Point(69, 57);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(57, 18);
            this.LFecha.TabIndex = 1;
            this.LFecha.Text = "Fecha: ";
            // 
            // LNumFactura
            // 
            this.LNumFactura.AutoSize = true;
            this.LNumFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LNumFactura.Location = new System.Drawing.Point(69, 19);
            this.LNumFactura.Name = "LNumFactura";
            this.LNumFactura.Size = new System.Drawing.Size(86, 18);
            this.LNumFactura.TabIndex = 0;
            this.LNumFactura.Text = "Nº Factura: ";
            // 
            // PBuscarPor
            // 
            this.PBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PBuscarPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBuscarPor.Controls.Add(this.CbFechas);
            this.PBuscarPor.Controls.Add(this.label3);
            this.PBuscarPor.Controls.Add(this.panel3);
            this.PBuscarPor.Controls.Add(this.label1);
            this.PBuscarPor.Controls.Add(this.CbNumsFacturas);
            this.PBuscarPor.Location = new System.Drawing.Point(73, 437);
            this.PBuscarPor.Name = "PBuscarPor";
            this.PBuscarPor.Size = new System.Drawing.Size(517, 100);
            this.PBuscarPor.TabIndex = 27;
            // 
            // CbFechas
            // 
            this.CbFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbFechas.FormattingEnabled = true;
            this.CbFechas.Location = new System.Drawing.Point(357, 58);
            this.CbFechas.Name = "CbFechas";
            this.CbFechas.Size = new System.Drawing.Size(127, 24);
            this.CbFechas.TabIndex = 20;
            this.CbFechas.SelectionChangeCommitted += new System.EventHandler(this.CbFechas_SelectionChangeCommitted);
            this.CbFechas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbFechas_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(289, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Fecha: ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.LBuscarPor);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(509, 30);
            this.panel3.TabIndex = 0;
            // 
            // LBuscarPor
            // 
            this.LBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBuscarPor.AutoSize = true;
            this.LBuscarPor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscarPor.Location = new System.Drawing.Point(187, 4);
            this.LBuscarPor.Name = "LBuscarPor";
            this.LBuscarPor.Padding = new System.Windows.Forms.Padding(2);
            this.LBuscarPor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LBuscarPor.Size = new System.Drawing.Size(134, 24);
            this.LBuscarPor.TabIndex = 2;
            this.LBuscarPor.Text = "BUSCAR POR:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nº Factura: ";
            // 
            // CbNumsFacturas
            // 
            this.CbNumsFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbNumsFacturas.FormattingEnabled = true;
            this.CbNumsFacturas.Location = new System.Drawing.Point(116, 58);
            this.CbNumsFacturas.Name = "CbNumsFacturas";
            this.CbNumsFacturas.Size = new System.Drawing.Size(103, 24);
            this.CbNumsFacturas.TabIndex = 18;
            this.CbNumsFacturas.SelectionChangeCommitted += new System.EventHandler(this.CbNumsFacturas_SelectionChangeCommitted);
            this.CbNumsFacturas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbNumsFacturas_KeyPress);
            // 
            // BtnImprimirFactura
            // 
            this.BtnImprimirFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnImprimirFactura.Location = new System.Drawing.Point(766, 464);
            this.BtnImprimirFactura.Name = "BtnImprimirFactura";
            this.BtnImprimirFactura.Size = new System.Drawing.Size(93, 60);
            this.BtnImprimirFactura.TabIndex = 21;
            this.BtnImprimirFactura.Text = "Imprimir Factura";
            this.BtnImprimirFactura.UseVisualStyleBackColor = true;
            this.BtnImprimirFactura.Click += new System.EventHandler(this.BtnImprimirFactura_Click);
            // 
            // FrmFactsGaraje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 559);
            this.Controls.Add(this.BtnImprimirFactura);
            this.Controls.Add(this.PBuscarPor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmFactsGaraje";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas Garajes";
            this.Load += new System.EventHandler(this.FrmFactsGaraje_Load);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LNumFactura;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.TextBox TxtNumFactura;
        private System.Windows.Forms.Label LIva;
        private System.Windows.Forms.Label LBaseImponible;
        private System.Windows.Forms.Label LPlaza;
        private System.Windows.Forms.Label LGaraje;
        private System.Windows.Forms.Label LConcepto;
        private System.Windows.Forms.TextBox TxtIva;
        private System.Windows.Forms.TextBox TxtBaseImponible;
        private System.Windows.Forms.TextBox TxtPlaza;
        private System.Windows.Forms.ComboBox CbGarajes;
        private System.Windows.Forms.ComboBox CbConceptos;
        private System.Windows.Forms.TextBox TxtTotalFactura;
        private System.Windows.Forms.Label LTotalFactura;
        private System.Windows.Forms.CheckBox CkBoxPagada;
        private System.Windows.Forms.Panel PBotonesControl;
        private System.Windows.Forms.Button BtnEliminarFactura;
        private System.Windows.Forms.Button BtnModificarFactura;
        private System.Windows.Forms.Button BtnAddFactura;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Panel PBuscarPor;
        private System.Windows.Forms.ComboBox CbFechas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LBuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbNumsFacturas;
        private System.Windows.Forms.Button BtnImprimirFactura;
        private System.Windows.Forms.DateTimePicker DtFecha;
        private System.Windows.Forms.ComboBox CbClientes;
        private System.Windows.Forms.Label LCliente;
    }
}