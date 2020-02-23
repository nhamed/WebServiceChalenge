using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace SoapChallenge
{
    /// <summary>
    /// Description résumée de XmlToJsonService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class XmlToJsonService : System.Web.Services.WebService
    {

        [WebMethod]
        public string CovertXmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
                return JsonConvert.SerializeXmlNode(doc);
            }
            catch (XmlException)
            {
                return "Bad Xml format";
            }

        }
    }
}
