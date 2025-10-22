using ApiConcessionaria.Infra.Data.Entities;
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
    public class VeiculoController : ControllerBase
    {
        //atributo
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        //construtor do atribuito
        public VeiculoController(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(VeiculoPostRequest request)
        {
            try
            {
                var veiculo = _mapper.Map<Veiculo>(request);

                _veiculoRepository.AddRange(veiculo);

                var response = _mapper.Map<VeiculoGetResponse>(veiculo);
                return StatusCode(201, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(VeiculoPutRequest request)
        {
            try
            {
                var veiculo = _veiculoRepository.Get(request.IdVeiculo);

                if (veiculo == null)
                    return StatusCode(422,
                        new { message = "ID Inválido. Produto não encontrado." });

                _mapper.Map(request, veiculo);
                _veiculoRepository.Update(veiculo);

                var response = _mapper.Map<VeiculoGetResponse>(veiculo);
                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var veiculo = _veiculoRepository.Get(id);

                if (veiculo == null)
                    return StatusCode(422,
                        new { message = "ID inválido. Veiculo não encontrado." });

                _veiculoRepository.Delete(veiculo);

                var response = _mapper.Map<VeiculoGetResponse>(veiculo);

                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var veiculos = _veiculoRepository.GetAll();
                var response = _mapper.Map<List<VeiculoGetResponse>>(veiculos);

                if (response.Count == 0)
                    return StatusCode(204); //NO CONTENT

                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var veiculo = _veiculoRepository.Get(id);
                var response = _mapper.Map<VeiculoGetResponse>(veiculo);

                if (response == null)
                    return StatusCode(204); //NO CONTENT

                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}
