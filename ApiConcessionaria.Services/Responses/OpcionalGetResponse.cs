namespace ApiConcessionaria.Services.Responses
{
    public class OpcionalGetResponse
    {
        public int IdOpcional { get; set; }
        public string? Item { get; set; }
        public decimal Preco { get; set; }

        #region Relacionamentos

        public VeiculoGetResponse? Veiculo { get; set; }

        #endregion
    }
}
