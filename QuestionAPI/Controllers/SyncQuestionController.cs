using Newtonsoft.Json;
using QuestionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuestionAPI.Controllers
{
    public class SyncQuestionController : ApiController
    {
        // GET: SyncQuestion
        [HttpGet]
        public async Task<HttpResponseMessage> GetListQuestion(int topnumber = 10, long? lastupdate = null)
        {
            string apiUrl = "http://haiduong.tetvietaic.com/api/service/questions";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<Result<Question>>(data);
                    var questions = results;
                    if (lastupdate != null)
                    {
                        questions.results.data = questions.results.data.Where(x => x.updated_at > lastupdate).OrderByDescending(x => x.updated_at).ToList();
                    }

                    questions.results.data = questions.results.data.Take(topnumber).ToList();
                    questions.results.total_items = questions.results.data.Count();

                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = 200,
                        data = questions
                    });
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, new
            {
                code = 404
            });
        }

        [HttpPost()]
        public async Task<HttpResponseMessage> PostOrganization([FromBody]List<Organization> organization)
        {
            string apiUrl = "http://haiduong.tetvietaic.com/api/service/question/organization/create";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");
                string json = JsonConvert.SerializeObject(organization);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = 200
                    });
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new
            {
                code = 400
            });
        }
    }
}