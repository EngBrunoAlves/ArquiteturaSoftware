namespace DemoAcmeAp.Domain.Entities
{
    using System;

    public class Fatura : EntityBase
    {
        public string Codigo { get; set; }

        public DateTime DataLeitura { get; set; }

        public DateTime DataVencimento { get; set; }

        public int NumeroLeitura { get; set; }

        public double ValorConta { get; set; }
        
        public virtual Instalacao Instalacao { get; set; }
    }
}