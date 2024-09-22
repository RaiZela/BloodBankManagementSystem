using BloodBankManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Client.Pages;

public partial class DonorQuestionaire
{
    private List<QuestionViewModel> Questions = new List<QuestionViewModel>();
    private string _searchString = "";
    private List<string> _events = new();
    private bool _readOnly;
    private MudMessageBox _mudMessageBox;
    private string _state = "Message box hasn't been opened yet";
    private MudDataGrid<QuestionViewModel> _dataGrid = new MudDataGrid<QuestionViewModel>();
    private string newAnswerText;
    [Inject] private IQuestionsService QuestionsService { get; set; }

    private Func<QuestionViewModel, bool> _quickFilter => x =>
    {
        if (string.IsNullOrWhiteSpace(_searchString))
            return true;

        if (x.QuestionText.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        if (x.QuestionType.ToString().Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        if (x.QuestionCategory.ToString().Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    protected override async Task OnInitializedAsync()
    {
        await GetUpdatedGrid();
    }

    void StartedEditingItem(QuestionViewModel item)
    {
        if (item.Answers == null || item.Answers.Count == 0)
            item.Answers = new List<AnswerViewModel>();

        _events.Insert(0, $"Event = StartedEditingItem, Data = {JsonConvert.SerializeObject(item)}");
    }

    void CanceledEditingItem(QuestionViewModel item)
    {
        _events.Insert(0, $"Event = CanceledEditingItem, Data = {JsonConvert.SerializeObject(item)}");
    }

    async void CommittedItemChanges(QuestionViewModel item)
    {
        if (item.ID == 0)
        {
            var result = await QuestionsService.Add(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {JsonConvert.SerializeObject(item)}");
        }
        else
        {
            var result = await QuestionsService.Update(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {JsonConvert.SerializeObject(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();

    }

    private async Task OnDeleteButtonClickedAsync(QuestionViewModel item)
    {
        bool? result = await _mudMessageBox.ShowAsync();
        _state = result is null ? "Canceled" : "Deleted!";
        if (result == true)
        {
            var actionResult = await QuestionsService.Delete(item.ID);
            if (actionResult.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {JsonConvert.SerializeObject(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();
    }

    private async Task GetUpdatedGrid()
    {
        var result = await QuestionsService.GetAll();
        Questions = (List<QuestionViewModel>)(result.Result == null ? Questions : result.Result);
    }

    private async Task AddNewAnswer(QuestionViewModel question)
    {
        if (!string.IsNullOrWhiteSpace(newAnswerText))
        {
            question.Answers.Add(new AnswerViewModel { AnswerText = newAnswerText });
            newAnswerText = string.Empty;
        }
    }
}
