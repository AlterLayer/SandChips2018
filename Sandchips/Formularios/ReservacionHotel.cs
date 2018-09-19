using System;
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

namespace Sandchips.Formularios
{
    public partial class ReservacionHotel : Form
    {
        public ReservacionHotel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvReservacionHotel.DataSource = DALHotel.mostrartabla();
            Conexion.obtenerconexion();
            cmbIdCliente.DataSource = DALHotel.ObtenerCliente();
            cmbIdCliente.DisplayMember = "Nombre";
            cmbIdCliente.ValueMember = "IdClientes";
            cmbIdHabitacion.DataSource = DALHotel.Obtener_Hab();
            cmbIdHabitacion.DisplayMember = "NumeroHabitacion";
            cmbIdHabitacion.ValueMember = "IdHabitacion"; 
            cmbIdCliente.SelectedIndex = -1;
            cmbIdHabitacion.SelectedIndex = -1; 
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

        }


        public bool ValidarReservacion()
        {
            bool validacion = false;
            if (dtpInicio.Value.Date <= dtpFin.Value.Date && cmbIdCliente.SelectedIndex != 0 && cmbIdHabitacion.SelectedIndex != 0)
            {
                validacion = true;
            }
            else
            {
                validacion = false;
                MessageBox.Show("Los campos con * son requeridos");
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

        //GUARDAR CLIENTE
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            if (ValidarReservacion())
            {
                ModelHotel agregar = new ModelHotel();
                var fecI = dtpInicio.Text.Split('/')[2] + "-" + dtpInicio.Text.Split('/')[1] + "-" + dtpInicio.Text.Split('/')[0];
                agregar.FechaIngreso = fecI;
                var fecF = dtpFin.Text.Split('/')[2] + "-" + dtpFin.Text.Split('/')[1] + "-" + dtpFin.Text.Split('/')[0];
                agregar.FechaSalida = fecF; 
                agregar.Precio = Convert.ToDouble(txtprecio.Text);
                agregar.IdHabitaciones = Convert.ToInt32(cmbIdHabitacion.SelectedValue.ToString());
                agregar.IdClientes = Convert.ToInt32(cmbIdCliente.SelectedValue.ToString()); 
                int datos = DALHotel.agregar(agregar);
                if (datos > 0)
                {
                    MessageBox.Show("Registro ingresado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtidreservacion.Clear(); 
                    txtprecio.Clear();
                    cmbIdCliente.SelectedIndex = 0;
                    txtprecio.Clear(); 
                    cmbIdHabitacion.SelectedIndex = 0; 
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
            if (ValidarReservacion())
            {
                ModelHotel agregar = new ModelHotel();
                agregar.IdReservacionHotel = Convert.ToInt32(txtidreservacion.Text);
                var fecI = dtpInicio.Text.Split('/')[2] + "-" + dtpInicio.Text.Split('/')[1] + "-" + dtpInicio.Text.Split('/')[0];
                agregar.FechaIngreso = fecI;
                var fecF = dtpFin.Text.Split('/')[2] + "-" + dtpFin.Text.Split('/')[1] + "-" + dtpFin.Text.Split('/')[0];
                agregar.FechaSalida = fecF;
                agregar.Precio = Convert.ToDouble(txtprecio.Text);
                agregar.IdHabitaciones = Convert.ToInt32(cmbIdHabitacion.SelectedIndex.ToString());
                agregar.IdClientes = Convert.ToInt32(cmbIdCliente.SelectedIndex.ToString());
                int datos = DALHotel.modificar(agregar);
                if (datos > 0)
                {
                    MessageBox.Show("Registro modificado correctamente", "Operacón exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtidreservacion.Clear();
                    txtprecio.Clear();
                    cmbIdCliente.SelectedIndex = 0;
                    txtprecio.Clear();
                    cmbIdHabitacion.SelectedIndex = 0;
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
                eliminar.IdClientes = Convert.ToInt32(txtidreservacion.Text);
                eliminar.IdEstado = Convert.ToInt32(cmbIdCliente.SelectedIndex.ToString());
                DALClientes.eliminar(eliminar);
                MessageBox.Show("Registro eliminado exitosamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvReservacionHotel.DataSource = DALClientes.mostrartabla();
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
            pocision = dgvReservacionHotel.CurrentRow.Index;
            txtidreservacion.Text = dgvReservacionHotel[0, pocision].Value.ToString();
            dtpInicio.Value = Convert.ToDateTime(dgvReservacionHotel[1, pocision].Value);
            dtpFin.Value = Convert.ToDateTime(dgvReservacionHotel[2, pocision].Value);
            txtprecio.Text = dgvReservacionHotel[3, pocision].Value.ToString(); 
            cmbIdHabitacion.SelectedValue = Convert.ToInt32(dgvReservacionHotel[5, pocision].Value.ToString());
            cmbIdCliente.SelectedValue = Convert.ToInt32(dgvReservacionHotel[3, pocision].Value.ToString());
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        //BUSCAR CLIENTE
        private void btnBuscar_Click_1(object sender, EventArgs e)
        { 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //MOSTRAR CLIENTES
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dgvReservacionHotel.DataSource = DALHotel.mostrartabla();
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
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            txtprecio.Text.TrimStart();
        }

        private void mtbTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        { 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        { 
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
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        { 
        }

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        { 
            cmbIdHabitacion.SelectedIndex = 0;
            cmbIdCliente.SelectedIndex = 0; 
            cmbIdHabitacion.SelectedIndex = 0;
            txtidreservacion.Text = "";
            txtprecio.Text = "";
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void dgvReservacionHotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int pocision;
            pocision = dgvReservacionHotel.CurrentRow.Index;
            txtidreservacion.Text = dgvReservacionHotel[0, pocision].Value.ToString();
            dtpInicio.Text = dgvReservacionHotel[1, pocision].Value.ToString();
            dtpFin.Text = dgvReservacionHotel[2, pocision].Value.ToString();
            cmbIdHabitacion.SelectedValue = Convert.ToInt32(dgvReservacionHotel[5, pocision].Value.ToString());
            cmbIdCliente.SelectedValue = Convert.ToInt32(dgvReservacionHotel[3, pocision].Value.ToString()); 
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
            btnGuardar.Enabled = false;

        }
    }
}
