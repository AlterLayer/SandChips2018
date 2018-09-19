
namespace Sandchips.Formularios
{
    partial class ReservacionHotel
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservacionHotel));
            this.label1 = new System.Windows.Forms.Label();
            this.txta = new System.Windows.Forms.Label();
            this.txtT = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.Label();
            this.txtTe = new System.Windows.Forms.Label();
            this.dgvReservacionHotel = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidreservacion = new System.Windows.Forms.TextBox();
            this.cmbIdCliente = new System.Windows.Forms.ComboBox();
            this.cmbIdHabitacion = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.txtprecio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservacionHotel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(110)))), ((int)(((byte)(93)))));
            this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(108, 315);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 28);
            this.label1.TabIndex = 61;
            this.label1.Text = "Fecha Inicio *";
            // 
            // txta
            // 
            this.txta.AutoSize = true;
            this.txta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(110)))), ((int)(((byte)(93)))));
            this.txta.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txta.Location = new System.Drawing.Point(107, 354);
            this.txta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txta.Name = "txta";
            this.txta.Size = new System.Drawing.Size(139, 28);
            this.txta.TabIndex = 62;
            this.txta.Text = "Fecha Salida *";
            // 
            // txtT
            // 
            this.txtT.AutoSize = true;
            this.txtT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(110)))), ((int)(((byte)(93)))));
            this.txtT.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtT.Location = new System.Drawing.Point(108, 395);
            this.txtT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtT.Name = "txtT";
            this.txtT.Size = new System.Drawing.Size(87, 28);
            this.txtT.TabIndex = 63;
            this.txtT.Text = "Cliente *";
            // 
            // txtC
            // 
            this.txtC.AutoSize = true;
            this.txtC.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtC.Location = new System.Drawing.Point(703, 268);
            this.txtC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(82, 28);
            this.txtC.TabIndex = 65;
            this.txtC.Text = "Precio *";
            // 
            // txtTe
            // 
            this.txtTe.AutoSize = true;
            this.txtTe.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTe.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTe.Location = new System.Drawing.Point(701, 311);
            this.txtTe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTe.Name = "txtTe";
            this.txtTe.Size = new System.Drawing.Size(122, 28);
            this.txtTe.TabIndex = 69;
            this.txtTe.Text = "Habitación *";
            // 
            // dgvReservacionHotel
            // 
            this.dgvReservacionHotel.AllowDrop = true;
            this.dgvReservacionHotel.AllowUserToAddRows = false;
            this.dgvReservacionHotel.AllowUserToDeleteRows = false;
            this.dgvReservacionHotel.AllowUserToResizeColumns = false;
            this.dgvReservacionHotel.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal;
            this.dgvReservacionHotel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReservacionHotel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservacionHotel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReservacionHotel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservacionHotel.Location = new System.Drawing.Point(81, 548);
            this.dgvReservacionHotel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvReservacionHotel.Name = "dgvReservacionHotel";
            this.dgvReservacionHotel.ReadOnly = true;
            this.dgvReservacionHotel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReservacionHotel.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvReservacionHotel.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReservacionHotel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservacionHotel.ShowCellErrors = false;
            this.dgvReservacionHotel.ShowRowErrors = false;
            this.dgvReservacionHotel.Size = new System.Drawing.Size(1271, 327);
            this.dgvReservacionHotel.TabIndex = 78;
            this.dgvReservacionHotel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonas_CellClick_1);
            this.dgvReservacionHotel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservacionHotel_CellContentClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(239)))), ((int)(((byte)(158)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(192, 490);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(69, 32);
            this.btnGuardar.TabIndex = 79;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            this.btnGuardar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            this.btnGuardar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGuardar_MouseMove);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(239)))), ((int)(((byte)(158)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.ForeColor = System.Drawing.Color.Black;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.Location = new System.Drawing.Point(312, 490);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(79, 32);
            this.btnActualizar.TabIndex = 80;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            this.btnActualizar.MouseLeave += new System.EventHandler(this.btnActualizar_MouseLeave);
            this.btnActualizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnActualizar_MouseMove);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(239)))), ((int)(((byte)(158)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(429, 490);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(69, 32);
            this.btnEliminar.TabIndex = 81;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            this.btnEliminar.MouseLeave += new System.EventHandler(this.btnEliminar_MouseLeave);
            this.btnEliminar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEliminar_MouseMove);
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(239)))), ((int)(((byte)(158)))));
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMostrar.ForeColor = System.Drawing.Color.Black;
            this.btnMostrar.Location = new System.Drawing.Point(544, 490);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(84, 32);
            this.btnMostrar.TabIndex = 82;
            this.btnMostrar.Text = "Consultar";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            this.btnMostrar.MouseLeave += new System.EventHandler(this.btnMostrar_MouseLeave);
            this.btnMostrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMostrar_MouseMove);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Rockwell", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(199, 177);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(344, 49);
            this.label13.TabIndex = 85;
            this.label13.Text = "Reservación de ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label13.Click += new System.EventHandler(this.label1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Rockwell", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(535, 175);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 49);
            this.label14.TabIndex = 86;
            this.label14.Text = "Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(110)))), ((int)(((byte)(93)))));
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(108, 276);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 28);
            this.label2.TabIndex = 87;
            this.label2.Text = "Id Reservación";
            // 
            // txtidreservacion
            // 
            this.txtidreservacion.Enabled = false;
            this.txtidreservacion.Location = new System.Drawing.Point(328, 272);
            this.txtidreservacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtidreservacion.Name = "txtidreservacion";
            this.txtidreservacion.ReadOnly = true;
            this.txtidreservacion.Size = new System.Drawing.Size(132, 22);
            this.txtidreservacion.TabIndex = 88;
            // 
            // cmbIdCliente
            // 
            this.cmbIdCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdCliente.FormattingEnabled = true;
            this.cmbIdCliente.Items.AddRange(new object[] {
            "Seleccione una opción",
            "Cédula",
            "DUI",
            "Otro"});
            this.cmbIdCliente.Location = new System.Drawing.Point(328, 394);
            this.cmbIdCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbIdCliente.Name = "cmbIdCliente";
            this.cmbIdCliente.Size = new System.Drawing.Size(317, 24);
            this.cmbIdCliente.TabIndex = 89;
            this.cmbIdCliente.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDoc_SelectedIndexChanged);
            this.cmbIdCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoDoc_KeyPress);
            // 
            // cmbIdHabitacion
            // 
            this.cmbIdHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdHabitacion.FormattingEnabled = true;
            this.cmbIdHabitacion.Items.AddRange(new object[] {
            "Seleccione una opción",
            "Masculino",
            "Femenino"});
            this.cmbIdHabitacion.Location = new System.Drawing.Point(871, 315);
            this.cmbIdHabitacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbIdHabitacion.Name = "cmbIdHabitacion";
            this.cmbIdHabitacion.Size = new System.Drawing.Size(297, 24);
            this.cmbIdHabitacion.TabIndex = 90;
            this.cmbIdHabitacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGenero_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1779, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 93;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(37, 25);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 94;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(239)))), ((int)(((byte)(158)))));
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnlimpiar.Location = new System.Drawing.Point(720, 490);
            this.btnlimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(120, 32);
            this.btnlimpiar.TabIndex = 112;
            this.btnlimpiar.Text = "Limpiar campos";
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(110)))), ((int)(((byte)(93)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.dtpFin);
            this.panel1.Controls.Add(this.dtpInicio);
            this.panel1.Controls.Add(this.btnlimpiar);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.cmbIdHabitacion);
            this.panel1.Controls.Add(this.cmbIdCliente);
            this.panel1.Controls.Add(this.txtidreservacion);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnMostrar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.dgvReservacionHotel);
            this.panel1.Controls.Add(this.txtprecio);
            this.panel1.Controls.Add(this.txtTe);
            this.panel1.Controls.Add(this.txtC);
            this.panel1.Controls.Add(this.txtT);
            this.panel1.Controls.Add(this.txta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1821, 945);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(328, 311);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(317, 22);
            this.dtpInicio.TabIndex = 113;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(328, 354);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(317, 22);
            this.dtpFin.TabIndex = 114;
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(871, 276);
            this.txtprecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(297, 22);
            this.txtprecio.TabIndex = 73;
            this.txtprecio.TextChanged += new System.EventHandler(this.txtDocumento_TextChanged);
            this.txtprecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // ReservacionHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1821, 945);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReservacionHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservacionHotel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txta;
        private System.Windows.Forms.Label txtT;
        private System.Windows.Forms.Label txtC;
        private System.Windows.Forms.Label txtTe;
        private System.Windows.Forms.DataGridView dgvReservacionHotel;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidreservacion;
        private System.Windows.Forms.ComboBox cmbIdCliente;
        private System.Windows.Forms.ComboBox cmbIdHabitacion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.TextBox txtprecio;
    }
}

