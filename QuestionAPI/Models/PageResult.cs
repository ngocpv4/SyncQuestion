using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class PageResult<T>
    {
        public Link links { get; set; }
        public int total_items { get; set; }
        public int item_per_page { get; set; }
        public List<T> data { get; set; }
    }
}