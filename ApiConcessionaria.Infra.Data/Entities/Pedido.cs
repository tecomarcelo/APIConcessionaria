using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Entities
{
    public class Pedido
    {
        public Guid IdPedido { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        
        public Guid IdCliente { get; set; }
        public Guid IdVeiculo { get; set; }
        public int IdOpcional { get; set; }

        #region Relacionamentos

        public Cliente? Cliente { get; set; }
        public Veiculo? Veiculo { get; set; }
        public Opcional? Opcional { get; set; }

        #endregion
    }
}
