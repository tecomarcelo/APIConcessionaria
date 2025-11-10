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
    public class OpcionalController : ControllerBase
    {
        //atributo
        private readonly IOpcionalRepository _opcionalRepository;
        private readonly IMapper _mapper;

        //construtor do atribuito
        public OpcionalController(IOpcionalRepository opcionalRepository, IMapper mapper)
        {
            _opcionalRepository = opcionalRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(OpcionalPostRequest request)
        {
            try
            {
                var opcional = _mapper.Map<Opcional>(request);
                
                _opcionalRepository.AddRange(opcional);

                var response = _mapper.Map<OpcionalGetResponse>(opcional);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(OpcionalPutRequest request)
        {
            try
            {
                var opcional = _opcionalRepository.GetInt(request.IdOpcional);

                if (opcional == null)
                    return StatusCode(422,
                        new { message = "ID Inválido. Opcional não encontrado." });

                _mapper.Map(request, opcional);
                _opcionalRepository.Update(opcional);

                var response = _mapper.Map<OpcionalGetResponse>(opcional);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var opcional = _opcionalRepository.GetInt(id);

                if (opcional == null)
                    return StatusCode(422,
                        new { message = "ID inválido. Opcional não encontrado." });

                _opcionalRepository.Delete(opcional);

                var response = _mapper.Map<OpcionalGetResponse>(opcional);
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
                var opcionais = _opcionalRepository.GetAll();
                var response = _mapper.Map<List<OpcionalGetResponse>>(opcionais);

                if (response.Count == 0)
                    return StatusCode(204); //NO CONTENT

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var opcional = _opcionalRepository.GetInt(id);
                var response = _mapper.Map<OpcionalGetResponse>(opcional);

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
