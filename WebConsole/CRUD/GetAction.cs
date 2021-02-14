﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WebConsole.CRUD
{
    class GetAction
    {
        List<string> data = new List<string>();
        public List<string> Call()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(Program.APP_PATH).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    data = response.Content.ReadAsAsync<List<string>>().Result;
                }
                else
                {
                    Program.Messages(response.StatusCode.ToString());
                }

            }
            catch (Exception exception)
            {
                Program.Messages(exception.InnerException.InnerException.Message);
            }
            return data;
        }
    }
}