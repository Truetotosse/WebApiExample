using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using System.Text.Json;
using System.Diagnostics;

namespace WebApiService.Controller {


    [Route("api/[controller]")]
    [ApiController]
    public class XPOController : ControllerBase {
       
        static IDataStore dataStore = new InMemoryDataStore();
        static IDataLayer dataLayer = new SimpleDataLayer(dataStore);
        static UnitOfWork uow = new UnitOfWork(dataLayer);
        [HttpPost("modifydataasync")]
        public ActionResult<ModificationResult> Modify( [FromBody] ModificationStatement[] args) {
            
            return dataStore.ModifyData(args);

        }
        [HttpPost("selectdataasync")]
        public ActionResult<SelectedData> Select([FromBody] SelectStatement[] args) {

            return dataStore.SelectData(args);

        }
        [HttpPost("updateschema/{boolArg:bool}")]
        public ActionResult<UpdateSchemaResult> UpdateT(bool boolArg, [FromBody] DBTable[] args) {
            
            return dataStore.UpdateSchema(boolArg,args);

        }
       
    }
}
