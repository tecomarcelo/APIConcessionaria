using ApiConcessionaria.Infra.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Services.Requests
{
    /// <summary>
    /// Modelo de dados para o serviço de cadastro do veiculo
    /// </summary>
    public class VeiculoPostRequest
    {
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
