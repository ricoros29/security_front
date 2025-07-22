using BlazorApp.DTO.Security;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorApp.Interfaces
{
    public interface IService
    {
        Task<ResultLoginDTO> LoginAsync(CredentialsDTO credentials);
        Task<T?> PostAsync<T>(string endpoint, T parameters, string? token = null) where T : new();
        Task<T?> PutAsync<T>(string endpoint, object parameters, string? token = null) where T : new();
        Task<T?> GetAsync<T>(string endpoint, Dictionary<string, string> parameters, string? token = null) where T : new();
        T? Get<T>(string endpoint, Dictionary<string, string> parameters, string? token = null) where T : new();
        T GetData<T>(string json);
        Task<List<SelectListItem>> GetCatalogo(string nombrecatalogo, string? token = null, int? id = null);
    }
}
