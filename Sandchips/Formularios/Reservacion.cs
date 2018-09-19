using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sandchips.DAL;
using Sandchips.Models;
using Sandchips.Formularios;

namespace ReservacionRestaurante
{
    public partial class Revervacion : Form
    {
        ModelReservacionRestaurante ag = new ModelReservacionRestaurante();
        ModelReservacionRestaurante actu = new ModelReservacionRestaurante();
        public Revervacion()
        {
            InitializeComponent();
        }
        void cargarComboxs()
        {
            DALReservacionRestaurante mostrarEstadoReserva = new DALReservacionRestaurante();
            cmbEstadoResturante.DisplayMember = "Estado";
            cmbEstadoResturante.ValueMember = "IdEstadoRestaurante";
            cmbEstadoResturante.DataSource = mostrarEstadoReserva.mostrarEstadoReserva();

            DALReservacionRestaurante mostrarIDcliente = new DALReservacionRestaurante();
            cmbIdCliente.DisplayMember = "Nombre";
            cmbIdCliente.ValueMember = "IdClientes ";
            cmbIdCliente.DataSource = mostrarIDcliente.mostrarIDcliente();

            DALReservacionRestaurante mostrarIDrestaurante = new DALReservacionRestaurante();
            cmbIdRestaurante.DisplayMember = "Restaurante";
            cmbIdRestaurante.ValueMember = "IdRestaurante";
            cmbIdRestaurante.DataSource = mostrarIDrestaurante.mostrarIDrestaurante();
        }
        void agregar()
        {
            try
            {
                ag.FechaHoraIngreso = dateFechaIngreso.Text;
                ag.NumeroPersonas = Convert.ToInt32(txtNumeroPersonas.Text);
                ag.IdCliente = Convert.ToInt32(cmbIdCliente.SelectedValue);
                ag.IdEstadoRestaurante = Convert.ToInt32(cmbEstadoResturante.SelectedValue);
                ag.IdRestaurante = Convert.ToInt32(cmbIdRestaurante.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        void insertar()
        {
            if (txtNumeroPersonas.Text.Trim() == "")
            {
                MessageBox.Show("Existen campos vacíos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                agregar();
                int datos = DALReservacionRestaurante.agregarReserva(ag);
            }
        }
        void mostrartabla()
        {
            DALReservacionRestaurante mostrar = new DALReservacionRestaurante();
            dgvmostrar.DataSource = mostrar.mostrarTabla();
        }
        void eliminarReserva()
        {
            try
            {
                ModelReservacionRestaurante del = new ModelReservacionRestaurante();
                int datos = DALReservacionRestaurante.eliminar(Convert.ToInt32(txtIDReservacion.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los campos de la tabla estan vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Revervacion_Load(object sender, EventArgs e)
        {
            cargarComboxs();
            mostrartabla();
        }

        private void btnAgragar_Click(object sender, EventArgs e)
        {
            insertar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarReserva();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form Chequeo_Mesa = new Menu_Restaurante();
            Chequeo_Mesa.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }
    }
}
