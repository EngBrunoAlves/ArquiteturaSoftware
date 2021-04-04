namespace BillsToPay.Services.Rest.Controllers
{
    using BillsToPay.Application.Interfaces;
    using BillsToPay.Services.Rest.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class BillsToPayControllerBase<TViewModel> : ControllerBase where TViewModel : class
    {
        private readonly IAppServiceBase<TViewModel> _appService;
        protected readonly ILogger _logger;

        protected BillsToPayControllerBase(IAppServiceBase<TViewModel> appService, ILogger logger)
        {
            _appService = appService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<TResult<TViewModel>> Add([FromBody] TViewModel viewModel)
        {
            return await Execute(() => _appService.Add(viewModel));
        }

        [HttpPut("{id}")]
        public async Task<TResult<TViewModel>> Update(Guid id, [FromBody] TViewModel viewModel)
        {
            return await Execute(() => _appService.Update(id, viewModel));
        }

        [HttpDelete("{id}")]
        public async Task<TResult> Delete(Guid id)
        {
            return await Execute(() => _appService.Delete(id));
        }

        [HttpGet("{id}")]
        public async Task<TResult<TViewModel>> Get(Guid id)
        {
            return await Execute(() => _appService.Get(id));
        }

        [HttpGet]
        public async Task<TResult<IEnumerable<TViewModel>>> List()
        {
            return await Execute(() => _appService.List());
        }

        protected async Task<TResult> Execute(Func<Task> func)
        {
            try
            {
                await func?.Invoke();
                return new TResult
                {
                    Success = true
                };
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while execute the operation. Exeption: {exception}");
                return new TResult
                {
                    Success = false,
                    ErrorMessage = exception.Message
                };
            }
        }

        protected async Task<TResult<TObject>> Execute<TObject>(Func<Task<TObject>> func)
        {
            try
            {
                var result = await func?.Invoke();
                return new TResult<TObject>
                {
                    Success = true,
                    Result = result
                };
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while execute the operation. Exeption: {exception}");
                return new TResult<TObject>
                {
                    Success = false,
                    ErrorMessage = exception.Message
                };
            }
        }
    }
}
