namespace DemoAcmeAp.Application.ViewModels
{
    using System;

    public class FaturaViewModel
    {
        public long Id { get; set; }

        public string Codigo { get; set; }

        public DateTime DataLeitura { get; set; }

        public DateTime DataVencimento { get; set; }

        public int NumeroLeitura { get; set; }

        public double ValorConta { get; set; }

        public InstalacaoViewModel Instalacao { get; set; }
    }
}