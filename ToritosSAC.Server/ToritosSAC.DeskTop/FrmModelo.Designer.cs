namespace ToritosSAC.DeskTop
{
    partial class FrmModelo
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
            components = new System.ComponentModel.Container();
            ErrorIcono = new ErrorProvider(components);
            lblTitulo = new Label();
            btnCancelar = new Button();
            tabPage2 = new TabPage();
            cboTipo = new ComboBox();
            cboMarca = new ComboBox();
            btnActualizar = new Button();
            btnInsertar = new Button();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            txtId = new TextBox();
            Seleccionar = new DataGridViewCheckBoxColumn();
            lblTotal = new Label();
            dgvListado = new DataGridView();
            tabGeneral = new TabControl();
            tabPage1 = new TabPage();
            btnEliminar = new Button();
            btnActivar = new Button();
            btnDesactivar = new Button();
            ChkSeleccionar = new CheckBox();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            tabGeneral.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // ErrorIcono
            // 
            ErrorIcono.ContainerControl = this;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(31, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(226, 25);
            lblTitulo.TabIndex = 9;
            lblTitulo.Text = "Registrar nuevo modelo";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(144, 254);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cboTipo);
            tabPage2.Controls.Add(cboMarca);
            tabPage2.Controls.Add(lblTitulo);
            tabPage2.Controls.Add(btnCancelar);
            tabPage2.Controls.Add(btnActualizar);
            tabPage2.Controls.Add(btnInsertar);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(txtPrecio);
            tabPage2.Controls.Add(txtNombre);
            tabPage2.Controls.Add(txtId);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(774, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Mantenimiento";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(144, 110);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(230, 23);
            cboTipo.TabIndex = 10;
            // 
            // cboMarca
            // 
            cboMarca.FormattingEnabled = true;
            cboMarca.Location = new Point(144, 81);
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new Size(230, 23);
            cboMarca.TabIndex = 10;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(30, 254);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(108, 23);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(28, 254);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(108, 23);
            btnInsertar.TabIndex = 6;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 209);
            label6.Name = "label6";
            label6.Size = new Size(192, 15);
            label6.TabIndex = 4;
            label6.Text = "(*) Indica que el dato es obligatorio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 142);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 1;
            label4.Text = "Precio (*):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 113);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 1;
            label3.Text = "Tipo (*)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 84);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Marca (*):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 55);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre (*):";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(144, 139);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(230, 23);
            txtPrecio.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(144, 52);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(230, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtId
            // 
            txtId.Location = new Point(668, 6);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            txtId.Visible = false;
            // 
            // Seleccionar
            // 
            Seleccionar.HeaderText = "Seleccionar";
            Seleccionar.Name = "Seleccionar";
            Seleccionar.ReadOnly = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(19, 372);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(35, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total:";
            // 
            // dgvListado
            // 
            dgvListado.AllowUserToAddRows = false;
            dgvListado.AllowUserToDeleteRows = false;
            dgvListado.AllowUserToOrderColumns = true;
            dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListado.Columns.AddRange(new DataGridViewColumn[] { Seleccionar });
            dgvListado.Location = new Point(6, 42);
            dgvListado.Name = "dgvListado";
            dgvListado.ReadOnly = true;
            dgvListado.RowTemplate.Height = 25;
            dgvListado.Size = new Size(758, 310);
            dgvListado.TabIndex = 0;
            dgvListado.CellContentClick += dgvListado_CellContentClick;
            dgvListado.CellDoubleClick += dgvListado_CellDoubleClick;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(tabPage1);
            tabGeneral.Controls.Add(tabPage2);
            tabGeneral.Location = new Point(9, 12);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.SelectedIndex = 0;
            tabGeneral.Size = new Size(782, 426);
            tabGeneral.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnEliminar);
            tabPage1.Controls.Add(btnActivar);
            tabPage1.Controls.Add(btnDesactivar);
            tabPage1.Controls.Add(ChkSeleccionar);
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(txtBuscar);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Controls.Add(dgvListado);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(774, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(660, 364);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(104, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActivar
            // 
            btnActivar.Location = new Point(550, 364);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(104, 23);
            btnActivar.TabIndex = 5;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = true;
            btnActivar.Visible = false;
            btnActivar.Click += btnActivar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(440, 364);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(104, 23);
            btnDesactivar.TabIndex = 5;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Visible = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // ChkSeleccionar
            // 
            ChkSeleccionar.AutoSize = true;
            ChkSeleccionar.Location = new Point(351, 367);
            ChkSeleccionar.Name = "ChkSeleccionar";
            ChkSeleccionar.Size = new Size(86, 19);
            ChkSeleccionar.TabIndex = 4;
            ChkSeleccionar.Text = "Seleccionar";
            ChkSeleccionar.UseVisualStyleBackColor = true;
            ChkSeleccionar.CheckedChanged += ChkSeleccionar_CheckedChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(395, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(6, 10);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(383, 23);
            txtBuscar.TabIndex = 2;
            // 
            // FrmModelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabGeneral);
            Name = "FrmModelo";
            Text = "Modelo";
            Load += FrmModelo_Load;
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
            tabGeneral.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ErrorProvider ErrorIcono;
        private TabControl tabGeneral;
        private TabPage tabPage1;
        private Button btnEliminar;
        private Button btnActivar;
        private Button btnDesactivar;
        private CheckBox ChkSeleccionar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label lblTotal;
        private DataGridView dgvListado;
        private DataGridViewCheckBoxColumn Seleccionar;
        private TabPage tabPage2;
        private Label lblTitulo;
        private Button btnCancelar;
        private Button btnActualizar;
        private Button btnInsertar;
        private Label label6;
        private ComboBox cboPais;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPrecio;
        private TextBox txtId;
        private ComboBox cboTipo;
        private ComboBox cboMarca;
        private TextBox txtNombre;
    }
}