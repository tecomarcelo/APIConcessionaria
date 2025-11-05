namespace ApiConcessionaria.Services.Responses
{
    public class PedidoGetResponse
    {
        public Guid IdPedido { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public Guid IdCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        #region Relacionamentos

        public ClienteGetResponse? Cliente { get; set; }
        public VeiculoGetResponse? Veiculo { get; set; }
        public List<OpcionalPedidoGetResponse>? Opcionais { get; set; }

        #endregion
    }

    public class OpcionalPedidoGetResponse
    {
        public int IdOpcional { get; set; }
        public string? Item { get; set; }
        public decimal Preco { get; set; }
    }
}
