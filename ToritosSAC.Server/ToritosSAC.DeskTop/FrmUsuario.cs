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
    public partial class FrmUsuario : Form
    {
        //Variables
        private string NombreAnt;
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarRol();
            this.CargarUsuarioTipoDocumento();
        }

        //Métodos básicos
        private void Listar()
        {
            try
            {
                dgvListado.DataSource = BLUsuario.Listar();
                this.Formato();
                this.Limpiar();
                lblTotal.Text = "Total registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void Buscar()
        {
            try
            {
                dgvListado.DataSource = BLUsuario.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotal.Text = "Total registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void Limpiar()
        {
            txtBuscar.Clear();
            txtId.Clear();
            txtNombre.Clear();
            txtNroDocumento.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtClave.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            ErrorIcono.Clear();

            dgvListado.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            ChkSeleccionar.Checked = false;
        }

        private void Formato()
        {
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[0].Width = 50;

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

            dgvListado.Columns[7].HeaderText = "IdPaís";
            dgvListado.Columns[7].Width = 50;
            dgvListado.Columns[7].Visible = false;

            dgvListado.Columns[8].HeaderText = "Estado";
            dgvListado.Columns[8].Width = 60;
        }


        //Complementarios
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarRol()
        {
            try
            {
                cboRol.DataSource = BLRol.ListarRoles();
                cboRol.ValueMember = "IdRol_i";
                cboRol.DisplayMember = "Nombre_v";
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void CargarUsuarioTipoDocumento()
        {
            try
            {
                cboTipoDocumento.DataSource = BLUsuario.ListarTipoDocumento();
                cboTipoDocumento.ValueMember = "Codigo_c";
                cboTipoDocumento.DisplayMember = "Nombre_v";
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }


        //Botones
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Buscar();
                this.Limpiar();
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || 
                    txtNroDocumento.Text == string.Empty || 
                    txtDireccion.Text == string.Empty || 
                    txtCorreo.Text == string.Empty || 
                    txtClave.Text == string.Empty || 
                    txtTelefono.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(txtNroDocumento, "Ingrese un numero número de documento.");
                    ErrorIcono.SetError(txtDireccion, "Ingrese una dirección.");
                    ErrorIcono.SetError(txtCorreo, "Ingrese un correo válido.");
                    ErrorIcono.SetError(txtClave, "Ingrese una clave.");
                    ErrorIcono.SetError(txtTelefono, "Ingrese un número de contacto.");
                }
                else
                {
                    Rpta = BLUsuario.Insertar(Convert.ToInt32(cboRol.SelectedValue), txtNombre.Text.Trim(),Convert.ToString(cboTipoDocumento.SelectedValue), txtNroDocumento.Text.Trim(), txtDireccion.Text.Trim(),txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),txtClave.Text.Trim());
                    //public static string Insertar(string Nombre, string Contacto, string Cargo, string Direccion, string Pais)
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro");

                        tabGeneral.SelectedIndex = 0;
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
                this.MensajeError(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {

        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
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

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblTitulo.Text = "Actualizar datos de usuario: " + Convert.ToString(dgvListado.CurrentRow.Cells["Nombre_v"].Value);
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdProveedor_i"].Value);

                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["CargoContacto_nv"].Value);
                txtNroDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["CargoContacto_nv"].Value);
                txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["CargoContacto_nv"].Value);
                txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["CargoContacto_nv"].Value);
                txtCorreo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["CargoContacto_nv"].Value);
                txtClave.Text = Convert.ToString(dgvListado.CurrentRow.Cells["CargoContacto_nv"].Value);
                
                cboRol.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["IdPais_i"].Value);
                cboTipoDocumento.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["IdPais_i"].Value);

                this.NombreAnt = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre_nv"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre_nv"].Value);

                tabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione desde la celda nombre.");
            }
        }
    }
}
