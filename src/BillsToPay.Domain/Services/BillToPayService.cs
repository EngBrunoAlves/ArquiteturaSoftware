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

    public class BillToPayService : IBillToPayService
    {
        private readonly IUnitOfWork uow;

        public BillToPayService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Create(BillToPay billToPay)
        {
            if (! ModelIsValid.Execute(billToPay, out var results))
                throw new ModelIsNotValidException($"Errors found: {string.Join("; ", results.Select(x => x.ErrorMessage))}.");

            await uow.BillsToPay.Add(billToPay);
        }

        public async Task<IEnumerable<BillToPayLateDto>> List()
        {
            var bills = await uow.BillsToPay.List();

            return bills
                .Select(b => new BillToPayLateDto
                {
                    Name = b.Name,
                    OriginalValue = b.OriginalValue,
                    CorrectValue = CalculateCorrectValue.Execute(b),
                    NumberOfDaysOverdue = CalculateNumberOfDaysOverdue.Execute(b),
                    PayDay = b.PayDay
                })
                .ToList();
        }
    }
}