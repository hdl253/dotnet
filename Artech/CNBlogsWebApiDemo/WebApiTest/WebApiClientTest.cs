using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CNBlogsWebApiDemo.ViewModels;

namespace WebApiClientTest
{
    public class WebApiClientTest
    {
        [Fact]
        public void WebApi_SiteList_Test()
        {
            var requestJson = JsonConvert.SerializeObject(new { startId = 1, itemcount = 3 });

            HttpContent httpContent = new StringContent(requestJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClient = new HttpClient();
            var responseJson = httpClient.PostAsync("http://localhost:9000/api/demo/sitelist", httpContent)
                .Result.Content.ReadAsStringAsync().Result;

            var sites = JsonConvert.DeserializeObject<IList<Site>>(responseJson);

            sites.ToList().ForEach(x => Console.WriteLine(x.Title + "：" + x.Uri));
        }
    }
}
