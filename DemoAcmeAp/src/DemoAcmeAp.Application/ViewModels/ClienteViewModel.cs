namespace DemoAcmeAp.Application.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ClienteViewModel
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public EnderecoViewModel EnderecoCobranca { get; set; }

        public IEnumerable<InstalacaoViewModel> ListaInstalacao { get; set; }
    }
}