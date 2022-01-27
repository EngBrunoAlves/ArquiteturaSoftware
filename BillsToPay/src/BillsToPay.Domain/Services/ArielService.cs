using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Domain.Services;
using Test.Infrastructure.Repository;

namespace Test.Domain.Services
{
    public static class ArielService
    {
        public async static Task<eArielIs> WhatIsAriel(MainDTO main)
        {
            var powderSoaps = await main.PowderSoaps();
            if (powderSoaps.Contains(main.Name))
                return eArielIs.PowderSoap;

            var mermaids = main.Mermaids(main.Age);
            if (mermaids.Contains(main.Name))
                return eArielIs.Mermaid;

            return eArielIs.None;
        }
    }

    public class MainDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Func<Task<IEnumerable<string>>> PowderSoaps { get; set; }
        public Func<int, IEnumerable<string>> Mermaids { get; set; }
    }

    public enum eArielIs
    {
        None = 0,
        PowderSoap = 1,
        Mermaid = 2
    }
}

namespace Test.Application.AppServices
{
    public class ArielAppService
    {
        private readonly IPowderSoapRepository _powderSoapRepository;
        private readonly IMermaidRepository _mermaidRepository;
        public ArielAppService()
        {
            _powderSoapRepository = new PowderSoapRepository();
            _mermaidRepository = new MermaidRepository();
        }

        public async Task<eArielIs> WhatIsAriel(string name)
        {
            var mainDTO = new MainDTO
            {
                Name = name,
                PowderSoaps = _powderSoapRepository.List,
                Mermaids = (int age) => _mermaidRepository.List(age)
            };

            return await ArielService.WhatIsAriel(mainDTO);
        }
    }
}

namespace Test.Infrastructure.Repository
{
    public interface IPowderSoapRepository
    {
        Task<IEnumerable<string>> List();
    }

    public interface IMermaidRepository
    {
        IEnumerable<string> List(int age);
    }

    public class PowderSoapRepository : IPowderSoapRepository
    {
        public async Task<IEnumerable<string>> List()
        {
            return await Task.FromResult(new[] { "Ariel Souza" });
        }
    }

    public class MermaidRepository : IMermaidRepository
    {
        public IEnumerable<string> List(int age)
        {
            if (age > 18)
                return new[] { "Ariel Edward" };

            return new[] { "Ariel E. Souza" };
        }
    }
}

namespace Test.Domain.Test
{
    public class ArielServiceTest
    {
        public async void ExpectedOurAriel()
        {
            var mainDTO = new MainDTO
            {
                Name = "Ariel Souza",
                Age = 18,
                PowderSoaps = async () => await Task.FromResult(new[] { "Ariel Jessé Barci" }),
                Mermaids = (int age) => 
                {
                    Assert.Equal(18, age);
                    return new[] { "Ariel Edward" }; 
                }
            };

            var result = await ArielService.WhatIsAriel(mainDTO);

            Assert.Equal(eArielIs.Mermaid, result);
        }
    }
}