namespace WindowsFormsApp2
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.txtvalor = new System.Windows.Forms.TextBox();
            this.txtdescuento = new System.Windows.Forms.TextBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.textventa = new System.Windows.Forms.TextBox();
            this.bttcalc = new System.Windows.Forms.Button();
            this.bttnlimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(106, 100);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(94, 16);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Valor de venta";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(105, 161);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(82, 16);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "Descuento $";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(106, 234);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(87, 16);
            this.lbl3.TabIndex = 2;
            this.lbl3.Text = "Descuento %";
            this.lbl3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(106, 302);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(74, 16);
            this.lbl4.TabIndex = 3;
            this.lbl4.Text = "Venta Final";
            this.lbl4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtvalor
            // 
            this.txtvalor.Location = new System.Drawing.Point(241, 97);
            this.txtvalor.Name = "txtvalor";
            this.txtvalor.Size = new System.Drawing.Size(170, 22);
            this.txtvalor.TabIndex = 4;
            // 
            // txtdescuento
            // 
            this.txtdescuento.Location = new System.Drawing.Point(241, 158);
            this.txtdescuento.Name = "txtdescuento";
            this.txtdescuento.Size = new System.Drawing.Size(170, 22);
            this.txtdescuento.TabIndex = 5;
            this.txtdescuento.TextChanged += new System.EventHandler(this.txtdescuento_TextChanged);
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(241, 231);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(170, 22);
            this.txtdesc.TabIndex = 6;
            // 
            // textventa
            // 
            this.textventa.Location = new System.Drawing.Point(241, 299);
            this.textventa.Name = "textventa";
            this.textventa.Size = new System.Drawing.Size(170, 22);
            this.textventa.TabIndex = 7;
            // 
            // bttcalc
            // 
            this.bttcalc.Location = new System.Drawing.Point(522, 100);
            this.bttcalc.Name = "bttcalc";
            this.bttcalc.Size = new System.Drawing.Size(98, 55);
            this.bttcalc.TabIndex = 8;
            this.bttcalc.Text = "Calcular";
            this.bttcalc.UseVisualStyleBackColor = true;
            this.bttcalc.Click += new System.EventHandler(this.bttcalc_Click);
            // 
            // bttnlimpiar
            // 
            this.bttnlimpiar.Location = new System.Drawing.Point(522, 161);
            this.bttnlimpiar.Name = "bttnlimpiar";
            this.bttnlimpiar.Size = new System.Drawing.Size(98, 53);
            this.bttnlimpiar.TabIndex = 9;
            this.bttnlimpiar.Text = "Limpiar";
            this.bttnlimpiar.UseVisualStyleBackColor = true;
            this.bttnlimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 52);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bttnlimpiar);
            this.Controls.Add(this.bttcalc);
            this.Controls.Add(this.textventa);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.txtdescuento);
            this.Controls.Add(this.txtvalor);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Name = "Form1";
            this.Text = "Descuentos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.TextBox txtvalor;
        private System.Windows.Forms.TextBox txtdescuento;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.TextBox textventa;
        private System.Windows.Forms.Button bttcalc;
        private System.Windows.Forms.Button bttnlimpiar;
        private System.Windows.Forms.Button button1;
    }
}

