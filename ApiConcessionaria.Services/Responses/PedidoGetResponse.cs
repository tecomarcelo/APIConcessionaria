namespace ApiConcessionaria.Services.Responses
{
    public class PedidoGetResponse
    {
        public Guid IdPedido { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdVeiculo { get; set; }
        public int IdOpcional { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        #region Relacionamentos

        public ClienteGetResponse? Cliente { get; set; }
        public VeiculoGetResponse? Veiculo { get; set; }
        public OpcionalGetResponse? Opcional { get; set; }

        #endregion
    }
}
