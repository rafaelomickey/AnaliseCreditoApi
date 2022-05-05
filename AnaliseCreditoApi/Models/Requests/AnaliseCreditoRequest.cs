using AnaliseCreditoApi.Models.Enums;
using System;

namespace AnaliseCreditoApi.Models.Requests
{
    public class AnaliseCreditoRequest
    {
        public decimal ValorCredito { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
    }
}
