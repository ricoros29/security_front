using BlazorApp.DTO;
using BlazorApp.DTO.Security;
using BlazorApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Services;
public class HttpService : IService
{
    private HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<ResultLoginDTO> LoginAsync(CredentialsDTO credentials)
    {
        ResultLoginDTO? result = null;

        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/authenticate/login", credentials);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var userLogin = JsonConvert.DeserializeObject<ResultLoginDTO?>(json);

                if (userLogin != null)
                {
                    result = userLogin;
                }
            }
            else
            {
                var json = response.Content.ReadAsStringAsync();
                throw new Exception(json.Result);
            }

            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T?> PostAsync<T>(string endpoint, T parameters, string? token = null) where T : new()
    {
        T? data = new();

        try
        {
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.PostAsJsonAsync(endpoint, parameters);


            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<T>(json);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var location = response.Headers.Location;
                }
            }
            else
            {
                var json = response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(json.Result))
                    throw new HttpRequestException(json.Result);
                else
                    throw new HttpRequestException(response.ReasonPhrase);
            }

            return data;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Message :{0} ", ex.Message);
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T?> PutAsync<T>(string endpoint, object parameters, string? token = null) where T : new()
    {
        T? data = new();

        try
        {
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.PutAsJsonAsync(endpoint, parameters);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                var json = response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(json.Result))
                    throw new HttpRequestException(json.Result);
                else
                    throw new HttpRequestException(response.ReasonPhrase);
            }

            return data;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Message :{0} ", ex.Message);
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T?> GetAsync<T>(string endpoint, Dictionary<string, string> parameters, string? token = null) where T : new()
    {
        T? data = default;
        var url = endpoint;

        try
        {
            if (parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    url += $"/{param.Value}";
                }
            }

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            using HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<T>(json.ToString());
            }
            else
            {
                var json = response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(json.Result))
                    throw new HttpRequestException(json.Result);
                else
                    throw new HttpRequestException(response.ReasonPhrase);
            }

            return data;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Message :{0} ", ex.Message);
            throw;
        }
        //catch (HttpRequestException ex) when (ex is { StatusCode: HttpStatusCode.NotFound })
        //{
        //    throw new Exception($"Not found: {ex.Message}");
        //}
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<SelectListItem>> GetCatalogo(string nombrecatalogo, string? token = null, int? id = null)
    {
        List<SelectListItem>? list = null;

        try
        {
            var parameters = new Dictionary<string, string>
            {
                { "cat", nombrecatalogo }
            };

            if (id != null)
            {
                parameters.Add("id", id.Value.ToString());
            }
            ;

            list = await GetAsync<List<SelectListItem>>("/api/catalogo", parameters, token);

            if (list != null)
            {
                list.Insert(0, new SelectListItem() { Value = "", Text = "-- Seleccionar --" });
            }

            return list;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public T GetData<T>(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception)
        {
            throw;
        }
    }

}