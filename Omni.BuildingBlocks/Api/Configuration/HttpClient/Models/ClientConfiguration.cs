namespace Omni.BuildingBlocks.Api.Configuration.HttpClient.Models
{
    public class ClientConfiguration
    {
        public string Name { get; set; }

        public string Audience { get; set; }

        public string BaseUrl { get; set; }

        public string TokenEndpointUrl { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}