using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SoapChallenge
{
    /// <summary>
    /// Description résumée de Fibonacci
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class FibonacciService : System.Web.Services.WebService
    {

        [WebMethod]
        public int calcul(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n < 1 || n> 100) return -1;           
            return calcul(n - 1) + calcul(n - 2);
        }
    }
}
