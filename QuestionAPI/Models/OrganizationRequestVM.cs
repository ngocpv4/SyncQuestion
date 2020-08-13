using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAPI.Models
{
    public class OrganizationRequestVM
    {
        //ID định danh
        public string id { get; set; }

        //Tên đơn vị
        public string name { get; set; }

        //1: active
        //0: inactive
        public string status { get; set; }
    }
}