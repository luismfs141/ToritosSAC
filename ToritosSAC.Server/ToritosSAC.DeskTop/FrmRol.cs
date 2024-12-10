using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToritosSAC.BusinessLogic;
using ToritosSAC.Entities;

namespace ToritosSAC.DeskTop
{
    public partial class FrmRol : Form
    {
        public FrmRol()
        {
            InitializeComponent();
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            this.Listar();
        }


        private void Listar()
        {
            try
            {
                dgvListado.DataSource = BLRol.ListarRoles();
                this.Formato();
                lblTotal.Text = "Total registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            dgvListado.Columns[0].Width = 50;
            dgvListado.Columns[0].HeaderText = "ID";

            dgvListado.Columns[1].Width = 100;
            dgvListado.Columns[1].HeaderText = "Nombre";

            dgvListado.Columns[2].Width = 200;
            dgvListado.Columns[2].HeaderText = "Descripción";

            dgvListado.Columns[3].Width = 200;
            dgvListado.Columns[3].HeaderText = "Abr. Estado";
            dgvListado.Columns[3].Visible = false;

            dgvListado.Columns[4].Width = 50;
            dgvListado.Columns[4].HeaderText = "Estado";
        }
    }
}
