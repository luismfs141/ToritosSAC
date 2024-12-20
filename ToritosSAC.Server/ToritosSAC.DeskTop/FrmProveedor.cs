﻿using System;
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
        //Variables
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


        //Métodos básicos
        private void Listar()
        {
            try
            {
                dgvListado.DataSource = BLProveedor.Listar();
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
                dgvListado.DataSource = BLProveedor.Buscar(txtBuscar.Text);
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
            txtCargo.Clear();
            txtContacto.Clear();
            txtDireccion.Clear();
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
                            Rpta = BLProveedor.Eliminar(Codigo);

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
            lblTitulo.Text = "Registrar nuevo proveedor";
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
                            Rpta = BLProveedor.Desactivar(Codigo);

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
                            Rpta = BLProveedor.Activar(Codigo);

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


        //Eventos
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
            lblTitulo.Text = "Actualizar datos de proveedor: "+ Convert.ToString(dgvListado.CurrentRow.Cells["Nombre_nv"].Value); 
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdProveedor_i"].Value);
                txtCargo.Text = Convert.ToString(dgvListado.CurrentRow.Cells["CargoContacto_nv"].Value);
                txtContacto.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Contacto_v"].Value);
                //string idPais = Convert.ToString(dgvListado.CurrentRow.Cells["IdPais_i"].Value);
                cboPais.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["IdPais_i"].Value);

                txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion_nv"].Value);

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
