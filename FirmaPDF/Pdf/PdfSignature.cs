using Nekdu.FirmaPDF.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

using Org.BouncyCastle.Crypto.Tls;

//--
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.X509;

using Nekdu.FirmaPDF.Pdf.Exceptions;
using Nekdu.FirmaPDF.Util.Extents;


namespace Nekdu.FirmaPDF.Pdf
{
    public class PdfSignature
    {
        PdfProperties pdfProps;
        public PdfSignature(PdfProperties pdf)
        {
            this.pdfProps = pdf;
        }

        //---
        public byte[] PdfStamperHash(byte[] bPdf, string hashLevel)
        {
            byte[] bPdfHashed= bPdf;
            using (MemoryStream isp = new MemoryStream(bPdf)) {
                PdfReader pdfReader = new PdfReader(isp);

                List<string> signatureNames = pdfReader.AcroFields.GetSignatureNames();
                /* Validaciones */
                if (signatureNames.Count == 0) /* Únicamente cuando el documento no ha sido firmado */
                {
                    string str = CalculateHash(bPdf);
                    MemoryStream memoryStream = new MemoryStream();
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream);
                    ///int numberOfPages = pdfReader.NumberOfPages;
                    Font font = new Font();
                    font.Size = 9f;
                    font.Color = BaseColor.BLUE;
                    pdfReader.SelectPages("1-" + pdfReader.NumberOfPages);
                    for (int i = 1; i <= pdfReader.NumberOfPages; i++)
                    {
                        Rectangle pageSizeWithRotation = pdfReader.GetPageSizeWithRotation(i);
                        PdfContentByte overContent = pdfStamper.GetOverContent(i);
                        float x = pageSizeWithRotation.Width - 30f;
                        float y = pageSizeWithRotation.Height / 2f;
                        ColumnText.ShowTextAligned(overContent, 1, new Phrase(str, font), x, y, 90f);
                    }
                    pdfStamper.Close();
                    bPdfHashed = memoryStream.ToArray();
                }
                return bPdfHashed;
            }

        }
        private static string CalculateHash(byte[] bPdf)
        {
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] bHash256 = sha256.ComputeHash(bPdf);
                return Convert.ToBase64String(bHash256);
            }

        }
        //-----------------

        public void PdfSign()
        {
            byte[] bPdf = File.ReadAllBytes(pdfProps.pathFilePdfSrc);
            bPdf = PdfStamperHash(bPdf, "SHA256");
            bPdf = PdfStamperSign(bPdf);
            //------------------
            
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(pdfProps.pathFilePdfDest)))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(pdfProps.pathFilePdfDest));
            }
            //--
            try
            {
                File.WriteAllBytes(pdfProps.pathFilePdfDest, bPdf);
            }
            catch (IOException ex3)
            {
                //log.Error(ex3);
                throw new IOException("No se puede escribir el archivo firmado.", ex3);
            }
        }

        public byte[] PdfStamperSign(byte[] bPdf) {

            byte[] bPdfSigned = null;
            using (MemoryStream isp = new MemoryStream(bPdf))
            {
                PdfReader pdfReader = new PdfReader(isp);
                List<string> signatureNames = pdfReader.AcroFields.GetSignatureNames();

                //---------- Validaciones
                if (!IsSignedUsing(signatureNames, pdfProps.component))
                {
                    //--- TODO. Indicar quienes son los firmantes actual y los nuevos
                    throw new PdfUnrecognizedException();
                }

                if (IsSignedBy(ref pdfReader, pdfProps.certificado.X509))
                {
                    throw new PdfAlreadySignedByException();
                }

                //--
                MemoryStream memoryStream = new MemoryStream();
                PdfStamper pdfStamper = ((signatureNames.Count == 0) 
                        ? PdfStamper.CreateSignature(pdfReader, memoryStream, '\0') 
                        : PdfStamper.CreateSignature(pdfReader, memoryStream, '\0', null, append: true));

                //-- Sign
                CertificateInfo.X509Name subjectFields = CertificateInfo.GetSubjectFields(pdfProps.certificado.X509);
                string txtFirmante = null;

                if (subjectFields != null)
                {
                    txtFirmante = subjectFields.GetField("CN");
                    if (txtFirmante == null)
                    {
                        txtFirmante = subjectFields.GetField("E");
                    }
                }
                else
                {
                    txtFirmante = "";
                }

                //---
                using (pdfStamper)
                {
                    PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;

                    //float fWidth = 60; /* original 20f; */
                    //float fHeight = 300; /* 165f; */
                    //float x = 60; /*8f; */
                    //float y = 60; /*; 8f*/


                    float fWidth = 34; /* original 20f; */
                    float fHeight = 240; /* 165f; */
                    float x = 10; /*8f; */
                    float y = 10; /*; 8f*/
                    float fontSize = 7f;/* 5f;*/


                    Rectangle pageSizeWithRotation = pdfReader.GetPageSizeWithRotation(pdfReader.NumberOfPages);

                    CalculaPosicionFirma(signatureNames.Count, ref x, ref y, fHeight, fWidth, pageSizeWithRotation.Width - x);

                    Rectangle pageRect = new Rectangle(x, y, x + fHeight, y + fWidth);
                    pageRect.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    pageRect.BorderWidth = 2;
                    pageRect.BorderColor = new BaseColor(130, 100, 0);
                    ClienteTSA tsaClient = new ClienteTSA(pdfProps.tsaUrl);

                    signatureAppearance.SetVisibleSignature(pageRect, pdfReader.NumberOfPages, string.Format("{0} [{1}-{2}]", pdfProps.certificado.X509.SerialNumber, pdfProps.component, pdfProps.version.Replace(".", "_")));
                    signatureAppearance.SignDate = tsaClient.CalculateTimeStamp();
                    signatureAppearance.Acro6Layers = true;
                    signatureAppearance.Reason = pdfProps.reason;
                    signatureAppearance.Location = pdfProps.location;

                    PdfTemplate layer = signatureAppearance.GetLayer(2);
                    string strSign = string.Format("{0}: {1}\nCertificado: {2}\nFecha: {3}"
                        , pdfProps.actionLabel
                        , txtFirmante.Elipsis(37)
                        , pdfProps.certificado.X509.SerialNumber.ToString()
                        , signatureAppearance.SignDate.ToString("dd/MM/yyyy hh:mm:ss tt")); /*"dd/MM/yyyy hh:mm:ss.fffffff tt"*/

                    //    Font font = FontFactory.GetFont("TIMES_ROMAN", "Cp1252", embedded: false, 5f, 0, BaseColor.BLUE);
                    Font font = FontFactory.GetFont("Arial", "Cp1252", embedded: false, fontSize, 0, BaseColor.BLACK);
                    float size = font.Size;
                    Rectangle rectangle = new Rectangle(2f, 2f, signatureAppearance.Rect.Width - 2f, signatureAppearance.Rect.Height - 2f);

                    ColumnText columnText = new ColumnText(layer);
                    columnText.RunDirection = signatureAppearance.RunDirection;
                    columnText.SetSimpleColumn(new Phrase(strSign, font), rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Top, size, 0);
                    columnText.Go();
                   
                    IExternalSignature externalSignature = new PrivateKeySignature(pdfProps.certificado.Key, "SHA-256");
                    IOcspClient ocspClient = new ClienteOcsp();

                    

                    MakeSignature.SignDetached(signatureAppearance
                        , externalSignature
                        , pdfProps.certificado.Chain.Take(1).ToList()
                        , null, ocspClient
                        , tsaClient
                        , 0
                        , CryptoStandard.CMS);
                    pdfStamper.Close();
                 
                }
                bPdfSigned = memoryStream.ToArray();
            }
            GC.Collect();
            return bPdfSigned;
        }


        

        //-------------------------------
        private bool IsSignedUsing(List<string> names, string componentName)
        {
            string pattern = "sign[0-9]+";
            string pattern2 = "([0-9]+)\\ \\[([\\w\\ áÁéÉíÍóÓúÚñÑ]+)\\-([\\d\\.\\w\\ áÁéÉíÍóÓúÚñÑ]+)\\]";
            Regex regex = new Regex(pattern);
            Regex regex2 = new Regex(pattern2);
            foreach (string name in names)
            {
                if (!regex.IsMatch(name))
                {
                    Match match = regex2.Match(name);
                    if (!match.Success || !match.Groups["2"].ToString().Contains(componentName))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private bool IsSignedBy(ref PdfReader reader, X509Certificate signerCertificate)
        {
            bool result = false;
            AcroFields acroFields = reader.AcroFields;
            X509Name issuerDN = signerCertificate.IssuerDN;
            IList<string> list = new List<string>();
            foreach (object value in issuerDN.GetValueList(X509Name.CN))
            {
                list.Add(value.ToString());
            }

            foreach (string signatureName in acroFields.GetSignatureNames())
            {
                X509Certificate signingCertificate = acroFields.VerifySignature(signatureName).SigningCertificate;
                IList<string> list2 = new List<string>();
                X509Name issuerDN2 = signingCertificate.IssuerDN;
                foreach (object value2 in issuerDN2.GetValueList(X509Name.CN))
                {
                    list2.Add(value2.ToString());
                }

                if (signingCertificate.SerialNumber.Equals(signerCertificate.SerialNumber) && list.Count.Equals(list2.Count) && list.All(list2.Contains))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        //-------
        

        //------------
        private void CalculaPosicionFirma(int numFirmas, ref float x, ref float y, float w, float h, float maxWidth)
        {
            int num = 0;
            int num2 = 0;
            int numBoxes = (int)maxWidth / (int)w;
            num2 = numFirmas / numBoxes;
            num = numFirmas - numBoxes * (numFirmas / numBoxes);
            x += (float)num * w;
            y += (float)num2 * h;
        }
    }
}
