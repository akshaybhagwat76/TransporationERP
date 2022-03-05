using System;
using System.Collections.Generic;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class TransactionDetail
    {
        public string AccountId { get; set; }
        public string TicketNumber { get; set; }
        public int? DetailId { get; set; }
        public int? Gross { get; set; }
        public int? Tare { get; set; }
        public int? Net { get; set; }
        public decimal? UnitCost { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
