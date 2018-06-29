namespace Project.Layer.App.AppModels.Cliente
{
    public class EnderecoAppModel
    {
        public virtual string Rua { get; set; } = "";
        public virtual string Bairro { get; set; } = "";
        public virtual string Cidade { get; set; } = "";
        public virtual string Complemento { get; set; } = "";
        public virtual string Numero { get; set; } = "";
        public virtual string Estado { get; set; } = "";
    }
}
