using System.Collections.Generic;
using System.IO;
using System.Net;
using Foundation.Models;
using Newtonsoft.Json;

namespace TresDivas.SocialInteractions.Processing
{
    public class Filters
    {
        public static List<Twitter_UT_Filters> GetFilters()
        {
            var filters = new List<Twitter_UT_Filters>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ut.hackathon.com/api/sitecore/TwitterFilterApi");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var responseStream = httpResponse.GetResponseStream();
            if (responseStream == null)
            {
                return filters;
            }

            using (var streamReader = new StreamReader(responseStream))
            {
                var responseText = streamReader.ReadToEnd();
                var response = JsonConvert.DeserializeObject<FiltersResponse>(responseText);
                filters = response.Response;
            }

            return filters;
        }
    }

    public class FiltersResponse
    {
        public FiltersResponse()
        {
            Response = new List<Twitter_UT_Filters>();
        }

        public List<Twitter_UT_Filters> Response { get; set; }

        public bool Success { get; set; }
    }
}
