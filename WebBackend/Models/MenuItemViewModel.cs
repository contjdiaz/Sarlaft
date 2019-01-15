using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBackend.Models
{
    public class MenuItemViewModel
    {
        public int IdMenu { get; set; }
        public int IdMenuPadre { get; set; }
        public string Menu { get; set; }
        public string Url { get; set; }
    }
}