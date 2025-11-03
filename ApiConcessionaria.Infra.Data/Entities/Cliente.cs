using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Entities
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        #region Relacionamentos

        public ICollection<Pedido>? Pedidos { get; set; }

        #endregion
    }
}
