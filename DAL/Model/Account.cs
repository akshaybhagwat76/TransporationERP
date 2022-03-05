using System;
using System.Collections.Generic;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class Account
    {
        public string AccountId { get; set; }
        public string Representative { get; set; }
        public bool? IncludeTransportation { get; set; }
    }
}
