using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class TransportationCommodity
    {
        //[Key]
        public int CommodityID { get; set; }


        //[ForeignKey("Accounts")]
        public string AccountID { get; set; }
        //[ForeignKey("Transportation_Location")]
        public int? LocationID { get; set; }
        public string Commodity_Name { get; set; }
        //public TransportationLocation Transportation_Location { get; set; }
        //public Accounts Accounts { get; set; }
    }
}
