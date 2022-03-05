using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportationERP.BL.Repository;
using TransportationERP.dal.Model;
using TransportationERP.DAL.Model;
using TransportationERP.ViewModel;

namespace TransportationERP.DAL.Services
{
    public class TransportationServices : ITransportation
    {
        private MMS_WebContext _db;
        public TransportationServices(MMS_WebContext db)
        {
            _db = db;
        }


        public List<SimpleDropDownDto> GetTransportationLocations()
        {
            var list = _db.TransportationLocations.Select(a => new SimpleDropDownDto
            {
                id = a.LocationID,
                name = a.LocationName
            }).ToList();
            return list;
        }

        public List<SimpleDropDownDto> GetTransportationCommodities()
        {
            var list= _db.TransportationCommodities.Select(a => new SimpleDropDownDto
            {
                id = a.CommodityID,
                name = a.Commodity_Name
            }).ToList();
            return list;
        }




        public TransportationFormInitialDto GetTransportationFormInitialData()
        {

            var locations_list = GetTransportationLocations();
            var commodities_list = GetTransportationCommodities();
            var result = new TransportationFormInitialDto
            {
                TransportationCommodities = commodities_list,
                TransportationLocations = locations_list
            };
            return result;
        }

        public bool SaveTransportationData(SaveTransportationData model)
        {
            var obj = new TransectionSetting();
            obj.LocationID =Convert.ToInt32( model.locations);
            obj.CommodityID = Convert.ToInt32(model.commodities);
            obj.Notes = model.notes;
            obj.CreatedBy = Convert.ToInt32(model.user_id);
            obj.CreatedOn = DateTime.Now;

            _db.TransectionSetting.Add(obj);
         var res=   _db.SaveChanges();
            return res>0? true:false;

        }
    }
}
