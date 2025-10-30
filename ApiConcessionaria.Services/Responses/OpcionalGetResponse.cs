namespace ApiConcessionaria.Services.Responses
{
    public class OpcionalGetResponse
    {
        public int IdOpcional { get; set; }
        public string Item { get; set; }
        public decimal Preco { get; set; }
        public string? IdVeiculo { get; set; }
    }
}
