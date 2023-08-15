using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

using Nekdu.FirmaPDF.Crypto.Exceptions;
using iTextSharp.text.pdf.security;
using iTextSharp.text.pdf;

namespace Nekdu.FirmaPDF.Crypto
{
    public class Certificado {

        private string pathPfx;
        private string pathCer;
        private string pathKey;
        private string password;

        public Certificado(string pathPfx, string password)
        {
            Chain = new LinkedList<X509Certificate>();
            this.pathPfx = pathPfx;
            this.password = password;
        }
        public Certificado(string pathCert, string pathKey, string password)
        {
            Chain = new LinkedList<X509Certificate>();
            this.pathCer = pathCert;
            this.pathKey = pathKey; 
            this.password=password;
        }
        //-- Properties
        public X509Certificate X509 { get; internal set; }
        public AsymmetricKeyParameter Key { get; internal set; }
        public LinkedList<X509Certificate> Chain { get; internal set; }

        public void Analizar()
        {
            try
            {
                if (!String.IsNullOrEmpty(pathPfx))
                {
                    Pkcs12Store pkcs12Store = null;
                
                    byte[] bStrPfx= File.ReadAllBytes(pathPfx);
                    pkcs12Store = new Pkcs12Store(new MemoryStream(bStrPfx), password.ToCharArray());

                    string aliasKey = null;
                    foreach (string alias in pkcs12Store.Aliases)
                    {
                        if (pkcs12Store.IsKeyEntry(alias))
                        {
                            aliasKey = alias;
                            break;
                        }
                    }
                    X509 = (new X509Certificate[1] { pkcs12Store.GetCertificate(aliasKey).Certificate })[0];
                    Key = pkcs12Store.GetKey(aliasKey).Key;
                }
                else if (!String.IsNullOrEmpty(pathCer))
                {
                    byte[] bStrCer = File.ReadAllBytes(pathCer);
                    byte[] bStrKey = File.ReadAllBytes(pathKey);
                    X509CertificateParser x509parser = new X509CertificateParser();

                    X509 = x509parser.ReadCertificate(bStrCer);
                    Key = PrivateKeyFactory.DecryptKey(password.ToCharArray(), bStrKey);
                }
                ValidateMatchCerKey();
                Chain.AddFirst(X509);
                Chain.AddLast(GetCertificadoIntermedio(X509));
            }
            catch (Exception innerException)
            {
                throw new CertificadoException(innerException);
            }
        }

        private void ValidateMatchCerKey()
        {
            RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)X509.GetPublicKey();
            RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParameters = (RsaPrivateCrtKeyParameters) Key;
            if (rsaPrivateCrtKeyParameters != null 
                && (!rsaKeyParameters.Modulus.Equals(rsaPrivateCrtKeyParameters.Modulus)
                || !rsaKeyParameters.Exponent.Equals(rsaPrivateCrtKeyParameters.PublicExponent)))
            {
                throw new CertificadoMismatchException();
            }
        }
        //---- Auxiliares
        private X509Certificate GetCertificadoIntermedio(X509Certificate x509UserCert)
        {
            HashSet<X509Certificate> store = CargarCertificateStore();
            X509Certificate x509Intermedio = null;

            foreach (X509Certificate issuerCert in store)
            {
                try
                {
                    x509UserCert.Verify(issuerCert.GetPublicKey());
                    x509Intermedio = issuerCert;
                }
                catch
                {
                    continue;
                }

                break;
            }

            if (x509Intermedio == null)
            {
                throw new CertificadoException("No ha instalado el certificado intermedio (emisor).");
            }
            return x509Intermedio;
        }

        //-- Tools
        public string GetTitular() {
            CertificateInfo.X509Name subjectFields = CertificateInfo.GetSubjectFields(X509);
            string text = null;

            if (subjectFields != null)
            {
                text = subjectFields.GetField("CN");
                if (text == null)
                {
                    text = subjectFields.GetField("E");
                }
            }
            return text;
        }

        public string GetIssuers()
        {
            CertificateInfo.X509Name issuerFields = CertificateInfo.GetIssuerFields(X509);
            string text = null;

            if (issuerFields != null)
            {
                text = issuerFields.GetField("CN");
            }
            return text;
        }
        public string GetVigencia()
        {
            string text = string.Format("{0} a {1}", X509.NotBefore, X509.NotAfter);
            return text;
        }

        //--
        private HashSet<X509Certificate> CargarCertificateStore()
        {
            HashSet<X509Certificate> store = new HashSet<X509Certificate>();

            System.Security.Cryptography.X509Certificates.X509Store
                myStore = new System.Security.Cryptography.X509Certificates.X509Store(
                    System.Security.Cryptography.X509Certificates.StoreName.CertificateAuthority,
                    System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);

            myStore.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

            X509CertificateParser x509CertificateParser = new X509CertificateParser();
            foreach (System.Security.Cryptography.X509Certificates.X509Certificate2 cert2 in myStore.Certificates)
            {
                byte[] obj = cert2.Export(System.Security.Cryptography.X509Certificates.X509ContentType.Cert);
                //--TODO. Agregar únicamente los vigentes
                store.Add(x509CertificateParser.ReadCertificate(obj));
            }
            //---
            System.Security.Cryptography.X509Certificates.X509Store
                myStoreAC = new System.Security.Cryptography.X509Certificates.X509Store(
                    System.Security.Cryptography.X509Certificates.StoreName.AuthRoot,
                    System.Security.Cryptography.X509Certificates.StoreLocation.CurrentUser);

            myStoreAC.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

            foreach (System.Security.Cryptography.X509Certificates.X509Certificate2 certAc in myStore.Certificates)
            {
                byte[] obj = certAc.Export(System.Security.Cryptography.X509Certificates.X509ContentType.Cert);
                //--TODO. Agregar únicamente los vigentes
                store.Add(x509CertificateParser.ReadCertificate(obj));
            }
            return store;
        }


        private HashSet<X509Certificate> CargarCertificadosResource()
        {
            HashSet<X509Certificate> store = new HashSet<X509Certificate>();
            ResourceManager rm = new ResourceManager("FirmaDOCNet.Properties.Resources", Assembly.GetExecutingAssembly());
                string[] certArray = { "ACI_CJF", "ACI_SCJN", "ACI_TEPJF",
                            "AC1_SAT_1","AC1_SAT_2","AC3_SAT","AC4_SAT", "AC5_SAT", "AC6_SAT",
                "AC_SAT1190"};

            X509CertificateParser parser = new X509CertificateParser();

            for (int i = 0; i < certArray.Length; i++)
            {
                object obj = rm.GetObject(certArray[i]);
                    
                store.Add(parser.ReadCertificate((byte[])obj));

            }
            return store;
        }
     }
    }
