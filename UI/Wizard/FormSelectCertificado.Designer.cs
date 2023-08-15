namespace Nekdu.UI.Wizard
{
    partial class FormSelectCertificado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectCertificado));
            this.label1 = new System.Windows.Forms.Label();
            this.grpCertificado = new System.Windows.Forms.GroupBox();
            this.lblValidez = new System.Windows.Forms.Label();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblEmisor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFirmarPDF = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLlavePrivada = new System.Windows.Forms.Button();
            this.txtLlavePrivada = new System.Windows.Forms.TextBox();
            this.btnAbrirCer = new System.Windows.Forms.Button();
            this.txtFileCertificado = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblLlavePrivada = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpCertificado.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Certificado de firma";
            // 
            // grpCertificado
            // 
            this.grpCertificado.Controls.Add(this.lblValidez);
            this.grpCertificado.Controls.Add(this.lblVigencia);
            this.grpCertificado.Controls.Add(this.lblTitular);
            this.grpCertificado.Controls.Add(this.lblEmisor);
            this.grpCertificado.Controls.Add(this.label5);
            this.grpCertificado.Controls.Add(this.label4);
            this.grpCertificado.Controls.Add(this.label3);
            this.grpCertificado.Controls.Add(this.label2);
            this.grpCertificado.Location = new System.Drawing.Point(12, 153);
            this.grpCertificado.Name = "grpCertificado";
            this.grpCertificado.Size = new System.Drawing.Size(426, 95);
            this.grpCertificado.TabIndex = 2;
            this.grpCertificado.TabStop = false;
            // 
            // lblValidez
            // 
            this.lblValidez.AutoSize = true;
            this.lblValidez.Location = new System.Drawing.Point(68, 73);
            this.lblValidez.Name = "lblValidez";
            this.lblValidez.Size = new System.Drawing.Size(10, 13);
            this.lblValidez.TabIndex = 7;
            this.lblValidez.Text = "-";
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Location = new System.Drawing.Point(67, 54);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(10, 13);
            this.lblVigencia.TabIndex = 6;
            this.lblVigencia.Text = "-";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitular.Location = new System.Drawing.Point(67, 16);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(11, 13);
            this.lblTitular.TabIndex = 5;
            this.lblTitular.Text = "-";
            // 
            // lblEmisor
            // 
            this.lblEmisor.AutoSize = true;
            this.lblEmisor.Location = new System.Drawing.Point(67, 35);
            this.lblEmisor.Name = "lblEmisor";
            this.lblEmisor.Size = new System.Drawing.Size(10, 13);
            this.lblEmisor.TabIndex = 4;
            this.lblEmisor.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Validez :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Vigencia :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Titular :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Emisor :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.btnFirmarPDF);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnLlavePrivada);
            this.groupBox1.Controls.Add(this.txtLlavePrivada);
            this.groupBox1.Controls.Add(this.btnAbrirCer);
            this.groupBox1.Controls.Add(this.txtFileCertificado);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.lblLlavePrivada);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 112);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnFirmarPDF
            // 
            this.btnFirmarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirmarPDF.Location = new System.Drawing.Point(335, 79);
            this.btnFirmarPDF.Name = "btnFirmarPDF";
            this.btnFirmarPDF.Size = new System.Drawing.Size(75, 24);
            this.btnFirmarPDF.TabIndex = 16;
            this.btnFirmarPDF.Text = "Firmar";
            this.btnFirmarPDF.UseVisualStyleBackColor = true;
            this.btnFirmarPDF.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnLlavePrivada
            // 
            this.btnLlavePrivada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLlavePrivada.Location = new System.Drawing.Point(372, 50);
            this.btnLlavePrivada.Name = "btnLlavePrivada";
            this.btnLlavePrivada.Size = new System.Drawing.Size(38, 25);
            this.btnLlavePrivada.TabIndex = 14;
            this.btnLlavePrivada.Text = "...";
            this.btnLlavePrivada.UseVisualStyleBackColor = true;
            this.btnLlavePrivada.Click += new System.EventHandler(this.btnAbrirKey_Click);
            // 
            // txtLlavePrivada
            // 
            this.txtLlavePrivada.Location = new System.Drawing.Point(163, 52);
            this.txtLlavePrivada.Name = "txtLlavePrivada";
            this.txtLlavePrivada.ReadOnly = true;
            this.txtLlavePrivada.Size = new System.Drawing.Size(203, 20);
            this.txtLlavePrivada.TabIndex = 13;
            // 
            // btnAbrirCer
            // 
            this.btnAbrirCer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCer.Location = new System.Drawing.Point(372, 19);
            this.btnAbrirCer.Name = "btnAbrirCer";
            this.btnAbrirCer.Size = new System.Drawing.Size(38, 25);
            this.btnAbrirCer.TabIndex = 12;
            this.btnAbrirCer.Text = "...";
            this.btnAbrirCer.UseVisualStyleBackColor = true;
            this.btnAbrirCer.Click += new System.EventHandler(this.btnAbrirCer_Click);
            // 
            // txtFileCertificado
            // 
            this.txtFileCertificado.Location = new System.Drawing.Point(163, 21);
            this.txtFileCertificado.Name = "txtFileCertificado";
            this.txtFileCertificado.ReadOnly = true;
            this.txtFileCertificado.Size = new System.Drawing.Size(203, 20);
            this.txtFileCertificado.TabIndex = 12;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(163, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(159, 20);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblLlavePrivada
            // 
            this.lblLlavePrivada.AutoSize = true;
            this.lblLlavePrivada.Location = new System.Drawing.Point(80, 56);
            this.lblLlavePrivada.Name = "lblLlavePrivada";
            this.lblLlavePrivada.Size = new System.Drawing.Size(77, 13);
            this.lblLlavePrivada.TabIndex = 8;
            this.lblLlavePrivada.Text = "Llave privada :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Certificado :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Contraseña :";
            // 
            // FormSelectCertificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(450, 260);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpCertificado);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelectCertificado";
            this.Text = "FormSelectCertificado";
            this.grpCertificado.ResumeLayout(false);
            this.grpCertificado.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCertificado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLlavePrivada;
        private System.Windows.Forms.Label lblValidez;
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblEmisor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAbrirCer;
        private System.Windows.Forms.TextBox txtLlavePrivada;
        private System.Windows.Forms.TextBox txtFileCertificado;
        private System.Windows.Forms.Button btnLlavePrivada;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFirmarPDF;
    }
}