namespace DemoAcmeAp.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Instalacao : EntityBase
    {
        public Instalacao()
        {
            ListaFatura = new List<Fatura>();
        }

        public string Codigo { get; set; }

        public DateTime DataInstalacao { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Endereco EnderecoInstalacao { get; set; }

        public virtual IEnumerable<Fatura> ListaFatura { get; set; }
    }
}