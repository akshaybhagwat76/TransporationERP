using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TransportationERP.dal.Model;

namespace TransportationERP.DAL.Model
{
    public class TransectionSetting
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("Transportation_Location")]
        public int? LocationID { get; set; }
        //[ForeignKey("Transportation_Commodities")]
        public int? CommodityID { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        //public TransportationLocation Transportation_Location { get; set; }
        //public TransportationCommodity Transportation_Commodities { get; set; }

    }
}
