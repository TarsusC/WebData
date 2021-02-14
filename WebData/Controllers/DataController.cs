using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebData.Models;

namespace WebData.Controllers
{
    public class DataController : ApiController
    {
            List<string> response = new List<string>();
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

        public IHttpActionResult Get()
        {
            int orderNumber = 0;

            using (DataContext db = new DataContext())
            {
                var query = from result in db.Dates
                            select result;

                foreach (var item in query)
                {
                    response.Add($"{++orderNumber})  {item.StartDate.ToString("yyyy-MM-dd")} / {item.EndDate.ToString("yyyy-MM-dd")}");
                }
                return Ok(response);
            }
        }
        public IHttpActionResult Post([FromBody] string incomingString)
            {
                int orderNumber = 0;
                (startDate, endDate) = ParseIncomingString(incomingString);

                using (DataContext db = new DataContext())
                {
                    var query = from result in db.Dates
                                where (result.StartDate >= startDate && result.EndDate <= endDate) ||
                                       (result.EndDate >= startDate && result.EndDate <= endDate)
                                select result;

                    foreach (var item in query)
                    {
                        response.Add($"{++orderNumber})  {item.StartDate.ToString("yyyy-MM-dd")} / {item.EndDate.ToString("yyyy-MM-dd")}");
                    }
                }
            return Ok(response);
            }

            public IHttpActionResult Put([FromBody] string incomingString)
            {
                (startDate, endDate) = ParseIncomingString(incomingString);
                using (DataContext db = new DataContext())
                {
                    db.Dates.Add(new Data { StartDate = startDate, EndDate = endDate });
                    db.SaveChanges();
                    return Ok();
                }
            }
            private (DateTime, DateTime) ParseIncomingString(string incomingString)
            {
                int start = 0;
                int end = 1;
                string[] words = incomingString.Split('/');
                return (DateTime.Parse(words[start].Trim()), DateTime.Parse(words[end].Trim()));
            }
    }
}
