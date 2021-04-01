namespace BillsToPay.Domain.Services.BillToPay
{
    using BillsToPay.Domain.BusinessRule;
    using BillsToPay.Domain.Dtos;
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Exceptions;
    using BillsToPay.Domain.Interfaces.Services;
    using BillsToPay.Domain.Interfaces.UoW;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class BillToPayService : ServiceBase<BillToPay>, IBillToPayService
    {
        private readonly IUnitOfWork _uow;

        public BillToPayService(IUnitOfWork uow) : base(uow.BillsToPay)
        {
            _uow = uow;
        }

        public async override Task<BillToPay> Add(BillToPay billToPay)
        {
            if (!ModelIsValid.Execute(billToPay, out var results))
                throw new ModelIsNotValidException($"Errors found: {string.Join("; ", results.Select(x => x.ErrorMessage))}.");

            billToPay.NumberOfDaysOverdue = CalculateNumberOfDaysOverdue.Execute(billToPay);

            return await _uow.BillsToPay.Add(billToPay);
        }

        public async Task<IEnumerable<BillToPayLateDto>> ListBillToPayLateDto()
        {
            var bills = await _uow.BillsToPay.List();
            var lateFees = await _uow.LateFees.List();

            return bills
                .Select(b => new BillToPayLateDto
                {
                    Name = b.Name,
                    OriginalValue = b.OriginalValue,
                    CorrectValue = CalculateCorrectedValue.Execute(b, lateFees),
                    NumberOfDaysOverdue = b.NumberOfDaysOverdue,
                    PayDay = b.PayDay
                })
                .ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}