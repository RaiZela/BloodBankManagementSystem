using Newtonsoft.Json;
using Shared.ViewModels;
using Shared;
using System.Net.Http.Json;

namespace BloodBankManagementSystem.Client.Services;

public interface IAntibodiesService
{
    public Task<ApiResponse<bool>> Add(AntibodyViewModel antibodiesVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(AntibodyViewModel antibodiesVm);
    public Task<ApiResponse<AntibodyViewModel>> Get(int id);
    public Task<ApiResponse<IEnumerable<AntibodyViewModel>>> GetAll();

}

public class AntibodiesService : IAntibodiesService
{
    private readonly HttpClient _httpClient;

    public AntibodiesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<bool>> Add(AntibodyViewModel antibodiesVm)
    {
        var result = await _httpClient.PostAsJsonAsync("https://localhost:44300/api/Antibodies", antibodiesVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Antibodiess");
        }
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        var result = await _httpClient.DeleteAsync($"https://localhost:44300/api/Antibodies/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Antibodiess");
        }
    }

    public async Task<ApiResponse<AntibodyViewModel>> Get(int id)
    {
        var result = await _httpClient.GetAsync($"https://localhost:44300/api/AntiBody/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<AntibodyViewModel>>(json);
            return response ?? ApiResponse<AntibodyViewModel>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<AntibodyViewModel>.ApiInternalServerErrorResponse("Failed to fetch Antibodiess");
        }
    }

    public async Task<ApiResponse<IEnumerable<AntibodyViewModel>>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync($"https://localhost:44300/api/AntiBody");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<AntibodyViewModel>>>(json);
                return response ?? ApiResponse<IEnumerable<AntibodyViewModel>>.ApiInternalServerErrorResponse("Failed to deserialize response");
            }
            else
            {
                return ApiResponse<IEnumerable<AntibodyViewModel>>.ApiInternalServerErrorResponse("Failed to fetch Antibodiess");
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<AntibodyViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Update(AntibodyViewModel antibodiesVm)
    {
        var result = await _httpClient.PutAsJsonAsync("https://localhost:44300/api/AntiBody", antibodiesVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Antibodiess");
        }
    }
}