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
    /// Classe de repositorio para Veiculo
    /// </summary>
    public class VeiculoRepository : IVeiculoRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para inicializar o atributo
        public VeiculoRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }


        public async void AddRange(Veiculo entity)
        {
            await _sqlServerContext.Veiculos.AddAsync(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Veiculo entity)
        {
            _sqlServerContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Veiculo entity)
        {
            _sqlServerContext.Veiculos.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public Veiculo Get(Guid id)
        {
            return _sqlServerContext.Veiculos
                //.Include(v => v.Pedido.Cliente) //INNER JOIN
                //.Include(v => v.Opcionais)
                .FirstOrDefault(v => v.IdVeiculo.Equals(id));
        }

        public List<Veiculo> GetAll()
        {
            return _sqlServerContext.Veiculos
                //.Include(v => v.Pedido.Cliente) //INNER JOIN
                //.Include(v => v.Opcionais)
                .OrderBy(v => v.Nome)
                .ToList();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
