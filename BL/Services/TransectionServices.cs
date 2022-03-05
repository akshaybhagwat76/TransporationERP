using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationERP.BL.Repository;
using TransportationERP.dal.Model;
using TransportationERP.ViewModel;

namespace TransportationERP.BL.Services
{
    public class TransectionServices : ITransection
    {
        private MMS_WebContext _db;
        public TransectionServices(MMS_WebContext db)
        {
            _db = db;
        }
        public string GetAccountID(string user_id)
        {
            var UserID = Convert.ToInt32(user_id);
            var user = _db.Users.FirstOrDefault(a => a.UserId == UserID);
            if (user != null)
            {
                return user.AccountId;
            }
            return null;
            
        }

        public TicketDetailsDto GetDetailsOfTicket(string ticket_no)
        {
            var details = _db.TransactionHeaders.Where(a => a.TicketNumber == ticket_no).AsEnumerable().Select(w => new TicketDetailsDto
            {
                ticket_no = w.TicketNumber,
                date = w.TicketDate.Value.ToString("dd MM yyyy"),
                order_no = w.OrderNumber,
                payment_terms = w.PaymentTerms,
                spplier_ticket_no = w.SupplierTicket,
                status = w.Status,
                truck_description = w.TruckDescription,
                TicketDetailsBodyDtos = _db.TransactionDetails.Where(a=>a.TicketNumber==w.TicketNumber).AsEnumerable().Select(q => new TicketDetailsBodyDto
                {
                    gross_weight = q.Gross + "",
                    item_name = "",
                    net_weight = q.Net + "",
                    tare_weight = q.Tare + "",
                    total_price = q.TotalCost + "",
                    unit_price = q.UnitCost + ""
                }).ToList(),
                 receivedPaperwork=_db.TransactionReceivedPaperwords.Where(a=>a.TicketNumber==w.TicketNumber).AsEnumerable().Select(e=>new ReceivedPaperworkDto
                 { 
                  
                   thumbnail_url=e.ThumbnailUrl
                 }).ToList(),
                  otherPictures=_db.TransactionOtherPictures.Where(a => a.TicketNumber == w.TicketNumber).AsEnumerable().Select(e => new OtherPicturesDto
                  { 
                        thumbnail_url=e.ThumbnailUrl

                  }).ToList(),
                   scalePictures= _db.TransactionScalePictures.Where(a => a.TicketNumber == w.TicketNumber).AsEnumerable().Select(e => new ScalePicturesDto
                   {
                        thumbnail_picture = e.ThumbnailUrl
                   }).ToList()
            }).FirstOrDefault();

            return details;

        }

        public List<TransectionsListDT> GetTransectionDT(string user_id)
        {
            var account_id = GetAccountID(user_id);
            if (account_id == null)
            {
                return new List<TransectionsListDT>();
            }
            var list = _db.TransactionHeaders.Where(a => a.AccountId == account_id).Select(a => new TransectionsListDT
            {
                ticket_no = a.TicketNumber,
                date = a.TicketDate.Value.ToString("dd MM yyyy"),
                commodity = "",
                 weight=""
            }).ToList();
            return list;
        }
    }
}
