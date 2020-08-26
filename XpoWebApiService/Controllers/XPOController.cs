using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace XpoWebApi {

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class XPOController : ControllerBase {
        private static  WebApiHelper webHelper;
        public XPOController(IDataStore dataStore) {
            webHelper = new WebApiHelper(dataStore);
        }

        [HttpPost("{method}")]
        public ActionResult<string> Post(string method, [FromBody]string args) {
            return webHelper.Handle(method, args);      
        }
    }    
}