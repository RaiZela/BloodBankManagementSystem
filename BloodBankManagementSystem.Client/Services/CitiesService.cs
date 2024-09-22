using Newtonsoft.Json;
using Shared.ViewModels;
using Shared;
using System.Net.Http.Json;

namespace BloodBankManagementSystem.Client.Services;

public interface ICitiesService
{
    public Task<ApiResponse<bool>> Add(CityViewModel CitiesVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(CityViewModel CitiesVm);
    public Task<ApiResponse<CityViewModel>> Get(int id);
    public Task<ApiResponse<IEnumerable<CityViewModel>>> GetAll();

}

public class CitiesService : ICitiesService
{
    private readonly HttpClient _httpClient;

    public CitiesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<bool>> Add(CityViewModel CitiesVm)
    {
        var result = await _httpClient.PostAsJsonAsync("https://localhost:44300/api/City", CitiesVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Citiess");
        }
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        var result = await _httpClient.DeleteAsync($"https://localhost:44300/api/City/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Citiess");
        }
    }

    public async Task<ApiResponse<CityViewModel>> Get(int id)
    {
        var result = await _httpClient.GetAsync($"https://localhost:44300/api/City/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<CityViewModel>>(json);
            return response ?? ApiResponse<CityViewModel>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<CityViewModel>.ApiInternalServerErrorResponse("Failed to fetch Citiess");
        }
    }

    public async Task<ApiResponse<IEnumerable<CityViewModel>>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync($"https://localhost:44300/api/City");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<CityViewModel>>>(json);
                return response ?? ApiResponse<IEnumerable<CityViewModel>>.ApiInternalServerErrorResponse("Failed to deserialize response");
            }
            else
            {
                return ApiResponse<IEnumerable<CityViewModel>>.ApiInternalServerErrorResponse("Failed to fetch Citiess");
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<CityViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Update(CityViewModel CitiesVm)
    {
        var result = await _httpClient.PutAsJsonAsync("https://localhost:44300/api/City", CitiesVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Citiess");
        }
    }
}
