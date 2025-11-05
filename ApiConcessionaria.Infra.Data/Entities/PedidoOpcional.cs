using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Entities
{
    /// <summary>
    /// relacionamento N:N entre Pedido e Opcional
    /// </summary>
    public class PedidoOpcional
    {
        public Guid IdPedido { get; set; }
        public Pedido? Pedido { get; set; }

        public int IdOpcional { get; set; }
        public Opcional? Opcional { get; set; }
    }
}
