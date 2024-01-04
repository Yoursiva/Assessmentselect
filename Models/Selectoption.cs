using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assessmentselect.Models
{
    public class Selectoption
    {
        public int id { get; set;}
        public string area { get; set;}
        public string section { get; set;}
        public string subsection {
            get; set;
        }
        public string question { get; set; }
    }
}