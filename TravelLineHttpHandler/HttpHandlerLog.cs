using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelLineHttpHandler
{
    public class HttpHandler
    {
        HttpResult _currentLog;
        public HttpResult CurrentLog { get { return _currentLog; } }

        public string Process(string url, string body, string response, params string[] secureParam)
        {
            var httpResult = new HttpResult
            {
                Url = url,
                RequestBody = body,
                ResponseBody = response
            };

            //очищаем secure данные в httpResult, либо создаем новый clearedHttpResult на основе httpResult

            ClearedHttp clHttp = new ClearedHttp();
            HttpResult clearedHttpResult = new HttpResult
            {
                Url = clHttp.SecureDataClear(url, secureParam),
                RequestBody = clHttp.SecureDataClear(body, secureParam),
                ResponseBody = clHttp.SecureDataClear(response, secureParam)
            };


            Log(clearedHttpResult);

            return response;
        }

        /// <summary>
        /// Логирует данные запроса, они должны быть уже без данных которые нужно защищать 
        /// </summary>
        /// <param name="result"></param>
        protected void Log(HttpResult result)
        {
            _currentLog = new HttpResult
            {
                Url = result.Url,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }
    }
}

