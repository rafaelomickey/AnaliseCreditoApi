using System.Text.Json.Serialization;

namespace AnaliseCreditoApi.Models.Responses
{
    public class BaseResponse
    {
        public string MensagemErro { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
    }
}
