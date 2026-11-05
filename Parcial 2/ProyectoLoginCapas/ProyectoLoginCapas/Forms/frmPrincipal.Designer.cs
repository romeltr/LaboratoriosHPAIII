namespace Forms
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrReloj = new System.Windows.Forms.Timer(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTituloApp = new System.Windows.Forms.Label();
            this.lblReloj = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.btnOpcMiCuenta = new System.Windows.Forms.Button();
            this.btnOpcUsuarios = new System.Windows.Forms.Button();
            this.btnOpcCerrarSesion = new System.Windows.Forms.Button();
            this.btnOpcSalir = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblDatosSesion = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lblConteo = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlLateral.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrReloj
            // 
            this.tmrReloj.Enabled = true;
            this.tmrReloj.Interval = 1000;
            this.tmrReloj.Tick += new System.EventHandler(this.tmrReloj_Tick);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.pnlTop.Controls.Add(this.lblTituloApp);
            this.pnlTop.Controls.Add(this.lblReloj);
            this.pnlTop.Controls.Add(this.btnMenu);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 56);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTituloApp
            // 
            this.lblTituloApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloApp.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloApp.ForeColor = System.Drawing.Color.White;
            this.lblTituloApp.Location = new System.Drawing.Point(56, 0);
            this.lblTituloApp.Name = "lblTituloApp";
            this.lblTituloApp.Size = new System.Drawing.Size(704, 56);
            this.lblTituloApp.TabIndex = 2;
            this.lblTituloApp.Text = "Panel principal";
            this.lblTituloApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReloj
            // 
            this.lblReloj.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReloj.ForeColor = System.Drawing.Color.White;
            this.lblReloj.Location = new System.Drawing.Point(760, 0);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(340, 56);
            this.lblReloj.TabIndex = 1;
            this.lblReloj.Text = "fecha y hora";
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI Symbol", 18F);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(56, 56);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "☰";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pnlLateral
            // 
            this.pnlLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlLateral.Controls.Add(this.btnOpcMiCuenta);
            this.pnlLateral.Controls.Add(this.btnOpcUsuarios);
            this.pnlLateral.Controls.Add(this.btnOpcCerrarSesion);
            this.pnlLateral.Controls.Add(this.btnOpcSalir);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 56);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(210, 584);
            this.pnlLateral.TabIndex = 1;
            // 
            // btnOpcMiCuenta
            // 
            this.btnOpcMiCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnOpcMiCuenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpcMiCuenta.FlatAppearance.BorderSize = 0;
            this.btnOpcMiCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnOpcMiCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcMiCuenta.ForeColor = System.Drawing.Color.White;
            this.btnOpcMiCuenta.Location = new System.Drawing.Point(0, 46);
            this.btnOpcMiCuenta.Name = "btnOpcMiCuenta";
            this.btnOpcMiCuenta.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnOpcMiCuenta.Size = new System.Drawing.Size(210, 46);
            this.btnOpcMiCuenta.TabIndex = 1;
            this.btnOpcMiCuenta.Text = "Mi cuenta";
            this.btnOpcMiCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpcMiCuenta.UseVisualStyleBackColor = false;
            this.btnOpcMiCuenta.Click += new System.EventHandler(this.btnOpcMiCuenta_Click);
            // 
            // btnOpcUsuarios
            // 
            this.btnOpcUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnOpcUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpcUsuarios.FlatAppearance.BorderSize = 0;
            this.btnOpcUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnOpcUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnOpcUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnOpcUsuarios.Name = "btnOpcUsuarios";
            this.btnOpcUsuarios.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnOpcUsuarios.Size = new System.Drawing.Size(210, 46);
            this.btnOpcUsuarios.TabIndex = 0;
            this.btnOpcUsuarios.Text = "Usuarios";
            this.btnOpcUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpcUsuarios.UseVisualStyleBackColor = false;
            this.btnOpcUsuarios.Click += new System.EventHandler(this.btnOpcUsuarios_Click);
            // 
            // btnOpcCerrarSesion
            // 
            this.btnOpcCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnOpcCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOpcCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnOpcCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnOpcCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnOpcCerrarSesion.Location = new System.Drawing.Point(0, 492);
            this.btnOpcCerrarSesion.Name = "btnOpcCerrarSesion";
            this.btnOpcCerrarSesion.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnOpcCerrarSesion.Size = new System.Drawing.Size(210, 46);
            this.btnOpcCerrarSesion.TabIndex = 2;
            this.btnOpcCerrarSesion.Text = "Cerrar sesión";
            this.btnOpcCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpcCerrarSesion.UseVisualStyleBackColor = false;
            this.btnOpcCerrarSesion.Click += new System.EventHandler(this.btnOpcCerrarSesion_Click);
            // 
            // btnOpcSalir
            // 
            this.btnOpcSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnOpcSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOpcSalir.FlatAppearance.BorderSize = 0;
            this.btnOpcSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnOpcSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcSalir.ForeColor = System.Drawing.Color.White;
            this.btnOpcSalir.Location = new System.Drawing.Point(0, 538);
            this.btnOpcSalir.Name = "btnOpcSalir";
            this.btnOpcSalir.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnOpcSalir.Size = new System.Drawing.Size(210, 46);
            this.btnOpcSalir.TabIndex = 3;
            this.btnOpcSalir.Text = "Salir";
            this.btnOpcSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpcSalir.UseVisualStyleBackColor = false;
            this.btnOpcSalir.Click += new System.EventHandler(this.btnOpcSalir_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlInfo.Controls.Add(this.lblDatosSesion);
            this.pnlInfo.Controls.Add(this.lblBienvenida);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(210, 56);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(890, 66);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblDatosSesion
            // 
            this.lblDatosSesion.AutoSize = true;
            this.lblDatosSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDatosSesion.Location = new System.Drawing.Point(16, 37);
            this.lblDatosSesion.Name = "lblDatosSesion";
            this.lblDatosSesion.Size = new System.Drawing.Size(59, 23);
            this.lblDatosSesion.TabIndex = 1;
            this.lblDatosSesion.Text = "Sesión";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.Location = new System.Drawing.Point(14, 8);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(132, 28);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "¡Bienvenido!";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnLimpiar);
            this.pnlBotones.Controls.Add(this.btnDesactivar);
            this.pnlBotones.Controls.Add(this.btnActivar);
            this.pnlBotones.Controls.Add(this.btnBuscar);
            this.pnlBotones.Controls.Add(this.txtBuscar);
            this.pnlBotones.Controls.Add(this.lblBuscar);
            this.pnlBotones.Controls.Add(this.btnListar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(210, 122);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(890, 52);
            this.pnlBotones.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(680, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 32);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(560, 10);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(100, 32);
            this.btnDesactivar.TabIndex = 5;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Location = new System.Drawing.Point(462, 10);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(90, 32);
            this.btnActivar.TabIndex = 4;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(362, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 32);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(204, 14);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 29);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(148, 17);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(64, 23);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar:";
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(14, 10);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(120, 32);
            this.btnListar.TabIndex = 0;
            this.btnListar.Text = "Listar usuarios";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(210, 174);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(890, 440);
            this.dgvUsuarios.TabIndex = 4;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // lblConteo
            // 
            this.lblConteo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblConteo.Location = new System.Drawing.Point(210, 614);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblConteo.Size = new System.Drawing.Size(890, 26);
            this.lblConteo.TabIndex = 5;
            this.lblConteo.Text = "0 usuario(s)";
            this.lblConteo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.lblConteo);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlLateral);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(900, 520);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlLateral.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrReloj;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTituloApp;
        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel pnlLateral;
        private System.Windows.Forms.Button btnOpcMiCuenta;
        private System.Windows.Forms.Button btnOpcUsuarios;
        private System.Windows.Forms.Button btnOpcCerrarSesion;
        private System.Windows.Forms.Button btnOpcSalir;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblDatosSesion;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblConteo;
    }
}
