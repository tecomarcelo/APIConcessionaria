using ApiConcessionaria.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Interfaces
{
    public interface IOpcionalRepository : IBaseRepository<Opcional>
    {
        /// <summary>
        /// Metodo para obter o opcional pelo id inteiro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Opcional GetInt(int id);
        List<Opcional> GetByIds(List<int> id);
    }
}
