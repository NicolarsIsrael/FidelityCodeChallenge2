using System;
using System.Text.Json;

namespace AccountMgt.DAO
{
    public class ApiResponseDto
    {
        public bool validationError { get; set; }
        public bool serverError { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
        public object data { get; set; }
        public Exception exception { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
