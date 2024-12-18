using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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
        private string CorreoAnt;
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
                //this.Formato();
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
            dgvListado.Columns[1].Width = 40;

            dgvListado.Columns[2].HeaderText = "IdRol";
            dgvListado.Columns[2].Width = 50;
            dgvListado.Columns[2].Visible = false;

            dgvListado.Columns[3].HeaderText = "Nombre";
            dgvListado.Columns[3].Width = 100;

            dgvListado.Columns[4].HeaderText = "Rol";
            dgvListado.Columns[4].Width = 100;

            dgvListado.Columns[5].HeaderText = "Abr. Tipo documento";
            dgvListado.Columns[5].Width = 150;
            dgvListado.Columns[5].Visible = false;

            dgvListado.Columns[6].HeaderText = "Nro documento";
            dgvListado.Columns[6].Width = 80;

            dgvListado.Columns[7].HeaderText = "Dirección";
            dgvListado.Columns[7].Width = 120;

            dgvListado.Columns[8].HeaderText = "Contacto";
            dgvListado.Columns[8].Width = 70;

            dgvListado.Columns[9].HeaderText = "Correo";
            dgvListado.Columns[9].Width = 120;

            dgvListado.Columns[10].HeaderText = "Abr. Estado";
            dgvListado.Columns[10].Width = 40;
            dgvListado.Columns[10].Visible = false;

            //dgvListado.Columns[11].HeaderText = "Estado";
            //dgvListado.Columns[11].Width = 80;

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
                    txtTelefono.Text == string.Empty || 
                    txtCorreo.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(txtNroDocumento, "Ingrese un numero número de documento.");
                    ErrorIcono.SetError(txtDireccion, "Ingrese una dirección.");
                    ErrorIcono.SetError(txtTelefono, "Ingrese un teléfono válido.");
                    ErrorIcono.SetError(txtCorreo, "Ingrese un correo válido.");
                }
                else
                {
                    Rpta = BLUsuario.Insertar(Convert.ToInt32(cboRol.SelectedValue), txtNombre.Text.Trim(),Convert.ToString(cboTipoDocumento.SelectedValue), txtNroDocumento.Text.Trim(), txtDireccion.Text.Trim(),txtTelefono.Text.Trim(), txtCorreo.Text.Trim(),txtClave.Text.Trim());

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
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty ||
                    txtNroDocumento.Text == string.Empty ||
                    txtDireccion.Text == string.Empty ||
                    txtTelefono.Text == string.Empty ||
                    txtCorreo.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(txtNroDocumento, "Ingrese un numero número de documento.");
                    ErrorIcono.SetError(txtDireccion, "Ingrese una dirección.");
                    ErrorIcono.SetError(txtTelefono, "Ingrese un teléfono válido.");
                    ErrorIcono.SetError(txtCorreo, "Ingrese un correo válido.");
                }
                else
                {
                    Rpta = BLUsuario.Actualizar(Convert.ToInt32(txtId.Text.Trim()), Convert.ToInt32(cboRol.SelectedValue), txtNombre.Text.Trim(), Convert.ToString(cboTipoDocumento.SelectedValue), txtNroDocumento.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtCorreo.Text.Trim(), txtCorreo.Text.Trim(), txtClave.Text.Trim());

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó de forma correcta el registro");
                        lblTitulo.Text = "Registrar nuevo proveedor";
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
                this.MensajeError(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas eliminar el(los) registro(s)?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = BLUsuario.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó el registro: " + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lblTitulo.Text = "Registrar nuevo usuario";
            Limpiar();
            tabGeneral.SelectedIndex = 0;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas desactivar el(los) registro(s)?", "Proveedores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = BLUsuario.Desactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se desactivó el registro: " + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas activar el(los) registro(s)?", "Proveedores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = BLUsuario.Activar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se activó el registro: " + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
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
            //lblTitulo.Text = "Actualizar datos de usuario: " + Convert.ToString(dgvListado.CurrentRow.Cells["Nombre_v"].Value);
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["ID"].Value);
                cboRol.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["IdRol_i"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                this.NombreAnt = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                cboTipoDocumento.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
                txtNroDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Num_Documento"].Value);
                txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
                txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Telefono"].Value);
                txtCorreo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Correo"].Value);

                tabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione desde la celda nombre.");
            }
        }
    }
}
