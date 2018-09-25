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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnEliminarCliente = new System.Windows.Forms.Button();
            this.BtnModificarCliente = new System.Windows.Forms.Button();
            this.BtnAddCliente = new System.Windows.Forms.Button();
            this.TxtLlaveMando = new System.Windows.Forms.TextBox();
            this.LLaveMando = new System.Windows.Forms.Label();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.LObservaciones = new System.Windows.Forms.Label();
            this.CbGarajes = new System.Windows.Forms.ComboBox();
            this.LGaraje = new System.Windows.Forms.Label();
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
            this.TxtId = new System.Windows.Forms.TextBox();
            this.LId = new System.Windows.Forms.Label();
            this.BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.LBuscarPor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbNifs = new System.Windows.Forms.ComboBox();
            this.CbClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtClientes = new GarajesAliKan.DtClientes();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).BeginInit();
            this.BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.BtnEliminarCliente);
            this.panel1.Controls.Add(this.BtnModificarCliente);
            this.panel1.Controls.Add(this.BtnAddCliente);
            this.panel1.Controls.Add(this.TxtLlaveMando);
            this.panel1.Controls.Add(this.LLaveMando);
            this.panel1.Controls.Add(this.TxtObservaciones);
            this.panel1.Controls.Add(this.LObservaciones);
            this.panel1.Controls.Add(this.CbGarajes);
            this.panel1.Controls.Add(this.LGaraje);
            this.panel1.Controls.Add(this.TxtTelefono);
            this.panel1.Controls.Add(this.LTelefono);
            this.panel1.Controls.Add(this.TxtDireccion);
            this.panel1.Controls.Add(this.LDireccion);
            this.panel1.Controls.Add(this.TxtNif);
            this.panel1.Controls.Add(this.LNif);
            this.panel1.Controls.Add(this.TxtApellidos);
            this.panel1.Controls.Add(this.LApellidos);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.LNombre);
            this.panel1.Controls.Add(this.TxtId);
            this.panel1.Controls.Add(this.LId);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 323);
            this.panel1.TabIndex = 0;
            // 
            // BtnEliminarCliente
            // 
            this.BtnEliminarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarCliente.Location = new System.Drawing.Point(596, 285);
            this.BtnEliminarCliente.Name = "BtnEliminarCliente";
            this.BtnEliminarCliente.Size = new System.Drawing.Size(123, 31);
            this.BtnEliminarCliente.TabIndex = 19;
            this.BtnEliminarCliente.Text = "Eliminar Cliente";
            this.BtnEliminarCliente.UseVisualStyleBackColor = true;
            // 
            // BtnModificarCliente
            // 
            this.BtnModificarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificarCliente.Location = new System.Drawing.Point(405, 285);
            this.BtnModificarCliente.Name = "BtnModificarCliente";
            this.BtnModificarCliente.Size = new System.Drawing.Size(136, 31);
            this.BtnModificarCliente.TabIndex = 18;
            this.BtnModificarCliente.Text = "Modificar Cliente";
            this.BtnModificarCliente.UseVisualStyleBackColor = true;
            // 
            // BtnAddCliente
            // 
            this.BtnAddCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCliente.Location = new System.Drawing.Point(227, 285);
            this.BtnAddCliente.Name = "BtnAddCliente";
            this.BtnAddCliente.Size = new System.Drawing.Size(123, 31);
            this.BtnAddCliente.TabIndex = 2;
            this.BtnAddCliente.Text = "Añadir Cliente";
            this.BtnAddCliente.UseVisualStyleBackColor = true;
            // 
            // TxtLlaveMando
            // 
            this.TxtLlaveMando.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "LlaveMando", true));
            this.TxtLlaveMando.Enabled = false;
            this.TxtLlaveMando.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLlaveMando.Location = new System.Drawing.Point(785, 70);
            this.TxtLlaveMando.Name = "TxtLlaveMando";
            this.TxtLlaveMando.Size = new System.Drawing.Size(56, 23);
            this.TxtLlaveMando.TabIndex = 17;
            // 
            // LLaveMando
            // 
            this.LLaveMando.AutoSize = true;
            this.LLaveMando.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLaveMando.Location = new System.Drawing.Point(682, 73);
            this.LLaveMando.Name = "LLaveMando";
            this.LLaveMando.Size = new System.Drawing.Size(97, 17);
            this.LLaveMando.TabIndex = 16;
            this.LLaveMando.Text = "Llave Mando: ";
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Observaciones", true));
            this.TxtObservaciones.Enabled = false;
            this.TxtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObservaciones.Location = new System.Drawing.Point(495, 153);
            this.TxtObservaciones.Multiline = true;
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Size = new System.Drawing.Size(284, 77);
            this.TxtObservaciones.TabIndex = 15;
            // 
            // LObservaciones
            // 
            this.LObservaciones.AutoSize = true;
            this.LObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LObservaciones.Location = new System.Drawing.Point(355, 184);
            this.LObservaciones.Name = "LObservaciones";
            this.LObservaciones.Size = new System.Drawing.Size(111, 17);
            this.LObservaciones.TabIndex = 14;
            this.LObservaciones.Text = "Observaciones: ";
            // 
            // CbGarajes
            // 
            this.CbGarajes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Garaje", true));
            this.CbGarajes.Enabled = false;
            this.CbGarajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbGarajes.FormattingEnabled = true;
            this.CbGarajes.Location = new System.Drawing.Point(450, 110);
            this.CbGarajes.Name = "CbGarajes";
            this.CbGarajes.Size = new System.Drawing.Size(143, 24);
            this.CbGarajes.TabIndex = 13;
            // 
            // LGaraje
            // 
            this.LGaraje.AutoSize = true;
            this.LGaraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGaraje.Location = new System.Drawing.Point(355, 113);
            this.LGaraje.Name = "LGaraje";
            this.LGaraje.Size = new System.Drawing.Size(59, 17);
            this.LGaraje.TabIndex = 12;
            this.LGaraje.Text = "Garaje: ";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Telefono", true));
            this.TxtTelefono.Enabled = false;
            this.TxtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTelefono.Location = new System.Drawing.Point(450, 70);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(116, 23);
            this.TxtTelefono.TabIndex = 11;
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(355, 73);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(72, 17);
            this.LTelefono.TabIndex = 10;
            this.LTelefono.Text = "Teléfono: ";
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Direccion", true));
            this.TxtDireccion.Enabled = false;
            this.TxtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDireccion.Location = new System.Drawing.Point(107, 190);
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(204, 23);
            this.TxtDireccion.TabIndex = 9;
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDireccion.Location = new System.Drawing.Point(12, 193);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(75, 17);
            this.LDireccion.TabIndex = 8;
            this.LDireccion.Text = "Dirección: ";
            // 
            // TxtNif
            // 
            this.TxtNif.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Nif", true));
            this.TxtNif.Enabled = false;
            this.TxtNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNif.Location = new System.Drawing.Point(105, 150);
            this.TxtNif.Name = "TxtNif";
            this.TxtNif.Size = new System.Drawing.Size(114, 23);
            this.TxtNif.TabIndex = 7;
            // 
            // LNif
            // 
            this.LNif.AutoSize = true;
            this.LNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNif.Location = new System.Drawing.Point(12, 153);
            this.LNif.Name = "LNif";
            this.LNif.Size = new System.Drawing.Size(49, 17);
            this.LNif.TabIndex = 6;
            this.LNif.Text = "N.I.F.: ";
            // 
            // TxtApellidos
            // 
            this.TxtApellidos.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Apellidos", true));
            this.TxtApellidos.Enabled = false;
            this.TxtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtApellidos.Location = new System.Drawing.Point(105, 110);
            this.TxtApellidos.Name = "TxtApellidos";
            this.TxtApellidos.Size = new System.Drawing.Size(164, 23);
            this.TxtApellidos.TabIndex = 5;
            // 
            // LApellidos
            // 
            this.LApellidos.AutoSize = true;
            this.LApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellidos.Location = new System.Drawing.Point(12, 113);
            this.LApellidos.Name = "LApellidos";
            this.LApellidos.Size = new System.Drawing.Size(73, 17);
            this.LApellidos.TabIndex = 4;
            this.LApellidos.Text = "Apellidos: ";
            // 
            // TxtNombre
            // 
            this.TxtNombre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Nombre", true));
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(105, 70);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(164, 23);
            this.TxtNombre.TabIndex = 3;
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(12, 73);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(66, 17);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombre: ";
            // 
            // TxtId
            // 
            this.TxtId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientesBindingSource, "Id", true));
            this.TxtId.Enabled = false;
            this.TxtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtId.Location = new System.Drawing.Point(107, 16);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(57, 23);
            this.TxtId.TabIndex = 1;
            // 
            // LId
            // 
            this.LId.AutoSize = true;
            this.LId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LId.Location = new System.Drawing.Point(12, 19);
            this.LId.Name = "LId";
            this.LId.Size = new System.Drawing.Size(27, 17);
            this.LId.TabIndex = 0;
            this.LId.Text = "Id: ";
            // 
            // BindingNavigator
            // 
            this.BindingNavigator.AddNewItem = null;
            this.BindingNavigator.BindingSource = this.clientesBindingSource;
            this.BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.BindingNavigator.DeleteItem = null;
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
            this.BindingNavigator.Size = new System.Drawing.Size(970, 25);
            this.BindingNavigator.TabIndex = 1;
            this.BindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(44, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // LBuscarPor
            // 
            this.LBuscarPor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBuscarPor.AutoSize = true;
            this.LBuscarPor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LBuscarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuscarPor.Location = new System.Drawing.Point(411, 418);
            this.LBuscarPor.Name = "LBuscarPor";
            this.LBuscarPor.Padding = new System.Windows.Forms.Padding(2);
            this.LBuscarPor.Size = new System.Drawing.Size(149, 26);
            this.LBuscarPor.TabIndex = 2;
            this.LBuscarPor.Text = "BUSCAR POR:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "N.I.F.: ";
            // 
            // CbNifs
            // 
            this.CbNifs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbNifs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbNifs.FormattingEnabled = true;
            this.CbNifs.Location = new System.Drawing.Point(307, 482);
            this.CbNifs.Name = "CbNifs";
            this.CbNifs.Size = new System.Drawing.Size(143, 24);
            this.CbNifs.TabIndex = 20;
            // 
            // CbClientes
            // 
            this.CbClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbClientes.FormattingEnabled = true;
            this.CbClientes.Location = new System.Drawing.Point(544, 482);
            this.CbClientes.Name = "CbClientes";
            this.CbClientes.Size = new System.Drawing.Size(175, 24);
            this.CbClientes.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(479, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cliente: ";
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.dtClientes;
            // 
            // dtClientes
            // 
            this.dtClientes.DataSetName = "DtClientes";
            this.dtClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FrmClientesGaraje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 551);
            this.Controls.Add(this.CbClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbNifs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBuscarPor);
            this.Controls.Add(this.BindingNavigator);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmClientesGaraje";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClientesGaraje_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator)).EndInit();
            this.BindingNavigator.ResumeLayout(false);
            this.BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingNavigator BindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label LId;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TxtNif;
        private System.Windows.Forms.Label LNif;
        private System.Windows.Forms.TextBox TxtApellidos;
        private System.Windows.Forms.Label LApellidos;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LGaraje;
        private System.Windows.Forms.ComboBox CbGarajes;
        private System.Windows.Forms.TextBox TxtObservaciones;
        private System.Windows.Forms.Label LObservaciones;
        private System.Windows.Forms.Label LLaveMando;
        private System.Windows.Forms.TextBox TxtLlaveMando;
        private System.Windows.Forms.Button BtnAddCliente;
        private System.Windows.Forms.Button BtnEliminarCliente;
        private System.Windows.Forms.Button BtnModificarCliente;
        private System.Windows.Forms.Label LBuscarPor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbNifs;
        private System.Windows.Forms.ComboBox CbClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private DtClientes dtClientes;
    }
}