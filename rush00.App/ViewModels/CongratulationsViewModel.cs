using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using rush00.Models;

namespace rush00.ViewModels;

public class CongratulationsViewModel : ViewModelBase
{
    private string _totalDays;

    public string TotalDays
    {
        get => _totalDays;
        set =>  this.RaiseAndSetIfChanged(ref _totalDays, value);
    }

    public CongratulationsViewModel(IEnumerable<HabitCheck> items, string motivation)
    {
        var itemsArray = items.ToArray();
        TotalDays =
            $"Congratulations!\n{itemsArray.Count(x => x.IsChecked)}/{itemsArray.Count()} days checked\nFinally: {motivation}";
    }
}
