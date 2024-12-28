using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToritosSAC.BusinessLogic;

namespace ToritosSAC.DeskTop
{
    public partial class FrmGrupo : Form
    {
        private byte[] deserializedDNI;
        private byte[] deserializedAntecedentes;
        private byte[] deserializedRecibo;
        private string nombreDescarga = "";
        TabPage hiddenTabPage;

        private string EstDNI = "";
        private string EstAntecedente = "";
        private string EstRecibo = "";



        public FrmGrupo()
        {
            InitializeComponent();
        }

        private void FrmGrupo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.OculatarTab(1);
            btnAprobarMiembro.Enabled = false;

        }


        //Métodos básicos
        private void Listar()
        {
            try
            {
                dgvListado.DataSource = BLGrupo.Listar();
                this.Formato();
                //this.Limpiar();
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
                dgvListado.DataSource = BLGrupo.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotal.Text = "Total registros: " + Convert.ToString(dgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void Formato()
        {
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns[0].Width = 50;

            dgvListado.Columns[1].HeaderText = "IdGrupo";
            dgvListado.Columns[1].Width = 50;
            dgvListado.Columns[1].Visible = false;

            dgvListado.Columns[2].HeaderText = "Codigo grupo";
            dgvListado.Columns[2].Width = 100;

            dgvListado.Columns[3].HeaderText = "IdCliente";
            dgvListado.Columns[3].Width = 50;
            dgvListado.Columns[3].Visible = false;

            dgvListado.Columns[4].HeaderText = "Cliente";
            dgvListado.Columns[4].Width = 200;

            dgvListado.Columns[5].HeaderText = "IdDocumentos";
            dgvListado.Columns[5].Width = 100;



            dgvListado.Columns[6].HeaderText = "EstadoDNI";
            dgvListado.Columns[6].Width = 50;
            dgvListado.Columns[6].Visible = false;

            dgvListado.Columns[7].HeaderText = "DNI";
            dgvListado.Columns[7].Width = 100;

            dgvListado.Columns[8].HeaderText = "RelevanciaDNI";
            dgvListado.Columns[8].Width = 50;
            dgvListado.Columns[8].Visible = false;




            dgvListado.Columns[9].HeaderText = "Estado Antecedentes";
            dgvListado.Columns[9].Width = 50;
            dgvListado.Columns[9].Visible = false;

            dgvListado.Columns[10].HeaderText = "Antecedentes penales";
            dgvListado.Columns[10].Width = 100;

            dgvListado.Columns[11].HeaderText = "Relevancia Antecedentes";
            dgvListado.Columns[11].Width = 50;
            dgvListado.Columns[11].Visible = false;



            dgvListado.Columns[12].HeaderText = "Estado Recibo";
            dgvListado.Columns[12].Width = 50;
            dgvListado.Columns[12].Visible = false;

            dgvListado.Columns[13].HeaderText = "Recibo de Luz o Agua";
            dgvListado.Columns[13].Width = 100;

            dgvListado.Columns[14].HeaderText = "Relevancia Recibo";
            dgvListado.Columns[14].Width = 50;
            dgvListado.Columns[14].Visible = false;



            dgvListado.Columns[15].HeaderText = "Estado general";
            dgvListado.Columns[15].Width = 50;
            dgvListado.Columns[15].Visible = false;

            dgvListado.Columns[16].HeaderText = "Estado general";
            dgvListado.Columns[16].Width = 100;

            dgvListado.Columns[17].Visible = false;
            dgvListado.Columns[18].Visible = false;
            dgvListado.Columns[19].Visible = false;




        }

        private void Limpiar()
        {
            txtId.Clear();
            txtRow.Clear();
            txtBuscar.Clear();
            
            ErrorIcono.Clear();

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

        private void CargarImagen()
        {
            try
            {
                if (deserializedDNI != null && deserializedDNI.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(deserializedDNI))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos del DNI no son válidos o están vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen del DNI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (deserializedAntecedentes != null && deserializedAntecedentes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(deserializedAntecedentes))
                    {
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos de los antecedentes no son válidos o están vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los antecedentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (deserializedRecibo != null && deserializedRecibo.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(deserializedRecibo))
                    {
                        pictureBox3.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos del Recibo no son válidos o están vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen del recibo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] HexStringToByteArray(string hex)
        {
            if (hex.StartsWith("0x"))
                hex = hex.Substring(2);

            return Enumerable.Range(0, hex.Length / 2)
                .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                .ToArray();
        }

        private byte[] ConvertHexStringToByteArray(string hexString)
        {
            hexString = hexString.Replace("0x", "").Replace(",", "").Replace("\n", "").Replace("\r", "");
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
        private void OculatarTab(int index)
        {
            if (index < tabGeneral.TabPages.Count && index >= 0)
            {
                hiddenTabPage = tabGeneral.TabPages[index];
                tabGeneral.TabPages.Remove(hiddenTabPage);
            }
        }
        private void MostrarTab(int index)
        {
            if (hiddenTabPage != null)
            {
                tabGeneral.TabPages.Insert(index, hiddenTabPage);
                hiddenTabPage = null;
            }
        }
        private void ActualizarEstado()
        {
            try
            {
                int rowIndex = int.Parse(txtRow.Text);

                DataGridViewRow row = dgvListado.Rows[rowIndex];

                EstDNI = Convert.ToString(row.Cells[6].Value);
                EstAntecedente = Convert.ToString(row.Cells[9].Value);
                EstRecibo = Convert.ToString(row.Cells[12].Value);

                lblEstadoDNI.Text = "Estado actual: " + Convert.ToString(row.Cells[7].Value);
                lblEstadoAntecedentes.Text = "Estado actual: " + Convert.ToString(row.Cells[10].Value);
                lblEstadoRecibo.Text = "Estado actual: " + Convert.ToString(row.Cells[13].Value);

                if (EstDNI == "A" && EstAntecedente == "A" && EstRecibo == "A")
                {
                    btnAprobarMiembro.Enabled = true;
                }
                else
                {
                    btnAprobarMiembro.Enabled = false;
                }


            }
            catch (Exception ex)
            {
                // Manejar posibles errores, como valores inválidos en txtRow
                MessageBox.Show("Error al actualizar los estados: " + ex.Message);
            }
        }


        //Eventos
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
            this.MostrarTab(1);
            lblTitulo.Text = "Actualizar estados de documentos: " + Convert.ToString(dgvListado.CurrentRow.Cells[4].Value);
            try
            {
                //this.Limpiar();
                //txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["IdDocumento_i"].Value);
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells[5].Value);


                lblEstadoDNI.Text = "Estado actual: " + Convert.ToString(dgvListado.CurrentRow.Cells[7].Value);
                lblEstadoRecibo.Text = "Estado actual: " + Convert.ToString(dgvListado.CurrentRow.Cells[13].Value);
                lblEstadoAntecedentes.Text = "Estado actual: " + Convert.ToString(dgvListado.CurrentRow.Cells[10].Value);
                

                txtRow.Text = e.RowIndex.ToString();

                // Deserializar datos de las celdas que contienen arreglos de bytes
                deserializedDNI = (byte[])dgvListado.CurrentRow.Cells[17].Value;
                deserializedRecibo = (byte[])dgvListado.CurrentRow.Cells[18].Value;
                deserializedAntecedentes = (byte[])dgvListado.CurrentRow.Cells[19].Value;

                nombreDescarga = Convert.ToString(dgvListado.CurrentRow.Cells[4].Value);
                btnAprobarMiembro.Text = "Aprobar a " + nombreDescarga;
                tabGeneral.SelectedIndex = 1;
                this.CargarImagen();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione desde la celda nombre.");
            }
        }

        

        //BOTONES
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Buscar();
                //this.Limpiar();
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void btnAprobarDNI_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas aprobar el registro?", "DNI", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.AprobarDNI(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se aprobó el DNI");

                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }
        private void btnRechazarDNI_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas rechazar el registro?", "DNI", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.RechazarDNI(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se rechazó el DNI");

                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }
        private void btnObservarDNI_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas rechazar el registro?", "DNI", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.ObservarDNI(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se observó el DNI");

                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void btnAprobarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas aprobar el registro?", "Recibo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.AprobarRecibo(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se aprobó el Recibo");

                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }
        private void btnRechazarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas rechazar el registro?", "Recibo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.RechazarRecibo(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se rechazó el Recibo");
                        ActualizarEstado();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }
        private void btnObservarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas rechazar el registro?", "Recibo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.ObservarRecibo(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se observó el Recibo");
                        ActualizarEstado();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void btnAprobarAntecedentes_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas aprobar el registro?", "Antecedentes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.AprobarAntecedentes(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se aprobaron los Antecedentes");
                        ActualizarEstado();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }
        private void btnRechazarAntecedentes_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas rechazar el registro?", "Antecedentes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.RechazarAntecedentes(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se rechazaron los antecedentes");
                        ActualizarEstado();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }
        private void btnObservarAntecedentes_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas rechazar el registro?", "Antecedentes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.ObservarAntecedentes(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se observaron los antecedentes");
                        ActualizarEstado();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }


                    this.Listar();
                    this.ActualizarEstado();
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }

        private void btnDescargarDNI_Click(object sender, EventArgs e)
        {
            try
            {
                if (deserializedDNI != null && deserializedDNI.Length > 0)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Imagen JPG|*.jpg";
                        saveFileDialog.Title = "Guardar archivo DNI";
                        saveFileDialog.FileName = "DNI_" + nombreDescarga + ".jpg";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, deserializedDNI);

                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos válidos del DNI para descargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDescargarAntecedentes_Click(object sender, EventArgs e)
        {
            try
            {
                if (deserializedAntecedentes != null && deserializedAntecedentes.Length > 0)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Imagen JPG|*.jpg";
                        saveFileDialog.Title = "Guardar archivo Antecedentes";
                        saveFileDialog.FileName = "Antecedente_" + nombreDescarga + ".jpg";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, deserializedAntecedentes);

                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos válidos del Antecedente para descargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDescargarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los datos del DNI no sean nulos
                if (deserializedRecibo != null && deserializedRecibo.Length > 0)
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Imagen JPG|*.jpg";
                        saveFileDialog.Title = "Guardar archivo Recibo";
                        saveFileDialog.FileName = "Recibo_" + nombreDescarga + ".jpg";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, deserializedRecibo);

                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay datos válidos del antecedente para descargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.OculatarTab(1);
            //Limpiar();
            tabGeneral.SelectedIndex = 0;
        }

        private void btnAprobarMiembro_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas aprobar el registro?", "Antecedentes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //Codigo = Convert.ToInt32(row.Cells[5].Value);
                    Codigo = Convert.ToInt32(txtId.Text);
                    Rpta = BLDocumento.Aprobar(Codigo);

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se aprobaron los Antecedentes");
                        ActualizarEstado();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                    this.Listar();
                    tabGeneral.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.MensajeError(ex.Message);
            }
        }
    }
}
