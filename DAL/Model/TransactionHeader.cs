using System;
using System.Collections.Generic;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class TransactionHeader
    {
        public string AccountId { get; set; }
        public string TicketNumber { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? TicketDate { get; set; }
        public string PaymentTerms { get; set; }
        public string SupplierTicket { get; set; }
        public string CarrierTicket { get; set; }
        public string TruckDescription { get; set; }
        public string Status { get; set; }
        public string PaymentReceiptUrl { get; set; }
    }
}
