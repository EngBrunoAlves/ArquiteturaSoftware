namespace DemoAcmeAp.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public string Logradouro { get; set; }

        public long Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }
    }
}