using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoneywellHackathon.Models
{
    public class Filter
    {
        public int Id { get; set; }
        public FilterConditionEnum FilterCondition { get; set; }
        public int Offset { get; set; }
    }
}