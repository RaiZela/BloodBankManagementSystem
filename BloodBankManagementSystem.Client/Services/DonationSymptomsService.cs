using Newtonsoft.Json;
using Shared.ViewModels;
using Shared;
using System.Net.Http.Json;

namespace BloodBankManagementSystem.Client.Services;

public interface IDonationSymptomsService
{
    public Task<ApiResponse<bool>> Add(DonationSymptomViewModel clinicsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DonationSymptomViewModel clinicsVm);
    public Task<ApiResponse<DonationSymptomViewModel>> Get(int id);
    public Task<ApiResponse<IEnumerable<DonationSymptomViewModel>>> GetAll();

}

public class DonationSymptomsService : IDonationSymptomsService
{
    private readonly HttpClient _httpClient;

    public DonationSymptomsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<bool>> Add(DonationSymptomViewModel clinicsVm)
    {
        var result = await _httpClient.PostAsJsonAsync("https://localhost:44300/api/clinic", clinicsVm);
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
        var result = await _httpClient.DeleteAsync($"https://localhost:44300/api/clinic/{id}");
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

    public async Task<ApiResponse<DonationSymptomViewModel>> Get(int id)
    {
        var result = await _httpClient.GetAsync($"https://localhost:44300/api/clinic/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<DonationSymptomViewModel>>(json);
            return response ?? ApiResponse<DonationSymptomViewModel>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<DonationSymptomViewModel>.ApiInternalServerErrorResponse("Failed to fetch clinics");
        }
    }

    public async Task<ApiResponse<IEnumerable<DonationSymptomViewModel>>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync($"https://localhost:44300/api/Clinic");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<DonationSymptomViewModel>>>(json);
                return response ?? ApiResponse<IEnumerable<DonationSymptomViewModel>>.ApiInternalServerErrorResponse("Failed to deserialize response");
            }
            else
            {
                return ApiResponse<IEnumerable<DonationSymptomViewModel>>.ApiInternalServerErrorResponse("Failed to fetch clinics");
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<DonationSymptomViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Update(DonationSymptomViewModel clinicsVm)
    {
        var result = await _httpClient.PutAsJsonAsync("https://localhost:44300/api/Clinic", clinicsVm);
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