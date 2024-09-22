using Shared.ViewModels;
using Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BloodBankManagementSystem.Client.Services;

public interface IPoliciesService
{
    public Task<ApiResponse<bool>> Add(PolicyViewModel policiesVm);
    public Task<ApiResponse<bool>> Delete(string id);
    public Task<ApiResponse<bool>> Update(PolicyViewModel policiesVm);
    public Task<ApiResponse<PolicyViewModel>> Get(string id);
    public Task<ApiResponse<IEnumerable<PolicyViewModel>>> GetAll();

}
public class PoliciesService : IPoliciesService
{
    private readonly HttpClient _httpClient;

    public PoliciesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

  public async Task<ApiResponse<bool>> Add(PolicyViewModel vm)
    {
        var result = await _httpClient.PostAsJsonAsync("https://localhost:44300/api/policy", vm);
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


    public Task<ApiResponse<bool>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<PolicyViewModel>> Get(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<IEnumerable<PolicyViewModel>>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync($"https://localhost:44300/api/Policy");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<PolicyViewModel>>>(json);
                return response ?? ApiResponse<IEnumerable<PolicyViewModel>>.ApiInternalServerErrorResponse("Failed to deserialize response");
            }
            else
            {
                return ApiResponse<IEnumerable<PolicyViewModel>>.ApiInternalServerErrorResponse("Failed to fetch clinics");
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<PolicyViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public Task<ApiResponse<bool>> Update(PolicyViewModel policiesVm)
    {
        throw new NotImplementedException();
    }
}
