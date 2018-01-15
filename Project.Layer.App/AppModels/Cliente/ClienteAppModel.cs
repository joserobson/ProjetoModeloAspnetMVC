namespace Project.Layer.App.AppModels.Cliente
{
    public class ClienteAppModel
    {
        public string Id { get; set; }
        public string CodigoFicha { get; set; }
        public decimal LimiteCredito { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public EnderecoAppModel Endereco { get; set; }
        public string DataDeNascimento { get; set; }
        public string NomeDaMae { get; set; }
        public string Cpf { get; set; }
    }
}
