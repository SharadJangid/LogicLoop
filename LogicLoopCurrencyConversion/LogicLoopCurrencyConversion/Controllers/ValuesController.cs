using LogicLoopCurrencyConversion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogicLoopCurrencyConversion.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("from-curr/from-curr-amt/to-curr")]
        public IEnumerable<dynamic> getprice([FromBody] CurrencyConverter _objpro)
        {
            // get the list of the responses for the supplied parameters
            CurrencyConverter obj = new CurrencyConverter();
            if (_objpro != null)
            {
                obj.baseCurr = _objpro.baseCurr;
                obj.qty = _objpro.qty;
                obj.reqCurr = _objpro.reqCurr;
            }

            List<dynamic> _listProd = new List<dynamic>();
            obj.GetApiCurrencyConverterData(ref _listProd, obj);
            return _listProd;
        }
    }
}
