using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnStile.BAL
{
    public static class CheckBarcode
    {
        public static JObject CheckBarcodeJSON(string barcode, string loginToken)
        {
            JObject obj = new JObject();
            obj["Action"] = "Execute";
            obj["Object"] = "SP_CHARGEENTRANCE_TOFOLIO";
            obj["LoginToken"] = loginToken;

            var Parameters = new JObject();


            //var Parameters1 = new JObject();
            Parameters["CARDNO"] = barcode;
            Parameters["TIMEDUMMY"] = DateTime.UtcNow.ToString("HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);

            obj["Parameters"] = Parameters;

            //Parameters.Add(Parameters1);

            // Parameters = Parameters1;
            return obj;
        }


        public static MODEL.Result CheckBarcodeForEntry(string barcode,DAL.Nodejs api)
        {
            MODEL.Result result = new MODEL.Result();

            var json = CheckBarcode.CheckBarcodeJSON(barcode, api.LoginToken);
            var dataset = api.GetDataSet(json,"Execute");
            DataTable dt = dataset.Tables["datatable1"];

            if (dt.Rows.Count > 0)
            {
                result.Success = Convert.ToBoolean(dt.Rows[0]["SUCCESS"]);
                result.Message = dt.Rows[0]["MESSAGE"].ToString();
            }
            else
            {
                result.Success = false;
                result.Message = "Procedure did not returned any message";
            }
            return result;
        }
    }
}
