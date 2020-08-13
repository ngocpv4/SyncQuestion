using Newtonsoft.Json;
using QuestionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace QuestionAPI.Controllers
{
    [RoutePrefix("api/SyncQuestion")]
    public class SyncQuestionController : ApiController
    {
        // GET: api/SyncQuestion/GetListQuestion
        /// <summary>
        /// Lấy danh sách câu hỏi tạo mới trên App Người Dân
        /// </summary>
        /// <param name="topnumber">số lượng bản ghi cần lấy </param>
        /// <param name="lastupdate">Lấy số lượng “topnumber” các câu hỏi có thời gian tạo hơn lastupdate,  => mỗi lần gọi api xong phía cổng cần lưu lại thời gian tạo của câu hỏi mới nhất, chưa từng lưu cần truyền 0</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetListQuestion")]
        public async Task<HttpResponseMessage> GetListQuestion(int topnumber = 5, long lastupdate = 0)
        {
            // apiUrl trên môi trường dev
            string apiUrl = $"http://haiduong.tetvietaic.com/api/service/questions?last_update={lastupdate}&top_number={topnumber}";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // SERVERCRSAPIKEY trên môi trường dev
                client.DefaultRequestHeaders.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                var data = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var results = JsonConvert.DeserializeObject<ResultSuccess<QuestionListVM>>(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = 200,
                        data = results
                    });
                }
                else
                {
                    var results = JsonConvert.DeserializeObject<ResultError>(data);
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = results.error.code,
                        message = results.error.message,
                        data = results.error.data
                    });
                }
            }
        }

        //// POST: api/SyncQuestion/PostOrganization
        /// <summary>
        /// Thêm, cập nhật danh sách đơn vị trả lời lên app
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostOrganization")]
        public async Task<HttpResponseMessage> PostOrganization([FromBody]List<OrganizationRequestVM> organizations)
        {
            // apiUrl trên môi trường dev
            string apiUrl = "http://haiduong.tetvietaic.com/api/service/question/organization/create";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // SERVERCRSAPIKEY trên môi trường dev
                client.DefaultRequestHeaders.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");
                string json = string.Empty;

                if (organizations != null)
                {
                    json = JsonConvert.SerializeObject(organizations);
                }
                else
                {
                    json = JsonConvert.SerializeObject(new { });
                }

                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);
                var data = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var results = JsonConvert.DeserializeObject<ResultSuccess<OrganizationResponseVM>>(data);
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = 200,
                        data = results.results.data
                    });
                }
                else
                {
                    var results = JsonConvert.DeserializeObject<ResultError>(data);
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = results.error.code,
                        message = results.error.message,
                        data = results.error.data
                    });
                }
            }
        }

        //// POST: api/SyncQuestion/PostQuestion
        /// <summary>
        /// Thêm mới, cập nhật danh sách câu hỏi, trả lời lên app
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostQuestion")]
        public async Task<HttpResponseMessage> PostQuestion([FromBody]List<QuestionCreateRequestVM> questions)
        {
            // apiUrl trên môi trường dev
            string apiUrl = "http://haiduong.tetvietaic.com/api/service/question/create";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // SERVERCRSAPIKEY trên môi trường dev
                client.DefaultRequestHeaders.Add("SERVERCRSAPIKEY", "f07e79e7-6176-4587-8020-a8e8113324dd");
                string json = string.Empty;

                if (questions != null)
                {
                    json = JsonConvert.SerializeObject(questions);
                }
                else
                {
                    json = JsonConvert.SerializeObject(new { });
                }

                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);
                var data = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var results = JsonConvert.DeserializeObject<ResultSuccess<QuestionCreateResponseVM>>(data);
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = 200,
                        data = results.results.data
                    });
                }
                else
                {
                    var results = JsonConvert.DeserializeObject<ResultError>(data);
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        code = results.error.code,
                        message = results.error.message,
                        data = results.error.data
                    });
                }
            }
        }
    }
}