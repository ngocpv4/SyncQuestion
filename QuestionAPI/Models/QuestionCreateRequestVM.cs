using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class QuestionCreateRequestVM
    {
        public long id { get; set; }
        public int type { get; set; }
        public int app_id { get; set; }
        public int status { get; set; }
        public int organization_id { get; set; }
        public string full_name { get; set; }
        public string address { get; set; }
        public string card_id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public List<AnswerQ> answers { get; set; }
        public long created_at { get; set; }
        public long last_update_time { get; set; }
    }
}