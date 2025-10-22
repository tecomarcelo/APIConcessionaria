﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConcessionaria.Infra.Data.Entities
{
    public class Opcional
    {
        public int IdOpcional { get; set; }
        public string? Item { get; set; }
        public decimal Preco { get; set; }
        public Guid? IdVeiculo { get; set; }

        public Veiculo? Veiculo { get; set; }
    }
}
