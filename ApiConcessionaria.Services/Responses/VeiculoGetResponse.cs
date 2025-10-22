namespace ApiConcessionaria.Services.Responses
{
    /// <summary>
    /// Modelo de dados para consulta de veiculos
    /// </summary>
    public class VeiculoGetResponse
    {
        public Guid IdVeiculo { get; set; }
        public string? Nome { get; set; }
        public string? Marca { get; set; }
        public decimal Preco { get; set; }
        public int AnoVeiculo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
