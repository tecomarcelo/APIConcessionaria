using ApiConcessionaria.Infra.Data.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiConcessionaria.Services.Requests
{
    public class OpcionalPostRequest
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Preco { get; set; }
    }
}
