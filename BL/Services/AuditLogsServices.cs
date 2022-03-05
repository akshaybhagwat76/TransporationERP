using TransportationERP.BL.Repository;
using TransportationERP.dal.Model;
using TransportationERP.DAL.Model;

namespace TransportationERP.BL.Services
{
    public class AuditLogsServices: IAuditLog

    {
        private MMS_WebContext _db;
        public AuditLogsServices(MMS_WebContext db)
        {
            _db = db;
        }
        public bool InsertAuditLogs(AuditLogs model)
        {
            _db.AuditLogs.Add(model);
            var res = _db.SaveChanges();
            return res > 0 ? true : false;

        }
    }
}
