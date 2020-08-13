using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class Link
    {
        public string next { get; set; }
        public bool? previous { get; set; }
    }
}