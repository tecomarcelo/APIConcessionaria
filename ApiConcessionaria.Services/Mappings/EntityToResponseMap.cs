﻿using ApiConcessionaria.Infra.Data.Entities;
using ApiConcessionaria.Services.Responses;
using AutoMapper;

namespace ApiConcessionaria.Services.Mappings
{
    /// <summary>
    /// Mapeamento Entity -> Response
    /// </summary>
    public class EntityToResponseMap : Profile
    {
        public EntityToResponseMap()
        {
            CreateMap<Cliente, ClienteGetResponse>();
            CreateMap<Pedido, PedidoGetResponse>();
            CreateMap<Veiculo, VeiculoGetResponse>();
            CreateMap<Opcional, OpcionalGetResponse>();
        }
    }
}
