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
    private IConfiguration _configuration;

    public HttpService(HttpClient httpClient, IConfiguration configuration)
    {
        this._httpClient = httpClient;
        this._configuration = configuration;
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
                url += "?";

                foreach (KeyValuePair<string, string> param in parameters)
                {
                    url += $"{param.Key}={param.Value}&";
                }


                url = url.Substring(0, url.Length - 1);
            }

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            using HttpResponseMessage response = await _httpClient.GetAsync(url);

            //if (response is { StatusCode: >= HttpStatusCode.BadRequest })
            //{
            //    throw new HttpRequestException(
            //        "Something went wrong", inner: null, response.StatusCode);
            //}
            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadFromJsonAsync<T>();

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

    public T? Get<T>(string endpoint, Dictionary<string, string> parameters, string? token = null) where T : new()
    {
        T? data = default;
        var url = endpoint;

        try
        {
            if (parameters.Count > 0)
            {
                url += "?";

                foreach (KeyValuePair<string, string> param in parameters)
                {
                    url += $"{param.Key}={param.Value}&";
                }


                url = url.Substring(0, url.Length - 1);
            }

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var response = _httpClient.GetAsync(url).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<T>(json.Result.ToString());
            }
            else
            {
                var json = response.Content.ReadAsStringAsync();
                throw new Exception(json.Result);

                //dynamic res = JsonConvert.DeserializeObject(json.Result);
                //string message = string.Empty;

                //if (res != null)
                //{
                //    Newtonsoft.Json.Linq.JObject respService = res;
                //    //resp = JsonConvert.DeserializeObject<RespuestaViewModel>(res.result.ToString());
                //    message = response.ReasonPhrase + ". " + respService["errors"].ToString();
                //}
                //else
                //{
                //    message = response.ReasonPhrase + ". " + res.Result;
                //}

                //throw new Exception(message);
            }

            return data;
        }
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