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


namespace ToritosSAC.DeskTop
{
    public partial class FrmProveedor : Form
    {
        private string NombreAnt;
        public FrmProveedor()
        {
            InitializeComponent();
        }
        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarPais();
        }

        private void Listar()
        {
            try
            {
                dgvListado.DataSource = BLProveedor.Listar();
                this.Formato();
                //this.Limpiar();
                lblTotal.Text = "Total registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Buscar()
        {
            try
            {
                dgvListado.DataSource = BLProveedor.Buscar(txtBuscar.Text);
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
            dgvListado.Columns[0].Visible = false;

            dgvListado.Columns[1].HeaderText = "Id";
            dgvListado.Columns[1].Width = 50;

            dgvListado.Columns[2].HeaderText = "Nombre";
            dgvListado.Columns[2].Width = 100;

            dgvListado.Columns[3].HeaderText = "Contacto";
            dgvListado.Columns[3].Width = 100;

            dgvListado.Columns[4].HeaderText = "Cargo";
            dgvListado.Columns[4].Width = 100;

            dgvListado.Columns[5].HeaderText = "Dirección";
            dgvListado.Columns[5].Width = 150;

            dgvListado.Columns[6].HeaderText = "País";
            dgvListado.Columns[6].Width = 100;

            dgvListado.Columns[7].HeaderText = "Estado";
            dgvListado.Columns[7].Width = 100;
        }


        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void CargarPais()
        {
            try
            {
                cboPais.DataSource = BLProveedor.SeleccionarPais();
                cboPais.ValueMember = "IdPais_i";
                cboPais.DisplayMember = "Nombre_nv";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtContacto.Text == string.Empty || txtDireccion.Text == string.Empty || txtCargo.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(txtContacto, "Ingrese un numero de contacto válido.");
                    ErrorIcono.SetError(txtDireccion, "Ingrese una dirección.");
                    ErrorIcono.SetError(txtCargo, "Ingrese un cargo.");
                }
                else
                {
                    Rpta = BLProveedor.Insertar(txtNombre.Text.Trim(), txtContacto.Text.Trim(), txtCargo.Text.Trim(), txtDireccion.Text.Trim(), Convert.ToString(cboPais.SelectedValue));
                    //public static string Insertar(string Nombre, string Contacto, string Cargo, string Direccion, string Pais)
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro");
                        //this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtContacto.Text == string.Empty || txtDireccion.Text == string.Empty || txtCargo.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(txtContacto, "Ingrese un numero de contacto válido.");
                    ErrorIcono.SetError(txtDireccion, "Ingrese una dirección.");
                    ErrorIcono.SetError(txtCargo, "Ingrese un cargo.");
                }
                else
                {
                    Rpta = BLProveedor.Actualizar(Convert.ToInt32(txtId.Text), this.NombreAnt, txtNombre.Text.Trim(), txtContacto.Text.Trim(), txtCargo.Text.Trim(), txtDireccion.Text.Trim(), Convert.ToString(cboPais.SelectedValue));
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó de forma correcta el registro");

                        this.Listar();
                        tabGeneral.SelectedIndex = 0;
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            tabGeneral.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                dgvListado.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                dgvListado.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
    }
}
