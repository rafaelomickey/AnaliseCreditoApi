using AnaliseCreditoApi.Interfaces.Services;
using AnaliseCreditoApi.Models.Requests;
using AnaliseCreditoApi.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AnaliseCreditoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnaliseCreditoController : ControllerBase
    {
        private readonly IAnaliseCreditoService _analiseCreditoService;
        private readonly ILogger<AnaliseCreditoController> _logger;

        public AnaliseCreditoController(ILogger<AnaliseCreditoController> logger, IAnaliseCreditoService analiseCreditoService)
        {
            _analiseCreditoService = analiseCreditoService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Solicitar([FromBody] AnaliseCreditoRequest request)
        {
            try
            {
                var response = await _analiseCreditoService.Solicitar(request);
                return new ObjectResult(response) { StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new ObjectResult(new BaseResponse
                {
                    MensagemErro = ex.Message
                })
                { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
