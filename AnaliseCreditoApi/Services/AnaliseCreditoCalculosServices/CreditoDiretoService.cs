using AnaliseCreditoApi.Models.Responses;

namespace AnaliseCreditoApi.Services.AnaliseCreditoCalculosServices
{
    public class CreditoDiretoService : CalculoBaseService
    {
        private const int JurosCreditoDiretoAoMes = 2;
        public AnaliseCreditoResponse Calcular(decimal valorTotal, int prazo)
        {
            var valorMensal = valorTotal / prazo;
            var valorJuros = valorMensal * JurosCreditoDiretoAoMes / 100m;
            var valorTotalComJuros = valorTotal + (valorJuros * prazo);

            return new AnaliseCreditoResponse
            {
                ValorSolicitado = valorTotal,
                ValorJuros = valorJuros,
                ValorComJuros = valorTotalComJuros
            };
        }
    }
}
