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
    /// Classe de repositorio para Cliente
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;
        
        //construtor para inicializar o atributo
        public ClienteRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }
        

        public void AddRange(Cliente entity)
        {
            _sqlServerContext.Cliente.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Cliente entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Cliente entity)
        {
            _sqlServerContext.Cliente.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public Cliente Get(Guid id)
        {
            return _sqlServerContext.Cliente
                .Find(id);
        }

        public List<Cliente> GetAll()
        {
            return _sqlServerContext.Cliente
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
