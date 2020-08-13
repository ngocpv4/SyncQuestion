using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class OrganizationResponseVM
    {
        public int web_id { get; set; }
        public string name { get; set; }
        public int status { get; set; }
    }
}