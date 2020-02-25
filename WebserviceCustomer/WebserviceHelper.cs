using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;
using System.IO;
namespace WebserviceCustomer
{
    public static class FibonacciService
    {

        public static Task<int> CallFubonacciWebService(int param)
        {
            var url = "https://localhost:44369/FibonacciService.asmx";
            var action = "http://tempuri.org/calcul";
            return Task.Run(() =>
            {
                XmlDocument soapEnvelopeXml = CreateSoapEnvelope(param);
                HttpWebRequest webRequest = CreateWebRequest(url, action);

                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                // begin async call to web request.
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                // suspend this thread until call is complete. You might want to
                // do something usefull here like update your UI.
                asyncResult.AsyncWaitHandle.WaitOne();

                // get the response from the completed web request.
                string soapResult = null;
                try {
                    using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                    {
                        using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                        {
                            soapResult = rd.ReadToEnd();
                        }
                        Console.Write(soapResult);
                    }
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var e = reader.ReadToEnd();
                        Console.WriteLine(e);

                    }
                    throw;
                }
                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(soapResult);
                return int.Parse(doc.DocumentElement.SelectSingleNode("/").InnerText);

            });
            
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(int param)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                + "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">"
                +"   <soap:Body>"
                + "    <calcul xmlns=\"http://tempuri.org/\">"
                 +"     <n>"+ param + "</n>"
                 + "   </calcul>"
                 + " </soap:Body>"
               + " </soap:Envelope>";
            soapEnvelopeDocument.LoadXml(xml);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
