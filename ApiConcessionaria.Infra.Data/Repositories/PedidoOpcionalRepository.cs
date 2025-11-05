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
    public class PedidoOpcionalRepository : IPedidoOpcionalRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        public PedidoOpcionalRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void AddRange(PedidoOpcional entity)
        {
            _sqlServerContext.PedidoOpcionals.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(PedidoOpcional entity)
        {
            _sqlServerContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(PedidoOpcional entity)
        {
            _sqlServerContext.PedidoOpcionals.Remove(entity);
            _sqlServerContext.SaveChanges();
        }        

        public PedidoOpcional Get(Guid id)
        {
            return _sqlServerContext.PedidoOpcionals
                .FirstOrDefault(o => o.IdOpcional.Equals(id));
        }

        public List<PedidoOpcional> GetAll()
        {
            return _sqlServerContext.PedidoOpcionals
                .Include(o => o.Opcional.Veiculo)
                .OrderBy(o => o.Opcional.Item)
                .ToList();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
