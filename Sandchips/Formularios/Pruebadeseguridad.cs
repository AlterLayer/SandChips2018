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
using System.Net;
using System.Net.Mail;

namespace Sandchips.Formularios
{
    public partial class Pruebadeseguridad : Form
    {
        public Pruebadeseguridad()
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
 

        private void Usuarios_LocationChanged(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        { 
        }

      
        //GUARDAR USUARIO
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            
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
            txtcorreo.Text.TrimStart();
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
        }

        private void mtbconfirmcontrasena_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        { 
        }

      
        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnabrir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcorreo.Text != "")
                {
                    var fromAddress = new MailAddress("sandchips.hotel.restaurant@gmail.com", "Sandchip's Hotel & Restaurant");
                    var toAddress = new MailAddress(txtcorreo.Text, "Cliente");
                    const string fromPassword = "sandchips2018";
                    const string subject = "Prueba de seguridad.";
                    const string body = "La puerta de su dormitorio ha sido abierta. De reconocer esta acción hacer caso omiso a este mensaje."; 
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                    MessageBox.Show("Se le ha notificado correctamente vía correo electronico", "Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe brindar un correo válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
