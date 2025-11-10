using ApiConcessionaria.Infra.Data.Entities;
using ApiConcessionaria.Infra.Data.Interfaces;
using ApiConcessionaria.Services.Requests;
using ApiConcessionaria.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConcessionaria.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //atributo
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        //contrutor do atributo
        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Post(ClientePostRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);

                _clienteRepository.AddRange(cliente);

                var response = _mapper.Map<ClienteGetResponse>(cliente);
                return StatusCode(201, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(ClientePutRequest request)
        {
            try
            {
                var cliente = _clienteRepository.Get(request.IdCliente);

                if (cliente == null)
                    return StatusCode(422, new { message = "ID inválido. Cliente não encontrado. " });

                _mapper.Map(request, cliente);

                _clienteRepository.Update(cliente);

                var response = _mapper.Map<ClienteGetResponse>(cliente);
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { mesage = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var cliente = _clienteRepository.Get(id);

                if (cliente == null)
                    return StatusCode(422, new { message = "Id inválido. Cliente não encontrado." });

                _clienteRepository.Delete(cliente);

                var response = _mapper.Map<ClienteGetResponse>(cliente);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mesage = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var clientes = _clienteRepository.GetAll();
                var response = _mapper.Map<List<ClienteGetResponse>>(clientes);

                if (response.Count == 0)
                    return StatusCode(204); //NO CONTENT

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mesage = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var cliente = _clienteRepository.Get(id);
                var response = _mapper.Map<ClienteGetResponse>(cliente);

                if (response == null)
                    return StatusCode(204); //NO CONTENT

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mesage = e.Message });
            }
        }
    }
}
