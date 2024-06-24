using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;

namespace BackFacture
{
    public enum ResponseStatus
    {
        Success,
        Error,
        Warning,
        Alert
    }

    public class Response
    {
        public ResponseStatus  Status { get; set; }
        public string Message { get; set; }
        public JObject Data { get; set; }

        public Response(ResponseStatus status, string message, JObject data = null)
        {
            Status = status;
            Message = message;
            Data = data ?? new JObject();
        }

        public string ToJson()
        {
            var responseObject = new JObject
            {
                ["status"] = Status.ToString(),
                ["message"] = Message,
                ["data"] = Data
            };

            return responseObject.ToString();
        }
    }
}
