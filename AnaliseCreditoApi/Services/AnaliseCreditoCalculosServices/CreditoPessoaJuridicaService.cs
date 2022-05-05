using AnaliseCreditoApi.Models.Responses;

namespace AnaliseCreditoApi.Services.AnaliseCreditoCalculosServices
{
    public class CreditoPessoaJuridicaService : CalculoBaseService
    {
        private const int JurosCreditoPessoaJuridicaAoMes = 5;
        public AnaliseCreditoResponse Calcular(decimal valorTotal, int prazo)
        {
            var valorMensal = valorTotal / prazo;
            var valorJuros = valorMensal * JurosCreditoPessoaJuridicaAoMes / 100m;
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
