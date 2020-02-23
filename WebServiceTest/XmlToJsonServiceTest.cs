using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using Xunit;

namespace WebServiceTest
{
    public class XmlToJsonServiceTest
    {
        [Theory]
        [InlineData("<foo>bar</foo>")]
        [InlineData("<foo>hello</bar>")]
        public void ConvertXmlToJson(string xml)
        {
            HttpWebRequest request = HttpWebRequest.Create("https://localhost:44369/XmlToJsonService.asmx") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            Encoding e = Encoding.GetEncoding("iso-8859-1");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string rawXml = doc.OuterXml;

            // you need to encode your Xml before you assign it to your parameter
            // the POST parameter name is myxmldata
            string requestText = string.Format("myxmldata={0}", HttpUtility.UrlEncode(rawXml, e));

            Stream requestStream = request.GetRequestStream();
            StreamWriter requestWriter = new StreamWriter(requestStream, e);
            requestWriter.Write(requestText);
            requestWriter.Close();

        }
    }
}
