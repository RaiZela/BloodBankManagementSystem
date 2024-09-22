using BloodBankManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Client.Pages;

public partial class DonationTherapies
{
    [Inject] private IDonationTherapiesService DonationTherapiesService { get; set; }
    private IEnumerable<DonationTherapyViewModel> DonationTherapiesList = new List<DonationTherapyViewModel>();
    private string _searchString = "";
    private List<string> _events = new();
    private bool _readOnly;
    private MudMessageBox _mudMessageBox;
    private string _state = "Message box hasn't been opened yet";
    private MudDataGrid<DonationTherapyViewModel> _dataGrid = new MudDataGrid<DonationTherapyViewModel>();
    private Func<DonationTherapyViewModel, bool> _quickFilter => x =>
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

    void StartedEditingItem(DonationTherapyViewModel item)
    {
        _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    void CanceledEditingItem(DonationTherapyViewModel item)
    {
        _events.Insert(0, $"Event = CanceledEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    async void CommittedItemChanges(DonationTherapyViewModel item)
    {
        if (item.ID == 0)
        {
            var result = await DonationTherapiesService.Add(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        else
        {
            var result = await DonationTherapiesService.Update(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();

    }

    private async Task OnDeleteButtonClickedAsync(DonationTherapyViewModel item)
    {
        bool? result = await _mudMessageBox.ShowAsync();
        _state = result is null ? "Canceled" : "Deleted!";
        if (result == true)
        {
            var actionResult = await DonationTherapiesService.Delete(item.ID);
            if (actionResult.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();
    }

    private async Task GetUpdatedGrid()
    {
        var result = await DonationTherapiesService.GetAll();
        DonationTherapiesList = result.Result == null ? DonationTherapiesList : result.Result;
    }
}
