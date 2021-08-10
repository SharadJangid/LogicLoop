using LogicLoopTaskAPI.Filters;
using LogicLoopTaskAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogicLoopTaskAPI.Controllers
{
    [BasicAuthentication]
    public class TaskController : ApiController
    {
        [HttpGet]
        [Route("todo/api/v1.0/tasks")]
        public IEnumerable<dynamic> gettask([FromBody] Task _objpro)
        {
            // get the list of the responses for the supplied parameters
            Task obj = new Task();
            if (_objpro != null)
            {

                obj.id = _objpro.id;
            }

            List<dynamic> _listProd = new List<dynamic>();
            obj.GetApiTaskData(ref _listProd, obj);
            return _listProd;
        }

        [HttpPost]
        [Route("todo/api/v1.0/tasks")]
        public IEnumerable<string> addupdateproduct([FromBody] Task _objpro)
        {
            Task obj = new Task();
            List<string> ProductId = new List<string>();
            if (_objpro != null)
            {

                obj.id = _objpro.id;
                obj.title = _objpro.title;
                obj.description = _objpro.description;
            
                _objpro.AddEditDeleteTaskData(ref ProductId, _objpro);
                return ProductId;
            }

            return ProductId;

        }

        [HttpDelete]
        [Route("todo/api/v1.0/tasks")]
        public IEnumerable<string> deleteproduct([FromBody] Task _objpro)
        {
            Task obj = new Task();
            List<string> ProductId = new List<string>();
            if (_objpro != null)
            {

                obj.id = _objpro.id;
                _objpro.DeleteTaskData(ref ProductId, _objpro);

            }
                     
            return ProductId;
        }

    }
}
