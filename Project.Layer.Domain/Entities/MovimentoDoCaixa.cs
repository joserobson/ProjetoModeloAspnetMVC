namespace Project.Layer.Domain.Entities
{
    public class MovimentoDoCaixa : BaseEntity
    {
        public string Descricao { get; set; }

        public string Valor { get; set; }

        public int TipoMovimentoCaixa { get; set; }

        public virtual int IdDoCaixa { get; set; }

        public virtual Caixa Caixa { get; set; }
    }
}
