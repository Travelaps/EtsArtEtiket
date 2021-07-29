using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnStile.BAL
{
    public static class GetDevices
    {
        public static JObject GetDevicesJSON(string loginToken)
        {
            JObject obj = new JObject();
            obj["Action"] = "Select";
            obj["Object"] = "HOTEL_TURNSTILE";
            obj["LoginToken"] = loginToken;

            var where = new JArray();
            obj["Where"] = where;

            var Paging = new JObject();
            Paging["Current"] = 1;
            Paging["ItemsPerPage"] = 1000;


            obj["Paging"] = Paging;

            var OrderBy = new JArray();
            obj["OrderBy"] = OrderBy;
            var OrderBy2 = new JObject();
            OrderBy2["Column"] = "NAME";
            OrderBy2["Direction"] = "ASC";
            OrderBy.Add(OrderBy2);

            /* var where1 = new JObject();
             where1["Column"] = "STOCKTYPE";
             where1["Operator"] = "=";
             where1["Value"] = "1";*/

            //var where2 = new JObject();

            //if (FicheId != null)
            //{
            //    where2["Column"] = "FICHEID";
            //    where2["Operator"] = "=";
            //    where2["Value"] = FicheId;
            //    where.Add(where2);
            //}
            //where.Add(where1);

            return obj;
        }

        public static List<MODEL.Turnstile> GetAllDevices(DAL.Nodejs api)
        {
            var json = GetDevices.GetDevicesJSON(api.LoginToken);
            var dataset = api.GetDataSet(json);
            DataTable dt = dataset.Tables["datatable1"];

            List<MODEL.Turnstile> list = new List<MODEL.Turnstile>();

            if (dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    MODEL.Turnstile a = new MODEL.Turnstile();
                    a.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    a.NAME = dt.Rows[i]["NAME"].ToString();
                    a.IPNUMBER = dt.Rows[i]["IPNUMBER"].ToString();
                    a.PORTNUMBER = dt.Rows[i]["PORTNUMBER"].ToString();
                    try
                    {
                        a.ISENTRANCE = Convert.ToBoolean(dt.Rows[i]["ISENTRANCE"].ToString());
                    }
                    catch (Exception)
                    {
                        a.ISENTRANCE = null;
                    }

                    try
                    {
                        a.HASOWNREADER = Convert.ToBoolean(dt.Rows[i]["HASOWNREADER"].ToString());
                    }
                    catch (Exception)
                    {
                        a.HASOWNREADER = false;
                    }

                    a.READER_ENTRY_COMPORT = dt.Rows[i]["READER_ENTRY_COMPORT"].ToString();
                    a.READER_EXIT_COMPORT = dt.Rows[i]["READER_EXIT_COMPORT"].ToString();

                    list.Add(a);
                }
            return list;
        }
    }
}
