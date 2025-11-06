using ApiConcessionaria.Infra.Data.Contexts;
using ApiConcessionaria.Infra.Data.Entities;
using ApiConcessionaria.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Repositories
{
    /// <summary>
    /// Classe de repositorio para Pedido
    /// </summary>
    public class PedidoRepository : IPedidoRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        public PedidoRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }


        public async void AddRange(Pedido entity)
        {
            await _sqlServerContext.Pedido.AddAsync(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Pedido entity)
        {
            _sqlServerContext.Pedido.RemoveRange(entity);
            _sqlServerContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Pedido entity)
        {
            _sqlServerContext.Pedido.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public Pedido Get(Guid id)
        {
            return _sqlServerContext.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Veiculo)
                .Include(p => p.PedidoOpcionais)
                    .ThenInclude(po => po.Opcional)
                .FirstOrDefault(p => p.IdPedido == id);
        }

        public List<Pedido> GetAll()
        {
            return _sqlServerContext.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Veiculo)  //INNER JOIN
                .Include(p => p.PedidoOpcionais)
                    .ThenInclude(po => po.Opcional)
                .OrderByDescending(p => p.DataCriacao)
                .ToList();
        }



        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
