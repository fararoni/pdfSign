using System;
using Nekdu.FirmaPDF.Crypto.Exceptions;
using iTextSharp.text.pdf.security;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Tsp;

namespace Nekdu.FirmaPDF.Crypto
{
    public class ClienteTSA : ITSAClient
    {
        private TSAClientBouncyCastle tsaClient;

        private string url;

        private DateTime dateResponse;

        public DateTime DateResponse => dateResponse;
        public ClienteTSA(string url)
        {
            tsaClient = new TSAClientBouncyCastle(url);
            this.url = url;
        }

        public IDigest GetMessageDigest()
        {
            return tsaClient.GetMessageDigest();
        }

        public byte[] GetTimeStampToken(byte[] imprint)
        {
            try
            {
                byte[] timeStampToken = tsaClient.GetTimeStampToken(imprint);
                TimeStampToken timeStampToken2 = new TimeStampToken(new CmsSignedData(timeStampToken));
                dateResponse = timeStampToken2.TimeStampInfo.GenTime;
                return timeStampToken;
            }
            catch (Exception inner)
            {
                throw new ClienteTSAConnectionException(url, inner);
            }
        }

        public int GetTokenSizeEstimate()
        {
            return tsaClient.GetTokenSizeEstimate();
        }

        public DateTime GenerateTimestampTest()
        {
            Random random = new Random();
            byte[] array = new byte[32];
            random.NextBytes(array);
            GetTimeStampToken(array);
            return dateResponse;
        }

        public DateTime CalculateTimeStamp()
        {
           
            DateTime dateTime = GenerateTimestampTest();
            DateTime signDate = dateTime.ToLocalTime();
            /*ok   if (dateTime.ToString("dd/MM/yyyy hh:mm") != customTSAClient.DateResponse.ToString("dd/MM/yyyy hh:mm"))
                    {
                        throw new DifferentDateException();
                    } */
            return signDate;
        }
    }
}
