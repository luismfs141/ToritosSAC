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
    public partial class FrmModelo : Form
    {
        //Variables
        private string NombreAnt;

        public FrmModelo()
        {
            InitializeComponent();
        }

        private void FrmModelo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarMarca();
            this.CargarTipo();
        }

        //Métodos básicos
        private void Listar()
        {
            try
            {
                dgvListado.DataSource = BLModelo.Listar();
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
                dgvListado.DataSource = BLModelo.Buscar(txtBuscar.Text);
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
            txtNombre.Clear();
            txtId.Clear();
            txtPrecio.Clear();
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

            dgvListado.Columns[2].HeaderText = "Modelo";
            dgvListado.Columns[2].Width = 100;

            dgvListado.Columns[3].HeaderText = "Id Marca";
            dgvListado.Columns[3].Width = 50;
            dgvListado.Columns[3].Visible = false;

            dgvListado.Columns[4].HeaderText = "Marca";
            dgvListado.Columns[4].Width = 100;

            dgvListado.Columns[5].HeaderText = "Abr. Tipo";
            dgvListado.Columns[5].Width = 50;
            dgvListado.Columns[5].Visible = false;

            dgvListado.Columns[6].HeaderText = "Tipo";
            dgvListado.Columns[6].Width = 100;

            dgvListado.Columns[7].HeaderText = "Precio";
            dgvListado.Columns[7].Width = 100;

            dgvListado.Columns[8].HeaderText = "Abr. Estado";
            dgvListado.Columns[8].Width = 50;
            dgvListado.Columns[8].Visible = false;

            dgvListado.Columns[9].HeaderText = "Estado";
            dgvListado.Columns[9].Width = 100;

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

        private void CargarMarca()
        {
            try
            {
                cboMarca.DataSource = BLModelo.SeleccionarMarca();
                cboMarca.ValueMember = "IdMarca_i";
                cboMarca.DisplayMember = "Nombre_nv";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CargarTipo()
        {
            try
            {
                cboTipo.DataSource = BLModelo.SeleccionarTipoModelo();
                cboTipo.ValueMember = "Abreviatura_c";
                cboTipo.DisplayMember = "Descripcion_vc";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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
                if (txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(txtPrecio, "Ingrese un precio");
                }
                else
                {
                    Rpta = BLModelo.Insertar(Convert.ToInt32(cboMarca.SelectedValue), txtNombre.Text.Trim(), Convert.ToString(cboTipo.SelectedValue), Convert.ToDecimal(txtPrecio.Text.Trim()));
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
                if (txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(txtPrecio, "Ingrese un precio");
                }
                else
                {
                    Rpta = BLModelo.Actualizar(Convert.ToInt32(txtId.Text), Convert.ToInt32(cboMarca.SelectedValue), this.NombreAnt, txtNombre.Text.Trim(), Convert.ToString(cboTipo.SelectedValue), Convert.ToDecimal(txtPrecio.Text.Trim()));
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó de forma correcta el registro");
                        lblTitulo.Text="Registrar nuevo modelo";
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
                            Rpta = BLModelo.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó el registro: " + Convert.ToString(row.Cells[2].Value));
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
            lblTitulo.Text = "Registrar nuevo modelo";
            Limpiar();
            tabGeneral.SelectedIndex = 0;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas desactivar el(los) registro(s)?", "Modelo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = BLModelo.Desactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se desactivó el registro: " + Convert.ToString(row.Cells[2].Value));
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
                Opcion = MessageBox.Show("Realmente deseas activar el(los) registro(s)?", "Modelo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = BLModelo.Activar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se activó el registro: " + Convert.ToString(row.Cells[2].Value));
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
            lblTitulo.Text = "Actualizar datos de Modelo: " + Convert.ToString(dgvListado.CurrentRow.Cells["Nombre_nv"].Value);
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdModeloVehiculo_i"].Value);
                cboMarca.SelectedValue = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdMarca_i"].Value);
                cboTipo.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["Tipo_c"].Value);
                txtPrecio.Text = Convert.ToString(dgvListado.CurrentRow.Cells["PrecioUnidadVehiculo_m"].Value);

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
