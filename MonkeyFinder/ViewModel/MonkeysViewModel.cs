using MonkeyFinder.Model;
using CommunityToolkit.Mvvm.Input;
using MonkeyFinder.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MonkeyFinder.ViewModel;
public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService _monkeyService;
    public ObservableCollection<Monkey> Monkeys { get; } = new();
    public MonkeysViewModel(MonkeyService monkeyService)
    {
        _monkeyService = monkeyService;
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if(IsBusy) return;

        try
        {
            IsBusy = true;
            var monkeys = await _monkeyService.GetMonkeys();
            if(Monkeys.Count != 0) 
                Monkeys.Clear();

            foreach(var monkey in monkeys)
                Monkeys.Add(monkey);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!", 
                $"Unable to get Monkeys: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}