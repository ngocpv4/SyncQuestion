using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<dynamic> data { get; set; }
    }
}