using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sandchips.Models;
using Sandchips.DAL;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Sandchips.Formularios
{
    public partial class Restaurante : Form
    {
        public Restaurante()
        { 
            InitializeComponent();
        }

        private void Local_Load_1(object sender, EventArgs e)
        {
            dgvRestaurante.DataSource = DALRestaurante.mostrartabla(); 
        }

         
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form tipos_de_habitaciones = new Menu_Hotel();
            tipos_de_habitaciones.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
 
        public bool ValidarRes()
        {
            bool validar = false;
            if (txtNRC2.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false; 
                MessageBox.Show("El campo NRC es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return validar;
            } 
            if (textBox8.Text != "")
            {
                validar = true;
            }
            else
            {
                validar = false;
                MessageBox.Show("El campo nombre es requerido", "Operacón fallida", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return validar;
            }
            return validar;

        }
             
       
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        //MODIFICAR RESTAURANTE
        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (ValidarRes())
            {
                ModelRestaurante model = new ModelRestaurante();
                model.IdRestaurante = Convert.ToInt32(txtIdRestaurante.Text);
                model.NRC = txtNRC2.Text;
                model.Restaurante = textBox8.Text;
                int datos = DALRestaurante.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
                    txtIdRestaurante.Clear();
                    txtNRC2.Clear();
                    textBox8.Clear();
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            ModelRestaurante model = new ModelRestaurante();
            model.IdRestaurante = Convert.ToInt32(txtIdRestaurante.Text);
            DALRestaurante.eliminar(model);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
            txtIdRestaurante.Clear();
            txtNRC2.Clear();
            textBox8.Clear();
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgvRestaurante.DataSource = DALRestaurante.buscar(textBox8.Text);
        }

        private void dgvRestaurante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvRestaurante.CurrentRow.Index;
            txtIdRestaurante.Text = dgvRestaurante[0, pocision].Value.ToString();
            txtNRC2.Text = dgvRestaurante[2, pocision].Value.ToString();
            textBox8.Text = dgvRestaurante[1, pocision].Value.ToString();
        }

        private void txtIdRestaurante_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreRestaurante_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNRC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_hab_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvRestaurante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //Validar contraseñas que sean iguales
            if (ValidarRes())
            {
                ModelRestaurante model = new ModelRestaurante();
                model.NRC = txtNRC.Text;
                model.Restaurante = textBox8.Text;
                int datos = DALRestaurante.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
                    txtNRC.Clear();
                    textBox8.Clear();
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ModelRestaurante model = new ModelRestaurante();
            model.IdRestaurante = Convert.ToInt32(txtIdRestaurante.Text);
            DALRestaurante.eliminar(model);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
            txtIdRestaurante.Clear();
            txtNRC2.Clear();
            textBox8.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarRes())
            {
                ModelRestaurante model = new ModelRestaurante();
                model.IdRestaurante = Convert.ToInt32(txtIdRestaurante.Text);
                model.NRC = txtNRC2.Text;
                model.Restaurante = textBox8.Text;
                int datos = DALRestaurante.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
                    txtIdRestaurante.Clear();
                    txtNRC.Clear();
                    textBox8.Clear();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvRestaurante.DataSource = DALRestaurante.buscar(textBox8.Text);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Form Restaurante = new Menu_Restaurante();
            Restaurante.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            
            //Validar contraseñas que sean iguales
            if (ValidarRes())
            {
                ModelRestaurante model = new ModelRestaurante();
                model.NRC = txtNRC2.Text;
                model.Restaurante = textBox8.Text;
                int datos = DALRestaurante.agregar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
                    txtNRC2.Clear();
                    textBox8.Clear();
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

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DALRestaurante.mostrartabla();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
        {
            ModelRestaurante model = new ModelRestaurante();
            model.IdRestaurante = Convert.ToInt32(txtIdRestaurante.Text);
            DALRestaurante.eliminar(model);
            MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView2.DataSource = DALRestaurante.mostrartabla();
            textBox6.Clear();
            txtNRC2.Clear();
            textBox8.Clear();
        }
      }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
              //MODIFICAR RESTAURANTE

        {
            if (ValidarRes())
            {
                ModelRestaurante model = new ModelRestaurante();
                model.IdRestaurante = Convert.ToInt32(txtIdRestaurante.Text);
                model.NRC = txtNRC2.Text;
                model.Restaurante = textBox8.Text;
                int datos = DALRestaurante.modificar(model);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRestaurante.DataSource = DALRestaurante.mostrartabla();
                    textBox8.Clear();
                    txtNRC2.Clear();
                    textBox8.Clear();
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
      }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            txtNRC2.Text.TrimStart();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

                Chunk chunk = new Chunk("Reporte General de Restaurantes",
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
                doc.Add(new Paragraph("Reporte General de Restaurantes",
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
            PdfPTable datos = new PdfPTable(dataGridView2.ColumnCount);
            datos.DefaultCell.Padding = 3;
            float[] margenAncho = columasdatagrid(dataGridView2);
            datos.SetWidths(margenAncho);
            datos.WidthPercentage = 100;
            datos.DefaultCell.BorderWidth = 1;
            datos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dataGridView2.ColumnCount; i++)
            {
                datos.AddCell(dataGridView2.Columns[i].HeaderText);
            }
            datos.HeaderRows = 1;
            datos.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    if (dataGridView2[j, i].Value != null)
                    {
                        datos.AddCell(new Phrase(dataGridView2[j, i].Value.ToString()));
                    }
                }
                datos.CompleteRow();
            }
            document.Add(datos);
        }

        private void btnReporteR_Click(object sender, EventArgs e)
        {
            Reporte ReporteR = new Reporte();
            ReporteR.Show();
        }
    }
}

