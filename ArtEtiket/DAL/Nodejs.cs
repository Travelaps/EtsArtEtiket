using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
namespace ArtEtiket.DAL
{
    public class Nodejs
    {

        public string ENDPOINTURL { get; set; } = "https://4001.hoteladvisor.net/";

        public string LoginToken { get; set; }
        public string HotelId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
         
        public  System.Data.DataSet GetDataSet(Newtonsoft.Json.Linq.JObject obj, string ActionType = "Select")
        {
            var data = post(obj.ToString());

            bool LoginOl = ((data == "401") || (data.Contains("not found") || data.Contains("LoginToken"))  || data.Contains("LoginToken is invalid"));

            if (LoginOl==true)
            {
                Login();
                data = post(obj.ToString());
            }
            
            var datasource = new JObject();

            if (ActionType == "Select")
            {
                if (!data.Contains("{") || !data.Contains("}"))
                {
                    System.Windows.Forms.MessageBox.Show(data.ToString(), "ElektraWeb", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    throw null;
                   
                }
                JArray dataSets = new JArray();
                dataSets = (JArray)JObject.Parse(data)["ResultSets"];

                datasource["datatable1"] = JObject.Parse(data)["ResultSets"][0];
            }
            else if (ActionType=="Execute")
            {
                if (!data.Contains("]") || !data.Contains("["))
                {
                    System.Windows.Forms.MessageBox.Show(data.ToString(),"ElektraWeb",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                    throw null;
                }
                JArray dataSets = new JArray();
                dataSets = JArray.Parse(data);
                var _obj = JArray.Parse(data);  
                datasource["datatable1"] = _obj[0]; //JObject.Parse(data)[0];
            }


            var datasourceStr = Newtonsoft.Json.JsonConvert.SerializeObject(datasource, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
            System.Data.DataSet dataset = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataSet>(datasourceStr);
            return dataset;

            //System.Data.DataTable datatable = dataset.Tables["datatable1"];
        }


        public    string post(string requestBody, string urlPostFix = "")
        {
            string responseBody = null;

            if (ENDPOINTURL.StartsWith("https"))
            {
                ServicePointManager.Expect100Continue = true;
                //(SecurityProtocolType)12288 | 
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;//TLS1.2;
                ServicePointManager.DefaultConnectionLimit = 9999;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            }

            var newRequest = WebRequest.Create(ENDPOINTURL + urlPostFix);
            HttpWebRequest request = (HttpWebRequest)newRequest;
            //2017-08-07:OGUZ
            request.Host = ENDPOINTURL.Replace("https://", "").Replace("http://", "").Split('/')[0]; //.NET FRAMEWORK BUG, see https://referencesource.microsoft.com/#System/net/System/Net/HttpWebRequest.cs,15b3b0da6dac6d63
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.AllowAutoRedirect = true;
            request.MaximumAutomaticRedirections = Int32.MaxValue;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 60000;
            request.ReadWriteTimeout = 60000;
            request.KeepAlive = false;

            if (requestBody != null)
            {
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);
                using (var outStream = request.GetRequestStream())
                {
                    outStream.Write(requestData, 0, requestData.Length);
                    outStream.Close();
                }
            }

            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

            //Try To Retrieve The Result
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var rdr = new System.IO.StreamReader(response.GetResponseStream(), encode))
                        responseBody = rdr.ReadToEnd();
                    response.Close();
                }
            }
            catch (WebException exc)
            {
                using (var response = (System.Net.HttpWebResponse)exc?.Response)
                {
                    //if Connection not Closed
                    if (response != null)
                    {
                        //2020-06-25:OGUZ:401 HATASI ALDIYSAK TEKRAR LOGIN OLMALIYIZDIR
                        //if (response?.StatusCode == HttpStatusCode.Unauthorized)
                        //    LastLogin = DateTime.Parse("2000-01-01");

                        using (var data = response.GetResponseStream())
                        using (var reader = new System.IO.StreamReader(data))
                            responseBody = reader.ReadToEnd();

                        response.Close();
                    }
                }

            }

            request.Abort();
            return responseBody;
        }

        public bool Login()
        {
            var loginResp = post(@"{ ""Action"":""Login"", ""Tenant"":""16534"", ""Usercode"":""ENTEGRASYON"", ""Password"":""123456aA.""}");
            //var loginResp = post(@"{ ""Action"":""Login"", ""Tenant"":""18892"", ""Usercode"":""demo"", ""Password"":""123""}");
            var Success = (bool)JObject.Parse(loginResp)["Success"];
            string token = "";
            if (Success == true)
            {
                token = (string)JObject.Parse(loginResp)["LoginToken"];
                LoginToken = token;
                return true;
            }
            return false;
             
        }


        
        /*
         var loginResp = post(@"{ ""Action"":""Login"", ""Tenant"":""18892"", ""Usercode"":""demo"", ""Password"":""123""}");
            var token = (string)JObject.Parse(loginResp)["LoginToken"];

            JObject obj = new JObject();
            obj["Action"] = "Select";
            obj["Object"] = "RES";
            obj["LoginToken"] = token;

            var where = new JArray();
            obj["Where"] = where;

            var where1 = new JObject();
            where1["Column"] = "CITARIHI";
            where1["Operator"] = ">";
            where1["Value"] = "2020-01-01";
            where.Add(where1);

            var data = post(obj.ToString());

            var datasource = new JObject();
            datasource["datatable1"] = JObject.Parse(data)["ResultSets"][0];

            var datasourceStr = Newtonsoft.Json.JsonConvert.SerializeObject(datasource, new Newtonsoft.Json.JsonSerializerSettings{NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore});
            System.Data.DataSet dataset = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataSet>(datasourceStr);
            System.Data.DataTable datatable = dataset.Tables["datatable1"];

            Console.WriteLine(data);
         
         */
    }
}
