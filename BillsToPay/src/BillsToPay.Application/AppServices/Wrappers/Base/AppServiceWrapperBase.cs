namespace BillsToPay.Application.AppServices.Wrappers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using BillsToPay.Application.AppServices.Base;
    using BillsToPay.Application.Interfaces;
    using BillsToPay.Domain.Entities;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    internal abstract class AppServiceWrapperBase<TInterface, TAppService, TModel, TViewModel> : IAppServiceBase<TViewModel>
        where TInterface : IAppServiceBase<TViewModel>
        where TAppService : AppServiceBase<TModel, TViewModel>
        where TModel : EntityBase
        where TViewModel : class
    {
        private readonly IServiceProvider _provider;
        private TAppService appServiceInstance;
        protected readonly ILogger _logger;

        public AppServiceWrapperBase(IServiceProvider provider, ILogger logger)
        {
            _logger = logger;
            _provider = provider;
        }

        public async Task<TViewModel> Add(TViewModel viewModel)
        {
            return await Caller(() => appService.Add(viewModel));
        }

        public async Task Delete(Guid id)
        {
            await Caller(() => appService.Delete(id));
        }

        public async Task<TViewModel> Get(Guid id)
        {
            return await Caller(() => appService.Get(id));
        }

        public async Task<IEnumerable<TViewModel>> List()
        {
            return await Caller(() => appService.List());
        }

        public async Task<TViewModel> Update(Guid id, TViewModel viewModel)
        {
            return await Caller(() => appService.Update(id, viewModel));
        }

        protected TAppService appService =>
            appServiceInstance ??= _provider.GetServices<TInterface>().FirstOrDefault(s => s is TAppService) as TAppService ?? throw new NotSupportedException();

        protected async Task Caller(Func<Task> func)
        {
            var timer = StartTimer();
            var method = new StackTrace().GetFrame(1).GetMethod().Name;

            try
            {
                await func?.Invoke();
            }
            finally
            {
                var timeElapsed = StopTimer(timer);
                LogTime(timeElapsed, method);
            }
        }

        protected async Task<T> Caller<T>(Func<Task<T>> func)
        {
            var timer = StartTimer();
            var method = new StackTrace().GetFrame(1).GetMethod().Name;

            try
            {
                return await func?.Invoke();
            }
            finally
            {
                var timeElapsed = StopTimer(timer);
                LogTime(timeElapsed, method);
            }
        }

        protected Stopwatch StartTimer()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            return stopWatch;
        }

        protected TimeSpan StopTimer(Stopwatch stopwatch)
        {
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        protected void LogTime(TimeSpan timeElapsed, string method)
        {
            _logger.LogInformation($"Time elapsed to call {method}: {timeElapsed.TotalMilliseconds}ms.");
        }

        public void Dispose()
        {
            appService?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}