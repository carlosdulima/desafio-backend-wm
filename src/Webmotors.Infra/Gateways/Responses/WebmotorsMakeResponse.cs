﻿using System.Text.Json.Serialization;

namespace Webmotors.Infra.Gateways.Responses
{
    public class WebmotorsMakeResponse
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}
