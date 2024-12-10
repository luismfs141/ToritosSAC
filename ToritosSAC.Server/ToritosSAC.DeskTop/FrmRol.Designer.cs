namespace ToritosSAC.DeskTop
{
    partial class FrmRol
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
            lblTotal = new Label();
            dgvListado = new DataGridView();
            tabGeneral = new TabControl();
            tabPage1 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvListado).BeginInit();
            tabGeneral.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // ErrorIcono
            // 
            ErrorIcono.ContainerControl = this;
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
            dgvListado.Location = new Point(6, 6);
            dgvListado.Name = "dgvListado";
            dgvListado.ReadOnly = true;
            dgvListado.RowTemplate.Height = 25;
            dgvListado.Size = new Size(758, 346);
            dgvListado.TabIndex = 0;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(tabPage1);
            tabGeneral.Location = new Point(6, 12);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.SelectedIndex = 0;
            tabGeneral.Size = new Size(782, 426);
            tabGeneral.TabIndex = 1;
            // 
            // tabPage1
            // 
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
            // FrmRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabGeneral);
            Name = "FrmRol";
            Text = "FrmRol";
            Load += FrmRol_Load;
            ((System.ComponentModel.ISupportInitialize)ErrorIcono).EndInit();
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
        private Label lblTotal;
        private DataGridView dgvListado;
    }
}