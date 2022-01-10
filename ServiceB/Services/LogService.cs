using ServiceB.Dtos;
using ServiceB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceB.Services
{
    public class LogService : ILogService
    {
        public void Save_Exception_Log_To_ExceptionLogDb(ExceptionModel model)
        {
            try
            {
                using (var client =new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                    //client.DefaultRequestHeaders.Add("authorization", TokenType() + " " + token);
                    string dataurl = ReturnRestApiUrl() + "/exLog/Log/SaveExceptionLog";
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(dataurl, data).Result;
                    string stringData = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ReturnRestApiUrl()
        {
            return "http://localhost:5000";
        }
    }
}
