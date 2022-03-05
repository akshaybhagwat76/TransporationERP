using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationERP.ViewModel
{
    public class ResponceVM
    {
        public bool status { get; set; }
        public int statusCode { get; set; }
        public string discription { get; set; }
        public string data { get; set; }
    }
    public class StatusCode
    {
        public static int Ok = 200;
        public static int BadRequest = 500;
      
    }

}
