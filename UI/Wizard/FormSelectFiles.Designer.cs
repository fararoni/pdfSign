namespace Nekdu.UI.Wizard
{
    partial class FormSelectFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectFiles));
            this.label1 = new System.Windows.Forms.Label();
            this.dragAndDropPamel = new System.Windows.Forms.Panel();
            this.uploadedFilesList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpFile = new System.Windows.Forms.PictureBox();
            this.btnUpFolder = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dragAndDropPamel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo o carpeta a firmar";
            // 
            // dragAndDropPamel
            // 
            this.dragAndDropPamel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dragAndDropPamel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dragAndDropPamel.Controls.Add(this.uploadedFilesList);
            this.dragAndDropPamel.Controls.Add(this.label3);
            this.dragAndDropPamel.Location = new System.Drawing.Point(12, 33);
            this.dragAndDropPamel.Name = "dragAndDropPamel";
            this.dragAndDropPamel.Size = new System.Drawing.Size(426, 139);
            this.dragAndDropPamel.TabIndex = 1;
            this.dragAndDropPamel.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragAndDropPamel_DragDrop);
            this.dragAndDropPamel.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragAndDropPamel_DragEnter);
            // 
            // uploadedFilesList
            // 
            this.uploadedFilesList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.uploadedFilesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uploadedFilesList.FormattingEnabled = true;
            this.uploadedFilesList.Location = new System.Drawing.Point(10, 10);
            this.uploadedFilesList.Margin = new System.Windows.Forms.Padding(20);
            this.uploadedFilesList.Name = "uploadedFilesList";
            this.uploadedFilesList.Size = new System.Drawing.Size(404, 117);
            this.uploadedFilesList.TabIndex = 0;
            this.uploadedFilesList.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(38, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Arrastre sus archivos PDF o carpeta aquí";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnUpFile
            // 
            this.btnUpFile.Image = ((System.Drawing.Image)(resources.GetObject("btnUpFile.Image")));
            this.btnUpFile.Location = new System.Drawing.Point(326, 192);
            this.btnUpFile.Name = "btnUpFile";
            this.btnUpFile.Size = new System.Drawing.Size(40, 40);
            this.btnUpFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnUpFile.TabIndex = 2;
            this.btnUpFile.TabStop = false;
            this.btnUpFile.Click += new System.EventHandler(this.btnUpFile_Click);
            // 
            // btnUpFolder
            // 
            this.btnUpFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnUpFolder.Image")));
            this.btnUpFolder.Location = new System.Drawing.Point(382, 192);
            this.btnUpFolder.Name = "btnUpFolder";
            this.btnUpFolder.Size = new System.Drawing.Size(56, 40);
            this.btnUpFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnUpFolder.TabIndex = 3;
            this.btnUpFolder.TabStop = false;
            this.btnUpFolder.Click += new System.EventHandler(this.btnUpFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "*Los archivos firmados se guardarán en la carpeta Firmados";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(22, 232);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(132, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cambiar la carpeta destino";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(80, 179);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Firmar";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(171, 178);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Rubricar";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // FormSelectFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(450, 260);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpFolder);
            this.Controls.Add(this.btnUpFile);
            this.Controls.Add(this.dragAndDropPamel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelectFiles";
            this.Text = "FormSelectFiles";
            this.dragAndDropPamel.ResumeLayout(false);
            this.dragAndDropPamel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dragAndDropPamel;
        private System.Windows.Forms.ListBox uploadedFilesList;
        private System.Windows.Forms.PictureBox btnUpFile;
        private System.Windows.Forms.PictureBox btnUpFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}