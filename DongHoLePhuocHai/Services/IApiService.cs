using System.Net.Http.Json;
using DongHoLePhuocHai.Models;

namespace DongHoLePhuocHai.Services;

public interface IApiService
{

    Task<T?> GetAsync<T>(string endpoint);
    Task<T?> PostAsync<T>(string endpoint, object data);
    Task<T?> PutAsync<T>(string endpoint, object data);
    Task<bool> DeleteAsync(string endpoint);
} 