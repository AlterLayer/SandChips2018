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
    }
}

