using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Entities
{
    /// <summary>
    /// Modelo da Entidade
    /// </summary>
    public class Veiculo
    {
        public Guid IdVeiculo { get; set; }
        public string? Nome { get; set; }
        public string? Marca { get; set; }
        public decimal Preco { get; set; }
        public int AnoVeiculo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        #region Relacionamentos

        public ICollection<Opcional>? Opcionais { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }

        #endregion
    }
}
