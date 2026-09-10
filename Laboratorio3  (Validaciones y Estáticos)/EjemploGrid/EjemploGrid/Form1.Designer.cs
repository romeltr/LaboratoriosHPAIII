namespace EjemploGrid
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvdatos = new System.Windows.Forms.DataGridView();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.nombres = new System.Windows.Forms.Label();
            this.Apellidos = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.Correo = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.Label();
            this.Salario = new System.Windows.Forms.Label();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo__Click = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvdatos
            // 
            this.dgvdatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdatos.Location = new System.Drawing.Point(31, 307);
            this.dgvdatos.Name = "dgvdatos";
            this.dgvdatos.RowHeadersWidth = 51;
            this.dgvdatos.RowTemplate.Height = 24;
            this.dgvdatos.Size = new System.Drawing.Size(690, 95);
            this.dgvdatos.TabIndex = 0;
            this.dgvdatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(151, 222);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(307, 22);
            this.dtpFechaNacimiento.TabIndex = 1;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(147, 26);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(311, 22);
            this.txtID.TabIndex = 2;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(148, 82);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(311, 22);
            this.txtNombres.TabIndex = 3;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(147, 132);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(311, 22);
            this.txtApellidos.TabIndex = 4;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(147, 182);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(311, 22);
            this.txtCorreo.TabIndex = 5;
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(147, 262);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(311, 22);
            this.txtSalario.TabIndex = 6;
            // 
            // nombres
            // 
            this.nombres.AutoSize = true;
            this.nombres.Location = new System.Drawing.Point(41, 88);
            this.nombres.Name = "nombres";
            this.nombres.Size = new System.Drawing.Size(63, 16);
            this.nombres.TabIndex = 7;
            this.nombres.Text = "Nombres";
            this.nombres.Click += new System.EventHandler(this.label7_Click);
            // 
            // Apellidos
            // 
            this.Apellidos.AutoSize = true;
            this.Apellidos.Location = new System.Drawing.Point(41, 135);
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.Size = new System.Drawing.Size(64, 16);
            this.Apellidos.TabIndex = 8;
            this.Apellidos.Text = "Apellidos";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(28, 32);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(86, 16);
            this.ID.TabIndex = 9;
            this.ID.Text = "ID Empleado";
            // 
            // Correo
            // 
            this.Correo.AutoSize = true;
            this.Correo.Location = new System.Drawing.Point(41, 182);
            this.Correo.Name = "Correo";
            this.Correo.Size = new System.Drawing.Size(48, 16);
            this.Correo.TabIndex = 10;
            this.Correo.Text = "Correo";
            this.Correo.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Location = new System.Drawing.Point(13, 222);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(132, 16);
            this.fecha.TabIndex = 11;
            this.fecha.Text = "Fecha de nacimiento";
            // 
            // Salario
            // 
            this.Salario.AutoSize = true;
            this.Salario.Location = new System.Drawing.Point(41, 268);
            this.Salario.Name = "Salario";
            this.Salario.Size = new System.Drawing.Size(50, 16);
            this.Salario.TabIndex = 12;
            this.Salario.Text = "Salario";
            this.Salario.Click += new System.EventHandler(this.label7_Click_2);
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo__Click});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(748, 27);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbNuevo__Click
            // 
            this.tsbNuevo__Click.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo__Click.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo__Click.Image")));
            this.tsbNuevo__Click.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo__Click.Name = "tsbNuevo__Click";
            this.tsbNuevo__Click.Size = new System.Drawing.Size(29, 24);
            this.tsbNuevo__Click.Text = "Boton hace la gestión";
            this.tsbNuevo__Click.Click += new System.EventHandler(this.tsbNuevoClick_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(748, 425);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.Salario);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.Correo);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.Apellidos);
            this.Controls.Add(this.nombres);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.dgvdatos);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvdatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvdatos;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label nombres;
        private System.Windows.Forms.Label Apellidos;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label Correo;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label Salario;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbNuevo__Click;
    }
}

