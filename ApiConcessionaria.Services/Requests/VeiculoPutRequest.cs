using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Services.Requests
{
    /// <summary>
    /// Modelo de dados para o serviço de atualização do Veiculo
    /// </summary>
    public class VeiculoPutRequest
    {
        [Required(ErrorMessage = "Campo obrigatorio.")]
        public Guid IdVeiculo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int AnoVeiculo { get; set; }

    }
}
