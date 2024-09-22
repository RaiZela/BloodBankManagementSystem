using Shared.ViewModels;
using Shared;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace BloodBankManagementSystem.Client.Services;

public interface IClinicService
{
    public Task<ApiResponse<bool>> Add(ClinicsViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(ClinicsViewModel clinicsVm);
    public Task<ApiResponse<ClinicsViewModel>> Get(int id);
    public Task<ApiResponse<IEnumerable<ClinicsViewModel>>> GetAll();

}

public class ClinicService : IClinicService
{
    private readonly HttpClient _httpClient;

    public ClinicService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<bool>> Add(ClinicsViewModel clinicsVm)
    {
        var result = await _httpClient.PostAsJsonAsync("clinic", clinicsVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch clinics");
        }
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        var result = await _httpClient.DeleteAsync($"clinic/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch clinics");
        }
    }

    public async Task<ApiResponse<ClinicsViewModel>> Get(int id)
    {
        var result = await _httpClient.GetAsync($"clinic/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<ClinicsViewModel>>(json);
            return response ?? ApiResponse<ClinicsViewModel>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<ClinicsViewModel>.ApiInternalServerErrorResponse("Failed to fetch clinics");
        }
    }

    public async Task<ApiResponse<IEnumerable<ClinicsViewModel>>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync($"Clinic");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ClinicsViewModel>>>(json);
                return response ?? ApiResponse<IEnumerable<ClinicsViewModel>>.ApiInternalServerErrorResponse("Failed to deserialize response");
            }
            else
            {
                return ApiResponse<IEnumerable<ClinicsViewModel>>.ApiInternalServerErrorResponse("Failed to fetch clinics");
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<ClinicsViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Update(ClinicsViewModel clinicsVm)
    {
        var result = await _httpClient.PutAsJsonAsync("Clinic", clinicsVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch clinics");
        }
    }
}