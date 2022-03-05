using TransportationERP.DAL.Model;

namespace TransportationERP.BL.Repository
{
    public interface IAuditLog
    {
        bool InsertAuditLogs(AuditLogs objauditmodel);

    }
}
