using AnaliseCreditoApi.Models.Enums;

namespace AnaliseCreditoApi.Models.Responses
{
    public class AnaliseCreditoResponse : BaseResponse
    {
        public StatusCredito StatusCredito { get; set; }
        public decimal ValorSolicitado { get; set; }
        public decimal ValorComJuros { get; set; }
        public decimal ValorJuros { get; set; }
    }
}
