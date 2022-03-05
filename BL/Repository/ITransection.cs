using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationERP.ViewModel;

namespace TransportationERP.BL.Repository
{
   public interface ITransection
    {
        List<TransectionsListDT> GetTransectionDT(string user_id);
        TicketDetailsDto GetDetailsOfTicket(string ticket_no);
    }
}
