using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationERP.ViewModel;

namespace TransportationERP.BL.Repository
{
   public interface ITransportation
    {

        TransportationFormInitialDto GetTransportationFormInitialData();
        bool SaveTransportationData(SaveTransportationData model);

    }
}
