namespace OpenWeather.Services.Rest.HostedServices
{
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class BackgroundHostedService : IHostedService, IDisposable
    {
        private Task _executingTask;
        private readonly CancellationTokenSource _stopping = new CancellationTokenSource();

        protected abstract Task ExecuteAsync(CancellationToken cancellationToken);

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _executingTask = ExecuteAsync(cancellationToken);

            if (_executingTask.IsCompleted)
                return _executingTask;

            return Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask is null)
                return;

            try
            {
                _stopping.Cancel();
            }
            finally
            {
                await Task.WhenAll(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        public void Dispose()
        {
            _stopping.Cancel();
        }
    }
}
