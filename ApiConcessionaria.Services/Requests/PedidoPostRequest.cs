using ApiConcessionaria.Infra.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Services.Requests
{
    public class PedidoPostRequest
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public Decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdVeiculo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public List<int> IdsOpcionais { get; set; } = new();

    }
}
