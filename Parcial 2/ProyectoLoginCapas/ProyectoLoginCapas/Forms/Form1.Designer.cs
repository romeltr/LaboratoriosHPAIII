namespace Forms
{
    partial class Form1
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEtiquetaUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblEtiquetaContrasenia = new System.Windows.Forms.Label();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.lblSinCuenta = new System.Windows.Forms.Label();
            this.btnRegistroUno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(28, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Iniciar sesión";
            //
            // lblEtiquetaUsuario
            //
            this.lblEtiquetaUsuario.AutoSize = true;
            this.lblEtiquetaUsuario.Location = new System.Drawing.Point(30, 75);
            this.lblEtiquetaUsuario.Name = "lblEtiquetaUsuario";
            this.lblEtiquetaUsuario.TabIndex = 1;
            this.lblEtiquetaUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            this.txtUsuario.Location = new System.Drawing.Point(30, 95);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(300, 25);
            this.txtUsuario.TabIndex = 2;
            //
            // lblEtiquetaContrasenia
            //
            this.lblEtiquetaContrasenia.AutoSize = true;
            this.lblEtiquetaContrasenia.Location = new System.Drawing.Point(30, 135);
            this.lblEtiquetaContrasenia.Name = "lblEtiquetaContrasenia";
            this.lblEtiquetaContrasenia.TabIndex = 3;
            this.lblEtiquetaContrasenia.Text = "Contraseña";
            //
            // txtContrasenia
            //
            this.txtContrasenia.Location = new System.Drawing.Point(30, 155);
            this.txtContrasenia.MaxLength = 100;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(300, 25);
            this.txtContrasenia.TabIndex = 4;
            this.txtContrasenia.UseSystemPasswordChar = true;
            //
            // btnIniciarSesion
            //
            this.btnIniciarSesion.Location = new System.Drawing.Point(30, 205);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(300, 36);
            this.btnIniciarSesion.TabIndex = 5;
            this.btnIniciarSesion.Text = "Iniciar sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            //
            // lblSinCuenta
            //
            this.lblSinCuenta.AutoSize = true;
            this.lblSinCuenta.Location = new System.Drawing.Point(30, 265);
            this.lblSinCuenta.Name = "lblSinCuenta";
            this.lblSinCuenta.TabIndex = 6;
            this.lblSinCuenta.Text = "¿Aún no tienes cuenta?";
            //
            // btnRegistroUno
            //
            this.btnRegistroUno.Location = new System.Drawing.Point(30, 287);
            this.btnRegistroUno.Name = "btnRegistroUno";
            this.btnRegistroUno.Size = new System.Drawing.Size(300, 32);
            this.btnRegistroUno.TabIndex = 7;
            this.btnRegistroUno.Text = "Registrarse";
            this.btnRegistroUno.UseVisualStyleBackColor = true;
            this.btnRegistroUno.Click += new System.EventHandler(this.btnRegistroUno_Click);
            //
            // Form1
            //
            this.AcceptButton = this.btnIniciarSesion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 345);
            this.Controls.Add(this.btnRegistroUno);
            this.Controls.Add(this.lblSinCuenta);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.lblEtiquetaContrasenia);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblEtiquetaUsuario);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesión";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEtiquetaUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblEtiquetaContrasenia;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Label lblSinCuenta;
        private System.Windows.Forms.Button btnRegistroUno;
    }
}
