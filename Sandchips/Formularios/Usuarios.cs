using Sandchips.DAL;
using Sandchips.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Sandchips.Formularios
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Chequeo_Mesa = new Menu_Hotel();
            Chequeo_Mesa.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }



        private string HassPassword(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // Convertimos los valores en hexadecimal, cuando tiene una cifra hay que rellenarlo con cero para que siempre ocupen dos dígitos.
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            //Devolvemos la cadena con el hash en mayúsculas
            return sb.ToString().ToUpper();
        }

        public bool ValidarUsu()
        {
            bool validar = false;
            if (txtusuario.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo usuario es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (mtbcontrasena.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo contraseña es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (mtbconfirmcontrasena.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo confirmar contraseña es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (mtbconfirmcontrasena.Text == mtbcontrasena.Text)
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("Las contraseñas no coinciden", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            if (cmbTipoDocumento.SelectedIndex > 0)
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo tipo usuario es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            }
            return validar;
        }

        private void Usuarios_LocationChanged(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            dgvusuarios.DataSource = DALUsuarios.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipoDocumento.DataSource = DALUsuarios.ObtenerTipoDocumento();
            cmbTipoDocumento.DisplayMember = "Documento";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoUsuario.DataSource = DALUsuarios.ObtenerTipoUsuario();
            cmbTipoUsuario.DisplayMember = "TipoUsuario";
            cmbTipoUsuario.ValueMember = "IdTipoUsuario";
            cmbGenero.DataSource = DALUsuarios.ObtenerGenero();
            cmbGenero.DisplayMember = "Genero";
            cmbGenero.ValueMember = "IdGenero";
            cmbTipoUsuario.SelectedIndex = 0;
            cmbTipoDocumento.SelectedIndex = 0;
            cmbGenero.SelectedIndex = 0;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void dgvusuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvusuarios.CurrentRow.Index;
            txtIdUsuario.Text = dgvusuarios[0, pocision].Value.ToString();
            txtusuario.Text = dgvusuarios[1, pocision].Value.ToString();
            mtbcontrasena.Text = dgvusuarios[2, pocision].Value.ToString();
            mtbconfirmcontrasena.Text = dgvusuarios[2, pocision].Value.ToString();
            txtNombre.Text = dgvusuarios[3, pocision].Value.ToString();
            txtApellidos.Text = dgvusuarios[4, pocision].Value.ToString();
            txtCorreo.Text = dgvusuarios[5, pocision].Value.ToString();
            txtNumeroDocumento.Text = dgvusuarios[6, pocision].Value.ToString();
            txtDireccion.Text = dgvusuarios[7, pocision].Value.ToString();
            mtbTelefono.Text = dgvusuarios[8, pocision].Value.ToString();
            dtpNacimiento.Value = Convert.ToDateTime(dgvusuarios[9, pocision].Value);
            cmbTipoDocumento.SelectedValue = Convert.ToInt32(dgvusuarios[10, pocision].Value.ToString());
            cmbGenero.SelectedValue = Convert.ToInt32(dgvusuarios[11, pocision].Value.ToString());
            cmbTipoUsuario.SelectedValue = Convert.ToInt32(dgvusuarios[13, pocision].Value.ToString());
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = true;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            dgvusuarios.DataSource = DALUsuarios.mostrartabla();
        }

        //GUARDAR USUARIO
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                //Validar contraseñas que sean iguales
                if (ValidarUsu())
                {
                    ModelUsuario model = new ModelUsuario();
                    model.Usuario = txtusuario.Text;
                    model.Clave = HassPassword(mtbcontrasena.Text);
                    model.Nombre = txtNombre.Text;
                    model.Apellidos = txtApellidos.Text;
                    model.Correo = txtCorreo.Text;
                    model.NumeroDocumento = txtNumeroDocumento.Text;
                    model.Direccion = txtDireccion.Text;
                    model.Telefono = mtbTelefono.Text;
                    var fecN = dtpNacimiento.Text.Split('/')[2] + "-" + dtpNacimiento.Text.Split('/')[1] + "-" + dtpNacimiento.Text.Split('/')[0];
                    model.Nacimiento = fecN;
                    model.IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue);
                    model.IdTipoUsuarios = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                    model.IdGenero = Convert.ToInt32(cmbGenero.SelectedValue);
                    int datos = DALUsuarios.agregarusuario(model);
                    if (datos > 0)
                    {
                        MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvusuarios.DataSource = DALUsuarios.mostrartabla();
                        txtusuario.Clear();
                        mtbcontrasena.Clear();
                        mtbconfirmcontrasena.Clear();
                        cmbGenero.SelectedIndex = 0;
                        cmbTipoUsuario.SelectedIndex = 0;
                        cmbTipoDocumento.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("Registro no ingresado", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //MessageBox.Show("", "Operacón fallida", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                //Validar contraseñas que sean iguales
                if (ValidarUsu())
                {
                    ModelUsuario model = new ModelUsuario();
                    model.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    model.Usuario = txtusuario.Text;
                    model.Clave = HassPassword(mtbcontrasena.Text);
                    model.Nombre = txtNombre.Text;
                    model.Apellidos = txtApellidos.Text;
                    model.Correo = txtCorreo.Text;
                    model.NumeroDocumento = txtNumeroDocumento.Text;
                    model.Direccion = txtDireccion.Text;
                    model.Telefono = mtbTelefono.Text;
                    var fecN = dtpNacimiento.Text.Split('/')[2] + "-" + dtpNacimiento.Text.Split('/')[1] + "-" + dtpNacimiento.Text.Split('/')[0];
                    model.Nacimiento = fecN;
                    model.IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue);
                    model.IdTipoUsuarios = Convert.ToInt32(cmbTipoUsuario.SelectedValue);
                    model.IdGenero = Convert.ToInt32(cmbGenero.SelectedValue);
                    int datos = DALUsuarios.actualizar(model);
                    if (datos > 0)
                    {
                        MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvusuarios.DataSource = DALUsuarios.mostrartabla();
                        txtusuario.Clear();
                        mtbcontrasena.Clear();
                        mtbconfirmcontrasena.Clear();
                        cmbGenero.SelectedIndex = 0;
                        cmbTipoUsuario.SelectedIndex = 0;
                        cmbTipoDocumento.SelectedIndex = 0;

                    }
                    else
                    {
                        MessageBox.Show("Registro no modificado", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //MessageBox.Show("", "Operacón fallida", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                if (MessageBox.Show("¿Estas seguro de eliminar este cliente?", "Precaución!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
                DALUsuarios.eliminar(Convert.ToInt32(txtIdUsuario.Text));
                MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvusuarios.DataSource = DALUsuarios.mostrartabla();

            }
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtbcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtbconfirmcontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Correo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {
            txtusuario.Text.TrimStart();
        }

        private void cmbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbTipoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbcontrasena_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtbcontrasena.Text.TrimStart();
        }

        private void mtbconfirmcontrasena_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtbconfirmcontrasena.Text.TrimStart();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text.TrimStart();
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            txtApellidos.Text.TrimStart();
        }

        private void Correo_TextChanged(object sender, EventArgs e)
        {
            txtCorreo.Text.TrimStart();
        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            txtNumeroDocumento.Text.TrimStart();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.Text.TrimStart();
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            btnModificar.BackColor = Color.FromArgb(190, 239, 158);
            btnModificar.ForeColor = Color.Black;
        }

        private void btnModificar_MouseMove(object sender, MouseEventArgs e)
        {
            btnModificar.BackColor = Color.Black;
            btnModificar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.FromArgb(190, 239, 158);
            btnGuardar.ForeColor = Color.Black;
        }

        private void btnGuardar_MouseMove(object sender, MouseEventArgs e)
        {
            btnGuardar.BackColor = Color.Black;
            btnGuardar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnEliminar_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminar.BackColor = Color.Black;
            btnEliminar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.FromArgb(190, 239, 158);
            btnEliminar.ForeColor = Color.Black;
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancelar.BackColor = Color.Black;
            btnCancelar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(190, 239, 158);
            btnCancelar.ForeColor = Color.Black;
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnlimpiiar_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            mtbconfirmcontrasena.Text = "";
            mtbcontrasena.Text = "";
            txtusuario.Text = "";
            txtNumeroDocumento.Text = "";
            mtbTelefono.Text = "";
            cmbTipoDocumento.SelectedIndex = 0;
            cmbTipoUsuario.SelectedIndex = 0;
            dtpNacimiento.Text = "";
            cmbGenero.SelectedIndex = 0;
            dtpNacimiento.Text = "";
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crearPDF()
        {
            Document doc = new Document(PageSize.LETTER.Rotate(), 10, 10, 10, 10);
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = "@C";
            save.Title = "Guardar Reporte";
            save.DefaultExt = "pdf";
            save.Filter = "pdf Files (*.pdf)|*.pdf| All files (*.*)|*.*";
            save.FilterIndex = 2;
            save.RestoreDirectory = true;
            string nombreArchivo = "";
            if (save.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = save.FileName;
            }
            if (nombreArchivo.Trim() != "")
            {
                FileStream file = new FileStream(nombreArchivo,
                                                FileMode.OpenOrCreate,
                                                FileAccess.ReadWrite,
                                                FileShare.ReadWrite);
                PdfWriter.GetInstance(doc, file);
                doc.Open();
                string remitente = "Sandchip's Hotel & Restaurant";
                string envio = "Fecha:" + DateTime.Now.ToString();

                Chunk chunk = new Chunk("Reporte General de Usuarios",
                    FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD));
                doc.Add(new Paragraph(chunk));
                doc.Add(new Paragraph("             "));
                doc.Add(new Paragraph("             "));
                doc.Add(new Paragraph("---------------------------------------------------------"));
                doc.Add(new Paragraph("Reporte de Usuarios"));
                doc.Add(new Paragraph(remitente));
                doc.Add(new Paragraph(envio));
                doc.Add(new Paragraph("---------------------------------------------------------"));
                doc.Add(new Paragraph("             "));
                doc.Add(new Paragraph("             "));
                reporte(doc);
                doc.AddCreationDate();
                doc.Add(new Paragraph("Reporte General de Usuarios",
                    FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                doc.Add(new Paragraph("Firma: Sandchip's Hotel & Restaurant",
                    FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                doc.Close();
                Process.Start(nombreArchivo);
            }
        }


        public float[] columasdatagrid(DataGridView dg)
        {
            //Declarando un objeto(vector) de tipo flotante que contara
            //las columnas de un objeto DataGridView
            float[] values = new float[dg.ColumnCount];
            //Evaluar el numero de columnas
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            //Retorno el numero de Columnas
            return values;
        }


        public void reporte(Document document)
        {
            int i, j;
            PdfPTable datos = new PdfPTable(dgvusuarios.ColumnCount);
            datos.DefaultCell.Padding = 3;
            float[] margenAncho = columasdatagrid(dgvusuarios);
            datos.SetWidths(margenAncho);
            datos.WidthPercentage = 100;
            datos.DefaultCell.BorderWidth = 1;
            datos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dgvusuarios.ColumnCount; i++)
            {
                datos.AddCell(dgvusuarios.Columns[i].HeaderText);
            }
            datos.HeaderRows = 1;
            datos.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dgvusuarios.Rows.Count; i++)
            {
                for (j = 0; j < dgvusuarios.Columns.Count; j++)
                {
                    if (dgvusuarios[j, i].Value != null)
                    {
                        datos.AddCell(new Phrase(dgvusuarios[j, i].Value.ToString()));
                    }
                }
                datos.CompleteRow();
            }
            document.Add(datos);
        }


        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte ReporteU = new Reporte();
            ReporteU.Show();
        }
    }
}
