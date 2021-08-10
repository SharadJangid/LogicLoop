using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace LogicLoopTaskAPI.Models
{
    public class Task
    {
        public Task() { }

        #region Params
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Boolean done { get; set; }

        public List<Task> _listTask { get; set; }

        #endregion
        #region function
        public void GetApiTaskData(ref List<dynamic> _list, Task _objProParameter)
        {

            DataSet ds = new DataSet();
            SqlParameter[] oparam = new SqlParameter[1];

            oparam[0] = new SqlParameter("@id", _objProParameter.id);
           
            try
            {
                ds = SqlHelper.ExecuteDataset(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "llp_task_select", oparam);

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

        public List<string> AddEditDeleteTaskData(ref List<string> pro, Task _objProParameter)
        {
            SqlParameter[] oParam = new SqlParameter[3];

            oParam[0] = new SqlParameter("@id", _objProParameter.id);
            oParam[1] = new SqlParameter("@title", _objProParameter.title);
            oParam[2] = new SqlParameter("@description", _objProParameter.description);        

            try
            {
                SqlHelper.ExecuteNonQuery(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[llp_task_insert_update]", oParam);
                pro.Add("Done");
                return pro;
            }
            catch (Exception ex)
            {
                pro.Add("Error! Something went wrong");
                return pro;
            }
        }
        public List<string> DeleteTaskData(ref List<string> pro, Task _objProParameter)
        {
            SqlParameter[] oParam = new SqlParameter[1];

            oParam[0] = new SqlParameter("@id", _objProParameter.id);
          
            try
            {
                SqlHelper.ExecuteNonQuery(AppConfig.GetConnectionString(), CommandType.StoredProcedure, "[llp_task_delete]", oParam);
                pro.Add("Deleted");
                return pro;
            }
            catch (Exception ex)
            {
                pro.Add("Error! Something went wrong");
                return pro;
            }
        }


        #endregion
    }
}