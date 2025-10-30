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
    public class OpcionalRepository : IOpcionalRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        public OpcionalRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }


        public void AddRange(Opcional entity)
        {
            _sqlServerContext.Opcionals.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Opcional entity)
        {
            _sqlServerContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Opcional entity)
        {
            _sqlServerContext.Opcionals.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public Opcional Get(Guid id)
        {
            return _sqlServerContext.Opcionals
                //.Include(o => o.Veiculo)
                .FirstOrDefault(o => o.IdOpcional.Equals(id));
        }

        public Opcional GetInt(int id)
        {
            return _sqlServerContext.Opcionals
                .FirstOrDefault(o => o.IdOpcional.Equals(id));
        }

        public List<Opcional> GetAll()
        {
            return _sqlServerContext.Opcionals
                //.Include(o => o.Veiculo)
                .OrderBy(o => o.Item)
                .ToList();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
