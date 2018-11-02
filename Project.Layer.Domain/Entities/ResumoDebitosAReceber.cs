namespace Project.Layer.Domain.Entities
{
    public class ResumoDebitosAReceber: BaseEntity
    {
        public decimal ValorRetroativo { get; set; }

        public decimal ValorAReceber { get; set; }

        public string DataReferencia { get; set; }
    }
}
