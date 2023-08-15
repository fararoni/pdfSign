using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Nekdu.FirmaPDF.Util.Extents;

//-- Source: https://www.makeuseof.com/winforms-app-drag-drop-file-uploader/


namespace Nekdu.UI.Wizard
{
    public partial class FormSelectFiles : Form , IWizard
    {
        FormBaseWizard formBaseWizard = null;
        public FormSelectFiles()
        {
            InitializeComponent();
            dragAndDropPamel.AllowDrop = true;
            dragAndDropPamel.AutoScroll = true;
        }

        public void SetFormBase(FormBaseWizard frmBaseWizard) { 
            formBaseWizard= frmBaseWizard;
            formBaseWizard.EnableBack(false);
            formBaseWizard.EnableNext(false);
        }

        public void SetStatusButtons()
        {
            formBaseWizard.VisibleBack(false);
            formBaseWizard.EnableBack(false);
            
            formBaseWizard.EnableNext(uploadedFilesList.Items.Count > 0);
        }
        private void dragAndDropPamel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void dragAndDropPamel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Boolean errorPdf = false;
            foreach (string file in files)
            {
                if (!String.IsNullOrEmpty(file)) {
                    if (file.GetIsDirectory()) {
                        //-- Leer el directorio
                        string[] dirFiles = Directory.GetFiles(file, "*.pdf");
                        foreach (string dirFileName in dirFiles)
                        {
                            uploadedFilesList.Items.Add("\\" + dirFileName.GetFileName());
                            FormBaseWizard.UIProps.PDFSrcFiles.Add(dirFileName);
                        }
                    } else {
                        if (".pdf".Equals(file.GetExtension().ToLower()))
                        {

                            uploadedFilesList.Items.Add(file.GetFileName());
                            FormBaseWizard.UIProps.PDFSrcFiles.Add(file);
                        }
                        else {
                            errorPdf = true;
                        }
                    }
                }
            }
            uploadedFilesList.Visible = uploadedFilesList.Items.Count > 0;
            formBaseWizard.EnableNext(uploadedFilesList.Visible);
            if (errorPdf)
            {
                MessageBox.Show(
                    "Agregar únicamente archivos con extensión .pdf"
                    , "Ayuda"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }

        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                openFileDialog.Title = "Abrir el archivo PDF a firmar";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    uploadedFilesList.Items.Add(openFileDialog.FileName.GetFileName());
                    FormBaseWizard.UIProps.PDFSrcFiles.Add(openFileDialog.FileName);
                }
                uploadedFilesList.Visible = uploadedFilesList.Items.Count > 0;

                formBaseWizard.EnableNext(uploadedFilesList.Visible);

            }
        }

        private void btnUpFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderOrigen = new FolderBrowserDialog()) {
                if (folderOrigen.ShowDialog() == DialogResult.OK) {
                    string[] dirFiles = Directory.GetFiles(folderOrigen.SelectedPath, "*.pdf");
                    foreach (string dirFileName in dirFiles)
                    {
                        uploadedFilesList.Items.Add("\\" + dirFileName.GetFileName());
                        FormBaseWizard.UIProps.PDFSrcFiles.Add(dirFileName);
                    }
                    uploadedFilesList.Visible = uploadedFilesList.Items.Count > 0;
                    formBaseWizard.EnableNext(uploadedFilesList.Visible);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FormBaseWizard.UIProps.actionLabel = "Firma";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FormBaseWizard.UIProps.actionLabel = "Rubrica";
        }
    }
}
