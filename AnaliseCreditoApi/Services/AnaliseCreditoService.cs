using AnaliseCreditoApi.Interfaces.Services;
using AnaliseCreditoApi.Models.Enums;
using AnaliseCreditoApi.Models.Requests;
using AnaliseCreditoApi.Models.Responses;
using AnaliseCreditoApi.Services.AnaliseCreditoCalculosServices;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AnaliseCreditoApi.Services
{
    public class AnaliseCreditoService : IAnaliseCreditoService
    {
        public async Task<AnaliseCreditoResponse> Solicitar(AnaliseCreditoRequest request)
        {
            var calculoBase = new CalculoBaseService();

            var analiseCreditoResponse = calculoBase.Calcular(request);

            analiseCreditoResponse.StatusCredito = StatusCredito.Aprovado;
            analiseCreditoResponse.StatusCode = StatusCodes.Status200OK;

            return await Task.Run(() =>
            {
                return analiseCreditoResponse;
            });
        }
    }
}
