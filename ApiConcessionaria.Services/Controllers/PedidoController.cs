﻿using ApiConcessionaria.Infra.Data.Entities;
using ApiConcessionaria.Infra.Data.Interfaces;
using ApiConcessionaria.Services.Requests;
using ApiConcessionaria.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConcessionaria.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        //atributo
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IOpcionalRepository _opcionalRepository;
        private readonly IMapper _mapper;

        //construtor do atribuito
        public PedidoController(IPedidoRepository pedidoRepository, IMapper mapper, IClienteRepository clienteRepository, 
            IVeiculoRepository veiculoRepository, IOpcionalRepository opcionalRepository)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _veiculoRepository = veiculoRepository;
            _opcionalRepository = opcionalRepository;
        }


        [HttpPost]
        public IActionResult Post(PedidoPostRequest request)
        {
            try
            {
                //pesquisando Cliente associada pelo id
                var cliente = _clienteRepository.Get(request.IdCliente);
                if (cliente == null)
                    return StatusCode(422, new { message = "O Cliente informado não está cadastrado." });

                //pesquisando Veiculos associada pelo id
                var veiculo = _veiculoRepository.Get(request.IdVeiculo);
                if (veiculo == null)
                    return StatusCode(422, new { message = "O Veiculo informado não está cadastrado." });

                //pesquisando Opcionais associada pelo id inteiro
                var opcional = _opcionalRepository.GetInt(request.IdOpcional);
                if (veiculo == null)
                    return StatusCode(422, new { message = "O Opcional informado não está cadastrado." });

                var pedido = _mapper.Map<Pedido>(request);

                _pedidoRepository.AddRange(pedido);

                var response = _mapper.Map<PedidoGetResponse>(pedido);
                response.Cliente = _mapper.Map<ClienteGetResponse>(cliente);
                response.Veiculo = _mapper.Map<VeiculoGetResponse>(veiculo);
                response.Opcional = _mapper.Map<OpcionalGetResponse>(opcional);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(PedidoPutRequest request)
        {
            try
            {
                //persquisando o pedido pelo id
                var pedido = _pedidoRepository.Get(request.IdPedido);

                //verificando se o pedido não foi encontrado
                if (pedido == null)
                    return StatusCode(422,
                        new { message = "ID Inválido. Pedido não encontrado." });

                //pesquisando Cliente associada pelo id para associação
                var cliente = _clienteRepository.Get(request.IdCliente);
                if (cliente == null)
                    return StatusCode(422, new { message = "O Cliente informado não está cadastrado." });

                //pesquisando Cliente associada pelo id
                var veiculo = _veiculoRepository.Get(request.IdVeiculo);
                if (veiculo == null)
                    return StatusCode(422, new { message = "O Veiculo informado não está cadastrado." });

                //pesquisando Cliente associada pelo id
                var opcional = _opcionalRepository.GetInt(request.IdOpcional);
                if (opcional == null)
                    return StatusCode(422, new { message = "O Opcional informado não está cadastrado." });

                _mapper.Map(request, pedido);
                _pedidoRepository.Update(pedido);

                var response = _mapper.Map<PedidoGetResponse>(pedido);
                response.Cliente = _mapper.Map<ClienteGetResponse>(cliente);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var pedido = _pedidoRepository.Get(id);

                if (pedido == null)
                    return StatusCode(422,
                        new { message = "ID inválido. Pedido não encontrado." });

                var cliente = _clienteRepository.Get(pedido.IdCliente);

                _pedidoRepository.Delete(pedido);

                var response = _mapper.Map<PedidoGetResponse>(pedido);
                response.Cliente = _mapper.Map<ClienteGetResponse>(cliente);

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var pedidos = _pedidoRepository.GetAll();
                var lista = _mapper.Map<List<PedidoGetResponse>>(pedidos);
                
                if (lista.Count == 0)
                    return StatusCode(204); //NO CONTENT

                return StatusCode(200, lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var pedido = _pedidoRepository.Get(id);
                var response = _mapper.Map<PedidoGetResponse>(pedido);

                if (response == null)
                    return StatusCode(204); //NO CONTENT

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
