using System;
using System.Collections.Generic;

#nullable disable

namespace TransportationERP.dal.Model
{
    public partial class TransactionOtherPicture
    {
        public string AccountId { get; set; }
        public string TicketNumber { get; set; }
        public string PictureId { get; set; }
        public string ThumbnailUrl { get; set; }
        public string FullResUrl { get; set; }
    }
}
