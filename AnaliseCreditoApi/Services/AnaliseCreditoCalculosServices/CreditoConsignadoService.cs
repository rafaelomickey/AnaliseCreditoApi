using AnaliseCreditoApi.Models.Responses;

namespace AnaliseCreditoApi.Services.AnaliseCreditoCalculosServices
{
    public class CreditoConsignadoService : CalculoBaseService
    {
        private const int JurosCreditoConsignadoAoMes = 1;
        public AnaliseCreditoResponse Calcular(decimal valorTotal, int prazo)
        {
            var valorMensal = valorTotal / prazo;
            var valorJuros = valorMensal * JurosCreditoConsignadoAoMes / 100m;
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
