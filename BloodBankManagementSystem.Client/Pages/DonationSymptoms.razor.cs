using BloodBankManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Client.Pages;

public partial class DonationSymptoms
{
    [Inject] private IDonationSymptomsService DonationSymptomsService { get; set; }
    private IEnumerable<DonationSymptomViewModel> DonationSymptomsList = new List<DonationSymptomViewModel>();
    private string _searchString = "";
    private List<string> _events = new();
    private bool _readOnly;
    private MudMessageBox _mudMessageBox;
    private string _state = "Message box hasn't been opened yet";
    private MudDataGrid<DonationSymptomViewModel> _dataGrid = new MudDataGrid<DonationSymptomViewModel>();
    private Func<DonationSymptomViewModel, bool> _quickFilter => x =>
    {
        if (string.IsNullOrWhiteSpace(_searchString))
            return true;

        if (x.Code.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        if (x.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    protected override async Task OnInitializedAsync()
    {
        await GetUpdatedGrid();
    }

    void StartedEditingItem(DonationSymptomViewModel item)
    {
        _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    void CanceledEditingItem(DonationSymptomViewModel item)
    {
        _events.Insert(0, $"Event = CanceledEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    async void CommittedItemChanges(DonationSymptomViewModel item)
    {
        if (item.ID == 0)
        {
            var result = await DonationSymptomsService.Add(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        else
        {
            var result = await DonationSymptomsService.Update(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();

    }

    private async Task OnDeleteButtonClickedAsync(DonationSymptomViewModel item)
    {
        bool? result = await _mudMessageBox.ShowAsync();
        _state = result is null ? "Canceled" : "Deleted!";
        if (result == true)
        {
            var actionResult = await DonationSymptomsService.Delete(item.ID);
            if (actionResult.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();
    }

    private async Task GetUpdatedGrid()
    {
        var result = await DonationSymptomsService.GetAll();
        DonationSymptomsList = result.Result == null ? DonationSymptomsList : result.Result;
    }
}
