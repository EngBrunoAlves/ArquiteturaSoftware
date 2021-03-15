namespace DemoAcmeAp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Cliente : EntityBase
    {
        public Cliente()
        {
            ListaInstalacao = new List<Instalacao>();
        }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }        

        public virtual Endereco EnderecoCobranca { get; set; }

        public virtual  IEnumerable<Instalacao> ListaInstalacao { get; set; }
    }
}