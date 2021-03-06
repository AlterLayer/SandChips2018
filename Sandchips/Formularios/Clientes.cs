﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sandchips.Models;
using Sandchips.DAL;
using Sandchips;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Sandchips.Formularios
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = DALClientes.mostrartabla();
            Conexion.obtenerconexion();
            cmbTipoDoc.DataSource = DALUsuarios.ObtenerTipoDocumento();
            cmbTipoDoc.DisplayMember = "Documento";
            cmbTipoDoc.ValueMember = "IdTipoDocumento";
            cmbUsuario.DataSource = DALUsuarios.ObtenerTipoUsuario();
            cmbUsuario.DisplayMember = "TipoUsuario";
            cmbUsuario.ValueMember = "IdTipoUsuario";
            cmbGenero.DataSource = DALUsuarios.ObtenerGenero();
            cmbGenero.DisplayMember = "Genero";
            cmbGenero.ValueMember = "IdGenero";
            cmbTipoDoc.SelectedIndex = 0;
            cmbGenero.SelectedIndex = 0;
            cmbUsuario.SelectedIndex = 0;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

        }


        public bool ValidarPersonas()
        {
            bool validacion = false;
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtDocumento.Text != "" && mtbTelefono.Text != "" && cmbTipoDoc.SelectedIndex != 0 && cmbGenero.SelectedIndex != 0 && cmbUsuario.SelectedIndex != 0)
            {
                validacion = true;
            }
            else
            {
                validacion = false;
                MessageBox.Show("El campo nombre es requerido");
                return validacion;
            }
            return validacion;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Form Menu_H = new Menu_Hotel();
            Menu_H.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //GUARDAR CLIENTEs
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            if (ValidarPersonas())
            {
                ModelClientes agregar = new ModelClientes();
                agregar.Nombre = txtNombre.Text;
                agregar.Apellidos = txtApellido.Text;
                agregar.Documento = txtDocumento.Text;
                agregar.Telefono = mtbTelefono.Text;
                agregar.IdGenero = Convert.ToInt32(cmbGenero.SelectedIndex.ToString());
                agregar.IdUsuario = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                agregar.IdTipoDocumento = Convert.ToInt32(cmbUsuario.SelectedValue.ToString());
                int datos = DALClientes.agregar(agregar);
                if (datos > 0)
                {
                    dgvClientes.DataSource = DALClientes.mostrartabla();
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdClientes.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtDocumento.Clear();
                    cmbTipoDoc.SelectedIndex = 0;
                    txtDocumento.Clear();
                    mtbTelefono.Clear();
                    cmbGenero.SelectedIndex = 0;
                    cmbUsuario.SelectedIndex = 0; 
                }
                else
                {
                    MessageBox.Show("Registro no ingresado", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }

        //MODIFICAR CLIENTE
        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (ValidarPersonas())
            {
                ModelClientes agregar = new ModelClientes();
                agregar.IdClientes = Convert.ToInt32(txtIdClientes.Text);
                agregar.Nombre = txtNombre.Text;
                agregar.Apellidos = txtApellido.Text;
                agregar.Documento = txtDocumento.Text;
                agregar.Telefono = mtbTelefono.Text;
                agregar.IdGenero = Convert.ToInt32(cmbGenero.SelectedIndex.ToString());
                agregar.IdUsuario = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
              
                agregar.IdTipoDocumento = Convert.ToInt32(cmbUsuario.SelectedValue.ToString());
                agregar.IdClientes = agregar.IdClientes;
                int datos = DALClientes.actualizar(agregar);
                if (datos > 0)
                {
                    dgvClientes.DataSource = DALClientes.mostrartabla();
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdClientes.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtDocumento.Clear();
                    cmbTipoDoc.SelectedIndex = 0;
                    txtDocumento.Clear();
                    mtbTelefono.Clear();
                    cmbGenero.SelectedIndex = 0;
                    cmbUsuario.SelectedIndex = 0; 
                }
                else
                {
                    MessageBox.Show("Registro no modificado", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }

        //ELIMINAR CLIENTE
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                if (MessageBox.Show("¿Estas seguro de eliminar este cliente?", "Precaución!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                ModelClientes eliminar = new ModelClientes();
                eliminar.IdClientes = Convert.ToInt32(txtIdClientes.Text);
                eliminar.IdEstado = Convert.ToInt32(cmbTipoDoc.SelectedIndex.ToString());
                DALClientes.eliminar(eliminar);
                MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClientes.DataSource = DALClientes.mostrartabla();
            }
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //MOSTRAR DATOS CLIENTE
        private void dgvPersonas_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvClientes.CurrentRow.Index;
            txtIdClientes.Text = dgvClientes[0, pocision].Value.ToString();
            txtNombre.Text = dgvClientes[1, pocision].Value.ToString();
            txtApellido.Text = dgvClientes[2, pocision].Value.ToString();
            txtDocumento.Text = dgvClientes[3, pocision].Value.ToString();
            mtbTelefono.Text = dgvClientes[4, pocision].Value.ToString();
            cmbGenero.SelectedValue = Convert.ToInt32(dgvClientes[5, pocision].Value.ToString());
            cmbUsuario.SelectedValue = Convert.ToInt32(dgvClientes[7, pocision].Value.ToString());
            cmbTipoDoc.SelectedValue = Convert.ToInt32(dgvClientes[8, pocision].Value.ToString());
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        //BUSCAR CLIENTE
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgvClientes.DataSource = DALClientes.buscar(txtBuscar.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //MOSTRAR CLIENTES
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = DALClientes.mostrartabla();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void mtbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text.TrimStart();
        }

        private void cmbTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            txtApellido.Text.TrimStart();
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            txtDocumento.Text.TrimStart();
        }

        private void mtbTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtbTelefono.Text.TrimStart();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            txtBuscar.Text.TrimStart();
        }

        private void btnGuardar_MouseMove(object sender, MouseEventArgs e)
        {
            btnGuardar.BackColor = Color.Black;
            btnGuardar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.BackColor = Color.FromArgb(190, 239, 158);
        }

        private void btnActualizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnActualizar.BackColor = Color.Black;
            btnActualizar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnActualizar_MouseLeave(object sender, EventArgs e)
        {
            btnActualizar.ForeColor = Color.Black;
            btnActualizar.BackColor = Color.FromArgb(190, 239, 158);
        }

        private void btnEliminar_MouseMove(object sender, MouseEventArgs e)
        {
            btnEliminar.BackColor = Color.Black;
            btnEliminar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.ForeColor = Color.Black;
            btnEliminar.BackColor = Color.FromArgb(190, 239, 158);
        }

        private void btnMostrar_MouseMove(object sender, MouseEventArgs e)
        {
            btnMostrar.BackColor = Color.Black;
            btnMostrar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnMostrar_MouseLeave(object sender, EventArgs e)
        {
            btnMostrar.ForeColor = Color.Black;
            btnMostrar.BackColor = Color.FromArgb(190, 239, 158);

        }

        private void btnBuscar_MouseMove(object sender, MouseEventArgs e)
        {
            btnBuscar.BackColor = Color.Black;
            btnBuscar.ForeColor = Color.FromArgb(190, 239, 158);
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            btnBuscar.BackColor = Color.FromArgb(190, 239, 158);
            btnBuscar.ForeColor = Color.Black;
        }

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            cmbGenero.SelectedIndex = 0;
            cmbTipoDoc.SelectedIndex = 0;
            mtbTelefono.Text = "";
            cmbUsuario.SelectedIndex = 0;
            txtIdClientes.Text = "";
            txtDocumento.Text = "";
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
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

                Chunk chunk = new Chunk("Reporte General de Clientes",
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
                doc.Add(new Paragraph("Reporte General de Clientes",
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
            PdfPTable datos = new PdfPTable(dgvClientes.ColumnCount);
            datos.DefaultCell.Padding = 3;
            float[] margenAncho = columasdatagrid(dgvClientes);
            datos.SetWidths(margenAncho);
            datos.WidthPercentage = 100;
            datos.DefaultCell.BorderWidth = 1;
            datos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dgvClientes.ColumnCount; i++)
            {
                datos.AddCell(dgvClientes.Columns[i].HeaderText);
            }
            datos.HeaderRows = 1;
            datos.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dgvClientes.Rows.Count; i++)
            {
                for (j = 0; j < dgvClientes.Columns.Count; j++)
                {
                    if (dgvClientes[j, i].Value != null)
                    {
                        datos.AddCell(new Phrase(dgvClientes[j, i].Value.ToString()));
                    }
                }
                datos.CompleteRow();
            }
            document.Add(datos);
        }

        private void btnReporteC_Click(object sender, EventArgs e)
        {
            Reporte ReporteC = new Reporte();
            ReporteC.Show();
        }
    }
}
