using Newtonsoft.Json;
using SavioWeb.Models;

namespace SavioWeb.Config
{
    public interface IApiConfigProvider
    {
        Task<ApiConfig> GetApiConfigAsync();
    }

    public class ApiConfigProvider : IApiConfigProvider
    {
        private readonly IConfiguration _configuration;

        public ApiConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ApiConfig> GetApiConfigAsync()
        {
            var env = _configuration["Environment"];
            var filePath = env == "Prod"
                ? "Config/api.json"
                : "Config/localApi.json";

            var json = await System.IO.File.ReadAllTextAsync(filePath);
            return JsonConvert.DeserializeObject<ApiConfig>(json);
        }
    }

}
