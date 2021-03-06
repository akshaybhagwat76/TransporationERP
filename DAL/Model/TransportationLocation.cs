using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class TransportationLocation
    {
        //[Key]
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        //[ForeignKey("Accounts")]
        public string AccountID { get; set; }
        //public Accounts Accounts { get; set; }
    }
}
