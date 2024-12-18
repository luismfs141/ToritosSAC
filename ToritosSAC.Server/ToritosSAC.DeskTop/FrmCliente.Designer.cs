namespace ToritosSAC.DeskTop
{
    partial class FrmCliente
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
            tabPage1 = new TabPage();
            btnActivar = new Button();
            btnDesactivar = new Button();
            ChkSeleccionar = new CheckBox();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            lblTotal = new Label();
            dgvListado = new DataGridView();
            Seleccionar = new DataGridViewCheckBoxColumn();
            tabGeneral = new TabControl();
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            tabGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // ErrorIcono
            // 
            ErrorIcono.ContainerControl = this;
            // 
            // tabPage1
            // 
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
            ChkSeleccionar.Location = new Point(354, 370);
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
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(6, 10);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(383, 23);
            txtBuscar.TabIndex = 2;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(22, 375);
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
            // 
            // Seleccionar
            // 
            Seleccionar.HeaderText = "Seleccionar";
            Seleccionar.Name = "Seleccionar";
            Seleccionar.ReadOnly = true;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(tabPage1);
            tabGeneral.Location = new Point(6, 12);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.SelectedIndex = 0;
            tabGeneral.Size = new Size(782, 426);
            tabGeneral.TabIndex = 2;
            // 
            // FrmCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabGeneral);
            Name = "FrmCliente";
            Text = "Cliente";
            Load += FrmCliente_Load;
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListado).EndInit();
            tabGeneral.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider ErrorIcono;
        private TabControl tabGeneral;
        private TabPage tabPage1;
        private Button btnActivar;
        private Button btnDesactivar;
        private CheckBox ChkSeleccionar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label lblTotal;
        private DataGridView dgvListado;
        private DataGridViewCheckBoxColumn Seleccionar;
    }
}