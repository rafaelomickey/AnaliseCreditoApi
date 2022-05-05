using AnaliseCreditoApi.Models.Requests;
using FluentValidation;

namespace AnaliseCreditoApi.Validators
{
    public class SolicitarAnaliseCreditoValidator : AbstractValidator<AnaliseCreditoRequest>
    {
        private readonly decimal ValorMaximoCredito = 100000000;
        private readonly decimal ValorMinimoPessoaJuridica = 15000;
        private readonly int LimiteMinimoParcelas = 5;
        private readonly int LimiteMaximoParcelas = 72;
        private readonly int LimiteDiasMinimoPrimeiroVencimento = 15;
        private readonly int LimiteDiasMaximoPrimeiroVencimento = 40;

        public SolicitarAnaliseCreditoValidator()
        {
            RuleFor(e => e.ValorCredito).LessThanOrEqualTo(ValorMaximoCredito)
                .WithMessage("Valor máximo de crédito excedido");

            RuleFor(e => e.ValorCredito).GreaterThanOrEqualTo(ValorMinimoPessoaJuridica)
                .When(e => e.TipoCredito == Models.Enums.TipoCredito.CreditoPessoaJuridica)
                .WithMessage("Valor de crédito não atingiu o valor mínimo");

            RuleFor(e => e.DataPrimeiroVencimento).LessThanOrEqualTo(System.DateTime.Now.AddDays(LimiteDiasMaximoPrimeiroVencimento))
                .WithMessage($"Prazo máximo do primeiro vencimento excedido({LimiteDiasMaximoPrimeiroVencimento} dias)");

            RuleFor(e => e.DataPrimeiroVencimento).GreaterThanOrEqualTo(System.DateTime.Now.AddDays(LimiteDiasMinimoPrimeiroVencimento))
                .WithMessage($"Prazo mínimo do primeiro vencimento excedido({LimiteDiasMinimoPrimeiroVencimento} dias)");

            RuleFor(e => e.QuantidadeParcelas).LessThanOrEqualTo(LimiteMaximoParcelas)
                .WithMessage("Limite máximo de parcelas excedido");

            RuleFor(e => e.QuantidadeParcelas).GreaterThanOrEqualTo(LimiteMinimoParcelas)
                .WithMessage("Quantidade mínima de parcelas não permitido");
        }
    }
}
