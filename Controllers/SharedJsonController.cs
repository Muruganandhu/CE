using ChitEngine.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChitEngine.Controllers
{
    public class SharedJsonController : ApiController
    {
        // GET api/sharedjson
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
      /// <summary>
      /// 
      /// </summary>
        public void SendSMS()
        {
            string requestUriString = string.Format("https://gallapetti.000webhostapp.com/sendsms.php?uid={0}&pwd={1}&phone={2}&msg={3}","9600214140","Sowmiya","9600214140","Test SMS from Chit engine");
            WebRequest request = WebRequest.Create(requestUriString);
            WebResponse myWebResponse = request.GetResponse();
        }
       
        
    }
}
