using Nekdu.FirmaPDF.Crypto;
using Nekdu.FirmaPDF.Pdf;
using Nekdu.FirmaPDF.Util.Extents;
using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace Nekdu.UI.Wizard
{
    public partial class FormSelectCertificado : Form, IWizard
    {
        string pathCertificado = null;
        string pathLlavePrivada= null;
        public FormSelectCertificado()
        {
            InitializeComponent();
            //-- Cer
            txtFileCertificado.Text = string.Empty;
            //-- Key
            lblLlavePrivada.Visible = false;
            txtLlavePrivada.Text = string.Empty;
            txtLlavePrivada.Visible = false;
            btnLlavePrivada.Visible = false;
            //- Password
            btnFirmarPDF.Enabled = false;
            grpCertificado.Visible = false;
        }

        private FormBaseWizard formBaseWizard = null;
        public void SetFormBase(FormBaseWizard formBaseWizard)
        {
            this.formBaseWizard = formBaseWizard;
        }
        public void SetStatusButtons()
        {
            formBaseWizard.VisibleBack(true);
            formBaseWizard.EnableBack(true);
            formBaseWizard.EnableNext(false);
            
        }
       
        private void btnAbrirCer_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos .CER|*.cer|Archivos .PFX|*.pfx";
                openFileDialog.Title = "Certificado de firma electrónica (CER o PFX)";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileCertificado.Text = openFileDialog.FileName.GetFileName();
                    pathCertificado = openFileDialog.FileName;
                    if (".pfx".Equals(openFileDialog.FileName.ToLower().GetExtension()))
                    {
                        lblLlavePrivada.Visible = false;
                        txtLlavePrivada.Visible = false;
                        btnLlavePrivada.Visible = false;
                        btnFirmarPDF.Enabled = (!String.IsNullOrEmpty(txtPassword.Text) );
                    }
                    if (".cer".Equals(openFileDialog.FileName.ToLower().GetExtension()))
                    {
                        lblLlavePrivada.Visible = true;
                        txtLlavePrivada.Visible = true;
                        btnLlavePrivada.Visible = true;
                        btnFirmarPDF.Enabled = (!String.IsNullOrEmpty(txtPassword.Text));
                    }
                }
            }
        }

        private void btnAbrirKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos .KEY|*.key";
                openFileDialog.Title = "Llave privada del certicado";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtLlavePrivada.Text = openFileDialog.FileName.GetFileName();
                    pathLlavePrivada = openFileDialog.FileName;
                    btnFirmarPDF.Enabled = (!String.IsNullOrEmpty(txtPassword.Text)); ;
                }
            }
        }

        private Certificado getCertificado() {
            Certificado cert = null;
            if (".pfx".Equals(pathCertificado.ToLower().GetExtension()))
            {
                cert = new Certificado(pathCertificado, txtPassword.Text);
            }
            if (".cer".Equals(pathCertificado.ToLower().GetExtension()))
            {
                cert = new Certificado(pathCertificado, pathLlavePrivada, txtPassword.Text);
            }
            cert.Analizar();
            /// OcspValidator ocspValidator = new OcspValidator(ref info);
            return cert;
        }

        private bool firmaPdfs(Certificado cert) {
            bool resultado = true;
            
            //-- Obtener el emisor
            lblEmisor.Text = cert.GetIssuers();
            lblTitular.Text = cert.GetTitular();
            lblVigencia.Text = cert.GetVigencia();

            //--------------- Ahora procesar la firma de los documentos
            PdfProperties prop = new PdfProperties();
            prop.certificado = cert;
            foreach (string filePdf in FormBaseWizard.UIProps.PDFSrcFiles)
            {
                prop.pathFilePdfSrc = filePdf;
                prop.pathFilePdfDest = filePdf.GetFileDirectory() + "\\Firmado\\" + filePdf.GetFileName();
                if (File.Exists(prop.pathFilePdfDest))
                {
                    MessageBox.Show(
                   "Ya existe el archivo " + prop.pathFilePdfDest + " en la carpeta de firmados, se va a ignorar."
                   , "Información"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                    continue;
                }
                prop.reason = "Razón validación";
                prop.location = "TECDMX";
                prop.component = "TECDMX";
                prop.version = "1.0";
                prop.actionLabel = FormBaseWizard.UIProps.actionLabel;

                prop.tsaUrl = "http://firel.uncocefi.cjf.gob.mx/tsacjf/";

                PdfSignature pdfSignature = new PdfSignature(prop);
                pdfSignature.PdfSign();
            }
            return resultado;
        }

           

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            Certificado cert = getCertificado();
            if (cert == null)
            {
                MessageBox.Show(
                   "Verificar su certificado y contraseña."
                   , "Ayuda"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
            }
            else
            {
                grpCertificado.Visible=true;
                if (firmaPdfs(cert))
                {
                    MessageBox.Show(
                   "Se firmaron los archivos correctamente."
                   , "Información"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
                    //---
                    formBaseWizard.EnableBack(false);
                    formBaseWizard.EnableNext(true);
                }
               
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnFirmarPDF.Enabled = (!String.IsNullOrEmpty(txtPassword.Text));
        }
    }
}
