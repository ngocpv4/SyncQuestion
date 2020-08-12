using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class Result<T>
    {
        public PageResult<T> results { get; set; }
    }
}