using BloodBankManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.ViewModels;

namespace BloodBankManagementSystem.Client.Pages;

public partial class Antibody
{
    [Inject] private IAntibodiesService AntibodiesService { get; set; }
    private IEnumerable<AntibodyViewModel> AntibodiesList = new List<AntibodyViewModel>();
    private string _searchString = "";
    private List<string> _events = new();
    private bool _readOnly;
    private MudMessageBox _mudMessageBox;
    private string _state = "Message box hasn't been opened yet";
    private MudDataGrid<AntibodyViewModel> _dataGrid = new MudDataGrid<AntibodyViewModel>();
    private Func<AntibodyViewModel, bool> _quickFilter => x =>
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

    void StartedEditingItem(AntibodyViewModel item)
    {
        _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    void CanceledEditingItem(AntibodyViewModel item)
    {
        _events.Insert(0, $"Event = CanceledEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
    }

    async void CommittedItemChanges(AntibodyViewModel item)
    {
        if (item.ID == 0)
        {
            var result = await AntibodiesService.Add(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        else
        {
            var result = await AntibodiesService.Update(item);
            if (result.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();

    }

    private async Task OnDeleteButtonClickedAsync(AntibodyViewModel item)
    {
        bool? result = await _mudMessageBox.ShowAsync();
        _state = result is null ? "Canceled" : "Deleted!";
        if (result == true)
        {
            var actionResult = await AntibodiesService.Delete(item.ID);
            if (actionResult.Success)
                _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
        await GetUpdatedGrid();
        StateHasChanged();
    }

    private async Task GetUpdatedGrid()
    {
        var result = await AntibodiesService.GetAll();
        AntibodiesList = result.Result == null ? AntibodiesList : result.Result;
    }

}
