using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sandchips.DAL;
using Sandchips.Models;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Sandchips.Formularios
{
    public partial class Tipo_Habitaciones : Form
    {
        public Tipo_Habitaciones()
        { 
            InitializeComponent();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Habitaciones_Load_1(object sender, EventArgs e)
        {
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
            Conexion.obtenerconexion();
            btnEliminarT.Enabled = false;
            btnModificarT.Enabled = false;
            btnModificarT.Enabled = false;
            btnEliminarT.Enabled = false;

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Form Chequeo_habitaciones = new Tiempo_de_estadia();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Form Usuarios = new Usuarios();
            Usuarios.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form Chequeo_habitaciones = new Habitaciones();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Chequeo_habitaciones = new inicio();
            Chequeo_habitaciones.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Form1 = new Clientes();
            Form1.Show();
            this.Hide();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoEspacios.SoloEspacios(e);
        }

        private void btnAgregarT_Click(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                //Validar contraseñas que sean iguales
                if (ValidarHabT())
                {
                    ModelTipoHabitacion model = new ModelTipoHabitacion();
                    model.TipoHabitacion = txtTipoHabitacion.Text;
                    int datos = DALTipoHabitaciones.agregar(model);
                    if (datos > 0)
                    {
                        MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
                        txtTipoHabitacion.Clear();
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

        private bool ValidarHabT()
        {
            throw new NotImplementedException();
        }

        private void btnModificarT_Click(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                if (ValidarHabT())
                {
                    ModelTipoHabitacion model = new ModelTipoHabitacion();
                    model.IdTipoHabitacion = Convert.ToInt32(txtIdTipoHabitacion.Text);
                    model.TipoHabitacion = txtTipoHabitacion.Text;
                    int datos = DALTipoHabitaciones.modificar(model);
                    if (datos > 0)
                    {
                        MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
                        txtTipoHabitacion.Clear();
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

        private void btnEliminarT_Click(object sender, EventArgs e)
        {
            if (ModelPermiso.TipoUsuarioP != "Empleado")
            {
                if (MessageBox.Show("¿Estas seguro de eliminar este cliente?", "Precaución!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
                DALTipoHabitaciones.eliminar(Convert.ToInt32(txtIdTipoHabitacion.Text));
                MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
            }
            else
            {
                MessageBox.Show("No posee los permisos para completar la acción", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarT_Click(object sender, EventArgs e)
        {
            dgvTipoHabitacion.DataSource = DALTipoHabitaciones.mostrartabla();
        }

        private void btnBuscarT_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tipo_Habitaciones_Load(object sender, EventArgs e)
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

                Chunk chunk = new Chunk("Reporte General de Tipos de Habitaciones",
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
                doc.Add(new Paragraph("Reporte General de Tipos de Habitaciones",
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
            PdfPTable datos = new PdfPTable(dgvTipoHabitacion.ColumnCount);
            datos.DefaultCell.Padding = 3;
            float[] margenAncho = columasdatagrid(dgvTipoHabitacion);
            datos.SetWidths(margenAncho);
            datos.WidthPercentage = 100;
            datos.DefaultCell.BorderWidth = 1;
            datos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dgvTipoHabitacion.ColumnCount; i++)
            {
                datos.AddCell(dgvTipoHabitacion.Columns[i].HeaderText);
            }
            datos.HeaderRows = 1;
            datos.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dgvTipoHabitacion.Rows.Count; i++)
            {
                for (j = 0; j < dgvTipoHabitacion.Columns.Count; j++)
                {
                    if (dgvTipoHabitacion[j, i].Value != null)
                    {
                        datos.AddCell(new Phrase(dgvTipoHabitacion[j, i].Value.ToString()));
                    }
                }
                datos.CompleteRow();
            }
            document.Add(datos);
        }
        private void btnReporteTH_Click(object sender, EventArgs e)
        {
            Reporte ReporteTH = new Reporte();
            ReporteTH.Show();
        }
    }
}
