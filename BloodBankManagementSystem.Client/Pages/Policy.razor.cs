using BloodBankManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Client.Pages;

public partial class Policy
{
    [Inject] private IPoliciesService PoliciesService { get; set; }
    private IEnumerable<PolicyViewModel> PoliciesList = new List<PolicyViewModel>();
    private string _searchString = "";
    private List<string> _events = new();
    private bool _readOnly;
    private MudMessageBox _mudMessageBox;
    private string _state = "Message box hasn't been opened yet";
    private MudDataGrid<PolicyViewModel> _dataGrid = new MudDataGrid<PolicyViewModel>();
    private Func<PolicyViewModel, bool> _quickFilter => x =>
    {
        if (string.IsNullOrWhiteSpace(_searchString))
            return true;

        if (x.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        if (x.ClaimValue.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        if (x.RequiredClaim.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };

    protected override async Task OnInitializedAsync()
    {
        await GetUpdatedGrid();
    }

    void StartedEditingItem(PolicyViewModel item)
    {
        _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    void CanceledEditingItem(PolicyViewModel item)
    {
        _events.Insert(0, $"Event = CanceledEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    async void CommittedItemChanges(PolicyViewModel item)
    {
        if (item.ID == null)
        {
            var result = await PoliciesService.Add(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        else
        {
            var result = await PoliciesService.Update(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();

    }

    private async Task OnDeleteButtonClickedAsync(PolicyViewModel item)
    {
        bool? result = await _mudMessageBox.ShowAsync();
        _state = result is null ? "Canceled" : "Deleted!";
        if (result == true)
        {
            var actionResult = await PoliciesService.Delete(item.ID);
            if (actionResult.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();
    }

    private async Task GetUpdatedGrid()
    {
        var result = await PoliciesService.GetAll();
        PoliciesList = result.Result == null ? PoliciesList : result.Result;
    }
}
