namespace ToritosSAC.DeskTop
{
    partial class FrmGrupo
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
            btnRegresar = new Button();
            tabPage2 = new TabPage();
            btnAprobarMiembro = new Button();
            btnDescargarRecibo = new Button();
            btnDescargarAntecedentes = new Button();
            btnDescargarDNI = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            lblEstadoAntecedentes = new Label();
            label3 = new Label();
            lblEstadoRecibo = new Label();
            label2 = new Label();
            label4 = new Label();
            lblEstadoDNI = new Label();
            label1 = new Label();
            btnAprobarAntecedentes = new Button();
            btnAprobarRecibo = new Button();
            btnAprobarDNI = new Button();
            btnRechazarAntecedentes = new Button();
            btnRechazarRecibo = new Button();
            btnObservarAntecedentes = new Button();
            btnRechazarDNI = new Button();
            btnObservarRecibo = new Button();
            btnObservarDNI = new Button();
            txtRow = new TextBox();
            txtId = new TextBox();
            Seleccionar = new DataGridViewCheckBoxColumn();
            lblTotal = new Label();
            dgvListado = new DataGridView();
            tabGeneral = new TabControl();
            tabPage1 = new TabPage();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            lblTitulo.Size = new Size(252, 25);
            lblTitulo.TabIndex = 9;
            lblTitulo.Text = "Registrar nuevo proveedor";
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(1165, 626);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(108, 23);
            btnRegresar.TabIndex = 8;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnAprobarMiembro);
            tabPage2.Controls.Add(btnDescargarRecibo);
            tabPage2.Controls.Add(btnDescargarAntecedentes);
            tabPage2.Controls.Add(btnDescargarDNI);
            tabPage2.Controls.Add(pictureBox3);
            tabPage2.Controls.Add(pictureBox2);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Controls.Add(lblEstadoAntecedentes);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(lblEstadoRecibo);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(lblEstadoDNI);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(lblTitulo);
            tabPage2.Controls.Add(btnRegresar);
            tabPage2.Controls.Add(btnAprobarAntecedentes);
            tabPage2.Controls.Add(btnAprobarRecibo);
            tabPage2.Controls.Add(btnAprobarDNI);
            tabPage2.Controls.Add(btnRechazarAntecedentes);
            tabPage2.Controls.Add(btnRechazarRecibo);
            tabPage2.Controls.Add(btnObservarAntecedentes);
            tabPage2.Controls.Add(btnRechazarDNI);
            tabPage2.Controls.Add(btnObservarRecibo);
            tabPage2.Controls.Add(btnObservarDNI);
            tabPage2.Controls.Add(txtRow);
            tabPage2.Controls.Add(txtId);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1288, 709);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Mantenimiento";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAprobarMiembro
            // 
            btnAprobarMiembro.Location = new Point(518, 648);
            btnAprobarMiembro.Name = "btnAprobarMiembro";
            btnAprobarMiembro.Size = new Size(287, 23);
            btnAprobarMiembro.TabIndex = 12;
            btnAprobarMiembro.Text = "APROBAR A ";
            btnAprobarMiembro.UseVisualStyleBackColor = true;
            btnAprobarMiembro.Click += btnAprobarMiembro_Click;
            // 
            // btnDescargarRecibo
            // 
            btnDescargarRecibo.Location = new Point(863, 597);
            btnDescargarRecibo.Name = "btnDescargarRecibo";
            btnDescargarRecibo.Size = new Size(108, 23);
            btnDescargarRecibo.TabIndex = 11;
            btnDescargarRecibo.Text = "Descargar";
            btnDescargarRecibo.UseVisualStyleBackColor = true;
            btnDescargarRecibo.Click += btnDescargarRecibo_Click;
            // 
            // btnDescargarAntecedentes
            // 
            btnDescargarAntecedentes.Location = new Point(447, 597);
            btnDescargarAntecedentes.Name = "btnDescargarAntecedentes";
            btnDescargarAntecedentes.Size = new Size(108, 23);
            btnDescargarAntecedentes.TabIndex = 11;
            btnDescargarAntecedentes.Text = "Descargar";
            btnDescargarAntecedentes.UseVisualStyleBackColor = true;
            btnDescargarAntecedentes.Click += btnDescargarAntecedentes_Click;
            // 
            // btnDescargarDNI
            // 
            btnDescargarDNI.Location = new Point(31, 597);
            btnDescargarDNI.Name = "btnDescargarDNI";
            btnDescargarDNI.Size = new Size(108, 23);
            btnDescargarDNI.TabIndex = 11;
            btnDescargarDNI.Text = "Descargar";
            btnDescargarDNI.UseVisualStyleBackColor = true;
            btnDescargarDNI.Click += btnDescargarDNI_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(863, 158);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(410, 394);
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(447, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(410, 394);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(31, 158);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 394);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // lblEstadoAntecedentes
            // 
            lblEstadoAntecedentes.AutoSize = true;
            lblEstadoAntecedentes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEstadoAntecedentes.Location = new Point(447, 112);
            lblEstadoAntecedentes.Name = "lblEstadoAntecedentes";
            lblEstadoAntecedentes.Size = new Size(97, 21);
            lblEstadoAntecedentes.TabIndex = 9;
            lblEstadoAntecedentes.Text = "Etado actual:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(447, 82);
            label3.Name = "label3";
            label3.Size = new Size(177, 21);
            label3.TabIndex = 9;
            label3.Text = "Antecedentes penales";
            // 
            // lblEstadoRecibo
            // 
            lblEstadoRecibo.AutoSize = true;
            lblEstadoRecibo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEstadoRecibo.Location = new Point(863, 112);
            lblEstadoRecibo.Name = "lblEstadoRecibo";
            lblEstadoRecibo.Size = new Size(108, 21);
            lblEstadoRecibo.TabIndex = 9;
            lblEstadoRecibo.Text = "Estado actual: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(863, 82);
            label2.Name = "label2";
            label2.Size = new Size(173, 21);
            label2.TabIndex = 9;
            label2.Text = "Recibo de Luz o Agua";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(518, 674);
            label4.Name = "label4";
            label4.Size = new Size(460, 19);
            label4.TabIndex = 9;
            label4.Text = "(*) Solo miembros con los 3 documentos validados podrán ser aprobados.";
            // 
            // lblEstadoDNI
            // 
            lblEstadoDNI.AutoSize = true;
            lblEstadoDNI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEstadoDNI.Location = new Point(31, 112);
            lblEstadoDNI.Name = "lblEstadoDNI";
            lblEstadoDNI.Size = new Size(108, 21);
            lblEstadoDNI.TabIndex = 9;
            lblEstadoDNI.Text = "Estado actual: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(31, 82);
            label1.Name = "label1";
            label1.Size = new Size(40, 21);
            label1.TabIndex = 9;
            label1.Text = "DNI";
            // 
            // btnAprobarAntecedentes
            // 
            btnAprobarAntecedentes.Location = new Point(447, 568);
            btnAprobarAntecedentes.Name = "btnAprobarAntecedentes";
            btnAprobarAntecedentes.Size = new Size(108, 23);
            btnAprobarAntecedentes.TabIndex = 7;
            btnAprobarAntecedentes.Text = "Aprobar";
            btnAprobarAntecedentes.UseVisualStyleBackColor = true;
            btnAprobarAntecedentes.Click += btnAprobarAntecedentes_Click;
            // 
            // btnAprobarRecibo
            // 
            btnAprobarRecibo.Location = new Point(863, 568);
            btnAprobarRecibo.Name = "btnAprobarRecibo";
            btnAprobarRecibo.Size = new Size(108, 23);
            btnAprobarRecibo.TabIndex = 7;
            btnAprobarRecibo.Text = "Aprobar";
            btnAprobarRecibo.UseVisualStyleBackColor = true;
            btnAprobarRecibo.Click += btnAprobarRecibo_Click;
            // 
            // btnAprobarDNI
            // 
            btnAprobarDNI.Location = new Point(31, 568);
            btnAprobarDNI.Name = "btnAprobarDNI";
            btnAprobarDNI.Size = new Size(108, 23);
            btnAprobarDNI.TabIndex = 7;
            btnAprobarDNI.Text = "Aprobar";
            btnAprobarDNI.UseVisualStyleBackColor = true;
            btnAprobarDNI.Click += btnAprobarDNI_Click;
            // 
            // btnRechazarAntecedentes
            // 
            btnRechazarAntecedentes.Location = new Point(561, 568);
            btnRechazarAntecedentes.Name = "btnRechazarAntecedentes";
            btnRechazarAntecedentes.Size = new Size(108, 23);
            btnRechazarAntecedentes.TabIndex = 6;
            btnRechazarAntecedentes.Text = "Rechazar";
            btnRechazarAntecedentes.UseVisualStyleBackColor = true;
            btnRechazarAntecedentes.Click += btnRechazarAntecedentes_Click;
            // 
            // btnRechazarRecibo
            // 
            btnRechazarRecibo.Location = new Point(977, 568);
            btnRechazarRecibo.Name = "btnRechazarRecibo";
            btnRechazarRecibo.Size = new Size(108, 23);
            btnRechazarRecibo.TabIndex = 6;
            btnRechazarRecibo.Text = "Rechazar";
            btnRechazarRecibo.UseVisualStyleBackColor = true;
            btnRechazarRecibo.Click += btnRechazarRecibo_Click;
            // 
            // btnObservarAntecedentes
            // 
            btnObservarAntecedentes.Location = new Point(675, 568);
            btnObservarAntecedentes.Name = "btnObservarAntecedentes";
            btnObservarAntecedentes.Size = new Size(108, 23);
            btnObservarAntecedentes.TabIndex = 6;
            btnObservarAntecedentes.Text = "Observado";
            btnObservarAntecedentes.UseVisualStyleBackColor = true;
            btnObservarAntecedentes.Click += btnObservarAntecedentes_Click;
            // 
            // btnRechazarDNI
            // 
            btnRechazarDNI.Location = new Point(145, 568);
            btnRechazarDNI.Name = "btnRechazarDNI";
            btnRechazarDNI.Size = new Size(108, 23);
            btnRechazarDNI.TabIndex = 6;
            btnRechazarDNI.Text = "Rechazar";
            btnRechazarDNI.UseVisualStyleBackColor = true;
            btnRechazarDNI.Click += btnRechazarDNI_Click;
            // 
            // btnObservarRecibo
            // 
            btnObservarRecibo.Location = new Point(1091, 568);
            btnObservarRecibo.Name = "btnObservarRecibo";
            btnObservarRecibo.Size = new Size(108, 23);
            btnObservarRecibo.TabIndex = 6;
            btnObservarRecibo.Text = "Observado";
            btnObservarRecibo.UseVisualStyleBackColor = true;
            btnObservarRecibo.Click += btnObservarRecibo_Click;
            // 
            // btnObservarDNI
            // 
            btnObservarDNI.Location = new Point(259, 568);
            btnObservarDNI.Name = "btnObservarDNI";
            btnObservarDNI.Size = new Size(108, 23);
            btnObservarDNI.TabIndex = 6;
            btnObservarDNI.Text = "Observado";
            btnObservarDNI.UseVisualStyleBackColor = true;
            btnObservarDNI.Click += btnObservarDNI_Click;
            // 
            // txtRow
            // 
            txtRow.Location = new Point(786, 6);
            txtRow.Name = "txtRow";
            txtRow.Size = new Size(100, 23);
            txtRow.TabIndex = 0;
            txtRow.Visible = false;
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
            lblTotal.Location = new Point(10, 520);
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
            dgvListado.Size = new Size(1237, 456);
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
            tabGeneral.Size = new Size(1296, 737);
            tabGeneral.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnBuscar);
            tabPage1.Controls.Add(txtBuscar);
            tabPage1.Controls.Add(lblTotal);
            tabPage1.Controls.Add(dgvListado);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1288, 709);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Listado";
            tabPage1.UseVisualStyleBackColor = true;
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
            // FrmGrupo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1451, 761);
            Controls.Add(tabGeneral);
            Name = "FrmGrupo";
            Text = "FrmGrupo";
            WindowState = FormWindowState.Maximized;
            Load += FrmGrupo_Load;
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label lblTotal;
        private DataGridView dgvListado;
        private DataGridViewCheckBoxColumn Seleccionar;
        private TabPage tabPage2;
        private Label lblTitulo;
        private Button btnRegresar;
        private Button btnAprobarDNI;
        private Button btnObservarDNI;
        private TextBox txtId;
        private Button btnDescargarDNI;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAprobarAntecedentes;
        private Button btnAprobarRecibo;
        private Button btnRechazarAntecedentes;
        private Button btnRechazarRecibo;
        private Button btnObservarAntecedentes;
        private Button btnRechazarDNI;
        private Button btnObservarRecibo;
        private Label lblEstadoAntecedentes;
        private Label lblEstadoRecibo;
        private Label lblEstadoDNI;
        private TextBox txtRow;
        private Button btnDescargarRecibo;
        private Button btnDescargarAntecedentes;
        private Button btnAprobarMiembro;
        private Label label4;
    }
}