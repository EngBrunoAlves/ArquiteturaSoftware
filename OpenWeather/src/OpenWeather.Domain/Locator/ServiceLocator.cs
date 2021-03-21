namespace OpenWeather.Domain.Locator
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class ServiceLocator
    {
        public static IServiceProvider Instance { private get; set; }

        public static T Resolve<T>() => Instance.GetService<T>();
    }
}