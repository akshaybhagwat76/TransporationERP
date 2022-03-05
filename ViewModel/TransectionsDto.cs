using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportationERP.ViewModel
{
    public class SimpleDropDownDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class TransportationFormInitialDto
    {
        public List<SimpleDropDownDto> TransportationCommodities { get; set; }
        public List<SimpleDropDownDto> TransportationLocations { get; set; }

    }
    public class SaveTransportationData
    {
        public string user_id { get; set; }
        public string locations { get; set; }
        public string commodities { get; set; }
        public string notes { get; set; }
    }


    public class TransectionsListDT
    {
        public string ticket_no { get; set; }
        public string date { get; set; }
        public string weight { get; set; }
        public string commodity { get; set; }

    }

    public class TicketDetailsDto
    {
        public string ticket_no { get; set; }
        public string date { get; set; }
        public string order_no { get; set; }
        public string truck_description { get; set; }
        public string spplier_ticket_no { get; set; }
        public string payment_terms { get; set; }
        public string status { get; set; }
        public List<ScalePicturesDto> scalePictures { get; set; }
        public List<TicketDetailsBodyDto> TicketDetailsBodyDtos { get; set; }
        public List<ReceivedPaperworkDto> receivedPaperwork { get; set; }
        public List<OtherPicturesDto> otherPictures { get; set; }
    }

    public class ScalePicturesDto
    {
        public string thumbnail_picture { get; set; }

    }
    public class ReceivedPaperworkDto
    {
        public string thumbnail_url { get; set; }


    }
    public class OtherPicturesDto
    {
        public string thumbnail_url { get; set; }


    }


    public class TicketDetailsBodyDto
    {
        public string item_name { get; set; }
        public string gross_weight { get; set; }
        public string tare_weight { get; set; }
        public string net_weight { get; set; }
        public string unit_price { get; set; }
        public string total_price { get; set; }
      

    }




}
