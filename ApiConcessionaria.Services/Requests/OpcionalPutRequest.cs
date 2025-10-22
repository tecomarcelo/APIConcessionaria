using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Services.Requests
{
    public class OpcionalPutRequest
    {
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public Guid IdOpcional { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdVeiculo { get; set; }
    }
}
