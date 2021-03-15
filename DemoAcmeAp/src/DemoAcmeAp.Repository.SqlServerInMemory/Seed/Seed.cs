namespace DemoAcmeAp.Repository.SqlServerInMemory.Seed
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Repository.SqlServerInMemory.Context;
    using System;

    public static class Seed
    {
        public static void SeedData(this DemoAcmeApContext context)
        {
            var end01 = context.Add(new Endereco
            {
                Id = 1,
                Bairro = "Jardim Paquetá",
                Cidade = "Belo Horizonte",
                Logradouro = "Rua Susana Maria",
                Numero = 1212,
                UF = "MG"
            }).Entity;

            var end02 = context.Add(new Endereco
            {
                Id = 2,
                Bairro = "Jardins Paulista",
                Cidade = "São Paulo",
                Logradouro = "Alameda Santos",
                Numero = 3500,
                UF = "SP"
            }).Entity;

            var end03 = context.Add(new Endereco
            {
                Id = 3,
                Bairro = "Jardins Paulista",
                Cidade = "São Paulo",
                Logradouro = "Alameda Jau",
                Numero = 1250,
                UF = "SP"
            }).Entity;

            var cli01 = context.Add(new Cliente
            {
                Id = 1,
                Cpf = "123",
                DataNascimento = new DateTime(1976, 09, 12, 15, 39, 52),
                Nome = "Aluno Teste A",
                EnderecoCobranca = end01
            }).Entity;

            var cli02 = context.Add(new Cliente
            {
                Id = 3,
                Cpf = "456",
                DataNascimento = new DateTime(1980, 07, 26, 08, 39, 45),
                Nome = "Aluno Teste B",
                EnderecoCobranca = end02
            }).Entity;

            var inst01 = context.Add(new Instalacao
            {
                Id = 1,
                Codigo = "INST-001",
                DataInstalacao = new DateTime(1999, 07, 26, 08, 39, 45),
                Cliente = cli01,
                EnderecoInstalacao = end02
            }).Entity;

            var inst02 = context.Add(new Instalacao
            {
                Id = 2,
                Codigo = "INST-002",
                DataInstalacao = new DateTime(2020, 06, 26, 08, 39, 45),
                Cliente = cli02,
                EnderecoInstalacao = end02
            }).Entity;

            var inst03 = context.Add(new Instalacao
            {
                Id = 3,
                Codigo = "INST-003",
                DataInstalacao = new DateTime(2019, 09, 15, 08, 39, 45),
                Cliente = cli02,
                EnderecoInstalacao = end03
            }).Entity;

            var fat01 = context.Add(new Fatura
            {
                Id = 1,
                Codigo = "FAT-001",
                DataLeitura = new DateTime(2019, 01, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 01, 10, 10, 42, 45),
                NumeroLeitura = 100999,
                ValorConta = 100,
                Instalacao = inst01
            }).Entity;

            var fat02 = context.Add(new Fatura
            {
                Id = 2,
                Codigo = "FAT-002",
                DataLeitura = new DateTime(2019, 02, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 02, 10, 10, 42, 45),
                NumeroLeitura = 101234,
                ValorConta = 255.20,
                Instalacao = inst01
            }).Entity;

            var fat03 = context.Add(new Fatura
            {
                Id = 3,
                Codigo = "FAT-003",
                DataLeitura = new DateTime(2019, 03, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 03, 10, 10, 42, 45),
                NumeroLeitura = 101334,
                ValorConta = 189.10,
                Instalacao = inst01
            }).Entity;

            var fat04 = context.Add(new Fatura
            {
                Id = 4,
                Codigo = "FAT-004",
                DataLeitura = new DateTime(2019, 04, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 04, 10, 10, 42, 45),
                NumeroLeitura = 101534,
                ValorConta = 100.99,
                Instalacao = inst01
            }).Entity;

            var fat05 = context.Add(new Fatura
            {
                Id = 5,
                Codigo = "FAT-005",
                DataLeitura = new DateTime(2019, 05, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 05, 10, 10, 42, 45),
                NumeroLeitura = 101834,
                ValorConta = 350.85,
                Instalacao = inst01
            }).Entity;

            var fat06 = context.Add(new Fatura
            {
                Id = 6,
                Codigo = "FAT-006",
                DataLeitura = new DateTime(2019, 06, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 06, 10, 10, 42, 45),
                NumeroLeitura = 102034,
                ValorConta = 112.12,
                Instalacao = inst01
            }).Entity;

            var fat07 = context.Add(new Fatura
            {
                Id = 7,
                Codigo = "FAT-007",
                DataLeitura = new DateTime(2019, 07, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 07, 10, 10, 42, 45),
                NumeroLeitura = 100000,
                ValorConta = 399,
                Instalacao = inst02
            }).Entity;

            var fat08 = context.Add(new Fatura
            {
                Id = 8,
                Codigo = "FAT-008",
                DataLeitura = new DateTime(2019, 08, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 08, 10, 10, 42, 45),
                NumeroLeitura = 100250,
                ValorConta = 898.76,
                Instalacao = inst02
            }).Entity;

            var fat09 = context.Add(new Fatura
            {
                Id = 9,
                Codigo = "FAT-009",
                DataLeitura = new DateTime(2019, 09, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 09, 10, 10, 42, 45),
                NumeroLeitura = 100650,
                ValorConta = 1504.26,
                Instalacao = inst02
            }).Entity;

            var fat10 = context.Add(new Fatura
            {
                Id = 10,
                Codigo = "FAT-010",
                DataLeitura = new DateTime(2019, 10, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 10, 10, 10, 42, 45),
                NumeroLeitura = 102134,
                ValorConta = 200,
                Instalacao = inst01
            }).Entity;

            var fat11 = context.Add(new Fatura
            {
                Id = 11,
                Codigo = "FAT-011",
                DataLeitura = new DateTime(2019, 11, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 11, 10, 10, 42, 45),
                NumeroLeitura = 1102334,
                ValorConta = 450,
                Instalacao = inst01
            }).Entity;

            var fat12 = context.Add(new Fatura
            {
                Id = 12,
                Codigo = "FAT-012",
                DataLeitura = new DateTime(2019, 12, 01, 10, 45, 42),
                DataVencimento = new DateTime(2019, 12, 10, 10, 42, 45),
                NumeroLeitura = 1102534,
                ValorConta = 909.87,
                Instalacao = inst01
            }).Entity;

            var fat13 = context.Add(new Fatura
            {
                Id = 13,
                Codigo = "FAT-013",
                DataLeitura = new DateTime(2020, 01, 01, 10, 45, 42),
                DataVencimento = new DateTime(2020, 01, 10, 10, 42, 45),
                NumeroLeitura = 1102834,
                ValorConta = 395,
                Instalacao = inst01
            }).Entity;

            var fat14 = context.Add(new Fatura
            {
                Id = 14,
                Codigo = "FAT-014",
                DataLeitura = new DateTime(2020, 02, 01, 10, 45, 42),
                DataVencimento = new DateTime(2020, 02, 10, 10, 42, 45),
                NumeroLeitura = 000999,
                ValorConta = 865,
                Instalacao = inst03
            }).Entity;

            var fat15 = context.Add(new Fatura
            {
                Id = 15,
                Codigo = "FAT-015",
                DataLeitura = new DateTime(2020, 03, 01, 10, 45, 42),
                DataVencimento = new DateTime(2020, 03, 10, 10, 42, 45),
                NumeroLeitura = 001199,
                ValorConta = 865,
                Instalacao = inst03
            }).Entity;

            var fat16 = context.Add(new Fatura
            {
                Id = 16,
                Codigo = "FAT-016",
                DataLeitura = new DateTime(2020, 04, 01, 10, 45, 42),
                DataVencimento = new DateTime(2020, 04, 10, 10, 42, 45),
                NumeroLeitura = 1102934,
                ValorConta = 840,
                Instalacao = inst01
            }).Entity;


            context.SaveChanges();
        }
    }
}