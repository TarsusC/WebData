using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Collections.Generic;
using System.Linq;

namespace WebConsole.CRUD
{
    class PutAction
    {
        List<string> data = new List<string>();
        public List<string> Call(string rangeDates)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PutAsync<string>(Program.APP_PATH, rangeDates, new JsonMediaTypeFormatter()).Result;

                if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                {
                    Program.Messages("Range was added.");
                }
                else 
                {
                    Program.Messages(response.StatusCode.ToString());
                }
            }
            catch(Exception exception)
            {
                Program.Messages(exception.InnerException.InnerException.Message);
            }
            
            return data;
        }

    }
}
