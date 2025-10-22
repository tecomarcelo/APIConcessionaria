using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Services.Requests
{
    public class PedidoPutRequest
    {
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public Guid IdPedido { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdVeiculo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int IdOpcional { get; set; }
    }
}
