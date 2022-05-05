using AnaliseCreditoApi.Models.Responses;
using System;

namespace AnaliseCreditoApi.Services.AnaliseCreditoCalculosServices
{
    public class CreditoImobiliarioService : CalculoBaseService
    {
        private const int JurosImobiliarioAoAno = 9;
        public AnaliseCreditoResponse Calcular(decimal valorTotal, int prazo)
        {
            //ToDo: Sem a regra de calculo de meses quebrados
            if (prazo % 12 > 0)
                throw new NotImplementedException("Quantidade de meses disponível apenas em anos completos(12, 24, 36, 48)");

            var totalAnos = prazo / 12;
            var valorJurosAnual = (((valorTotal / totalAnos) * JurosImobiliarioAoAno) / 100m);
            var valorJurosTotal = valorJurosAnual * totalAnos;
            var valorTotalComJuros = valorTotal + valorJurosTotal;

            return new AnaliseCreditoResponse
            {
                ValorSolicitado = valorTotal,
                ValorJuros = valorJurosTotal,
                ValorComJuros = valorTotalComJuros
            };
        }
    }
}
