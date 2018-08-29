using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TonerViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ClientId { get; set; }
    }
}