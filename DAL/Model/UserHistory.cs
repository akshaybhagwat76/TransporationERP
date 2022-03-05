using System;
using System.Collections.Generic;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class UserHistory
    {
        public int? UserId { get; set; }
        public DateTime? EventDate { get; set; }
        public string Ip { get; set; }
        public string EventType { get; set; }
        public string Details { get; set; }
    }
}
