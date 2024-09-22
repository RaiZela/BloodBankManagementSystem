using Newtonsoft.Json;
using Shared.ViewModels;
using Shared;
using System.Net.Http.Json;

namespace BloodBankManagementSystem.Client.Services;

public interface IQuestionsService
{
    public Task<ApiResponse<bool>> Add(QuestionViewModel questionsVm);
    public Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<bool>> Update(QuestionViewModel questionsVm);
    public Task<ApiResponse<QuestionViewModel>> Get(int id);
    public Task<ApiResponse<IEnumerable<QuestionViewModel>>> GetAll();

}

public class QuestionsService : IQuestionsService
{
    private readonly HttpClient _httpClient;

    public QuestionsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<bool>> Add(QuestionViewModel questionsVm)
    {
        var test = JsonConvert.SerializeObject(questionsVm);
        var result = await _httpClient.PostAsJsonAsync<QuestionViewModel>("https://localhost:44300/api/Questions/create",questionsVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Questionss");
        }
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        var result = await _httpClient.DeleteAsync($"https://localhost:44300/api/Questions/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Questionss");
        }
    }

    public async Task<ApiResponse<QuestionViewModel>> Get(int id)
    {
        var result = await _httpClient.GetAsync($"https://localhost:44300/api/Questions/{id}");
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<QuestionViewModel>>(json);
            return response ?? ApiResponse<QuestionViewModel>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<QuestionViewModel>.ApiInternalServerErrorResponse("Failed to fetch Questionss");
        }
    }

    public async Task<ApiResponse<IEnumerable<QuestionViewModel>>> GetAll()
    {
        try
        {
            var result = await _httpClient.GetAsync($"https://localhost:44300/api/Questions");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<QuestionViewModel>>>(json);
                return response ?? ApiResponse<IEnumerable<QuestionViewModel>>.ApiInternalServerErrorResponse("Failed to deserialize response");
            }
            else
            {
                return ApiResponse<IEnumerable<QuestionViewModel>>.ApiInternalServerErrorResponse("Failed to fetch Questions");
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<IEnumerable<QuestionViewModel>>.ApiInternalServerErrorResponse(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> Update(QuestionViewModel questionsVm)
    {
        var test = JsonConvert.SerializeObject(questionsVm);
        var result = await _httpClient.PutAsJsonAsync("https://localhost:44300/api/Questions", questionsVm);
        if (result.IsSuccessStatusCode)
        {
            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<ApiResponse<bool>>(json);
            return response ?? ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to deserialize response");
        }
        else
        {
            return ApiResponse<bool>.ApiInternalServerErrorResponse("Failed to fetch Questions");
        }
    }
}
