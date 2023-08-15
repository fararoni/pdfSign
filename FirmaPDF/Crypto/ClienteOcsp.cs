using CJF.Firma.Util.Exceptions;
using Nekdu.FirmaPDF.Crypto.Exceptions;
using iTextSharp.text.pdf.security;
using Org.BouncyCastle.X509;      

namespace Nekdu.FirmaPDF.Crypto
{
    public class ClienteOcsp : IOcspClient
    {
        private readonly IOcspClient oscpClient;
        public ClienteOcsp()
        {
            oscpClient = new OcspClientBouncyCastle(new OcspVerifier(null, null));
        }

        public byte[] GetEncoded(X509Certificate checkCert, X509Certificate rootCert, string url)
        {
            try
            {
                return oscpClient.GetEncoded(checkCert, null, url);
            }
            catch (CertificadoException inner)
            {
                throw new ConnectionException(inner, url);
            }
        }
    }
}
