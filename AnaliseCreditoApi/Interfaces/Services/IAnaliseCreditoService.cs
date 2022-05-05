using AnaliseCreditoApi.Models.Requests;
using AnaliseCreditoApi.Models.Responses;
using System.Threading.Tasks;

namespace AnaliseCreditoApi.Interfaces.Services
{
    public interface IAnaliseCreditoService
    {
        Task<AnaliseCreditoResponse> Solicitar(AnaliseCreditoRequest request);
    }
}
