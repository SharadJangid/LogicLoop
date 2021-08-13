using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace LogicLoopCurrencyConversion.Models
{
    public class CurrencyConverter
    {
        public string qty { get; set; }
        public string baseCurr { get; set; }
        public string reqCurr { get; set; }
        public string converted_Price { get; set; }

        public List<CurrencyConverter> _listTask { get; set; }

        public void GetApiCurrencyConverterData(ref List<dynamic> _list, CurrencyConverter _objProParameter)
        {

            DataSet ds = new DataSet();
            SqlParameter[] oparam = new SqlParameter[3];

            oparam[0] = new SqlParameter("@call", _objProParameter.baseCurr);
            oparam[1] = new SqlParameter("@req", _objProParameter.reqCurr);
            oparam[2] = new SqlParameter("@qty", _objProParameter.qty);

            try
            {
                ds = SqlHelper.ExecuteDataset(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "llp_curr_convert_select", oparam);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtAPIUser = ds.Tables[0];
                        if (dtAPIUser.Rows.Count > 0)
                        {
                            foreach (DataRow drApplicant in dtAPIUser.Rows)
                            {
                                //this code is used for creating dynamic property according to database column name
                                // property name will be same as column name as per store procedure
                                dynamic apiUserLoginData = new ExpandoObject();
                                foreach (DataColumn dc in dtAPIUser.Columns)
                                {
                                    var expandoAPIUserLoginDic = apiUserLoginData as IDictionary<string, object>;
                                    expandoAPIUserLoginDic.Add(dc.ToString(), Convert.ToString(drApplicant[dc]));
                                }
                                _list.Add(apiUserLoginData);

                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}