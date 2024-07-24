using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using rush00.Models;
using rush00.Data;

namespace rush00.ViewModels;

public class HabitCheckListViewModel: ViewModelBase
{ 
    public Habit Habit { get; set; }

    public string CurrentDate { get; set; }

    public DateTimeOffset EndDate {get; set;}
   
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set => this.RaiseAndSetIfChanged(ref _isChecked, value);
    }
    
    public ObservableCollection<HabitCheck> Days { get; }
        
    public HabitCheckListViewModel(IEnumerable<HabitCheck> days)
    {
        Days = new ObservableCollection<HabitCheck>(days);
        EndDate = Days[Days.Count - 1].CurrentDate;
    }

}