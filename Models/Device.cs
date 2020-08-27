using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoneywellHackathon.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public Filter Filter { get; set; }
    }
}