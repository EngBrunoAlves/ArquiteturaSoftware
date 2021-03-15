namespace DemoAcmeAp.Application.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class InstalacaoViewModel
    {
        public long Id { get; set; }

        public string Codigo { get; set; }

        public DateTime DataInstalacao { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public EnderecoViewModel EnderecoInstalacao { get; set; }

        public IEnumerable<FaturaViewModel> ListaFatura { get; set; }
    }
}