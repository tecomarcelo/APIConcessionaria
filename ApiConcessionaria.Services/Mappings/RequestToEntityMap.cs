using ApiConcessionaria.Infra.Data.Entities;
using ApiConcessionaria.Services.Requests;
using AutoMapper;

namespace ApiConcessionaria.Services.Mappings
{
    /// <summary>
    /// Mapeamento Request -> Entity
    /// </summary>
    public class RequestToEntityMap : Profile
    {
        public RequestToEntityMap()
        {
            CreateMap<ClientePostRequest, Cliente>()
                .AfterMap((src, dest) =>
                {
                    dest.IdCliente = Guid.NewGuid();
                    dest.DataCriacao = DateTime.Now;
                    dest.DataAlteracao = DateTime.Now;
                });

            CreateMap<ClientePutRequest, Cliente>()
                .AfterMap((src, dest) =>
                {
                    dest.DataAlteracao = DateTime.Now;
                });

            CreateMap<PedidoPostRequest, Pedido>()
                .AfterMap((src, dest) =>
                {
                    dest.IdPedido = Guid.NewGuid();
                    dest.DataCriacao = DateTime.Now;
                    dest.DataAlteracao = DateTime.Now;
                });

            CreateMap<PedidoPutRequest, Pedido>()
                .AfterMap((src, dest) =>
                {
                    dest.DataAlteracao = DateTime.Now;
                });

            CreateMap<VeiculoPostRequest, Veiculo>()
                .AfterMap((src, dest) =>
                {
                    dest.DataCriacao = DateTime.Now;
                    dest.DataAlteracao = DateTime.Now;
                });

            CreateMap<VeiculoPutRequest, Veiculo>()
                .AfterMap((src, dest) =>
                {
                    dest.DataAlteracao = DateTime.Now;
                });

            CreateMap<OpcionalPostRequest, Opcional>();

            CreateMap<OpcionalPutRequest, Opcional>();
        }
    }
}
