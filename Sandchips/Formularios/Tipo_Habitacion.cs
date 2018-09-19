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
    }
}
