using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Services.Requests
{
    public class ClientePutRequest
    {
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cpf { get; set; }
    }
}
