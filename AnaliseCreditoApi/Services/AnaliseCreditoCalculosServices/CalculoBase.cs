using AnaliseCreditoApi.Models.Requests;
using AnaliseCreditoApi.Models.Responses;
using System;

namespace AnaliseCreditoApi.Services.AnaliseCreditoCalculosServices
{
    public abstract class CalculoBaseServiceFactory
    {
        public abstract AnaliseCreditoResponse Calcular(AnaliseCreditoRequest request);
    }

    public class CalculoBaseService : CalculoBaseServiceFactory
    {
        public override AnaliseCreditoResponse Calcular(AnaliseCreditoRequest request)
        {
            switch (request.TipoCredito)
            {
                case Models.Enums.TipoCredito.CreditoDireto:
                    return new CreditoDiretoService().Calcular(request.ValorCredito, request.QuantidadeParcelas);
                case Models.Enums.TipoCredito.CreditoConsignado:
                    return new CreditoConsignadoService().Calcular(request.ValorCredito, request.QuantidadeParcelas);
                case Models.Enums.TipoCredito.CreditoPessoaJuridica:
                    return new CreditoPessoaJuridicaService().Calcular(request.ValorCredito, request.QuantidadeParcelas);
                case Models.Enums.TipoCredito.CreditoPessoaFisica:
                    return new CreditoPessoaFisicaService().Calcular(request.ValorCredito, request.QuantidadeParcelas);
                case Models.Enums.TipoCredito.CreditoImobiliario:
                    return new CreditoImobiliarioService().Calcular(request.ValorCredito, request.QuantidadeParcelas);
                default:
                    throw new NotImplementedException("Não implementado");
            }
        }
    }
}
