using ApiConcessionaria.Infra.Data.Entities;
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
            CreateMap<Pedido, PedidoGetResponse>()
                .ForMember(dest => dest.Opcionais, opt =>
                    opt.MapFrom(src => src.PedidoOpcionais.Select(po => po.Opcional)));
            CreateMap<Veiculo, VeiculoGetResponse>();
            CreateMap<Opcional, OpcionalGetResponse>();
            CreateMap<Opcional, OpcionalPedidoGetResponse>();

        }
    }
}
