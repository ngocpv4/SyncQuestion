using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class AnswerQ
    {
        public int id { get; set; }
        public int? organization_id { get; set; }
        public string answer { get; set; }
        public long created_at { get; set; }
    }
}