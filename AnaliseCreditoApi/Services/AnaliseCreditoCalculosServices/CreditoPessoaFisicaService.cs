using AnaliseCreditoApi.Models.Responses;

namespace AnaliseCreditoApi.Services.AnaliseCreditoCalculosServices
{
    public class CreditoPessoaFisicaService : CalculoBaseService
    {
        private const int JurosCreditoPessoaFisicaAoMes = 3;
        public AnaliseCreditoResponse Calcular(decimal valorTotal, int prazo)
        {
            var valorMensal = valorTotal / prazo;
            var valorJuros = valorMensal * JurosCreditoPessoaFisicaAoMes / 100m;
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
