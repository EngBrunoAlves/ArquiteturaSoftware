namespace BillsToPay.Domain.Interfaces.Services
{
    using BillsToPay.Domain.Dtos;
    using BillsToPay.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBillToPayService
    {
        Task Create(BillToPay billToPay);
        Task<IEnumerable<BillToPayLateDto>> List();
    }
}