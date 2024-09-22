using Newtonsoft.Json;
using Shared.ViewModels;
using Shared;
using System.Net.Http.Json;

namespace BloodBankManagementSystem.Client.Services;

public interface IDonationTherapiesService
{
    public Task<ApiResponse<bool>> Add(DonationTherapyViewModel donationTherapiessVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(DonationTherapyViewModel donationTherapiessVm);
    public Task<ApiResponse<DonationTherapyViewModel>> Get(int id);
    public Task<ApiResponse<IEnumerable<DonationTherapyViewModel>>> GetAll();

}

public class DonationTherapiesService : IDonationTherapiesService
{
    private readonly HttpClient _httpClient;

    public DonationTherapiesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<bool>> Add(DonationTherapyViewModel donationTherapiesVm)
    {
        var result = await _httpClient.PostAsJsonAsync("https://localhost:44300/api/DonationTherapy", donationTherapiesVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch DonationTherapiess");
        }
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        var result = await _httpClient.DeleteAsync($"https://localhost:44300/api/DonationTherapy/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch DonationTherapiess");
        }
    }

    public async Task<ApiResponse<DonationTherapyViewModel>> Get(int id)
    {
        var result = await _httpClient.GetAsync($"https://localhost:44300/api/DonationTherapy/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<DonationTherapyViewModel>>(json);
            return response ?? ApiResponse<DonationTherapyViewModel>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<DonationTherapyViewModel>.ApiInternalServerErrorResponse("Failed to fetch DonationTherapiess");
        }
    }

    public async Task<ApiResponse<IEnumerable<DonationTherapyViewModel>>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync($"https://localhost:44300/api/DonationTherapy");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<DonationTherapyViewModel>>>(json);
                return response ?? ApiResponse<IEnumerable<DonationTherapyViewModel>>.ApiInternalServerErrorResponse("Failed to deserialize response");
            }
            else
            {
                return ApiResponse<IEnumerable<DonationTherapyViewModel>>.ApiInternalServerErrorResponse("Failed to fetch DonationTherapiess");
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<DonationTherapyViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Update(DonationTherapyViewModel donationTherapiesVm)
    {
        var result = await _httpClient.PutAsJsonAsync("https://localhost:44300/api/DonationTherapy", donationTherapiesVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch DonationTherapiess");
        }
    }
}